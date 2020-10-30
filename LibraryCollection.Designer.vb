<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLibraryCollection
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
                If dr IsNot Nothing Then
                    If Not dr.IsClosed Then
                        dr.Close()
                    End If
                    dr = Nothing
                End If

                AuthorFullName = Nothing
                AuthorFirstName = Nothing
                AuthorMiddleName = Nothing
                AuthorLastName = Nothing
                Title = Nothing
                BookType = Nothing
                ISBN = Nothing
                TitleID = Nothing
                AuthorID = Nothing
                TitleAuthorID = Nothing

            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim MainPicture As System.Windows.Forms.PictureBox
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLibraryCollection))
        Me.CollectionGrid = New System.Windows.Forms.DataGridView()
        Me.AddMenuEdit = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.CancelMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchPanel = New System.Windows.Forms.Panel()
        Me.SearchCriteriaTextbox = New System.Windows.Forms.TextBox()
        Me.SearchLabel = New System.Windows.Forms.Label()
        Me.ErrorLabel = New System.Windows.Forms.Label()
        Me.SearchMagnifyingGlass = New System.Windows.Forms.PictureBox()
        Me.ItemCountLabel = New System.Windows.Forms.Label()
        MainPicture = New System.Windows.Forms.PictureBox()
        CType(MainPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CollectionGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AddMenuEdit.SuspendLayout()
        Me.SearchPanel.SuspendLayout()
        CType(Me.SearchMagnifyingGlass, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MainPicture
        '
        MainPicture.Enabled = False
        MainPicture.Image = CType(resources.GetObject("MainPicture.Image"), System.Drawing.Image)
        MainPicture.InitialImage = Global.Collections.My.Resources.Resources._79px_Blue_magnifying_glass_icon_svg
        MainPicture.Location = New System.Drawing.Point(11, 26)
        MainPicture.Name = "MainPicture"
        MainPicture.Size = New System.Drawing.Size(321, 74)
        MainPicture.TabIndex = 0
        MainPicture.TabStop = False
        '
        'CollectionGrid
        '
        Me.CollectionGrid.AllowUserToAddRows = False
        Me.CollectionGrid.AllowUserToDeleteRows = False
        Me.CollectionGrid.AllowUserToResizeRows = False
        Me.CollectionGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CollectionGrid.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
        Me.CollectionGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.CollectionGrid.ContextMenuStrip = Me.AddMenuEdit
        Me.CollectionGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.CollectionGrid.GridColor = System.Drawing.SystemColors.ControlLight
        Me.CollectionGrid.Location = New System.Drawing.Point(12, 107)
        Me.CollectionGrid.MinimumSize = New System.Drawing.Size(100, 100)
        Me.CollectionGrid.MultiSelect = False
        Me.CollectionGrid.Name = "CollectionGrid"
        Me.CollectionGrid.ReadOnly = True
        Me.CollectionGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.CollectionGrid.Size = New System.Drawing.Size(776, 311)
        Me.CollectionGrid.TabIndex = 1
        '
        'AddMenuEdit
        '
        Me.AddMenuEdit.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddMenu, Me.EditMenu, Me.CancelMenu, Me.DeleteMenu})
        Me.AddMenuEdit.Name = "ContextMenuStrip1"
        Me.AddMenuEdit.Size = New System.Drawing.Size(151, 92)
        '
        'AddMenu
        '
        Me.AddMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.AddMenu.Name = "AddMenu"
        Me.AddMenu.Size = New System.Drawing.Size(150, 22)
        Me.AddMenu.Text = "Add New Item"
        '
        'EditMenu
        '
        Me.EditMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.EditMenu.Name = "EditMenu"
        Me.EditMenu.Size = New System.Drawing.Size(150, 22)
        Me.EditMenu.Text = "Edit"
        '
        'CancelMenu
        '
        Me.CancelMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.CancelMenu.Name = "CancelMenu"
        Me.CancelMenu.Size = New System.Drawing.Size(150, 22)
        Me.CancelMenu.Text = "Cancel"
        '
        'DeleteMenu
        '
        Me.DeleteMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.DeleteMenu.Name = "DeleteMenu"
        Me.DeleteMenu.Size = New System.Drawing.Size(150, 22)
        Me.DeleteMenu.Text = "Delete Item"
        '
        'SearchPanel
        '
        Me.SearchPanel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SearchPanel.Controls.Add(Me.SearchCriteriaTextbox)
        Me.SearchPanel.Controls.Add(Me.SearchLabel)
        Me.SearchPanel.Location = New System.Drawing.Point(333, 26)
        Me.SearchPanel.MaximumSize = New System.Drawing.Size(386, 0)
        Me.SearchPanel.MinimumSize = New System.Drawing.Size(386, 74)
        Me.SearchPanel.Name = "SearchPanel"
        Me.SearchPanel.Size = New System.Drawing.Size(386, 74)
        Me.SearchPanel.TabIndex = 9
        '
        'SearchCriteriaTextbox
        '
        Me.SearchCriteriaTextbox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SearchCriteriaTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.SearchCriteriaTextbox.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.SearchCriteriaTextbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchCriteriaTextbox.HideSelection = False
        Me.SearchCriteriaTextbox.Location = New System.Drawing.Point(6, 52)
        Me.SearchCriteriaTextbox.Name = "SearchCriteriaTextbox"
        Me.SearchCriteriaTextbox.Size = New System.Drawing.Size(375, 19)
        Me.SearchCriteriaTextbox.TabIndex = 0
        Me.SearchCriteriaTextbox.WordWrap = False
        '
        'SearchLabel
        '
        Me.SearchLabel.AutoSize = True
        Me.SearchLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchLabel.Location = New System.Drawing.Point(3, 27)
        Me.SearchLabel.Name = "SearchLabel"
        Me.SearchLabel.Size = New System.Drawing.Size(66, 20)
        Me.SearchLabel.TabIndex = 1
        Me.SearchLabel.Text = "Search"
        Me.SearchLabel.UseWaitCursor = True
        '
        'ErrorLabel
        '
        Me.ErrorLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ErrorLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ErrorLabel.Location = New System.Drawing.Point(14, 427)
        Me.ErrorLabel.Name = "ErrorLabel"
        Me.ErrorLabel.Size = New System.Drawing.Size(646, 30)
        Me.ErrorLabel.TabIndex = 3
        Me.ErrorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SearchMagnifyingGlass
        '
        Me.SearchMagnifyingGlass.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SearchMagnifyingGlass.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.SearchMagnifyingGlass.Image = Global.Collections.My.Resources.Resources._79px_Blue_magnifying_glass_icon_svg
        Me.SearchMagnifyingGlass.InitialImage = Nothing
        Me.SearchMagnifyingGlass.Location = New System.Drawing.Point(720, 27)
        Me.SearchMagnifyingGlass.Name = "SearchMagnifyingGlass"
        Me.SearchMagnifyingGlass.Size = New System.Drawing.Size(66, 72)
        Me.SearchMagnifyingGlass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.SearchMagnifyingGlass.TabIndex = 0
        Me.SearchMagnifyingGlass.TabStop = False
        '
        'ItemCountLabel
        '
        Me.ItemCountLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ItemCountLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ItemCountLabel.Location = New System.Drawing.Point(666, 427)
        Me.ItemCountLabel.Name = "ItemCountLabel"
        Me.ItemCountLabel.Size = New System.Drawing.Size(122, 30)
        Me.ItemCountLabel.TabIndex = 10
        Me.ItemCountLabel.Text = "# Records: "
        Me.ItemCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmLibraryCollection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(800, 464)
        Me.Controls.Add(Me.ItemCountLabel)
        Me.Controls.Add(Me.ErrorLabel)
        Me.Controls.Add(Me.SearchPanel)
        Me.Controls.Add(Me.SearchMagnifyingGlass)
        Me.Controls.Add(Me.CollectionGrid)
        Me.Controls.Add(MainPicture)
        Me.Name = "frmLibraryCollection"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Library Collection"
        CType(MainPicture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CollectionGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AddMenuEdit.ResumeLayout(False)
        Me.SearchPanel.ResumeLayout(False)
        Me.SearchPanel.PerformLayout()
        CType(Me.SearchMagnifyingGlass, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CollectionGrid As DataGridView
    Friend WithEvents SearchPanel As Panel
    Friend WithEvents ErrorLabel As Label
    Friend WithEvents SearchCriteriaTextbox As TextBox
    Friend WithEvents SearchLabel As Label
    Friend WithEvents AddMenuEdit As ContextMenuStrip
    Friend WithEvents AddMenu As ToolStripMenuItem
    Friend WithEvents EditMenu As ToolStripMenuItem
    Friend WithEvents CancelMenu As ToolStripMenuItem
    Friend WithEvents DeleteMenu As ToolStripMenuItem
    Friend WithEvents ItemCountLabel As Label
    Friend WithEvents SearchMagnifyingGlass As PictureBox
End Class
