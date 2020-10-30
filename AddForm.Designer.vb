<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
                AuthorFirstName = Nothing
                AuthorMiddleName = Nothing
                AuthorLastName = Nothing
                AuthorFullName = Nothing
                Title = Nothing
                AuthorID = Nothing
                TitleID = Nothing
                TitleAuthorID = Nothing
                BookType = Nothing
                AddFormMessage = Nothing
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
        Me.AuthorFirstNameLabel = New System.Windows.Forms.Label()
        Me.AuthorMiddleNameLabel = New System.Windows.Forms.Label()
        Me.AuthorLastNameLabel = New System.Windows.Forms.Label()
        Me.AuthorFirstNameTextbox = New System.Windows.Forms.TextBox()
        Me.TitleLabel = New System.Windows.Forms.Label()
        Me.AuthorMiddleNameTextbox = New System.Windows.Forms.TextBox()
        Me.AuthorLastNameTextbox = New System.Windows.Forms.TextBox()
        Me.TitleTextbox = New System.Windows.Forms.TextBox()
        Me.InstructionLabel = New System.Windows.Forms.Label()
        Me.SaveButton = New System.Windows.Forms.Button()
        Me.CancelProcessButton = New System.Windows.Forms.Button()
        Me.MessageLabel = New System.Windows.Forms.Label()
        Me.TypeLabel = New System.Windows.Forms.Label()
        Me.BookTypeCombobox = New System.Windows.Forms.ComboBox()
        Me.ISBNTextbox = New System.Windows.Forms.TextBox()
        Me.ISBNLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'AuthorFirstNameLabel
        '
        Me.AuthorFirstNameLabel.AutoSize = True
        Me.AuthorFirstNameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AuthorFirstNameLabel.Location = New System.Drawing.Point(35, 73)
        Me.AuthorFirstNameLabel.Name = "AuthorFirstNameLabel"
        Me.AuthorFirstNameLabel.Size = New System.Drawing.Size(114, 16)
        Me.AuthorFirstNameLabel.TabIndex = 0
        Me.AuthorFirstNameLabel.Text = "Author First Name"
        '
        'AuthorMiddleNameLabel
        '
        Me.AuthorMiddleNameLabel.AutoSize = True
        Me.AuthorMiddleNameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AuthorMiddleNameLabel.Location = New System.Drawing.Point(19, 103)
        Me.AuthorMiddleNameLabel.Name = "AuthorMiddleNameLabel"
        Me.AuthorMiddleNameLabel.Size = New System.Drawing.Size(130, 16)
        Me.AuthorMiddleNameLabel.TabIndex = 1
        Me.AuthorMiddleNameLabel.Text = "Author Middle Name"
        '
        'AuthorLastNameLabel
        '
        Me.AuthorLastNameLabel.AutoSize = True
        Me.AuthorLastNameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AuthorLastNameLabel.Location = New System.Drawing.Point(35, 133)
        Me.AuthorLastNameLabel.Name = "AuthorLastNameLabel"
        Me.AuthorLastNameLabel.Size = New System.Drawing.Size(114, 16)
        Me.AuthorLastNameLabel.TabIndex = 2
        Me.AuthorLastNameLabel.Text = "Author Last Name"
        '
        'AuthorFirstNameTextbox
        '
        Me.AuthorFirstNameTextbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AuthorFirstNameTextbox.Location = New System.Drawing.Point(167, 69)
        Me.AuthorFirstNameTextbox.Name = "AuthorFirstNameTextbox"
        Me.AuthorFirstNameTextbox.Size = New System.Drawing.Size(207, 22)
        Me.AuthorFirstNameTextbox.TabIndex = 3
        '
        'TitleLabel
        '
        Me.TitleLabel.AutoSize = True
        Me.TitleLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitleLabel.Location = New System.Drawing.Point(115, 163)
        Me.TitleLabel.Name = "TitleLabel"
        Me.TitleLabel.Size = New System.Drawing.Size(34, 16)
        Me.TitleLabel.TabIndex = 4
        Me.TitleLabel.Text = "Title"
        '
        'AuthorMiddleNameTextbox
        '
        Me.AuthorMiddleNameTextbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AuthorMiddleNameTextbox.Location = New System.Drawing.Point(167, 98)
        Me.AuthorMiddleNameTextbox.Name = "AuthorMiddleNameTextbox"
        Me.AuthorMiddleNameTextbox.Size = New System.Drawing.Size(207, 22)
        Me.AuthorMiddleNameTextbox.TabIndex = 4
        '
        'AuthorLastNameTextbox
        '
        Me.AuthorLastNameTextbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AuthorLastNameTextbox.Location = New System.Drawing.Point(167, 127)
        Me.AuthorLastNameTextbox.Name = "AuthorLastNameTextbox"
        Me.AuthorLastNameTextbox.Size = New System.Drawing.Size(207, 22)
        Me.AuthorLastNameTextbox.TabIndex = 5
        '
        'TitleTextbox
        '
        Me.TitleTextbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitleTextbox.Location = New System.Drawing.Point(167, 156)
        Me.TitleTextbox.Name = "TitleTextbox"
        Me.TitleTextbox.Size = New System.Drawing.Size(207, 22)
        Me.TitleTextbox.TabIndex = 6
        '
        'InstructionLabel
        '
        Me.InstructionLabel.AutoSize = True
        Me.InstructionLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InstructionLabel.Location = New System.Drawing.Point(111, 33)
        Me.InstructionLabel.Name = "InstructionLabel"
        Me.InstructionLabel.Size = New System.Drawing.Size(205, 16)
        Me.InstructionLabel.TabIndex = 8
        Me.InstructionLabel.Text = "Add New Author And/Or Title"
        '
        'SaveButton
        '
        Me.SaveButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SaveButton.Location = New System.Drawing.Point(299, 262)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(75, 23)
        Me.SaveButton.TabIndex = 9
        Me.SaveButton.Text = "Save"
        Me.SaveButton.UseVisualStyleBackColor = True
        '
        'CancelProcessButton
        '
        Me.CancelProcessButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.CancelProcessButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CancelProcessButton.Location = New System.Drawing.Point(167, 262)
        Me.CancelProcessButton.Name = "CancelProcessButton"
        Me.CancelProcessButton.Size = New System.Drawing.Size(75, 23)
        Me.CancelProcessButton.TabIndex = 9
        Me.CancelProcessButton.Text = "Cancel"
        Me.CancelProcessButton.UseVisualStyleBackColor = True
        '
        'MessageLabel
        '
        Me.MessageLabel.Location = New System.Drawing.Point(13, 302)
        Me.MessageLabel.Name = "MessageLabel"
        Me.MessageLabel.Size = New System.Drawing.Size(415, 45)
        Me.MessageLabel.TabIndex = 11
        '
        'TypeLabel
        '
        Me.TypeLabel.AutoSize = True
        Me.TypeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TypeLabel.Location = New System.Drawing.Point(74, 193)
        Me.TypeLabel.Name = "TypeLabel"
        Me.TypeLabel.Size = New System.Drawing.Size(75, 16)
        Me.TypeLabel.TabIndex = 12
        Me.TypeLabel.Text = "Book Type"
        '
        'BookTypeCombobox
        '
        Me.BookTypeCombobox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BookTypeCombobox.FormattingEnabled = True
        Me.BookTypeCombobox.Items.AddRange(New Object() {"", "HB - Hard Back", "SB - Soft Back", "EB - E-book", "AB - Audible Book"})
        Me.BookTypeCombobox.Location = New System.Drawing.Point(167, 185)
        Me.BookTypeCombobox.Name = "BookTypeCombobox"
        Me.BookTypeCombobox.Size = New System.Drawing.Size(207, 24)
        Me.BookTypeCombobox.TabIndex = 7
        '
        'ISBNTextbox
        '
        Me.ISBNTextbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ISBNTextbox.Location = New System.Drawing.Point(167, 216)
        Me.ISBNTextbox.Name = "ISBNTextbox"
        Me.ISBNTextbox.Size = New System.Drawing.Size(207, 22)
        Me.ISBNTextbox.TabIndex = 8
        '
        'ISBNLabel
        '
        Me.ISBNLabel.AutoSize = True
        Me.ISBNLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ISBNLabel.Location = New System.Drawing.Point(110, 223)
        Me.ISBNLabel.Name = "ISBNLabel"
        Me.ISBNLabel.Size = New System.Drawing.Size(39, 16)
        Me.ISBNLabel.TabIndex = 13
        Me.ISBNLabel.Text = "ISBN"
        '
        'AddForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(440, 360)
        Me.Controls.Add(Me.ISBNTextbox)
        Me.Controls.Add(Me.ISBNLabel)
        Me.Controls.Add(Me.BookTypeCombobox)
        Me.Controls.Add(Me.TypeLabel)
        Me.Controls.Add(Me.MessageLabel)
        Me.Controls.Add(Me.CancelProcessButton)
        Me.Controls.Add(Me.SaveButton)
        Me.Controls.Add(Me.InstructionLabel)
        Me.Controls.Add(Me.TitleTextbox)
        Me.Controls.Add(Me.AuthorLastNameTextbox)
        Me.Controls.Add(Me.AuthorMiddleNameTextbox)
        Me.Controls.Add(Me.TitleLabel)
        Me.Controls.Add(Me.AuthorFirstNameTextbox)
        Me.Controls.Add(Me.AuthorLastNameLabel)
        Me.Controls.Add(Me.AuthorMiddleNameLabel)
        Me.Controls.Add(Me.AuthorFirstNameLabel)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AddForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "e"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents AuthorFirstNameLabel As Label
    Friend WithEvents AuthorMiddleNameLabel As Label
    Friend WithEvents AuthorLastNameLabel As Label
    Friend WithEvents AuthorFirstNameTextbox As TextBox
    Friend WithEvents TitleLabel As Label
    Friend WithEvents AuthorMiddleNameTextbox As TextBox
    Friend WithEvents AuthorLastNameTextbox As TextBox
    Friend WithEvents TitleTextbox As TextBox
    Friend WithEvents InstructionLabel As Label
    Friend WithEvents SaveButton As Button
    Friend WithEvents CancelProcessButton As Button
    Friend WithEvents MessageLabel As Label
    Friend WithEvents TypeLabel As Label
    Friend WithEvents BookTypeCombobox As ComboBox
    Friend WithEvents ISBNTextbox As TextBox
    Friend WithEvents ISBNLabel As Label
End Class
