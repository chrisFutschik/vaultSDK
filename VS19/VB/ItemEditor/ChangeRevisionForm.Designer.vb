<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChangeRevisionForm
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
        Me.m_groupBox = New System.Windows.Forms.GroupBox()
        Me.m_customTextBox = New System.Windows.Forms.TextBox()
        Me.m_customRadioButton = New System.Windows.Forms.RadioButton()
        Me.m_tertiaryRadioButton = New System.Windows.Forms.RadioButton()
        Me.m_secondaryRadioButton = New System.Windows.Forms.RadioButton()
        Me.m_primaryRadioButton = New System.Windows.Forms.RadioButton()
        Me.m_okButton = New System.Windows.Forms.Button()
        Me.m_cancelButton = New System.Windows.Forms.Button()
        Me.m_groupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'm_groupBox
        '
        Me.m_groupBox.Controls.Add(Me.m_customTextBox)
        Me.m_groupBox.Controls.Add(Me.m_customRadioButton)
        Me.m_groupBox.Controls.Add(Me.m_tertiaryRadioButton)
        Me.m_groupBox.Controls.Add(Me.m_secondaryRadioButton)
        Me.m_groupBox.Controls.Add(Me.m_primaryRadioButton)
        Me.m_groupBox.Location = New System.Drawing.Point(8, 6)
        Me.m_groupBox.Name = "m_groupBox"
        Me.m_groupBox.Size = New System.Drawing.Size(272, 152)
        Me.m_groupBox.TabIndex = 10
        Me.m_groupBox.TabStop = False
        Me.m_groupBox.Text = "Revision Number"
        '
        'm_customTextBox
        '
        Me.m_customTextBox.Location = New System.Drawing.Point(80, 120)
        Me.m_customTextBox.Name = "m_customTextBox"
        Me.m_customTextBox.Size = New System.Drawing.Size(184, 20)
        Me.m_customTextBox.TabIndex = 4
        '
        'm_customRadioButton
        '
        Me.m_customRadioButton.Location = New System.Drawing.Point(16, 112)
        Me.m_customRadioButton.Name = "m_customRadioButton"
        Me.m_customRadioButton.Size = New System.Drawing.Size(64, 32)
        Me.m_customRadioButton.TabIndex = 3
        Me.m_customRadioButton.Text = "Custom"
        '
        'm_tertiaryRadioButton
        '
        Me.m_tertiaryRadioButton.Location = New System.Drawing.Point(16, 80)
        Me.m_tertiaryRadioButton.Name = "m_tertiaryRadioButton"
        Me.m_tertiaryRadioButton.Size = New System.Drawing.Size(248, 32)
        Me.m_tertiaryRadioButton.TabIndex = 2
        Me.m_tertiaryRadioButton.Text = "Tertiary"
        '
        'm_secondaryRadioButton
        '
        Me.m_secondaryRadioButton.Location = New System.Drawing.Point(16, 48)
        Me.m_secondaryRadioButton.Name = "m_secondaryRadioButton"
        Me.m_secondaryRadioButton.Size = New System.Drawing.Size(248, 32)
        Me.m_secondaryRadioButton.TabIndex = 1
        Me.m_secondaryRadioButton.Text = "Secondary"
        '
        'm_primaryRadioButton
        '
        Me.m_primaryRadioButton.Location = New System.Drawing.Point(16, 16)
        Me.m_primaryRadioButton.Name = "m_primaryRadioButton"
        Me.m_primaryRadioButton.Size = New System.Drawing.Size(248, 32)
        Me.m_primaryRadioButton.TabIndex = 0
        Me.m_primaryRadioButton.Text = "Primary"
        '
        'm_okButton
        '
        Me.m_okButton.Location = New System.Drawing.Point(96, 166)
        Me.m_okButton.Name = "m_okButton"
        Me.m_okButton.Size = New System.Drawing.Size(88, 24)
        Me.m_okButton.TabIndex = 8
        Me.m_okButton.Text = "OK"
        '
        'm_cancelButton
        '
        Me.m_cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.m_cancelButton.Location = New System.Drawing.Point(192, 166)
        Me.m_cancelButton.Name = "m_cancelButton"
        Me.m_cancelButton.Size = New System.Drawing.Size(88, 24)
        Me.m_cancelButton.TabIndex = 9
        Me.m_cancelButton.Text = "Cancel"
        '
        'ChangeRevisionForm
        '
        Me.AcceptButton = Me.m_okButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.m_cancelButton
        Me.ClientSize = New System.Drawing.Size(288, 197)
        Me.Controls.Add(Me.m_groupBox)
        Me.Controls.Add(Me.m_okButton)
        Me.Controls.Add(Me.m_cancelButton)
        Me.Name = "ChangeRevisionForm"
        Me.Text = "Select New Revision Number"
        Me.m_groupBox.ResumeLayout(False)
        Me.m_groupBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents m_groupBox As System.Windows.Forms.GroupBox
    Private WithEvents m_customTextBox As System.Windows.Forms.TextBox
    Private WithEvents m_customRadioButton As System.Windows.Forms.RadioButton
    Private WithEvents m_tertiaryRadioButton As System.Windows.Forms.RadioButton
    Private WithEvents m_secondaryRadioButton As System.Windows.Forms.RadioButton
    Private WithEvents m_primaryRadioButton As System.Windows.Forms.RadioButton
    Private WithEvents m_okButton As System.Windows.Forms.Button
    Private WithEvents m_cancelButton As System.Windows.Forms.Button
End Class
