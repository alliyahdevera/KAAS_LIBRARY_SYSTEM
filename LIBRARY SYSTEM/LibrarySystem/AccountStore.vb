Imports System.Data
Imports System.IO
Imports System.Xml.Serialization

Module AccountStore

    Public Const PenaltyRatePerDay As Decimal = 150
    Public Students As New List(Of StudentAccount)()
    Public BooksTable As New DataTable("Books")
    Public BorrowRecords As New List(Of BorrowRecord)
    Private ReadOnly DataFolder As String = System.Windows.Forms.Application.StartupPath
    Private ReadOnly StudentsFile As String = Path.Combine(DataFolder, "students.xml")
    Private ReadOnly BooksFile As String = Path.Combine(DataFolder, "books.xml")
    Private ReadOnly BorrowRecordsFile As String = Path.Combine(DataFolder, "borrowrecords.xml")

    Public Sub SaveData()
        Try
            Dim studentSerializer As New XmlSerializer(GetType(List(Of StudentAccount)))
            Using writer As New StreamWriter(StudentsFile)
                studentSerializer.Serialize(writer, Students)
            End Using

            Dim borrowSerializer As New XmlSerializer(GetType(List(Of BorrowRecord)))
            Using writer As New StreamWriter(BorrowRecordsFile)
                borrowSerializer.Serialize(writer, BorrowRecords)
            End Using

            BooksTable.WriteXml(BooksFile, XmlWriteMode.WriteSchema)

        Catch ex As Exception
            MsgBox("Failed to save data: " & ex.Message, vbExclamation, "Save Error")
        End Try
    End Sub

    Public Sub LoadData()
        Try
            If File.Exists(StudentsFile) Then
                Dim studentSerializer As New XmlSerializer(GetType(List(Of StudentAccount)))
                Using reader As New StreamReader(StudentsFile)
                    Students = CType(studentSerializer.Deserialize(reader), List(Of StudentAccount))
                End Using
            End If

            If File.Exists(BorrowRecordsFile) Then
                Dim borrowSerializer As New XmlSerializer(GetType(List(Of BorrowRecord)))
                Using reader As New StreamReader(BorrowRecordsFile)
                    BorrowRecords = CType(borrowSerializer.Deserialize(reader), List(Of BorrowRecord))
                End Using
            End If

            If File.Exists(BooksFile) AndAlso New FileInfo(BooksFile).Length > 0 Then
                BooksTable.ReadXml(BooksFile)
            End If

        Catch ex As Exception
            MsgBox("Failed to load saved data: " & ex.Message, vbExclamation, "Load Error")
        End Try
    End Sub

    Public Function IsStudentIDTaken(studentID As String, excludeUsername As String) As Boolean
        For Each s In Students
            ' Skip the account currently being edited
            If Not String.IsNullOrEmpty(excludeUsername) AndAlso
               s.Username.Equals(excludeUsername, StringComparison.OrdinalIgnoreCase) Then
                Continue For
            End If

            If s.StudentID.Equals(studentID, StringComparison.OrdinalIgnoreCase) Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Sub SetupBooksTable()
        If BooksTable.Columns.Count = 0 Then
            BooksTable.Columns.Add("ISBN")
            BooksTable.Columns.Add("Title")
            BooksTable.Columns.Add("Author")
            BooksTable.Columns.Add("Copies", GetType(Integer))
        End If
    End Sub

    ' Returns the current status of a borrow record: Borrowed, Overdue, Returned, or Penalty
    ' (Penalty means the book was returned late and the penalty has not yet been paid)
    Public Function GetRecordStatus(record As BorrowRecord) As String
        If record.ReturnDate <> "" Then
            If record.Penalty > 0 AndAlso Not record.PenaltyPaid Then
                Return "Penalty"
            End If
            Return "Returned"
        End If

        Dim dueDate As DateTime
        If DateTime.TryParseExact(record.DueDate, "MM-dd-yyyy",
                                   Globalization.CultureInfo.InvariantCulture,
                                   Globalization.DateTimeStyles.None, dueDate) Then
            If DateTime.Now.Date > dueDate Then
                Return "Overdue"
            End If
        End If

        Return "Borrowed"
    End Function

    ' Keeps BorrowRecords in sync when a student's Username is changed in Account Management.
    ' BorrowRecords link back to a student purely by matching the Username string, so if that
    ' string changes on the account and nowhere else, every existing borrow/history record for
    ' that student becomes orphaned (wrong or missing student) until this runs.
    Public Sub UpdateUsernameInRecords(oldUsername As String, newUsername As String)
        If oldUsername Is Nothing OrElse newUsername Is Nothing Then Exit Sub
        If oldUsername.Equals(newUsername, StringComparison.OrdinalIgnoreCase) Then Exit Sub

        For Each record In BorrowRecords
            If record.Username.Equals(oldUsername, StringComparison.OrdinalIgnoreCase) Then
                record.Username = newUsername
            End If
        Next
    End Sub

    ' Looks up a student's account type (Student/Admin) by username, defaulting to "Student"
    Public Function GetAccountType(username As String) As String
        For Each s In Students
            If s.Username.Equals(username, StringComparison.OrdinalIgnoreCase) Then
                Return s.AccountType
            End If
        Next
        Return "Student"
    End Function

End Module
Public Class Book
    Public Property ISBN As String
    Public Property Title As String
    Public Property Author As String
    Public Property Copies As Integer
End Class
Public Class BorrowRecord
    Public Property Username As String
    Public Property BookISBN As String
    Public Property BookTitle As String
    Public Property Author As String
    Public Property BorrowDate As String
    Public Property DueDate As String
    Public Property ReturnDate As String
    Public Property Penalty As Decimal = 0
    Public Property PenaltyPaid As Boolean = False
    Public Property PaymentMethod As String = ""
    Public Property ReceiptNumber As String = ""
End Class

Public Class PenaltyRecord
    Public Property ReceiptNumber As String
    Public Property Username As String
    Public Property BookTitle As String
    Public Property BookISBN As String
    Public Property BorrowDate As String
    Public Property DueDate As String
    Public Property ReturnDate As String
    Public Property OverdueDays As Integer
    Public Property PenaltyRate As Decimal
    Public Property PenaltyAmount As Decimal
    Public Property PaymentMethod As String
    Public Property PaymentStatus As String
End Class