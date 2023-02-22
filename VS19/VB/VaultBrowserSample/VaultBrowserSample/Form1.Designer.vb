Partial Class Form1
    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing

    ''' <summary>
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Windows Form Designer generated code"

    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.vaultBrowserControl1 = New Autodesk.DataManagement.Client.Framework.Vault.Forms.Controls.ClassicVaultBrowserControl()
        Me.vaultNavigationPathComboboxControl1 = New Autodesk.DataManagement.Client.Framework.Vault.Forms.Controls.VaultNavigationPathComboboxControl()
        Me.lookIn_label = New System.Windows.Forms.Label()
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.toolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.login_toolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.logout_toolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.actionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.m_openFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.m_addFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.m_advancedFindToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.fileName_multiPartTextBox = New Autodesk.DataManagement.Client.Framework.Forms.Controls.MultiPartTextBoxControl()
        Me.fileName_label = New System.Windows.Forms.Label()
        Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.navigateBack_toolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.navigateUp_toolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.switchView_toolStripSplitButton = New System.Windows.Forms.ToolStripSplitButton()
        Me.revision_label = New System.Windows.Forms.Label()
        Me.fileType_comboBox = New System.Windows.Forms.ComboBox()
        Me.m_tabControl = New System.Windows.Forms.TabControl()
        Me.tabPage1 = New System.Windows.Forms.TabPage()
        Me.m_associationsTreeView = New System.Windows.Forms.TreeView()
        Me.menuStrip1.SuspendLayout()
        Me.tableLayoutPanel1.SuspendLayout()
        Me.toolStrip1.SuspendLayout()
        Me.m_tabControl.SuspendLayout()
        Me.tabPage1.SuspendLayout()
        Me.SuspendLayout()
        ' 
        ' vaultBrowserControl1
        ' 
        resources.ApplyResources(Me.vaultBrowserControl1, "vaultBrowserControl1")
        Me.tableLayoutPanel1.SetColumnSpan(Me.vaultBrowserControl1, 3)
        Me.vaultBrowserControl1.Name = "vaultBrowserControl1"
        ' 
        ' vaultNavigationPathComboboxControl1
        ' 
        resources.ApplyResources(Me.vaultNavigationPathComboboxControl1, "vaultNavigationPathComboboxControl1")
        Me.vaultNavigationPathComboboxControl1.Name = "vaultNavigationPathComboboxControl1"
        ' 
        ' lookIn_label
        ' 
        resources.ApplyResources(Me.lookIn_label, "lookIn_label")
        Me.lookIn_label.Name = "lookIn_label"
        ' 
        ' menuStrip1
        ' 
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripMenuItem1, Me.actionsToolStripMenuItem})
        resources.ApplyResources(Me.menuStrip1, "menuStrip1")
        Me.menuStrip1.Name = "menuStrip1"
        ' 
        ' toolStripMenuItem1
        ' 
        Me.toolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.login_toolStripMenuItem, Me.logout_toolStripMenuItem})
        Me.toolStripMenuItem1.Name = "toolStripMenuItem1"
        resources.ApplyResources(Me.toolStripMenuItem1, "toolStripMenuItem1")
        ' 
        ' login_toolStripMenuItem
        ' 
        Me.login_toolStripMenuItem.Name = "login_toolStripMenuItem"
        resources.ApplyResources(Me.login_toolStripMenuItem, "login_toolStripMenuItem")
        AddHandler Me.login_toolStripMenuItem.Click, New System.EventHandler(AddressOf Me.login_toolStripMenuItem_Click)
        ' 
        ' logout_toolStripMenuItem
        ' 
        resources.ApplyResources(Me.logout_toolStripMenuItem, "logout_toolStripMenuItem")
        Me.logout_toolStripMenuItem.Name = "logout_toolStripMenuItem"
        AddHandler Me.logout_toolStripMenuItem.Click, New System.EventHandler(AddressOf Me.logout_toolStripMenuItem_Click)
        ' 
        ' actionsToolStripMenuItem
        ' 
        Me.actionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.m_openFileToolStripMenuItem, Me.m_addFileToolStripMenuItem, Me.m_advancedFindToolStripMenuItem})
        Me.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem"
        resources.ApplyResources(Me.actionsToolStripMenuItem, "actionsToolStripMenuItem")
        ' 
        ' m_openFileToolStripMenuItem
        ' 
        resources.ApplyResources(Me.m_openFileToolStripMenuItem, "m_openFileToolStripMenuItem")
        Me.m_openFileToolStripMenuItem.Name = "m_openFileToolStripMenuItem"
        AddHandler Me.m_openFileToolStripMenuItem.Click, New System.EventHandler(AddressOf Me.m_openFileToolStripMenuItem_Click)
        ' 
        ' m_addFileToolStripMenuItem
        ' 
        resources.ApplyResources(Me.m_addFileToolStripMenuItem, "m_addFileToolStripMenuItem")
        Me.m_addFileToolStripMenuItem.Name = "m_addFileToolStripMenuItem"
        AddHandler Me.m_addFileToolStripMenuItem.Click, New System.EventHandler(AddressOf Me.m_addFileToolStripMenuItem_Click)
        ' 
        ' m_advancedFindToolStripMenuItem
        ' 
        resources.ApplyResources(Me.m_advancedFindToolStripMenuItem, "m_advancedFindToolStripMenuItem")
        Me.m_advancedFindToolStripMenuItem.Name = "m_advancedFindToolStripMenuItem"
        AddHandler Me.m_advancedFindToolStripMenuItem.Click, New System.EventHandler(AddressOf Me.m_advancedFindToolStripMenuItem_Click)
        ' 
        ' fileName_multiPartTextBox
        ' 
        resources.ApplyResources(Me.fileName_multiPartTextBox, "fileName_multiPartTextBox")
        Me.tableLayoutPanel1.SetColumnSpan(Me.fileName_multiPartTextBox, 2)
        Me.fileName_multiPartTextBox.EditMode = Autodesk.DataManagement.Client.Framework.Forms.Controls.MultiPartTextBoxControl.EditModeOption.FullEdit
        Me.fileName_multiPartTextBox.Name = "fileName_multiPartTextBox"
        Me.fileName_multiPartTextBox.Parts = DirectCast(resources.GetObject("fileName_multiPartTextBox.Parts"), System.Collections.Generic.IEnumerable(Of String))
        ' 
        ' fileName_label
        ' 
        resources.ApplyResources(Me.fileName_label, "fileName_label")
        Me.fileName_label.Name = "fileName_label"
        ' 
        ' tableLayoutPanel1
        ' 
        resources.ApplyResources(Me.tableLayoutPanel1, "tableLayoutPanel1")
        Me.tableLayoutPanel1.Controls.Add(Me.lookIn_label, 0, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.vaultNavigationPathComboboxControl1, 1, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.toolStrip1, 2, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.vaultBrowserControl1, 0, 1)
        Me.tableLayoutPanel1.Controls.Add(Me.fileName_label, 0, 2)
        Me.tableLayoutPanel1.Controls.Add(Me.fileName_multiPartTextBox, 1, 2)
        Me.tableLayoutPanel1.Controls.Add(Me.revision_label, 0, 3)
        Me.tableLayoutPanel1.Controls.Add(Me.fileType_comboBox, 1, 3)
        Me.tableLayoutPanel1.Controls.Add(Me.m_tabControl, 0, 4)
        Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
        ' 
        ' toolStrip1
        ' 
        Me.toolStrip1.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.toolStrip1, "toolStrip1")
        Me.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.navigateBack_toolStripButton, Me.navigateUp_toolStripButton, Me.switchView_toolStripSplitButton})
        Me.toolStrip1.Name = "toolStrip1"
        ' 
        ' navigateBack_toolStripButton
        ' 
        Me.navigateBack_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.navigateBack_toolStripButton.Image = Global.VaultBrowserSample.Resource.Back_16
        resources.ApplyResources(Me.navigateBack_toolStripButton, "navigateBack_toolStripButton")
        Me.navigateBack_toolStripButton.Name = "navigateBack_toolStripButton"
        AddHandler Me.navigateBack_toolStripButton.Click, New System.EventHandler(AddressOf Me.navigateBack_toolStripButton_Click)
        ' 
        ' navigateUp_toolStripButton
        ' 
        Me.navigateUp_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.navigateUp_toolStripButton.Image = Global.VaultBrowserSample.Resource.uplevel_16
        resources.ApplyResources(Me.navigateUp_toolStripButton, "navigateUp_toolStripButton")
        Me.navigateUp_toolStripButton.Name = "navigateUp_toolStripButton"
        AddHandler Me.navigateUp_toolStripButton.Click, New System.EventHandler(AddressOf Me.navigateUp_toolStripButton_Click)
        ' 
        ' switchView_toolStripSplitButton
        ' 
        Me.switchView_toolStripSplitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.switchView_toolStripSplitButton.Image = Global.VaultBrowserSample.Resource.ViewOptions_16
        resources.ApplyResources(Me.switchView_toolStripSplitButton, "switchView_toolStripSplitButton")
        Me.switchView_toolStripSplitButton.Name = "switchView_toolStripSplitButton"
        AddHandler Me.switchView_toolStripSplitButton.ButtonClick, New System.EventHandler(AddressOf Me.switchView_toolStripSplitButton_ButtonClick)
        AddHandler Me.switchView_toolStripSplitButton.DropDownOpening, New System.EventHandler(AddressOf Me.switchView_toolStripSplitButton_DropDownOpening)
        ' 
        ' revision_label
        ' 
        resources.ApplyResources(Me.revision_label, "revision_label")
        Me.revision_label.Name = "revision_label"
        ' 
        ' fileType_comboBox
        ' 
        Me.tableLayoutPanel1.SetColumnSpan(Me.fileType_comboBox, 2)
        resources.ApplyResources(Me.fileType_comboBox, "fileType_comboBox")
        Me.fileType_comboBox.FormattingEnabled = True
        Me.fileType_comboBox.Name = "fileType_comboBox"
        AddHandler Me.fileType_comboBox.SelectedIndexChanged, New System.EventHandler(AddressOf Me.fileType_comboBox_SelectedIndexChanged)
        ' 
        ' m_tabControl
        ' 
        Me.tableLayoutPanel1.SetColumnSpan(Me.m_tabControl, 3)
        Me.m_tabControl.Controls.Add(Me.tabPage1)
        resources.ApplyResources(Me.m_tabControl, "m_tabControl")
        Me.m_tabControl.Name = "m_tabControl"
        Me.m_tabControl.SelectedIndex = 0
        ' 
        ' tabPage1
        ' 
        Me.tabPage1.Controls.Add(Me.m_associationsTreeView)
        resources.ApplyResources(Me.tabPage1, "tabPage1")
        Me.tabPage1.Name = "tabPage1"
        Me.tabPage1.UseVisualStyleBackColor = True
        ' 
        ' m_associationsTreeView
        ' 
        resources.ApplyResources(Me.m_associationsTreeView, "m_associationsTreeView")
        Me.m_associationsTreeView.Name = "m_associationsTreeView"
        ' 
        ' Form1
        ' 
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tableLayoutPanel1)
        Me.Controls.Add(Me.menuStrip1)
        Me.MainMenuStrip = Me.menuStrip1
        Me.Name = "Form1"
        AddHandler Me.FormClosed, New System.Windows.Forms.FormClosedEventHandler(AddressOf Me.Form1_FormClosed)
        AddHandler Me.Shown, New System.EventHandler(AddressOf Me.Form1_Shown)
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        Me.tableLayoutPanel1.ResumeLayout(False)
        Me.tableLayoutPanel1.PerformLayout()
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        Me.m_tabControl.ResumeLayout(False)
        Me.tabPage1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private vaultBrowserControl1 As Autodesk.DataManagement.Client.Framework.Vault.Forms.Controls.ClassicVaultBrowserControl
    Private vaultNavigationPathComboboxControl1 As Autodesk.DataManagement.Client.Framework.Vault.Forms.Controls.VaultNavigationPathComboboxControl
    Private lookIn_label As System.Windows.Forms.Label
    Private menuStrip1 As System.Windows.Forms.MenuStrip
    Private toolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Private login_toolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private logout_toolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private fileName_multiPartTextBox As Autodesk.DataManagement.Client.Framework.Forms.Controls.MultiPartTextBoxControl
    Private fileName_label As System.Windows.Forms.Label
    Private tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Private revision_label As System.Windows.Forms.Label
    Private fileType_comboBox As System.Windows.Forms.ComboBox
    Private toolStrip1 As System.Windows.Forms.ToolStrip
    Private navigateBack_toolStripButton As System.Windows.Forms.ToolStripButton
    Private navigateUp_toolStripButton As System.Windows.Forms.ToolStripButton
    Private switchView_toolStripSplitButton As System.Windows.Forms.ToolStripSplitButton
    Private m_tabControl As System.Windows.Forms.TabControl
    Private tabPage1 As System.Windows.Forms.TabPage
    Private m_associationsTreeView As System.Windows.Forms.TreeView
    Private actionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private m_openFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private m_addFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private m_advancedFindToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
