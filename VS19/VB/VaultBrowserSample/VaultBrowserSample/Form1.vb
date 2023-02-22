'=====================================================================
'  
'  This file is part of the Autodesk Vault API Code Samples.
'
'  Copyright (C) Autodesk Inc.  All rights reserved.
'
'THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'=====================================================================


Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Imports ACW = Autodesk.Connectivity.WebServices
Imports Framework = Autodesk.DataManagement.Client.Framework
Imports Vault = Autodesk.DataManagement.Client.Framework.Vault
Imports Forms = Autodesk.DataManagement.Client.Framework.Vault.Forms


Partial Public Class Form1
    Inherits Form
#Region "Member Variables"

    Private m_conn As Vault.Currency.Connections.Connection = Nothing
    Private m_model As Vault.Forms.Models.BrowseVaultNavigationModel = Nothing

    Private m_availableLayouts As New List(Of Framework.Forms.Controls.GridLayout)()
    Private m_viewButtons As New List(Of ToolStripMenuItem)()

    Private m_filterCanDisplayEntity As Func(Of Vault.Currency.Entities.IEntity, Boolean)

#End Region

#Region "Constructors and Initialization Methods"

    Public Sub New()
        InitializeComponent()

        fileName_multiPartTextBox.EditMode = Framework.Forms.Controls.MultiPartTextBoxControl.EditModeOption.[ReadOnly]

        'create some filetype filters, borrowing from the Select Entity dialog
        Dim filter1 As New Forms.Settings.SelectEntitySettings.EntityRegularExpressionFilter("All Files (*.*)", ".+", Vault.Currency.Entities.EntityClassIds.Files)
        fileType_comboBox.Items.Add(filter1)
        Dim filter2 As New Forms.Settings.SelectEntitySettings.EntityRegularExpressionFilter("Text Files (*.txt)", ".+txt", Vault.Currency.Entities.EntityClassIds.Files)
        fileType_comboBox.Items.Add(filter2)
        Dim filter3 As New Forms.Settings.SelectEntitySettings.EntityRegularExpressionFilter("Pictures (*.jpg, *.png, *.gif)", ".+jpg|.+png|.+gif", Vault.Currency.Entities.EntityClassIds.Files)
        fileType_comboBox.Items.Add(filter3)
        Dim filter4 As New Forms.Settings.SelectEntitySettings.EntityRegularExpressionFilter("Project Files (*.ipj)", ".+ipj", Vault.Currency.Entities.EntityClassIds.Files)
        fileType_comboBox.Items.Add(filter4)
        fileType_comboBox.SelectedItem = filter1
        m_filterCanDisplayEntity = AddressOf filter1.CanDisplayEntity
    End Sub

    ''' <summary>
    ''' Prepares the app to browse a vault by creating the inital set of columns, creating the browse model, connecting all the controls to it,
    ''' and navigating to the root of the vault.
    ''' </summary>
    Private Sub initalizeGrid()
        Dim propDefs As Vault.Currency.Properties.PropertyDefinitionDictionary = m_conn.PropertyManager.GetPropertyDefinitions(Nothing, Nothing, Vault.Currency.Properties.PropertyDefinitionFilter.IncludeAll)

        Dim initialConfig As New Vault.Forms.Controls.ClassicVaultBrowserControl.Configuration(m_conn, "VaultBrowserSample", propDefs)

        initialConfig.AddInitialColumn(Vault.Currency.Properties.PropertyDefinitionIds.Client.EntityIcon)
        initialConfig.AddInitialColumn(Vault.Currency.Properties.PropertyDefinitionIds.Client.VaultStatus)
        initialConfig.AddInitialColumn(Vault.Currency.Properties.PropertyDefinitionIds.Server.EntityName)
        initialConfig.AddInitialColumn(Vault.Currency.Properties.PropertyDefinitionIds.Server.CheckInDate)
        initialConfig.AddInitialColumn(Vault.Currency.Properties.PropertyDefinitionIds.Server.Comment)
        initialConfig.AddInitialColumn(Vault.Currency.Properties.PropertyDefinitionIds.Server.ThumbnailSystem)
        initialConfig.AddInitialSortCriteria(Vault.Currency.Properties.PropertyDefinitionIds.Server.EntityName, True)

        initialConfig.AddInitialQuickListColumn(Vault.Currency.Properties.PropertyDefinitionIds.Client.EntityIcon)
        initialConfig.AddInitialQuickListColumn(Vault.Currency.Properties.PropertyDefinitionIds.Client.VaultStatus)
        initialConfig.AddInitialQuickListColumn(Vault.Currency.Properties.PropertyDefinitionIds.Server.EntityName)
        initialConfig.AddInitialQuickListColumn(Vault.Currency.Properties.PropertyDefinitionIds.Server.CheckInDate)
        initialConfig.AddInitialQuickListColumn(Vault.Currency.Properties.PropertyDefinitionIds.Server.Comment)
        initialConfig.AddInitialQuickListColumn(Vault.Currency.Properties.PropertyDefinitionIds.Server.ThumbnailSystem)

        m_model = New Forms.Models.BrowseVaultNavigationModel(m_conn, True, True)

        AddHandler m_model.ParentChanged, New EventHandler(AddressOf m_model_ParentChanged)
        AddHandler m_model.SelectedContentChanged, New EventHandler(Of Forms.Currency.SelectionChangedEventArgs)(AddressOf m_model_SelectedContentChanged)

        vaultBrowserControl1.SetDataSource(initialConfig, m_model)
        vaultBrowserControl1.OptionsCustomizations.CanDisplayEntityHandler = AddressOf canDisplayEntity
        vaultBrowserControl1.OptionsBehavior.MultiSelect = False
        vaultBrowserControl1.OptionsBehavior.AllowOverrideSelections = False

        vaultNavigationPathComboboxControl1.SetDataSource(m_conn, m_model, Nothing)

        m_model.Navigate(m_conn.FolderManager.RootFolder, Forms.Currency.NavigationContext.NewContext)
    End Sub

