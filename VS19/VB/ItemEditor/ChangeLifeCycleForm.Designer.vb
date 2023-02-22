<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChangeLifeCycleForm
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
        Me.m_lifeCycleListBox = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'm_okButton
        '
        Me.m_okButton.Location = New System.Drawing.Point(97, 105)
        Me.m_okButton.Name = "m_okButton"
        Me.m_okButton.Size = New System.Drawing.Size(88, 24)
        Me.m_okButton.TabIndex = 8
        Me.m_okButton.Text = "OK"
        '
        'm_cancelButton
        '
        Me.m_cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.m_cancelButton.Location = New System.Drawing.Point(193, 105)
        Me.m_cancelButton.Name = "m_cancelButton"
        Me.m_cancelButton.Size = New System.Drawing.Size(88, 24)
        Me.m_cancelButton.TabIndex = 9
        Me.m_cancelButton.Text = "Cancel"
        '
        'm_lifeCycleListBox
        '
        Me.m_lifeCycleListBox.Location = New System.Drawing.Point(9, 9)
        Me.m_lifeCycleListBox.Name = "m_lifeCycleListBox"
        Me.m_lifeCycleListBox.Size = New System.Drawing.Size(272, 82)
        Me.m_lifeCycleListBox.TabIndex = 7
        '
        'ChangeLifeCycleForm
        '
        Me.AcceptButton = Me.m_okButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.m_cancelButton
        Me.ClientSize = New System.Drawing.Size(290, 139)
        Me.Controls.Add(Me.m_okButton)
        Me.Controls.Add(Me.m_cancelButton)
        Me.Controls.Add(Me.m_lifeCycleListBox)
        Me.Name = "ChangeLifeCycleForm"
        Me.Text = "Select Life Cycle State"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents m_okButton As System.Windows.Forms.Button
    Private WithEvents m_cancelButton As System.Windows.Forms.Button
    Private WithEvents m_lifeCycleListBox As System.Windows.Forms.ListBox
End Class
