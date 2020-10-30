Imports System.Text
Imports System.Data.SqlClient

Friend Class DataWorkingClass

    Friend cn As SqlConnection
    Friend cmd As SqlCommand
    Friend dr As SqlDataReader
    Friend message As String

    Friend Function DeleteISBNRecord(ByVal ISBNId As Integer) As Integer

        Dim intReturn As Integer
        Dim strSQL As New StringBuilder

        Try

            strSQL.Append("DELETE FROM TableISBN WHERE ISBNId = " & ISBNId)

            dr = RunSQL(strSQL)

            If dr IsNot Nothing Then
                dr.Read()
            End If
            If dr.RecordsAffected = 1 Then
                intReturn = 1
            End If

            dr.Close()
            strSQL.Clear()

        Catch ex As Exception
            Return 0
        End Try

        Return intReturn

    End Function

    Friend Function DeleteTitleRecord(ByVal TitleId As Integer) As Integer

        Dim intReturn As Integer
        Dim strSQL As New StringBuilder

        Try

            strSQL.Append("DELETE FROM Title WHERE TitleId = " & TitleId)

            dr = RunSQL(strSQL)

            If dr IsNot Nothing Then
                dr.Read()
            End If
            If dr.RecordsAffected = 1 Then
                intReturn = 1
            End If

            dr.Close()
            strSQL.Clear()

        Catch ex As Exception
            Return 0
        End Try

        Return intReturn

    End Function

    Friend Function DeleteTitleAuthorRecord(ByVal TitleAuthorId As Integer) As Integer

        Dim intReturn As Integer
        Dim strSQL As New StringBuilder

        Try

            strSQL.Append("DELETE FROM TitleAuthor WHERE TitleAuthorId = " & TitleAuthorId)

            dr = RunSQL(strSQL)

            If dr IsNot Nothing Then
                dr.Read()
            End If
            If dr.RecordsAffected = 1 Then
                intReturn = 1
            End If

            dr.Close()
            strSQL.Clear()

        Catch ex As Exception
            Return 0
        End Try

        Return intReturn

    End Function

    Friend Function UpdateTitleAuthor(ByVal TitleAuthorID As Integer, ByVal ISBNID As Integer) As Integer

        Dim strSQL As New StringBuilder
        Dim intReturn As Integer

        Try

            strSQL.Append("UPDATE [TitleAuthor] SET [TitleAuthor].[ISBNID] = " & ISBNID & " " _
                      & "WHERE [TitleAuthor].[TitleAuthorID] = " & TitleAuthorID)

            dr = RunSQL(strSQL)

            If dr IsNot Nothing Then
                dr.Read()
            End If
            If dr.RecordsAffected = 1 Then
                intReturn = TitleAuthorID
            End If

            dr.Close()
            strSQL.Clear()

        Catch ex As Exception
            Return 0
        End Try

        Return intReturn
    End Function

    Friend Function UpdateTitle(ByVal TitleID As Integer, ByVal Title As String) As Integer

        Dim strSQL As New StringBuilder
        Dim intReturn As Integer

        Try

            strSQL.Append("UPDATE [Title] SET [Title].[Title] =  '" & Title _
                          & "' WHERE [Title].[TitleID] = " & TitleID)

            dr = RunSQL(strSQL)

            If dr IsNot Nothing Then
                dr.Read()
            End If
            If dr.RecordsAffected = 1 Then
                intReturn = 1
            End If

            dr.Close()
            strSQL.Clear()

        Catch ex As Exception
            Return 0
        End Try

        Return intReturn

    End Function

    Friend Function UpdateISBN(ByVal ISBNID As Integer, ByVal ISBN As String, ByVal BookType As String) As Integer

        Dim strSQL As New StringBuilder
        Dim intReturn As Integer

        Try

            strSQL.Append("UPDATE [TableISBN] SET [TableISBN].[ISBN] = NullIf('" + ISBN + "','') " & ", " _
                      & "[TableISBN].[BookTypeID] = (SELECT [BookType].[BookTypeID] FROM [BookType] WHERE BookType = '" & BookType & "') " _
                      & "WHERE [TableISBN].[ISBNID] = " & ISBNID)

            dr = RunSQL(strSQL)

            If dr IsNot Nothing Then
                dr.Read()
            End If
            If dr.RecordsAffected = 1 Then
                intReturn = 1
            End If

            dr.Close()
            strSQL.Clear()

        Catch ex As Exception
            Return 0
        End Try

        Return intReturn

    End Function

    Friend Function GetOrInsertISBNID(ByVal ISBN As String, ByVal BookType As String) As Integer

        Dim strSQL As New StringBuilder
        Dim intBookTypeID As Integer
        Dim intISBNID As Integer

        Try


            strSQL.Append("SELECT BookTypeID FROM BookType WHERE BookType = '" & BookType & "'")

            dr = RunSQL(strSQL)

            If dr IsNot Nothing Then
                dr.Read()
            End If
            If dr.HasRows Then
                intBookTypeID = dr.Item(0)
            End If

            dr.Close()
            strSQL.Clear()

            strSQL.Append("INSERT INTO [TableISBN] ([TableISBN].[ISBN], [TableISBN].[BookTypeID]) VALUES (NullIf('" + ISBN + "',''), " & intBookTypeID & ")")

            dr = RunSQL(strSQL)

            If dr IsNot Nothing Then
                dr.Read()
            End If
            If dr.RecordsAffected = 1 Then

                dr.Close()
                strSQL.Clear()

                strSQL.Append("Select MAX([TableISBN].[ISBNID]) As ISBNID FROM [TableISBN] WHERE [TableISBN].[ISBN] = " _
                              & "NullIf('" + ISBN + "', '') OR [TableISBN].[BookTypeID] = " & intBookTypeID)

                dr = RunSQL(strSQL)

                If dr.HasRows Then
                    dr.Read()
                    intISBNID = dr.Item(0)
                Else
                    intISBNID = 0
                End If

            End If

            dr.Close()
            strSQL.Clear()

        Catch ex As Exception
            Return intISBNID
        End Try

        Return intISBNID

    End Function

    Friend Function DoubleCheckForAuthor(ByVal FirstName As String, ByVal MiddleName As String,
                                         ByVal LastName As String, ByVal Title As String, ByVal BookType As String, ByVal ISBN As String) As SqlDataReader

        Dim strSQL As New StringBuilder

        Try
            strSQL.Append("SELECT [Author].[AuthorID] FROM [Author] " _
                          & "FULL OUTER JOIN [TitleAuthor] ON [Author].[ID] = [TitleAuthor].[AuthorID] " _
                          & "FULL OUTER JOIN [Title] ON [Title].[TitleID] = [TitleAuthor].[TitleID] " _
                          & "JOIN [TableISBN] ON [TitleAuthor].[ISBNId] = [TableISBN].[ISBNID] " _
                          & "JOIN [BookType] ON [TableISBN].[BookTypeID] = [BookType].[BookTypeID] " _
                          & "WHERE (([Author].[AuthorFirstName] Like '%" & FirstName & "%' OR [Author].[AuthorFirstName] Is Null) " _
                            & "AND ([Author].[AuthorMiddleName] LIKE '%" & MiddleName & "%' OR [Author].[AuthorMiddleName] Is Null) " _
                            & "AND ([Author].[AuthorLastName] LIKE '%" & LastName & "%' OR [Author].[AuthorFirstName] Is Null) " _
                            & "AND [Title].[Title] LIKE '" & Title & "' " _
                            & "AND ([BookType].[BookType] LIKE '" & BookType & "' OR [BookType].[BookType] Is Null) " _
                            & "AND [TableISBN].[ISBN] = '" & ISBN & "' OR [TableISBN].[ISBN] Is Null)")

            dr = RunSQL(strSQL)

            strSQL.Clear()

            If dr Is Nothing Then
                Return Nothing
            Else
                Return dr
            End If

        Catch

            Return Nothing

        End Try

        dr.Close()

    End Function

    Friend Function InsertTitleAuthorData(ByVal AuthorID As Integer, ByVal TitleID As Integer, ByVal ISBNID As Integer) As Integer

        Dim TitleAuthorID As Integer
        Dim strSQL As New StringBuilder

        Try

            If ISBNID = 0 Then

                strSQL.Append("INSERT INTO [TitleAuthor] ([TitleAuthor].[AuthorID], [TitleAuthor].[TitleID]) " _
                          & "VALUES (" & AuthorID & ", " & TitleID & ")")
            Else

                strSQL.Append("INSERT INTO [TitleAuthor] ([TitleAuthor].[AuthorID], [TitleAuthor].[TitleID], [TitleAuthor].[ISBNID]) " _
                          & "VALUES (" & AuthorID & ", " & TitleID & ", " & ISBNID & ")")

            End If

            dr = RunSQL(strSQL)
            If dr IsNot Nothing Then
                dr.Read()
            End If
            If dr.RecordsAffected = 1 Then

                strSQL.Clear()
                dr.Close()

                If ISBNID > 0 Then
                    strSQL.Append("SELECT MAX([TitleAuthor].[TitleAuthorID]) " _
                              & "FROM [TitleAuthor] " _
                              & "WHERE [TitleAuthor].[AuthorID] = " & AuthorID & " " _
                              & "AND [TitleAuthor].[TitleID] = " & TitleID)
                Else

                    strSQL.Append("SELECT MAX([TitleAuthor].[TitleAuthorID]) " _
                              & "FROM [TitleAuthor] " _
                              & "WHERE [TitleAuthor].[AuthorID] = " & AuthorID & " " _
                              & "AND [TitleAuthor].[TitleID] = " & TitleID & " " _
                              & "AND [TitleAuthor].[ISBNID] = " & ISBNID)
                End If

                dr = RunSQL(strSQL)

                If dr IsNot Nothing Then
                    dr.Read()
                End If
                If dr.HasRows Then
                    TitleAuthorID = dr.Item(0)
                End If
            End If

            dr.Close()
            strSQL.Clear()

            Return TitleAuthorID

        Catch ex As Exception

            TitleAuthorID = -4
            Return TitleAuthorID
            message = ""
            message = ex.Message.ToString
            SendMessage()
        End Try

    End Function

    'Friend Function CheckForExistingTitleAuthor(ByVal AuthorID As Integer, ByVal TitleID As Integer, ByVal ISBNID As Integer) As Integer

    '    Dim strSQL As New StringBuilder
    '    Dim intReturn As Integer

    '    Try

    '        strSQL.Append("SELECT [TitleAuthor].[TitleAuthorID] FROM [TitleAuthor] " _
    '                      & "WHERE [TitleAuthor].[TitleID] = " & TitleID & " " _
    '                       & "AND [TitleAuthor].[AuthorID] = " & AuthorID & " " _
    '                       & "AND [TitleAuthor].[ISBNID] = " & ISBNID)

    '        dr = RunSQL(strSQL)

    '        If dr.HasRows Then

    '            dr.Read()
    '            intReturn = dr.Item(0)

    '        End If

    '        dr.Close()
    '        strSQL.Clear()

    '        Return intReturn

    '    Catch ex As Exception
    '        Return -1
    '        message = ""
    '        message = ex.Message.ToString
    '        SendMessage()
    '    End Try

    '    Return intReturn

    'End Function

    Friend Function UpdateAuthorData(ByVal AuthorID As Integer, AuthorFirstName As String, AuthorMiddleName As String, AuthorLastName As String) As Integer
        'may be called by CheckForExistingAuthor
        'may be called by the Edit Context Menu on the main form.
        Dim strSQL As New StringBuilder

        Try

            strSQL.Append("UPDATE [Author] SET [Author].[AuthorFirstName] = NullIf('" & AuthorFirstName & "',''), " _
                          & "[Author].[AuthorMiddleName] = NullIf('" & AuthorMiddleName & "',''), " _
                          & "[Author].[AuthorLastName] = NullIf('" & AuthorLastName & "','') " _
                          & "WHERE [Author].[AuthorID] = " & AuthorID)

            dr = RunSQL(strSQL)
            If dr.RecordsAffected = 1 Then

                dr.Close()
                strSQL.Clear()
                Return 1

            End If

        Catch ex As Exception
            Return -1
            message = ""
            message = ex.Message.ToString
            SendMessage()
        End Try

        Return 0

    End Function

    Friend Function InsertTitle(ByVal Title As String) As Integer

        Dim strSQL As New StringBuilder
        Dim strTitle As New StringBuilder
        Dim TitleID As Integer
        Dim intCounter As Integer

        Try
            strSQL.Append("SELECT [Title].[TitleID] FROM [Title] WHERE [Title].[Title] = '")

            'check each letter in the Title and add formatting
            'as needed
            For intCounter = 0 To Title.Length - 1

                If Title(intCounter).ToString = "'" Then
                    strSQL.Append("''")
                Else
                    strSQL.Append(Title(intCounter).ToString)
                End If

            Next

            strSQL.Append("'")

            dr = RunSQL(strSQL)

            If dr IsNot Nothing And dr.HasRows Then
                dr.Read()
                TitleID = dr.Item(0)

            Else
                strSQL.Clear()
                dr.Close()

                intCounter = 0

                For intCounter = 0 To Title.Length - 1
                    If Title(intCounter).ToString = "'" Then
                        strTitle.Append("''")
                    Else
                        strTitle.Append(Title(intCounter).ToString)
                    End If
                Next

                strSQL.Append("INSERT INTO [Title] ([Title].[Title]) " _
                            & "VALUES ('" + strTitle.ToString + "')")

                dr = RunSQL(strSQL)

                If dr IsNot Nothing Then

                    dr.Read()

                    If dr.RecordsAffected = 1 Then

                        strSQL.Clear()
                        dr.Close()

                        strSQL.Append("SELECT MAX([Title].[TitleID]) " _
                                        & "FROM [Title] " _
                                        & "WHERE [Title].[Title] = '" & strTitle.ToString & "'")

                        dr = RunSQL(strSQL)

                        If dr IsNot Nothing Then
                            dr.Read()
                        End If

                        If dr.HasRows Then
                            TitleID = dr.Item(0)
                        End If
                    End If

                End If

                strSQL.Clear()
                dr.Close()

            End If

            Return TitleID

        Catch ex As Exception
            Return -3
            message = ""
            message = ex.Message.ToString
            SendMessage()
        End Try

    End Function

    Friend Function InsertAuthorData(ByVal FirstName As String,
                                     ByVal MiddleName As String,
                                     ByVal LastName As String) As Integer

        Dim intReturn As Integer
        Dim strSQL As New StringBuilder

        ' TODO: Extensive testing required - better messaging?
        Try

            'any return greater than or equal to zero gets the author added.
            'we may want to add a way for the user to allow or cancel this add, but still check
            'for the new title.
            strSQL.Append("INSERT INTO [Author] ([Author].[AuthorFirstName], " _
                                & "[Author].[AuthorMiddleName], [Author].[AuthorLastName]) " _
                        & "VALUES (NullIf('" + FirstName + "',''), " _
                        & "NullIf('" + MiddleName + "', ''), " _
                        & "NullIf('" + LastName + "', ''))")

            dr = RunSQL(strSQL)

            If dr IsNot Nothing Then

                'The return from the read should be the
                'number of records inserted = 1
                dr.Read()

                intReturn = dr.RecordsAffected

                strSQL.Clear()
                dr.Close()

                If intReturn = 1 Then

                    strSQL.Append("SELECT [Author].[AuthorID] FROM [Author] " _
                      & "WHERE ([Author].[AuthorFirstName]='" + FirstName + "' OR [Author].[AuthorFirstName] Is Null)" _
                      & " AND ([Author].[AuthorMiddleName]='" + MiddleName + "' OR [Author].[AuthorMiddleName] Is Null)" _
                      & " AND ([Author].[AuthorLastName]=N'" + LastName + "' OR [Author].[AuthorLastName] Is Null)")

                    dr = RunSQL(strSQL)

                    If dr IsNot Nothing Then
                        dr.Read()
                        If dr.HasRows Then
                            intReturn = dr.Item(0)  'Author ID
                        End If
                    End If
                Else
                    intReturn = 0    'insert failed
                End If
            Else
                'dr is nothing
            End If

            strSQL.Clear()
            dr.Close()

            Return intReturn

        Catch ex As Exception
            intReturn = -1
            Return intReturn
            message = Nothing
            message = ex.Message.ToString
            SendMessage()
        End Try

    End Function
    Friend Function CheckForExistingAuthor(ByVal FirstName As String, ByVal MiddleName As String, ByVal LastName As String) As SqlDataReader

        Dim strSQL As New StringBuilder

        Try

            'Check to see if there is already an author with the submitted data
            strSQL.Append("SELECT IIF ([Author].[AuthorFirstName] IS NULL, '', [Author].[AuthorFirstName] + ' ') + " _
                & "IIF ([Author].[AuthorMiddleName] Is NULL, '', [Author].[AuthorMiddleName] + ' ') + " _
                & "IIf([Author].[AuthorLastName] Is NULL, '', [Author].[AuthorLastName]) AS Name, " _
                & "[Title].[Title] As Title, [BookType].[BookType] As BookType, [Author].[AuthorID] As AuthorID, [Title].[TitleID] As TitleID, " _
                & "[TitleAuthor].[TitleAuthorID] As TitleAuthorID, [Author].[AuthorFirstName], [Author].[AuthorMiddleName], [Author].[AuthorLastName], " _
                & "[TableISBN].[ISBN] As ISBN " _
                & "FROM [Author] FULL OUTER JOIN [TitleAuthor] ON [Author].[AuthorID] = [TitleAuthor].[AuthorID] " _
                & "FULL OUTER JOIN [Title] ON [Title].[TitleID] = [TitleAuthor].[TitleID] " _
                & "JOIN [TableISBN] ON [TitleAuthor].[ISBNId] = [TableISBN].[ISBNID] " _
                & "JOIN [BookType] ON [TableISBN].[BookTypeID] = [BookType].[BookTypeID] " _
                & "WHERE (([Author].[AuthorFirstName] Like '%" & FirstName & "%' OR [Author].[AuthorFirstName] Is Null) " _
                & "AND ([Author].[AuthorMiddleName] Like '%" & MiddleName & "%' OR [Author].[AuthorMiddleName] Is Null) " _
                & "AND ([Author].[AuthorLastName] Like '%" & LastName & "%' OR [Author].[AuthorFirstName] Is Null))")

            dr = RunSQL(strSQL)

            Return dr

        Catch ex As Exception
            message = ""
            message = (ex.Message)
            SendMessage()
            Return dr

        End Try

    End Function

    Friend Function SearchGrid(txtSearch As String) As SqlDataReader

        Dim strSQL As New StringBuilder

        txtSearch = txtSearch.Trim

        Try

            strSQL.Append("SELECT IIF ([Author].[AuthorFirstName] IS NULL, '', [Author].[AuthorFirstName] + ' ') + " _
                & "IIF ([Author].[AuthorMiddleName] Is NULL, '', [Author].[AuthorMiddleName] + ' ') + " _
                & "IIf([Author].[AuthorLastName] Is NULL, '', [Author].[AuthorLastName]) AS Name, " _
                & "[Title].[Title] As Title, [BookType].[BookType] As BookType, [Author].[AuthorID] As AuthorID, [Title].[TitleID] As TitleID, " _
                & "[TitleAuthor].[TitleAuthorID] As TitleAuthorID, [Author].[AuthorFirstName], [Author].[AuthorMiddleName], [Author].[AuthorLastName], " _
                & "[TableISBN].[ISBN], [TableISBN].[ISBNID] " _
                & "FROM [Author] FULL OUTER JOIN [TitleAuthor] ON [Author].[AuthorID] = [TitleAuthor].[AuthorID] " _
                & "FULL OUTER JOIN [Title] ON [Title].[TitleID] = [TitleAuthor].[TitleID] " _
                & "FULL OUTER JOIN [TableISBN] ON [TitleAuthor].[ISBNId] = [TableISBN].[ISBNID] " _
                & "FULL OUTER JOIN [BookType] ON [TableISBN].[BookTypeID] = [BookType].[BookTypeID] " _
                & "WHERE (([Author].[AuthorFirstName] Like '%" & txtSearch & "%') " _
                & "OR ([Author].[AuthorMiddleName] Like '%" & txtSearch & "%') " _
                & "OR ([Author].[AuthorLastName] Like '%" & txtSearch & "%') " _
                & "OR ([Author].[AuthorFirstName] + ' ' + [Author].[AuthorLastName] Like '%" & txtSearch & "%') " _
                & "OR ([Title].[Title] Like '%" & txtSearch & "%') " _
                & "OR ([TableISBN].[ISBN] = '" & txtSearch & "')) " _
                & "ORDER BY ([Author].[AuthorLastName] + ', ' + [Author].[AuthorFirstName]) , [Title].[Title]")

            dr = RunSQL(strSQL)
            Return dr

        Catch ex As Exception
            message = ""
            message = (ex.Message)
            SendMessage()
            Return dr
        End Try

    End Function

    Friend Function FillGrid() As SqlDataReader

        Dim strSQL As New StringBuilder

        Try

            strSQL.Append("SELECT IIF ([Author].[AuthorFirstName] IS NULL, '', [Author].[AuthorFirstName] + ' ') + " _
                & "IIF ([Author].[AuthorMiddleName] Is NULL, '', [Author].[AuthorMiddleName] + ' ') + " _
                & "IIf([Author].[AuthorLastName] Is NULL, '', [Author].[AuthorLastName]) AS Name, " _
                & "[Title].[Title] As Title, [BookType].[BookType] As BookType, [Author].[AuthorID] As AuthorID, [Title].[TitleID] As TitleID, " _
                & "[TitleAuthor].[TitleAuthorID] As TitleAuthorID, [Author].[AuthorFirstName], [Author].[AuthorMiddleName], [Author].[AuthorLastName], " _
                & "[TableISBN].[ISBN] As ISBN, [TableISBN].[ISBNID] As ISBNID " _
                & "FROM [Author] FULL OUTER JOIN [TitleAuthor] ON [Author].[AuthorID] = [TitleAuthor].[AuthorID] " _
                & "FULL OUTER JOIN [Title] ON [TitleAuthor].[TitleID] = [Title].[TitleID] " _
                & "FULL OUTER JOIN [TableISBN] ON [TitleAuthor].[ISBNId] = [TableISBN].[ISBNID] " _
                & "FULL OUTER JOIN [BookType] ON [TableISBN].[BookTypeID] = [BookType].[BookTypeID] " _
                & "ORDER BY ([Author].[AuthorLastName] + ', ' + [Author].[AuthorFirstName]) , [Title].[Title]")

            dr = RunSQL(strSQL)
            Return dr

        Catch ex As Exception
            message = ""
            message = ex.Message
            SendMessage()
            Return dr
        End Try

    End Function

    Friend Function RunSQL(strSQL As StringBuilder) As SqlDataReader

        Dim strConnection As String

        strConnection = GetConnectionString()

        Try

            'Open a connection
            If IsNothing(cn) Then
                cn = New SqlConnection
            End If

            Try
                cn.ConnectionString = strConnection
                cn.Open()
            Catch
            End Try

            If dr IsNot Nothing Then
                dr.Close()
            End If

            'get a new command object
            If IsNothing(cmd) Then
                cmd = New SqlCommand
            End If

            cmd = cn.CreateCommand()

            'configure the command and execute it
            cmd.CommandText = strSQL.ToString

            dr = cmd.ExecuteReader()

            'change code to return the data reader to the form
            Return dr
            ClearMemory()

        Catch ex As Exception
            message = ""
            message = ex.Message
            SendMessage()
            Return dr
            ClearMemory()

        End Try
    End Function

    Friend Function GetConnectionString() As String

        Dim mySettings As New My.MySettings
        Dim ReturnString As String

        ReturnString = mySettings.CollectionsConnectionString

        Return ReturnString

    End Function

    Friend Sub SendMessage()


        frmLibraryCollection.ErrorLabel.Text = message.ToString.Trim


    End Sub

    Friend Sub ClearMemory()

        Try
            If cn IsNot Nothing Then
                cn.Close()
            End If
        Catch
        End Try

        Try
            cn = Nothing

        Catch
        End Try

        Try
            cmd = Nothing
        Catch
        End Try

        Try
            dr = Nothing
        Catch
        End Try


    End Sub

    Protected Overrides Sub Finalize()

        ClearMemory()
        MyBase.Finalize()

    End Sub
End Class