#End Region

#Region "Event Handlers"

#Region "Form Events"

    Private Sub Form1_Shown(sender As Object, e As EventArgs)
        'save each available layout of the browser control as well as generate a button to use in the switch view dropdown
        For Each layout As Framework.Forms.Controls.GridLayout In vaultBrowserControl1.AvailableLayouts
            m_availableLayouts.Add(layout)
            Dim item As New ToolStripMenuItem(layout.Name)
            item.Tag = layout
            item.CheckOnClick = True
            AddHandler item.Click, New EventHandler(AddressOf switchViewDropdown_itemClick)
            switchView_toolStripSplitButton.DropDownItems.Add(item)
            m_viewButtons.Add(item)
        Next

        m_conn = Vault.Forms.Library.Login(Nothing)
        controlStates(m_conn IsNot Nothing)
        If m_conn IsNot Nothing Then
            initalizeGrid()
        End If
    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs)
        'we need to be sure to release all our connections when the app closes
        Vault.Library.ConnectionManager.CloseAllConnections()
    End Sub

#End Region

#Region "BrowserVaultNavigationModel Events"

    Private Sub m_model_SelectedContentChanged(sender As Object, e As Forms.Currency.SelectionChangedEventArgs)
        'when the selected content changes, we need to update the filename field to reflect the selected entities
        Dim selectedEntities As New List(Of Vault.Currency.Entities.IEntity)(e.SelectedEntities)

        Dim fileSelected As Boolean = False
        Dim selectedEntityNames As New List(Of String)()
        For Each entity As Vault.Currency.Entities.IEntity In selectedEntities
            If TypeOf entity Is Vault.Currency.Entities.FileIteration Then
                fileSelected = True
            End If
            selectedEntityNames.Add(entity.EntityName)
        Next
        fileName_multiPartTextBox.Parts = selectedEntityNames

        ' update availability of commands
        m_openFileToolStripMenuItem.Enabled = fileSelected

        UpdateAssociationsTreeView()
    End Sub

    Private Sub m_model_ParentChanged(sender As Object, e As EventArgs)
        navigateBack_toolStripButton.Enabled = m_model.CanMoveBack
        navigateUp_toolStripButton.Enabled = m_model.CanMoveUp
    End Sub

#End Region

#Region "ToolStripButton Events"

    Private Sub navigateBack_toolStripButton_Click(sender As Object, e As EventArgs)
        m_model.MoveBack()
    End Sub

    Private Sub navigateUp_toolStripButton_Click(sender As Object, e As EventArgs)
        m_model.MoveUp()
    End Sub

    Private Sub switchView_toolStripSplitButton_ButtonClick(sender As Object, e As EventArgs)
        'cycle through the list of available layouts when the switch view button is pressed without using the dropdown
        Dim setIdx As Integer = (m_availableLayouts.IndexOf(vaultBrowserControl1.CurrentLayout) + 1) Mod m_availableLayouts.Count
        vaultBrowserControl1.CurrentLayout = m_availableLayouts(setIdx)
    End Sub

    Private Sub switchView_toolStripSplitButton_DropDownOpening(sender As Object, e As EventArgs)
        'Check the currenly visible view in the menu
        For Each button As ToolStripMenuItem In m_viewButtons
            button.Checked = button.Tag.Equals(vaultBrowserControl1.CurrentLayout)
        Next
    End Sub

