
Imports System.Text
Imports System.Data.SqlClient
Public Class AddForm

    Friend AuthorFirstName As String
    Friend AuthorMiddleName As String
    Friend AuthorLastName As String
    Friend AuthorFullName As String
    Friend Title As String
    Friend AuthorID As Integer
    Friend TitleID As Integer
    Friend TitleAuthorID As Integer
    Friend ISBNID As Integer
    Friend BookType As String
    Friend ISBN As String
    Friend AddFormMessage As String
    Friend SelectedProcess As Integer

    'Enum for the context menu on the main form
    'Add = 2
    'Edit = 1
    'Cancel = 0
    'Delete = 3

    Private Function CheckForExistingAuthor() As Integer

        Dim intReturn As Integer
        Dim DataWorkingClass As New DataWorkingClass
        Dim dr As SqlDataReader

        Try

            If AuthorID <= 0 Then

                'first check for an existing author record, return a message telling the user the results
                dr = DataWorkingClass.CheckForExistingAuthor(AuthorFirstName, AuthorMiddleName, AuthorLastName)

                If dr IsNot Nothing Then
                    dr.Read()
                End If


                If dr.HasRows Then

                    If AuthorFirstName = dr.Item(6).ToString And AuthorMiddleName = dr.Item(7).ToString And AuthorLastName = dr.Item(8).ToString Then
                        'everything matches so the author is in the database
                        AuthorID = dr.Item(3)
                        intReturn = AuthorID
                        Return intReturn

                    ElseIf AuthorFirstName = dr.Item(8).ToString And AuthorLastName = dr.Item(6).ToString Then
                        'user has entered entered the author's name backwards
                        AuthorFirstName = dr.Item(6).ToString
                        AuthorLastName = dr.Item(8).ToString
                        AuthorID = dr.Item(3)
                        intReturn = AuthorID
                        Return intReturn

                    ElseIf ((IsDBNull(dr.Item(6)) And AuthorFirstName = "") Or (IsDBNull(dr.Item(6)) And AuthorFirstName.Trim <> "")) _
                        Or (dr.Item(6) <> AuthorFirstName) _
                        Or ((IsDBNull(dr.Item(7)) And AuthorMiddleName = "") Or (IsDBNull(dr.Item(7)) And AuthorMiddleName.Trim <> "")) _
                        Or (dr.Item(7) <> AuthorMiddleName) _
                        Or ((IsDBNull(dr.Item(8)) And AuthorLastName = "") Or (IsDBNull(dr.Item(8)) And AuthorLastName.Trim <> "") _
                        Or (dr.Item(8) <> AuthorLastName)) Then
                        'testing for 3 conditions: db is null & typed in is empty, 
                        'db is null And typed Is Not Empty 
                        'And db Is Not null And different than typed.
                        'This could be a match but possibly not, but err on the side of getting the data in and enter the
                        'author information even if it is a close match to another.
                        'OR do a second check using the TitleAuthorTable
                        intReturn = -1
                        Return intReturn
                    End If

                Else
                    'no author matched. We will Add them.
                    intReturn = 0
                    Return intReturn
                End If

                'TODO: Any other possibilities???
                With Me.MessageLabel
                    If intReturn > 0 Then
                        .Text = "Author already exists - Will update then check for existing title."
                    ElseIf intReturn = 0 Then
                        .Text = "New author to be added."
                    ElseIf intReturn = -1 Then
                        'do a second check and compare with TitleAuthor?
                    ElseIf intReturn < -1 Then
                        .Text = "An unexpected error occurred. " + DataWorkingClass.message
                    End If
                End With

            Else
                'We already know the author and will
                'try to update them next
                intReturn = AuthorID
            End If

            Return intReturn

            'Release the memory
            dr = Nothing
            DataWorkingClass = Nothing

        Catch ex As Exception
            AddFormMessage = ""
            AddFormMessage = ex.Message
            intReturn = -1
            Return intReturn

        End Try

    End Function
    Private Sub CanceProcesslButton_Click(sender As Object, e As EventArgs) Handles CancelProcessButton.Click

        With Me
            AuthorFullName = Nothing
            AuthorFirstName = Nothing
            AuthorMiddleName = Nothing
            AuthorLastName = Nothing
            Title = Nothing
            BookType = Nothing
            TitleID = Nothing
            AuthorID = Nothing
            TitleAuthorID = Nothing
            AddFormMessage = Nothing
            ISBN = Nothing
            SelectedProcess = 0

            .AuthorFirstNameTextbox.Clear()
            .AuthorMiddleNameTextbox.Clear()
            .AuthorLastNameTextbox.Clear()
            .TitleTextbox.Clear()
            .BookTypeCombobox.SelectedIndex = -1
            .ISBNTextbox.Clear()
            .Close()

        End With

    End Sub

    Private Function DeepCheckForAuthor() As Integer

        Dim DataWorkingClass As New DataWorkingClass
        Dim dr As SqlDataReader
        Dim intReturn As Integer

        Try

            dr = DataWorkingClass.DoubleCheckForAuthor(AuthorFirstName, AuthorMiddleName, AuthorLastName, Title, BookType, ISBN)

            If dr IsNot Nothing Then
                If dr.HasRows Then

                    dr.Read()

                    'First Check to see if any of the parts of the author's name match.
                    If dr.Item(0).ToString = AuthorFirstName Or
                        dr.Item(1).ToString = AuthorMiddleName Or
                        dr.Item(2).ToString = AuthorLastName Then

                        'If there is a match or partial match then check to see if the title exists 
                        If dr.Item(3).ToString = Title Then
                            'if that is the case then there is no need for any more database work
                            intReturn = 2
                        Else
                            'enter the title
                            intReturn = 1
                        End If

                    Else
                        'no match (not sure whether this code should ever be reached as it should
                        'have been captured in an earlier function.
                        intReturn = 0
                    End If
                End If
            End If

        Catch ex As Exception
            intReturn = -1
            Return intReturn
        End Try

        Return intReturn

    End Function

    Private Sub InsertNewRecord()

        Dim DataWorkingClass As New DataWorkingClass

        'Run the Function above that manages the search for an existing author
        AuthorID = CheckForExistingAuthor()

        'This means we will add the data.
        'It is possible that there may be a duplicate if
        'the author's name is misspelled.
        If AuthorID = 0 Then

            'No record found - add a new author
            AuthorID = DataWorkingClass.InsertAuthorData(AuthorFirstName,
            AuthorMiddleName, AuthorLastName)

        End If

        'See if there is a title entry like the one currently being
        'entered/edited
        TitleID = DataWorkingClass.InsertTitle(Title)

    End Sub

    Private Sub UpdateExistingRecord()

        Dim DataWorkingClass As New DataWorkingClass
        Dim intReturn As Integer

        If AuthorID > 0 Then

            'We are updating a row already entered
            'Update the author based on the Author Id returned
            intReturn = DataWorkingClass.UpdateAuthorData(AuthorID, AuthorFirstName, AuthorMiddleName, AuthorLastName)
            AddFormMessage = "Author Updated"

        End If

        'Update the title
        intReturn = DataWorkingClass.UpdateTitle(TitleID, Title)

    End Sub

    Private Sub ControlDataInsertandUpdate()

        Dim DataWorkingClass As New DataWorkingClass

        'We are stacking these calls in order to be able
        'to have a semi-transaction.  Probably would do
        'all this work in the database for pure transactional control.
        'TODO: We could also do the work using SQL Transactions here - maybe for a future version?

        AuthorFirstName = Me.AuthorFirstNameTextbox.Text.ToString.Trim
        AuthorMiddleName = Me.AuthorMiddleNameTextbox.Text.ToString.Trim
        AuthorLastName = Me.AuthorLastNameTextbox.Text.ToString.Trim
        Title = Me.TitleTextbox.Text.ToString.Trim
        BookType = Me.BookTypeCombobox.Text.Substring(0, 2)
        ISBN = Me.ISBNTextbox.Text.ToString.Trim

        If SelectedProcess = 1 Then

            'We are updating a row already entered
            'Update the author based on the Author Id returned
            UpdateExistingRecord()
            AddFormMessage = "Author and Title Updated"

        Else

            InsertNewRecord()
            AddFormMessage = "Author and Title Added"

        End If

        If TitleID > 0 And AuthorID > 0 Then

            'The user has supplied an ISBN and/or book type so enter it and get the ID back
            If Me.ISBNTextbox.Text.Trim.Length > 0 Or Me.BookTypeCombobox.Text.Length > 0 Then
                ISBNID = DataWorkingClass.GetOrInsertISBNID(ISBN, BookType)
            End If

            If TitleAuthorID <= 0 Then

                'Call the method to insert the values into TitleAuthor
                'This should complete the work
                TitleAuthorID = DataWorkingClass.InsertTitleAuthorData(AuthorID, TitleID, ISBNID)

            Else

                'There is a titleauthor record so we must be updating ISBN and/or Bpok Type
                DataWorkingClass.UpdateISBN(ISBNID, ISBN, BookType)
                DataWorkingClass.UpdateTitleAuthor(TitleAuthorID, ISBNID)

            End If

        End If

        SendMessage("Process complete.")

    End Sub

    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click

        ControlDataInsertandUpdate()

        Title = ""
        BookType = ""
        AuthorFirstName = ""
        AuthorMiddleName = ""
        AuthorLastName = ""
        AddFormMessage = ""
        ISBN = ""
        AuthorID = 0
        TitleID = 0
        TitleAuthorID = 0
        ISBNID = 0

        Me.Close()

    End Sub

    Friend Sub SendMessage(ByVal message As String)


        frmLibraryCollection.ErrorLabel.Text = message.ToString.Trim


    End Sub

End Class