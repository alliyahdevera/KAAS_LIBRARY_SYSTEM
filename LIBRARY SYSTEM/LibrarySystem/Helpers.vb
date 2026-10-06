Imports System.Linq
Imports System.Security.Cryptography

' ---------------------------------------------------------------
' Who is logged in right now
' ---------------------------------------------------------------
Module AppSession
    Public Property UserId As Integer
    Public Property SchoolId As String
    Public Property Username As String
    Public Property FullName As String
    Public Property Role As String            ' Admin / Librarian / Member
    Public Property MemberId As Integer?      ' Nothing if this user cannot borrow
    Public Property MemberType As String     ' Student / Teacher / Staff / ""

    Public ReadOnly Property IsSignedIn As Boolean
        Get
            Return UserId > 0
        End Get
    End Property

    Public Sub SignIn(uid As Integer, schoolId As String, uname As String, fullName As String,
                      role As String, memberId As Integer?, memberType As String)
        AppSession.UserId = uid
        AppSession.SchoolId = schoolId
        AppSession.Username = uname
        AppSession.FullName = fullName
        AppSession.Role = role
        AppSession.MemberId = memberId
        AppSession.MemberType = memberType
    End Sub

    Public Sub SignOut()
        UserId = 0
        SchoolId = Nothing
        Username = Nothing
        FullName = Nothing
        Role = Nothing
        MemberId = Nothing
        MemberType = Nothing
    End Sub
End Module

' ---------------------------------------------------------------
' Library rules: change the numbers here and the whole app follows
' ---------------------------------------------------------------
Module LibraryRules
    Public Const LatePenaltyPerDay As Decimal = 20D
    Public Const PenaltyGraceDays As Integer = 0     ' no grace period: every day after the due date is charged

    Public Function LoanDays(memberType As String) As Integer
        Select Case memberType
            Case "Teacher", "Staff" : Return 2
            Case Else : Return 2          ' Student
        End Select
    End Function

    Public Function PenaltyPerDay(memberType As String) As Decimal
        Return LatePenaltyPerDay          ' same rate for Student, Teacher and Staff
    End Function

    ' Only the days AFTER the grace period are charged
    Public Function ChargeableDays(daysLate As Integer) As Integer
        Return Math.Max(0, daysLate - PenaltyGraceDays)
    End Function

    Public Function LatePenalty(daysLate As Integer, memberType As String) As Decimal
        Return ChargeableDays(daysLate) * PenaltyPerDay(memberType)
    End Function

    Public Function MaxActiveLoans(memberType As String) As Integer
        Select Case memberType
            Case "Teacher", "Staff" : Return 3
            Case Else : Return 3
        End Select
    End Function
End Module

' ---------------------------------------------------------------
' Password hashing (PBKDF2). Old plain-text passwords still verify
' and are upgraded to a hash at the next successful login.
' ---------------------------------------------------------------
Module Security
    Private Const Prefix As String = "PBKDF2"
    Private Const Iterations As Integer = 10000

    Public Function HashPassword(plain As String) As String
        Dim salt(15) As Byte
        Using rng = RandomNumberGenerator.Create()
            rng.GetBytes(salt)
        End Using
        Using kdf As New Rfc2898DeriveBytes(plain, salt, Iterations)
            Dim hash = kdf.GetBytes(32)
            Return Prefix & "$" & Iterations & "$" &
                   Convert.ToBase64String(salt) & "$" & Convert.ToBase64String(hash)
        End Using
    End Function

    Public Function IsHashed(stored As String) As Boolean
        Return stored IsNot Nothing AndAlso stored.StartsWith(Prefix & "$")
    End Function

    Public Function VerifyPassword(plain As String, stored As String) As Boolean
        If Not IsHashed(stored) Then Return plain = stored   ' legacy plain text
        Dim parts = stored.Split("$"c)
        If parts.Length <> 4 Then Return False
        Dim iters As Integer = Integer.Parse(parts(1))
        Dim salt = Convert.FromBase64String(parts(2))
        Dim expected = Convert.FromBase64String(parts(3))
        Using kdf As New Rfc2898DeriveBytes(plain, salt, iters)
            Dim actual = kdf.GetBytes(expected.Length)
            Dim diff As Integer = 0
            For i As Integer = 0 To expected.Length - 1
                diff = diff Or (expected(i) Xor actual(i))
            Next
            Return diff = 0
        End Using
    End Function
End Module

' ---------------------------------------------------------------
' Loads a form inside a menu's content panel (Panel3)
' ---------------------------------------------------------------
Module FormHost
    Public Sub LoadInto(host As Panel, child As Form)
        For Each f As Form In host.Controls.OfType(Of Form)().ToList()
            If Not Object.ReferenceEquals(f, child) Then f.Hide()
        Next
        If child.Parent IsNot host Then
            child.TopLevel = False
            child.FormBorderStyle = FormBorderStyle.None
            child.Dock = DockStyle.Fill
            host.Controls.Add(child)
        End If
        child.Show()
        child.BringToFront()
    End Sub
End Module