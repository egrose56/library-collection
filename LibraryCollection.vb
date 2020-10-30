Imports System.Data.SqlClient

Public Class frmLibraryCollection

    Friend dr As SqlDataReader
    Friend AuthorFullName As String
    Friend AuthorFirstName As String
    Friend AuthorMiddleName As String
    Friend AuthorLastName As String
    Friend Title As String
    Friend BookType As String
    Friend ISBN As String
    Friend AuthorID As Integer
    Friend TitleID As Integer
    Friend TitleAuthorID As Integer
    Friend ISBNId As Integer
    Friend RowIndex As Integer

    Friend Enum AddEdit
        Add = 2
        Edit = 1
        Cancel = 0
        Delete = 3
    End Enum

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call.
        FillGrid()

    End Sub

    Private Sub FillGrid()

        Try

            Dim gridWorks As New DataWorkingClass

            If dr IsNot Nothing Then
                dr.Close()
            End If

            'Go get the data to fill the grid
            dr = gridWorks.FillGrid()

            If dr IsNot Nothing Then

                'If we have data, clear the grid
                'and apply the fresh data
                Me.CollectionGrid.Rows.Clear()

                Dim intReturn As Integer
                intReturn = FormatGrid()
                Me.CollectionGrid.Refresh()

                Me.ItemCountLabel.Text = ""
                Me.ItemCountLabel.Text = "# Records: " & intReturn
                Me.SearchCriteriaTextbox.Focus()

                gridWorks = Nothing

            End If

        Catch ex As Exception

            Me.ErrorLabel.Text = ex.Message
            Me.ErrorLabel.Visible = True

        End Try

    End Sub

    Private Function FormatGrid() As Integer

        Dim intCount As Integer

        If dr IsNot Nothing Then
            Try
                With Me.CollectionGrid

                    'set up the grid appearance
                    .Rows.Clear()
                    .Columns.Clear()
                    .AllowUserToAddRows = False
                    .ReadOnly = True

                    'Column 1
                    .Columns.Add(dr.GetName(0), "Author")
                    .Columns(0).Width = 200

                    ''Column 2
                    .Columns.Add(dr.GetName(1), "Title")
                    .Columns(1).Width = 250

                    .Columns.Add(dr.GetName(2), "Book Type")
                    .Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

                    .Columns.Add(dr.GetName(3), "Author ID")
                    .Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

                    .Columns.Add(dr.GetName(4), "Title ID")
                    .Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

                    .Columns.Add(dr.GetName(5), "TitleAuthor ID")
                    .Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

                    .Columns.Add(dr.GetName(6), "Author First Name")
                    .Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    .Columns.Item(6).Visible = False

                    .Columns.Add(dr.GetName(7), "Author Middle Name")
                    .Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    .Columns.Item(7).Visible = False

                    .Columns.Add(dr.GetName(8), "Author Last Name")
                    .Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    .Columns.Item(8).Visible = False

                    .Columns.Add(dr.GetName(9), "ISBN")
                    .Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

                    .Columns.Add(dr.GetName(10), "ISBNID")
                    .Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

                    'Add the data.
                    'loop through the dataReader and add
                    'values to the grid
                    Do While dr.Read()

                        'add a row to the grid
                        Me.CollectionGrid.Rows.Add(1)

                        'add the cell data
                        'Author Full Name
                        If IsDBNull(dr.Item(0)) Then
                            Me.CollectionGrid.Rows(intCount).Cells(0).Value = ""
                        Else
                            Me.CollectionGrid.Rows(intCount).Cells(0).Value = dr.GetString(0)
                        End If

                        'Title
                        If IsDBNull(dr.Item(1)) Then
                            Me.CollectionGrid.Rows(intCount).Cells(1).Value = ""
                        Else
                            Me.CollectionGrid.Rows(intCount).Cells(1).Value = dr.GetString(1)
                        End If

                        'Book Type
                        If IsDBNull(dr.Item(2)) Then
                            Me.CollectionGrid.Rows(intCount).Cells(2).Value = ""
                        Else
                            Me.CollectionGrid.Rows(intCount).Cells(2).Value = dr.Item(2)
                        End If

                        'AuthorID
                        If IsDBNull(dr.Item(3)) Then
                            Me.CollectionGrid.Rows(intCount).Cells(3).Value = ""
                        Else
                            Me.CollectionGrid.Rows(intCount).Cells(3).Value = dr.Item(3)
                        End If

                        'TitleID
                        If IsDBNull(dr.Item(4)) Then
                            Me.CollectionGrid.Rows(intCount).Cells(4).Value = ""
                        Else
                            Me.CollectionGrid.Rows(intCount).Cells(4).Value = dr.Item(4)
                        End If

                        'TitleAuthorID
                        If IsDBNull(dr.Item(5)) Then
                            Me.CollectionGrid.Rows(intCount).Cells(5).Value = ""
                        Else
                            Me.CollectionGrid.Rows(intCount).Cells(5).Value = dr.Item(5)
                        End If

                        'AuthorFirstName
                        If IsDBNull(dr.Item(6)) Then
                            Me.CollectionGrid.Rows(intCount).Cells(6).Value = ""
                        Else
                            Me.CollectionGrid.Rows(intCount).Cells(6).Value = dr.Item(6)
                        End If

                        'AuthorMiddleName
                        If IsDBNull(dr.Item(7)) Then
                            Me.CollectionGrid.Rows(intCount).Cells(7).Value = ""
                        Else
                            Me.CollectionGrid.Rows(intCount).Cells(7).Value = dr.Item(7)
                        End If

                        'AuthorLastName
                        If IsDBNull(dr.Item(8)) Then
                            Me.CollectionGrid.Rows(intCount).Cells(8).Value = ""
                        Else
                            Me.CollectionGrid.Rows(intCount).Cells(8).Value = dr.Item(8)
                        End If

                        'ISBN
                        If IsDBNull(dr.Item(9)) Then
                            Me.CollectionGrid.Rows(intCount).Cells(9).Value = ""
                        Else
                            Me.CollectionGrid.Rows(intCount).Cells(9).Value = dr.Item(9)
                        End If

                        'ISBNID
                        If IsDBNull(dr.Item(10)) Then
                            Me.CollectionGrid.Rows(intCount).Cells(10).Value = ""
                        Else
                            Me.CollectionGrid.Rows(intCount).Cells(10).Value = dr.Item(10)
                        End If

                        intCount += 1
                    Loop
                End With

                'clear the memory
                dr.Close()
                dr = Nothing

                intCount = Me.CollectionGrid.Rows.Count
                Me.CollectionGrid.Rows.SharedRow(0).Selected = False

            Catch ex As Exception

                Me.ErrorLabel.Text = ex.Message
                Me.ErrorLabel.Visible = True

                'clear the memory
                dr.Close()
                dr = Nothing

                'return failure
                Return 0

            End Try

        End If

        'return success
        Return intCount

    End Function

    Private Sub SearchMagnifyingGlass_Click(sender As Object, e As EventArgs) Handles SearchMagnifyingGlass.Click

        Dim grid As New DataWorkingClass
        Dim intReturn As Integer

        Try
            'Call the routine to search the database using the user
            'supplied text and return the data in a datareader object
            dr = grid.SearchGrid(SearchCriteriaTextbox.Text)

            intReturn = FormatGrid()

            If dr IsNot Nothing Then
                dr.Close()
                dr = Nothing
            End If
            grid = Nothing

        Catch ex As Exception

            Me.ErrorLabel.Text = ex.Message
            Me.ErrorLabel.Visible = True

        End Try

    End Sub

    Private Sub SearchCriteriaTextbox_KeyDown(sender As Object, e As KeyEventArgs) Handles SearchCriteriaTextbox.KeyDown

        'Allow the search if the Enter key has been pressed
        If e.KeyValue.ToString = "13" Then
            Call Me.SearchMagnifyingGlass_Click(Me, e)
        End If

    End Sub

    Private Sub ClearVariableValues()

        AuthorFullName = ""
        AuthorFirstName = ""
        AuthorMiddleName = ""
        AuthorLastName = ""
        Title = ""
        BookType = ""
        ISBN = ""
        AuthorID = 0
        TitleID = 0
        TitleAuthorID = 0
        ISBNId = 0
        RowIndex = 0

    End Sub

    Private Sub AddMenu_Click(sender As Object, e As EventArgs) Handles AddMenu.Click

        Dim frmAdd As New AddForm

        Try
            'load an empty form to fill and save
            'using that form's button
            With frmAdd
                .SelectedProcess = AddEdit.Add 'This value indicates the add item has been selected.
                .ShowDialog(Me.CollectionGrid)
            End With

        Catch ex As Exception
            Me.ErrorLabel.Text = ex.Message

        End Try

        'Need to refresh the grid to capture the addition
        FillGrid()
        ClearVariableValues()
        frmAdd = Nothing


    End Sub

    Private Sub DisplayAddEditForm(ByVal SelectedProcess As Integer)

        Dim frmAdd As New AddForm

        If SelectedProcess = AddEdit.Edit Then 'Want to edit the selected row

            Try

                GetSelectedRowData()


                'Fill the add/edit form with the selected information for edit,
                'When the save button is pressed, the changed data goes to the database
                'then is pulled back to the grid.
                With frmAdd
                    .AuthorFirstNameTextbox.Text = AuthorFirstName
                    .AuthorMiddleNameTextbox.Text = AuthorMiddleName
                    .AuthorLastNameTextbox.Text = AuthorLastName
                    .TitleTextbox.Text = Title
                    .BookTypeCombobox.Text = BookType
                    .ISBNTextbox.Text = ISBN
                    .AuthorID = AuthorID
                    .TitleID = TitleID
                    .TitleAuthorID = TitleAuthorID
                    SelectedProcess = AddEdit.Edit
                    .Show(Me)
                End With

            Catch ex As Exception
                Me.ErrorLabel.Text = ex.Message

            End Try

        End If

        FillGrid()
        Me.CollectionGrid.Refresh()
        ClearVariableValues()
        frmAdd = Nothing

    End Sub

    Private Function DeleteSelectedRecord() As Integer

        Dim intReturn As Integer
        Dim dataWorks As New DataWorkingClass

        Try

            'remove the incorrect TitleAuthor record (TitleAuthorID)
            intReturn = dataWorks.DeleteTitleAuthorRecord(TitleAuthorID)

            If intReturn = 1 Then
                intReturn = 0

                'we don't want to leave an orphaned ISBN duplicate
                intReturn = dataWorks.DeleteISBNRecord(ISBNId)
            End If

        Catch

            intReturn = -1

        End Try

        ClearVariableValues()
        Return intReturn

    End Function

    Private Sub GetSelectedRowData()

        With Me.CollectionGrid

            If .SelectedRows.Count > 1 Then
                Me.ErrorLabel.Text = "Please select only one row at a time."
            Else

                'Collect all the row's values into variables
                'for inserts and updates
                If .SelectedRows.Count = 1 Then

                    If .SelectedCells.Item(0).Value IsNot "" Then
                        AuthorFullName = .SelectedCells.Item(0).Value
                    Else
                        AuthorFullName = ""
                    End If
                    If .SelectedCells.Item(1).Value IsNot "" Then
                        Title = .SelectedCells.Item(1).Value
                    Else
                        Title = ""
                    End If
                    If .SelectedCells.Item(2).Value IsNot "" Then
                        BookType = .SelectedCells.Item(2).Value
                    Else
                        BookType = ""
                    End If
                    If .SelectedCells.Item(3).Value.ToString IsNot "" Then
                        AuthorID = .SelectedCells.Item(3).Value.ToString
                    Else
                        AuthorID = 0
                    End If
                    If .SelectedCells.Item(4).Value.ToString IsNot "" Then
                        TitleID = .SelectedCells.Item(4).Value.ToString
                    Else
                        TitleID = 0
                    End If
                    If .SelectedCells.Item(5).Value.ToString IsNot "" Then
                        TitleAuthorID = .SelectedCells.Item(5).Value.ToString
                    Else
                        TitleAuthorID = 0
                    End If
                    If .SelectedCells.Item(6).Value IsNot "" Then
                        AuthorFirstName = .SelectedCells.Item(6).Value
                    Else
                        AuthorFirstName = ""
                    End If
                    If .SelectedCells.Item(7).Value IsNot "" Then
                        AuthorMiddleName = .SelectedCells.Item(7).Value
                    Else
                        AuthorMiddleName = ""
                    End If
                    If .SelectedCells.Item(8).Value IsNot "" Then
                        AuthorLastName = .SelectedCells.Item(8).Value
                    Else
                        AuthorLastName = ""
                    End If
                    If .SelectedCells.Item(9).Value IsNot "" Then
                        ISBN = .SelectedCells.Item(9).Value
                    Else
                        ISBN = ""
                    End If
                    If .SelectedCells.Item(10).Value IsNot "" Then
                        ISBNId = .SelectedCells.Item(10).Value
                    Else
                        ISBNId = 0
                    End If
                End If
            End If
        End With

    End Sub

    Private Sub CancelMenu_Click(sender As Object, e As EventArgs) Handles CancelMenu.Click

        FillGrid()

    End Sub

    Private Sub CollectionGrid_MouseDown(sender As Object, e As MouseEventArgs) Handles CollectionGrid.MouseDown

        Dim xPoint As Integer
        Dim yPoint As Integer

        If e.Button = MouseButtons.Right Then

            xPoint = e.X
            yPoint = e.Y

            If Not TryCast(sender, DataGridView) Is Nothing Then

                If sender.SelectedRows.Count > 1 Then
                    'do nothing, we only want one row at a time
                Else
                    'Clear the current values
                    ClearVariableValues()

                    'Get the user requested row index
                    RowIndex = Me.CollectionGrid.HitTest(xPoint, yPoint).RowIndex

                    'Tell the grid to show the user requested row as selected
                    Me.CollectionGrid.Rows.Item(RowIndex).Selected = True

                End If

            End If

            AddMenuEdit.Show()

        End If

    End Sub

    Private Sub EditMenu_Click(sender As Object, e As EventArgs) Handles EditMenu.Click

        DisplayAddEditForm(AddEdit.Edit) 'call the routine to fill the edit form with the selected row information

        FillGrid()

    End Sub

    Private Sub DeleteMenu_Click(sender As Object, e As EventArgs) Handles DeleteMenu.Click

        'First get the data from the selected row to identify
        'the records to delete.
        GetSelectedRowData()

        DeleteSelectedRecord()

        FillGrid()

    End Sub
End Class
