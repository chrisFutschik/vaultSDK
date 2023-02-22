<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreateItemForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.m_okButton = New System.Windows.Forms.Button()
        Me.m_cancelButton = New System.Windows.Forms.Button()
        Me.m_itemTitleTextBox = New System.Windows.Forms.TextBox()
        Me.m_itemTypeComboBox = New System.Windows.Forms.ComboBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'm_okButton
        '
        Me.m_okButton.Location = New System.Drawing.Point(97, 65)
        Me.m_okButton.Name = "m_okButton"
        Me.m_okButton.Size = New System.Drawing.Size(88, 24)
        Me.m_okButton.TabIndex = 9
        Me.m_okButton.Text = "OK"
        '
        'm_cancelButton
        '
        Me.m_cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.m_cancelButton.Location = New System.Drawing.Point(193, 65)
        Me.m_cancelButton.Name = "m_cancelButton"
        Me.m_cancelButton.Size = New System.Drawing.Size(88, 24)
        Me.m_cancelButton.TabIndex = 10
        Me.m_cancelButton.Text = "Cancel"
        '
        'm_itemTitleTextBox
        '
        Me.m_itemTitleTextBox.Location = New System.Drawing.Point(89, 9)
        Me.m_itemTitleTextBox.Name = "m_itemTitleTextBox"
        Me.m_itemTitleTextBox.Size = New System.Drawing.Size(192, 20)
        Me.m_itemTitleTextBox.TabIndex = 7
        '
        'm_itemTypeComboBox
        '
        Me.m_itemTypeComboBox.Location = New System.Drawing.Point(89, 33)
        Me.m_itemTypeComboBox.Name = "m_itemTypeComboBox"
        Me.m_itemTypeComboBox.Size = New System.Drawing.Size(192, 21)
        Me.m_itemTypeComboBox.TabIndex = 8
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(9, 33)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(72, 16)
        Me.label2.TabIndex = 6
        Me.label2.Text = "Type:"
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(9, 9)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(72, 16)
        Me.label1.TabIndex = 5
        Me.label1.Text = "Title:"
        '
        'CreateItemForm
        '
        Me.AcceptButton = Me.m_okButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.m_cancelButton
        Me.ClientSize = New System.Drawing.Size(290, 99)
        Me.Controls.Add(Me.m_okButton)
        Me.Controls.Add(Me.m_cancelButton)
        Me.Controls.Add(Me.m_itemTitleTextBox)
        Me.Controls.Add(Me.m_itemTypeComboBox)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Name = "CreateItemForm"
        Me.Text = "Create Item"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents m_okButton As System.Windows.Forms.Button
    Private WithEvents m_cancelButton As System.Windows.Forms.Button
    Private WithEvents m_itemTitleTextBox As System.Windows.Forms.TextBox
    Private WithEvents m_itemTypeComboBox As System.Windows.Forms.ComboBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
End Class
