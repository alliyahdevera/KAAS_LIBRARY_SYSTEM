Imports System.IO
Imports System.IO.Compression
Imports System.Text

Module ExcelExporter

    ''' <summary>
    ''' Exports the contents of any ListView (View.Details) into a real .xlsx file.
    ''' No Excel install and no external library needed.
    ''' </summary>
    Public Sub ExportListViewToExcel(lv As ListView, suggestedFileName As String, Optional sheetTitle As String = "Sheet1")

        If lv.Items.Count = 0 Then
            MsgBox("There is no data to export.", vbExclamation, "Export to Excel")
            Exit Sub
        End If

        Using sfd As New SaveFileDialog()
            sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx"
            sfd.FileName = suggestedFileName
            sfd.Title = "Export to Excel"

            If sfd.ShowDialog() <> DialogResult.OK Then Exit Sub

            Try
                WriteXlsx(sfd.FileName, lv, sheetTitle)

                Dim openIt As MsgBoxResult = MsgBox(
                    "Export successful!" & vbCrLf & sfd.FileName & vbCrLf & vbCrLf & "Open the file now?",
                    vbInformation + vbYesNo, "Export to Excel")

                If openIt = vbYes Then
                    Process.Start(sfd.FileName)
                End If

            Catch ex As Exception
                MsgBox("Failed to export to Excel: " & ex.Message, vbCritical, "Export to Excel")
            End Try
        End Using

    End Sub

    Private Sub WriteXlsx(path As String, lv As ListView, sheetTitle As String)

        If File.Exists(path) Then
            File.Delete(path)
        End If

        Dim safeName As String = SanitizeSheetName(sheetTitle)

        Using archive As ZipArchive = ZipFile.Open(path, ZipArchiveMode.Create)
            AddEntry(archive, "[Content_Types].xml", ContentTypesXml())
            AddEntry(archive, "_rels/.rels", RelsXml())
            AddEntry(archive, "xl/workbook.xml", WorkbookXml(safeName))
            AddEntry(archive, "xl/_rels/workbook.xml.rels", WorkbookRelsXml())
            AddEntry(archive, "xl/styles.xml", StylesXml())
            AddEntry(archive, "xl/worksheets/sheet1.xml", SheetXml(lv))
        End Using

    End Sub

    Private Sub AddEntry(archive As ZipArchive, entryName As String, content As String)
        Dim entry As ZipArchiveEntry = archive.CreateEntry(entryName)
        Using writer As New StreamWriter(entry.Open(), New UTF8Encoding(False))
            writer.Write(content)
        End Using
    End Sub

    Private Function SanitizeSheetName(name As String) As String
        Dim invalid() As Char = {"\"c, "/"c, "?"c, "*"c, "["c, "]"c, ":"c}
        Dim result As String = name
        For Each ch As Char In invalid
            result = result.Replace(ch, "-"c)
        Next
        If result.Length > 31 Then result = result.Substring(0, 31)
        If result = "" Then result = "Sheet1"
        Return result
    End Function

    Private Function ContentTypesXml() As String
        Return "<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>" &
               "<Types xmlns=""http://schemas.openxmlformats.org/package/2006/content-types"">" &
               "<Default Extension=""rels"" ContentType=""application/vnd.openxmlformats-package.relationships+xml""/>" &
               "<Default Extension=""xml"" ContentType=""application/xml""/>" &
               "<Override PartName=""/xl/workbook.xml"" ContentType=""application/vnd.openxmlformats-officedocument.spreadsheetml.sheet.main+xml""/>" &
               "<Override PartName=""/xl/worksheets/sheet1.xml"" ContentType=""application/vnd.openxmlformats-officedocument.spreadsheetml.worksheet+xml""/>" &
               "<Override PartName=""/xl/styles.xml"" ContentType=""application/vnd.openxmlformats-officedocument.spreadsheetml.styles+xml""/>" &
               "</Types>"
    End Function

    Private Function RelsXml() As String
        Return "<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>" &
               "<Relationships xmlns=""http://schemas.openxmlformats.org/package/2006/relationships"">" &
               "<Relationship Id=""rId1"" Type=""http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument"" Target=""xl/workbook.xml""/>" &
               "</Relationships>"
    End Function

    Private Function WorkbookXml(sheetTitle As String) As String
        Return "<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>" &
               "<workbook xmlns=""http://schemas.openxmlformats.org/spreadsheetml/2006/main"" xmlns:r=""http://schemas.openxmlformats.org/officeDocument/2006/relationships"">" &
               "<sheets><sheet name=""" & XmlEscape(sheetTitle) & """ sheetId=""1"" r:id=""rId1""/></sheets>" &
               "</workbook>"
    End Function

    Private Function WorkbookRelsXml() As String
        Return "<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>" &
               "<Relationships xmlns=""http://schemas.openxmlformats.org/package/2006/relationships"">" &
               "<Relationship Id=""rId1"" Type=""http://schemas.openxmlformats.org/officeDocument/2006/relationships/worksheet"" Target=""worksheets/sheet1.xml""/>" &
               "<Relationship Id=""rId2"" Type=""http://schemas.openxmlformats.org/officeDocument/2006/relationships/styles"" Target=""styles.xml""/>" &
               "</Relationships>"
    End Function

    Private Function StylesXml() As String
        Return "<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>" &
               "<styleSheet xmlns=""http://schemas.openxmlformats.org/spreadsheetml/2006/main"">" &
               "<fonts count=""2"">" &
               "<font><sz val=""11""/><name val=""Calibri""/></font>" &
               "<font><sz val=""11""/><name val=""Calibri""/><b/></font>" &
               "</fonts>" &
               "<fills count=""2""><fill><patternFill patternType=""none""/></fill><fill><patternFill patternType=""gray125""/></fill></fills>" &
               "<borders count=""1""><border><left/><right/><top/><bottom/><diagonal/></border></borders>" &
               "<cellStyleXfs count=""1""><xf numFmtId=""0"" fontId=""0""/></cellStyleXfs>" &
               "<cellXfs count=""2"">" &
               "<xf numFmtId=""0"" fontId=""0"" xfId=""0""/>" &
               "<xf numFmtId=""0"" fontId=""1"" xfId=""0"" applyFont=""1""/>" &
               "</cellXfs>" &
               "</styleSheet>"
    End Function

    Private Function SheetXml(lv As ListView) As String
        Dim sb As New StringBuilder()
        sb.Append("<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>")
        sb.Append("<worksheet xmlns=""http://schemas.openxmlformats.org/spreadsheetml/2006/main"">")
        sb.Append("<sheetData>")

        ' Header row (bold - style index 1)
        sb.Append("<row r=""1"">")
        For col As Integer = 0 To lv.Columns.Count - 1
            Dim cellRef As String = ColumnLetter(col) & "1"
            sb.Append("<c r=""" & cellRef & """ t=""inlineStr"" s=""1""><is><t xml:space=""preserve"">" & XmlEscape(lv.Columns(col).Text) & "</t></is></c>")
        Next
        sb.Append("</row>")

        ' Data rows
        For rowIdx As Integer = 0 To lv.Items.Count - 1
            Dim excelRow As Integer = rowIdx + 2
            sb.Append("<row r=""" & excelRow.ToString() & """>")
            Dim item As ListViewItem = lv.Items(rowIdx)
            For col As Integer = 0 To lv.Columns.Count - 1
                Dim text As String = If(col < item.SubItems.Count, item.SubItems(col).Text, "")
                Dim cellRef As String = ColumnLetter(col) & excelRow.ToString()
                sb.Append("<c r=""" & cellRef & """ t=""inlineStr""><is><t xml:space=""preserve"">" & XmlEscape(text) & "</t></is></c>")
            Next
            sb.Append("</row>")
        Next

        sb.Append("</sheetData>")
        sb.Append("</worksheet>")
        Return sb.ToString()
    End Function

    Private Function ColumnLetter(colIndex As Integer) As String
        Dim dividend As Integer = colIndex + 1
        Dim columnName As String = ""
        While dividend > 0
            Dim modulo As Integer = (dividend - 1) Mod 26
            columnName = Chr(65 + modulo) & columnName
            dividend = (dividend - modulo) \ 26
        End While
        Return columnName
    End Function

    Private Function XmlEscape(s As String) As String
        If s Is Nothing Then Return ""
        Return s.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("""", "&quot;").Replace("'", "&apos;")
    End Function

End Module