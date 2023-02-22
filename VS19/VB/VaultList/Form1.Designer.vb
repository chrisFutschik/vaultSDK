<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.m_listBox = New System.Windows.Forms.ListBox()
        Me.button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'm_listBox
        '
        Me.m_listBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.m_listBox.Location = New System.Drawing.Point(0, 0)
        Me.m_listBox.Name = "m_listBox"
        Me.m_listBox.Size = New System.Drawing.Size(292, 250)
        Me.m_listBox.TabIndex = 2
        '
        'button1
        '
        Me.button1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.button1.Location = New System.Drawing.Point(0, 250)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(292, 23)
        Me.button1.TabIndex = 3
        Me.button1.Text = "List Files"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.Add(Me.m_listBox)
        Me.Controls.Add(Me.button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents m_listBox As System.Windows.Forms.ListBox
    Private WithEvents button1 As System.Windows.Forms.Button

End Class
