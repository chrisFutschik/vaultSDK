<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
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
        Me.label1 = New System.Windows.Forms.Label
        Me.m_tableLayoutPanel = New System.Windows.Forms.TableLayoutPanel
        Me.SuspendLayout()
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(12, 11)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(256, 13)
        Me.label1.TabIndex = 3
        Me.label1.Text = "Check the boxes to restrict specific Vault commands:"
        '
        'm_tableLayoutPanel
        '
        Me.m_tableLayoutPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.m_tableLayoutPanel.AutoScroll = True
        Me.m_tableLayoutPanel.ColumnCount = 1
        Me.m_tableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.m_tableLayoutPanel.Location = New System.Drawing.Point(12, 50)
        Me.m_tableLayoutPanel.Name = "m_tableLayoutPanel"
        Me.m_tableLayoutPanel.RowCount = 1
        Me.m_tableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.m_tableLayoutPanel.Size = New System.Drawing.Size(260, 502)
        Me.m_tableLayoutPanel.TabIndex = 2
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 562)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.m_tableLayoutPanel)
        Me.Name = "Form1"
        Me.Text = "Configure Restrictions"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents m_tableLayoutPanel As System.Windows.Forms.TableLayoutPanel

End Class