#End Region

#Region "MenuItem Events"

    Private Sub login_toolStripMenuItem_Click(sender As Object, e As EventArgs)
        m_conn = Vault.Forms.Library.Login(Nothing)
        controlStates(m_conn IsNot Nothing)
        If m_conn IsNot Nothing Then
            initalizeGrid()
        End If
    End Sub

    Private Sub logout_toolStripMenuItem_Click(sender As Object, e As EventArgs)
        'logout presents the user the option to log in again, so we need to be sure to handle that case
        m_conn = Vault.Forms.Library.Logout(m_conn, Nothing)
        vaultBrowserControl1.SetDataSource(Nothing, Nothing)
        fileName_multiPartTextBox.Parts = New List(Of String)()
        controlStates(m_conn IsNot Nothing)
        If m_conn IsNot Nothing Then
            initalizeGrid()
        End If
    End Sub

    Private Sub m_openFileToolStripMenuItem_Click(sender As Object, e As EventArgs)
        OpenFile()
    End Sub

    Private Sub m_addFileToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim parent As Vault.Currency.Entities.Folder = TryCast(m_model.Parent, Vault.Currency.Entities.Folder)
        If parent IsNot Nothing Then
            Dim openFileDialog As New OpenFileDialog()
            openFileDialog.Multiselect = True

            If openFileDialog.ShowDialog() = DialogResult.OK Then
                Dim filePaths As String() = openFileDialog.FileNames
                For Each filePath As String In filePaths
                    AddFileCommand.Execute(filePath, parent, m_conn)
                Next
                m_model.Reload()
            End If
        End If
    End Sub

    Private Sub m_advancedFindToolStripMenuItem_Click(sender As Object, e As EventArgs)
        AdvancedSearch()
    End Sub

#End Region

    Private Sub switchViewDropdown_itemClick(sender As Object, e As EventArgs)
        'switch to the exact layout that was chosen with the switch view dropdown menu
        Dim item As ToolStripMenuItem = TryCast(sender, ToolStripMenuItem)
        vaultBrowserControl1.CurrentLayout = TryCast(item.Tag, Framework.Forms.Controls.GridLayout)
    End Sub



    Private Sub fileType_comboBox_SelectedIndexChanged(sender As Object, e As EventArgs)
        'when a new filetype filter is selected, we need to update the saved filter function then tell the grid to update
        Dim filter As Forms.Settings.SelectEntitySettings.EntityFilter = TryCast(fileType_comboBox.SelectedItem, Forms.Settings.SelectEntitySettings.EntityFilter)
        m_filterCanDisplayEntity = AddressOf filter.CanDisplayEntity
        vaultBrowserControl1.ReEvaluateCustomFilters()
    End Sub

#End Region

