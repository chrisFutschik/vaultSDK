<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.m_changeRevisionButton = New System.Windows.Forms.Button()
        Me.m_createItemButton = New System.Windows.Forms.Button()
        Me.m_gridLabel = New System.Windows.Forms.Label()
        Me.m_tableStyle = New System.Windows.Forms.DataGridTableStyle()
        Me.m_itemsGrid = New System.Windows.Forms.DataGrid()
        Me.m_fileLinkButton = New System.Windows.Forms.Button()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.m_importButton = New System.Windows.Forms.Button()
        Me.m_exportButton = New System.Windows.Forms.Button()
        Me.m_rollbackButton = New System.Windows.Forms.Button()
        Me.m_changeLifeCycleButton = New System.Windows.Forms.Button()
        CType(Me.m_itemsGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'm_changeRevisionButton
        '
        Me.m_changeRevisionButton.Location = New System.Drawing.Point(8, 54)
        Me.m_changeRevisionButton.Name = "m_changeRevisionButton"
        Me.m_changeRevisionButton.Size = New System.Drawing.Size(112, 24)
        Me.m_changeRevisionButton.TabIndex = 1
        Me.m_changeRevisionButton.Text = "Change Revision"
        '
        'm_createItemButton
        '
        Me.m_createItemButton.Location = New System.Drawing.Point(8, 24)
        Me.m_createItemButton.Name = "m_createItemButton"
        Me.m_createItemButton.Size = New System.Drawing.Size(112, 24)
        Me.m_createItemButton.TabIndex = 0
        Me.m_createItemButton.Text = "Create Item"
        '
        'm_gridLabel
        '
        Me.m_gridLabel.Location = New System.Drawing.Point(164, 16)
        Me.m_gridLabel.Name = "m_gridLabel"
        Me.m_gridLabel.Size = New System.Drawing.Size(264, 16)
        Me.m_gridLabel.TabIndex = 5
        Me.m_gridLabel.Text = "Item List"
        '
        'm_tableStyle
        '
        Me.m_tableStyle.DataGrid = Me.m_itemsGrid
        Me.m_tableStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.m_tableStyle.ReadOnly = True
        '
        'm_itemsGrid
        '
        Me.m_itemsGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.m_itemsGrid.CaptionVisible = False
        Me.m_itemsGrid.DataMember = ""
        Me.m_itemsGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.m_itemsGrid.Location = New System.Drawing.Point(164, 40)
        Me.m_itemsGrid.Name = "m_itemsGrid"
        Me.m_itemsGrid.ReadOnly = True
        Me.m_itemsGrid.RowHeadersVisible = False
        Me.m_itemsGrid.Size = New System.Drawing.Size(384, 279)
        Me.m_itemsGrid.TabIndex = 6
        Me.m_itemsGrid.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.m_tableStyle})
        '
        'm_fileLinkButton
        '
        Me.m_fileLinkButton.Location = New System.Drawing.Point(8, 144)
        Me.m_fileLinkButton.Name = "m_fileLinkButton"
        Me.m_fileLinkButton.Size = New System.Drawing.Size(112, 24)
        Me.m_fileLinkButton.TabIndex = 5
        Me.m_fileLinkButton.Text = "Link to File"
        '
        'groupBox1
        '
        Me.groupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.groupBox1.Controls.Add(Me.m_importButton)
        Me.groupBox1.Controls.Add(Me.m_exportButton)
        Me.groupBox1.Controls.Add(Me.m_fileLinkButton)
        Me.groupBox1.Controls.Add(Me.m_rollbackButton)
        Me.groupBox1.Controls.Add(Me.m_changeLifeCycleButton)
        Me.groupBox1.Controls.Add(Me.m_changeRevisionButton)
        Me.groupBox1.Controls.Add(Me.m_createItemButton)
        Me.groupBox1.Location = New System.Drawing.Point(12, 8)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(136, 319)
        Me.groupBox1.TabIndex = 4
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Commands"
        '
        'm_importButton
        '
        Me.m_importButton.Location = New System.Drawing.Point(8, 204)
        Me.m_importButton.Name = "m_importButton"
        Me.m_importButton.Size = New System.Drawing.Size(112, 24)
        Me.m_importButton.TabIndex = 8
        Me.m_importButton.Text = "Import From CSV"
        '
        'm_exportButton
        '
        Me.m_exportButton.Location = New System.Drawing.Point(8, 174)
        Me.m_exportButton.Name = "m_exportButton"
        Me.m_exportButton.Size = New System.Drawing.Size(112, 24)
        Me.m_exportButton.TabIndex = 7
        Me.m_exportButton.Text = "Export to CSV"
        '
        'm_rollbackButton
        '
        Me.m_rollbackButton.Location = New System.Drawing.Point(8, 114)
        Me.m_rollbackButton.Name = "m_rollbackButton"
        Me.m_rollbackButton.Size = New System.Drawing.Size(112, 24)
        Me.m_rollbackButton.TabIndex = 3
        Me.m_rollbackButton.Text = "Rollback Life Cycle"
        '
        'm_changeLifeCycleButton
        '
        Me.m_changeLifeCycleButton.Location = New System.Drawing.Point(8, 84)
        Me.m_changeLifeCycleButton.Name = "m_changeLifeCycleButton"
        Me.m_changeLifeCycleButton.Size = New System.Drawing.Size(112, 24)
        Me.m_changeLifeCycleButton.TabIndex = 2
        Me.m_changeLifeCycleButton.Text = "Change Life Cycle"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(560, 336)
        Me.Controls.Add(Me.m_gridLabel)
        Me.Controls.Add(Me.m_itemsGrid)
        Me.Controls.Add(Me.groupBox1)
        Me.Name = "MainForm"
        Me.Text = "Item Editor"
        CType(Me.m_itemsGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents m_changeRevisionButton As System.Windows.Forms.Button
    Private WithEvents m_createItemButton As System.Windows.Forms.Button
    Private WithEvents m_gridLabel As System.Windows.Forms.Label
    Private WithEvents m_tableStyle As System.Windows.Forms.DataGridTableStyle
    Private WithEvents m_itemsGrid As System.Windows.Forms.DataGrid
    Private WithEvents m_fileLinkButton As System.Windows.Forms.Button
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents m_rollbackButton As System.Windows.Forms.Button
    Private WithEvents m_changeLifeCycleButton As System.Windows.Forms.Button
    Private WithEvents m_importButton As System.Windows.Forms.Button
    Private WithEvents m_exportButton As System.Windows.Forms.Button

End Class
