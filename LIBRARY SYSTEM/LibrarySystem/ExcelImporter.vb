Imports System.IO
Imports System.IO.Compression
Imports System.Linq
Imports System.Xml.Linq

Module ExcelImporter

    ''' <summary>
    ''' Reads an .xlsx file and returns its first worksheet as a list of rows,
    ''' where each row is a list of cell text values (row 0 = header row).
    ''' </summary>
    Public Function ReadXlsxRows(filePath As String) As List(Of List(Of String))
        Dim rows As New List(Of List(Of String))

        Using archive As ZipArchive = ZipFile.OpenRead(filePath)

            ' ---- 1. Load shared strings table (Excel stores repeated text here) ----
            Dim sharedStrings As New List(Of String)
            Dim sstEntry = archive.GetEntry("xl/sharedStrings.xml")
            If sstEntry IsNot Nothing Then
                Using s = sstEntry.Open()
                    Dim doc = XDocument.Load(s)
                    Dim ns = doc.Root.Name.Namespace
                    For Each siEl In doc.Root.Elements(ns + "si")
                        Dim text = String.Join("", siEl.Descendants(ns + "t").Select(Function(t) t.Value))
                        sharedStrings.Add(text)
                    Next
                End Using
            End If

            ' ---- 2. Resolve the path of the first worksheet ----
            Dim sheetPath As String = "xl/worksheets/sheet1.xml" ' fallback

            Dim wbEntry = archive.GetEntry("xl/workbook.xml")
            Dim relsEntry = archive.GetEntry("xl/_rels/workbook.xml.rels")
            If wbEntry IsNot Nothing AndAlso relsEntry IsNot Nothing Then
                Dim rIdToTarget As New Dictionary(Of String, String)
                Using s = relsEntry.Open()
                    Dim relsDoc = XDocument.Load(s)
                    Dim relsNs = relsDoc.Root.Name.Namespace
                    For Each rel In relsDoc.Root.Elements(relsNs + "Relationship")
                        rIdToTarget(rel.Attribute("Id").Value) = rel.Attribute("Target").Value
                    Next
                End Using

                Using s = wbEntry.Open()
                    Dim wbDoc = XDocument.Load(s)
                    Dim wbNs = wbDoc.Root.Name.Namespace
                    Dim rNs As XNamespace = "http://schemas.openxmlformats.org/officeDocument/2006/relationships"
                    Dim firstSheet = wbDoc.Descendants(wbNs + "sheet").FirstOrDefault()
                    If firstSheet IsNot Nothing Then
                        Dim rId = firstSheet.Attribute(rNs + "id").Value
                        If rIdToTarget.ContainsKey(rId) Then
                            Dim target = rIdToTarget(rId)
                            sheetPath = If(target.StartsWith("/"), target.TrimStart("/"c), "xl/" & target)
                        End If
                    End If
                End Using
            End If

            Dim sheetEntry = archive.GetEntry(sheetPath)
            If sheetEntry Is Nothing Then
                Throw New Exception("Could not find a worksheet inside the Excel file.")
            End If

            ' ---- 3. Parse rows/cells ----
            Using s = sheetEntry.Open()
                Dim sheetDoc = XDocument.Load(s)
                Dim ns = sheetDoc.Root.Name.Namespace

                For Each rowEl In sheetDoc.Descendants(ns + "row")
                    Dim rowValues As New List(Of String)

                    For Each cellEl In rowEl.Elements(ns + "c")
                        Dim cellRef = If(cellEl.Attribute("r") IsNot Nothing, cellEl.Attribute("r").Value, Nothing)
                        Dim expectedCol = If(cellRef IsNot Nothing, ColumnIndexFromRef(cellRef), rowValues.Count)

                        ' Pad any skipped/empty cells so column positions still line up
                        While rowValues.Count < expectedCol
                            rowValues.Add("")
                        End While

                        Dim cellType = If(cellEl.Attribute("t") IsNot Nothing, cellEl.Attribute("t").Value, Nothing)
                        Dim value As String = ""

                        If cellType = "s" Then
                            Dim vEl = cellEl.Element(ns + "v")
                            If vEl IsNot Nothing Then
                                Dim idx As Integer
                                If Integer.TryParse(vEl.Value, idx) AndAlso idx >= 0 AndAlso idx < sharedStrings.Count Then
                                    value = sharedStrings(idx)
                                End If
                            End If
                        ElseIf cellType = "inlineStr" Then
                            value = String.Join("", cellEl.Descendants(ns + "t").Select(Function(t) t.Value))
                        Else
                            Dim vEl = cellEl.Element(ns + "v")
                            If vEl IsNot Nothing Then value = vEl.Value
                        End If

                        rowValues.Add(value)
                    Next

                    rows.Add(rowValues)
                Next
            End Using
        End Using

        Return rows
    End Function

    Private Function ColumnIndexFromRef(cellRef As String) As Integer
        Dim colLetters As String = New String(cellRef.TakeWhile(Function(c) Not Char.IsDigit(c)).ToArray())
        Dim colIndex As Integer = 0
        For Each ch In colLetters
            colIndex = colIndex * 26 + (Convert.ToInt32(Char.ToUpper(ch)) - 64)
        Next
        Return colIndex - 1
    End Function

    ' ---- Small shared helpers used by both import screens ----
    Public Function FindColumn(headers As List(Of String), name As String) As Integer
        For i As Integer = 0 To headers.Count - 1
            If headers(i).Trim().Equals(name, StringComparison.OrdinalIgnoreCase) Then Return i
        Next
        Return -1
    End Function

    Public Function GetCell(row As List(Of String), index As Integer) As String
        If index < 0 OrElse index >= row.Count Then Return ""
        Return row(index)
    End Function

End Module