#Region "Implemenation Methods"

    ''' <summary>
    ''' Set the enabled/disabled states of all the controls in the app based on if we have an active connection or not.
    ''' </summary>
    ''' <param name="activeConnection">True if there is an active connection.</param>
    Private Sub controlStates(activeConnection As Boolean)
        login_toolStripMenuItem.Enabled = Not activeConnection
        logout_toolStripMenuItem.Enabled = activeConnection
        vaultNavigationPathComboboxControl1.Enabled = activeConnection
        switchView_toolStripSplitButton.Enabled = activeConnection
        vaultBrowserControl1.Enabled = activeConnection
        fileType_comboBox.Enabled = activeConnection
        m_addFileToolStripMenuItem.Enabled = activeConnection
        m_openFileToolStripMenuItem.Enabled = activeConnection AndAlso m_model IsNot Nothing AndAlso TypeOf m_model.SelectedContent.FirstOrDefault() Is Vault.Currency.Entities.FileIteration
        m_advancedFindToolStripMenuItem.Enabled = activeConnection

        'navigate up and back are normally handled by the model (m_model_ParentChanged), but we need to specifically disable them when we log out
        If activeConnection = False Then
            navigateBack_toolStripButton.Enabled = False
            navigateUp_toolStripButton.Enabled = False
        End If
    End Sub

    ''' <summary>
    ''' Wrapper between the filetype filters and the CanDisplayEntity deleagate on the Vault Browser control.
    ''' </summary>
    ''' <param name="entity">The entity to run the filter against.</param>
    ''' <returns>True if the entity can be displayed.</returns>
    Private Function canDisplayEntity(entity As Vault.Currency.Entities.IEntity) As Boolean
        If m_filterCanDisplayEntity IsNot Nothing Then
            If Not m_filterCanDisplayEntity(entity) Then
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub OpenFile()
        Dim file As Vault.Currency.Entities.FileIteration = TryCast(m_model.SelectedContent.FirstOrDefault(), Vault.Currency.Entities.FileIteration)
        If file IsNot Nothing Then
            OpenFileCommand.Execute(file, m_conn)
        End If
    End Sub

    Private Sub AdvancedSearch()
        Dim finderForm As New FinderForm(m_conn)
        finderForm.Show()
    End Sub

    ''' <summary>
    ''' List all children for a file.
    ''' </summary>
    Private Sub UpdateAssociationsTreeView()
        m_associationsTreeView.Nodes.Clear()

        Dim selectedFile As Vault.Currency.Entities.FileIteration = TryCast(m_model.SelectedContent.FirstOrDefault(), Vault.Currency.Entities.FileIteration)
        If selectedFile Is Nothing Then
            Return
        End If

        Me.m_associationsTreeView.BeginUpdate()

        ' get all parent and child information for the file
        ' parent associations
        ' child associations
        Dim associationArrays As ACW.FileAssocArray() = m_conn.WebServiceManager.DocumentService.GetFileAssociationsByIds(New Long() {selectedFile.EntityIterationId}, ACW.FileAssociationTypeEnum.None, False, ACW.FileAssociationTypeEnum.Dependency, True, False, _
         True)

        If associationArrays IsNot Nothing AndAlso associationArrays.Length > 0 AndAlso associationArrays(0).FileAssocs IsNot Nothing AndAlso associationArrays(0).FileAssocs.Length > 0 Then
            Dim associations As ACW.FileAssoc() = associationArrays(0).FileAssocs
            m_associationsTreeView.ShowLines = True

            ' organize the return values by the parent file
            Dim associationsByFile As New Dictionary(Of Long, List(Of Vault.Currency.Entities.FileIteration))()
            For Each association As ACW.FileAssoc In associations
                Dim parent As ACW.File = association.ParFile
                If associationsByFile.ContainsKey(parent.Id) Then
                    ' parent is already in the hashtable, add an new child entry
                    Dim list As List(Of Vault.Currency.Entities.FileIteration) = associationsByFile(parent.Id)
                    list.Add(New Vault.Currency.Entities.FileIteration(m_conn, association.CldFile))
                Else
                    ' add the parent to the hashtable.
                    Dim list As New List(Of Vault.Currency.Entities.FileIteration)()
                    list.Add(New Vault.Currency.Entities.FileIteration(m_conn, association.CldFile))
                    associationsByFile.Add(parent.Id, list)
                End If
            Next

            ' construct the tree
            If associationsByFile.ContainsKey(selectedFile.EntityIterationId) Then
                Dim rootNode As New TreeNode(selectedFile.EntityName)
                rootNode.Tag = selectedFile
                m_associationsTreeView.Nodes.Add(rootNode)
                AddChildAssociation(rootNode, associationsByFile)
            End If
        Else
            m_associationsTreeView.ShowLines = False
            m_associationsTreeView.Nodes.Add("<< no children >>")
        End If

        m_associationsTreeView.EndUpdate()
    End Sub

    ''' <summary>
    ''' Add tree node for the association tree.
    ''' </summary>
    ''' <param name="parentNode">Node to add to</param>
    Private Sub AddChildAssociation(parentNode As TreeNode, associationsByFile As Dictionary(Of Long, List(Of Vault.Currency.Entities.FileIteration)))
        ' get the File object for the Node
        Dim parentFile As Vault.Currency.Entities.FileIteration = DirectCast(parentNode.Tag, Vault.Currency.Entities.FileIteration)

        ' if associations exist, create a Node for each one
        If associationsByFile.ContainsKey(parentFile.EntityIterationId) Then
            Dim list As List(Of Vault.Currency.Entities.FileIteration) = associationsByFile(parentFile.EntityIterationId)
            For Each childFile As Vault.Currency.Entities.FileIteration In list
                Dim childNode As New TreeNode(childFile.EntityName)
                childNode.Tag = childFile
                parentNode.Nodes.Add(childNode)

                ' add all of the Nodes for the children's children
                AddChildAssociation(childNode, associationsByFile)
            Next
        End If
    End Sub

#End Region
End Class
