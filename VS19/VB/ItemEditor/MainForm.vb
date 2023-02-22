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


Imports System.Drawing
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Linq
Imports System.IO

Imports Autodesk.Connectivity.WebServices
Imports Autodesk.Connectivity.WebServicesTools
Imports VDF = Autodesk.DataManagement.Client.Framework

''' <summary>
''' Summary description for Form1.
''' </summary>
Public Class MainForm
    Inherits System.Windows.Forms.Form

    Private m_dataTable As DataTable

    ''' <summary>
    ''' A mapping between rows in the table and an Item object.
    ''' </summary>
    Private m_tableMap As Dictionary(Of String, Item)

    ''' <summary>
    ''' The selected Item.
    ''' </summary>
    Private m_selectedItem As Item

    ''' <summary>
    ''' A mapping between life cycle definition IDs and life cycle definition objects.
    ''' </summary>
    Private m_lifeCycleMap As Dictionary(Of Long, LfCycDef)

    Private m_connection As VDF.Vault.Currency.Connections.Connection

    Public Sub New(connection As VDF.Vault.Currency.Connections.Connection)
        '
        ' Required for Windows Form Designer support
        '
        InitializeComponent()

        m_connection = connection

        ' set up the grid
        Dim dataSet As New DataSet("itemSet")
        m_dataTable = New DataTable("itemTable")
        m_dataTable.Columns.Add("Item Number")
        m_dataTable.Columns.Add("Revision Number")
        m_dataTable.Columns.Add("Title")
        m_dataTable.Columns.Add("Life Cycle State")
        m_dataTable.Columns.Add("Primary File Link")

        dataSet.Tables.Add(m_dataTable)
        m_itemsGrid.SetDataBinding(dataSet, "ItemTable")
        m_tableMap = New Dictionary(Of String, Item)()
        m_selectedItem = Nothing

        ' get all of the life cycle definitions
        Dim definitions As LfCycDef() = m_connection.WebServiceManager.LifeCycleService.GetAllLifeCycleDefinitions()
        m_lifeCycleMap = New Dictionary(Of Long, LfCycDef)()

        ' put the life cycle definitions into a hashtable for easy lookup
        For Each definition As LfCycDef In definitions
            m_lifeCycleMap(definition.Id) = definition
        Next

        RefreshItemList()
    End Sub

    ''' <summary>
    ''' The main entry point for the application.
    ''' </summary>
    <STAThread()> _
    Public Shared Sub Main()
        Dim settings As New VDF.Vault.Forms.Settings.LoginSettings()
        Dim connection As VDF.Vault.Currency.Connections.Connection = VDF.Vault.Forms.Library.Login(settings)

        If connection Is Nothing Then
            Return
        End If

        Dim mainForm As New MainForm(connection)
        mainForm.ShowDialog()

        VDF.Vault.Library.ConnectionManager.LogOut(connection)
    End Sub

    Private Sub m_createItemButton_Click(sender As Object, e As System.EventArgs) Handles m_createItemButton.Click
        CreateItem()
    End Sub





    Private Sub RefreshItemList()
        m_tableMap.Clear()
        m_dataTable.Clear()
        m_selectedItem = Nothing
        m_gridLabel.Text = "Refreshing Grid"
        m_itemsGrid.Refresh()

        Dim itemSvc As ItemService = m_connection.WebServiceManager.ItemService

        Dim bookmark As String = Nothing
        Dim items As New List(Of Item)()
        Dim status As SrchStatus = Nothing
        While status Is Nothing OrElse status.TotalHits > items.Count
            items.AddRange(itemSvc.FindItemRevisionsBySearchConditions(Nothing, Nothing, True, bookmark, status))
        End While


        If items IsNot Nothing AndAlso items.Count > 0 Then
            For Each item As Item In items
                Dim lifeCycleDef As LfCycDef = m_lifeCycleMap(item.LfCyc.LfCycDefId)
                Dim lifeCycleState As LfCycState = lifeCycleDef.StateArray.FirstOrDefault(Function(lfState As LfCycState) lfState.Id = item.LfCycStateId)

                Dim newRow As DataRow = m_dataTable.NewRow()
                newRow("Item Number") = item.ItemNum
                newRow("Revision Number") = item.RevNum
                newRow("Title") = item.Title
                newRow("Life Cycle State") = lifeCycleState.DispName

                Dim associations As ItemFileAssoc() = itemSvc.GetItemFileAssociationsByItemIds(New Long() {item.Id}, ItemFileLnkTypOpt.Primary)
                If associations IsNot Nothing Then
                    For Each assoc As ItemFileAssoc In associations
                        newRow("Primary File Link") = assoc.FileName
                        Exit For
                    Next
                End If

                m_tableMap(item.ItemNum) = item
                m_dataTable.Rows.Add(newRow)
            Next
        End If



        m_itemsGrid.Refresh()
        m_gridLabel.Text = "Item List"

    End Sub

    Private Sub m_changeRevisionButton_Click(sender As Object, e As System.EventArgs) Handles m_changeRevisionButton.Click
        ChangeRevision()
    End Sub


    Private Sub m_itemsGrid_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles m_itemsGrid.MouseUp
        Dim info As DataGrid.HitTestInfo = m_itemsGrid.HitTest(e.X, e.Y)
        If info IsNot Nothing AndAlso info.Row >= 0 Then
            m_itemsGrid.[Select](info.Row)

            Dim row As DataRow = m_dataTable.Rows(info.Row)
            m_selectedItem = m_tableMap(row("Item Number").ToString())
        End If
    End Sub

    Private Sub m_changeLifeCycleButton_Click(sender As Object, e As System.EventArgs) Handles m_changeLifeCycleButton.Click
        ChangeLifeCycle()
    End Sub



    Private Sub m_rollbackButton_Click(sender As Object, e As System.EventArgs) Handles m_rollbackButton.Click
        RollbackLifeCycle()
    End Sub

    Private Sub ClearItemLock(revisionId As Long)
        Dim itemSvc As ItemService = m_connection.WebServiceManager.ItemService

        Dim editableItem As Item = itemSvc.EditItems(New Long() {revisionId}).First()
        itemSvc.UndoEditItems(New Long() {editableItem.Id})
    End Sub




    Private Sub m_fileLinkButton_Click(sender As Object, e As System.EventArgs) Handles m_fileLinkButton.Click
        LinkToFile()
    End Sub




    Private Sub CreateItem()
        Dim itemSvc As ItemService = m_connection.WebServiceManager.ItemService

        Dim form As New CreateItemForm(m_connection)
        form.ShowDialog()

        If form.DialogResult <> DialogResult.OK Then
            Return
        End If

        Try
            ' create the initial object
            Dim item As Item = itemSvc.AddItemRevision(form.Category.Id)

            ' set the data
            item.Title = form.ItemTitle

            ' commit the item, which finalizes the object
            itemSvc.UpdateAndCommitItems(New Item() {item})
        Catch e As Exception
            ErrorHandler.HandleError(e)
        End Try

        ' MessageBox.Show("Item Created");
        RefreshItemList()
    End Sub

    Private Sub ChangeRevision()
        If m_selectedItem Is Nothing Then
            MessageBox.Show("You must select an Item first")
            Return
        End If

        Dim changeRevisionForm As New ChangeRevisionForm(m_selectedItem, m_connection)
        changeRevisionForm.ShowDialog()

        If changeRevisionForm.DialogResult <> DialogResult.OK Then
            Return
        End If

        Dim newNumber As String = changeRevisionForm.SelectedRevisionNumber

        If newNumber Is Nothing OrElse newNumber.Length = 0 Then
            Return
        End If

        Try
            Dim itemSvc As ItemService = m_connection.WebServiceManager.ItemService

            ' updates and commits the change in a singe call
            itemSvc.UpdateItemRevisionNumbers(New Long() {m_selectedItem.Id}, New String() {newNumber}, "")
        Catch e As Exception
            ErrorHandler.HandleError(e)
        End Try

        RefreshItemList()
    End Sub

    Private Sub ChangeLifeCycle()
        If m_selectedItem Is Nothing Then
            MessageBox.Show("You must select an Item first")
            Return
        End If

        Dim changeLifeCycleForm As New ChangeLifeCycleForm(m_selectedItem.LfCyc.LfCycDefId, m_selectedItem.LfCycStateId, m_connection)

        changeLifeCycleForm.ShowDialog()
        If changeLifeCycleForm.DialogResult <> DialogResult.OK Then
            Return
        End If

        Try
            Dim itemSvc As ItemService = m_connection.WebServiceManager.ItemService

            ' updates the life cycle state - but the change is still uncommitted
            Dim updatedItems As Item() = itemSvc.UpdateItemLifeCycleStates(New Long() {m_selectedItem.MasterId}, New Long() {changeLifeCycleForm.SelectedLifeCycleStateId}, Nothing)

        Catch e As Exception
            ErrorHandler.HandleError(e)
        End Try

        RefreshItemList()
    End Sub

    Private Sub RollbackLifeCycle()
        If m_selectedItem Is Nothing Then
            MessageBox.Show("You must select an Item first")
            Return
        End If

        Try
            Dim itemSvc As ItemService = m_connection.WebServiceManager.ItemService

            ' begin the rollback
            Dim targetItem As Item = itemSvc.GetLifecycleRollbackTargetItem(m_selectedItem.MasterId)
            itemSvc.ItemRollbackLifeCycleState(targetItem.Id)
        Catch e As Exception
            ErrorHandler.HandleError(e)
        End Try

        MessageBox.Show("Rollback completed")

        RefreshItemList()
    End Sub

    Private Sub LinkToFile()
        If m_selectedItem Is Nothing Then
            MessageBox.Show("You must select an Item first")
            Return
        End If

        Try
            Dim settings As New VDF.Vault.Forms.Settings.SelectEntitySettings()
            settings.MultipleSelect = False
            settings.ActionableEntityClassIds.Add(VDF.Vault.Currency.Entities.EntityClassIds.Files)
            settings.ConfigureActionButtons("Select", Nothing, Nothing, False)
            Dim results As VDF.Vault.Forms.Results.SelectEntityResults = VDF.Vault.Forms.Library.SelectEntity(m_connection, settings)

            If results Is Nothing OrElse results.SelectedEntities Is Nothing OrElse Not results.SelectedEntities.Any() Then
                Return
            End If

            Dim file As VDF.Vault.Currency.Entities.FileIteration = TryCast(results.SelectedEntities.First(), VDF.Vault.Currency.Entities.FileIteration)
            If file Is Nothing Then
                MessageBox.Show("You must select a file")
                Return
            End If

            Dim itemSvc As ItemService = m_connection.WebServiceManager.ItemService

            ' first assign the file to a new item
            itemSvc.AddFilesToPromote(New Long() {file.EntityIterationId}, ItemAssignAll.Default, True)
            Dim timestamp As DateTime
            Dim getPromoteComponentOrderResults As GetPromoteOrderResults = itemSvc.GetPromoteComponentOrder(timestamp)
            If Not getPromoteComponentOrderResults.PrimaryArray Is Nothing AndAlso getPromoteComponentOrderResults.PrimaryArray.Any() Then
                itemSvc.PromoteComponents(timestamp, getPromoteComponentOrderResults.PrimaryArray)
            End If
            If Not getPromoteComponentOrderResults.NonPrimaryArray Is Nothing AndAlso getPromoteComponentOrderResults.NonPrimaryArray.Any() Then
                itemSvc.PromoteComponentLinks(getPromoteComponentOrderResults.NonPrimaryArray)
            End If

            Dim promoteResult As ItemsAndFiles = itemSvc.GetPromoteComponentsResults(timestamp)

            ' find out which item corresponds to the file
            Dim itemId As Long = -1
            For Each assoc As ItemFileAssoc In promoteResult.FileAssocArray
                If assoc.CldFileId = file.EntityIterationId Then
                    itemId = assoc.ParItemId
                End If
            Next

            If itemId < 0 Then
                MessageBox.Show("Promote error")
            Else
                ' next reassign the file from the new item to the existing item
                Dim updatedItems As Item() = itemSvc.ReassignComponentsToDifferentItems(New Long() {itemId}, New Long() {m_selectedItem.Id})

                ' commit the changes
                itemSvc.UpdateAndCommitItems(updatedItems)
            End If

            ' clear out the items from the initial Promote
            Dim itemIds As Long() = New Long(promoteResult.ItemRevArray.Length - 1) {}
            Dim itemMasterIds As Long() = New Long(promoteResult.ItemRevArray.Length - 1) {}

            For i As Integer = 0 To promoteResult.ItemRevArray.Length - 1
                itemIds(i) = promoteResult.ItemRevArray(i).Id
                itemMasterIds(i) = promoteResult.ItemRevArray(i).MasterId
            Next

            itemSvc.DeleteUnusedItemNumbers(itemMasterIds)
            itemSvc.UndoEditItems(itemIds)
        Catch e As Exception
            ErrorHandler.HandleError(e)
        End Try

        RefreshItemList()
    End Sub

    Private Sub m_exportButton_Click(sender As Object, e As EventArgs) Handles m_exportButton.Click
        Export()
    End Sub

    Private Sub Export()
        If m_selectedItem Is Nothing Then
            MessageBox.Show("You must select an Item first")
            Return
        End If

        Dim dialog As New SaveFileDialog()
        dialog.Filter = "CSV Files|*.csv"
        Dim result As DialogResult = dialog.ShowDialog()
        If result <> DialogResult.OK Then
            Return
        End If

        Dim filename As String = dialog.FileName

        Dim packageSvc As PackageService = m_connection.WebServiceManager.PackageService

        ' export to CSV file
        Dim pkgBom As PkgItemsAndBOM = packageSvc.GetLatestPackageDataByItemIds(New Long() {m_selectedItem.Id}, BOMTyp.Latest)

        ' Create a mapping between Item properties and columns in the CSV file
        Dim levelPair As New MapPair()
        levelPair.ToName = "Level"
        levelPair.FromName = "BOMIndicator-41FF056B-8EEF-47E2-8F9E-490BC0C52C71"

        Dim numberPair As New MapPair()
        numberPair.ToName = "Number"
        numberPair.FromName = "Number"

        Dim typePair As New MapPair()
        typePair.ToName = "Type"
        typePair.FromName = "ItemClass"

        ' NOTE: not everything is being exported in this example.  So if this file is imported,
        ' omitted data, such as lifecycle state, may not be the same.

        Dim fileNameAndURL As FileNameAndURL = packageSvc.ExportToPackage(pkgBom, FileFormat.CSV_LEVEL, New MapPair() {levelPair, numberPair, typePair})

        Dim currentByte As Long = 0
        Dim partSize As Long = m_connection.PartSizeInBytes
        Using fs As New FileStream(filename, FileMode.Create)
            While currentByte < fileNameAndURL.FileSize
                Dim lastByte As Long = If(currentByte + partSize < fileNameAndURL.FileSize, currentByte + partSize, fileNameAndURL.FileSize)
                Dim contents As Byte() = packageSvc.DownloadPackagePart(fileNameAndURL.Name, currentByte, lastByte)
                fs.Write(contents, 0, lastByte - currentByte)
                currentByte += partSize
            End While
        End Using

        MessageBox.Show("Export completed")
    End Sub

    Private Sub m_importButton_Click(sender As Object, e As EventArgs) Handles m_importButton.Click
        Import()
    End Sub


    Private Sub Import()
        Dim dialog As New OpenFileDialog()
        dialog.Filter = "CSV Files|*.csv"
        Dim result As DialogResult = dialog.ShowDialog()
        If result <> DialogResult.OK Then
            Return
        End If

        Dim filename As String = dialog.FileName

        Dim packageSvc As PackageService = m_connection.WebServiceManager.PackageService

        ' Create a mapping between the CVS columns and the item properties.
        ' NOTE: It is assumed the we are importing a file created by the
        ' export command in this sample.  Otherwise we can't assume the
        ' columns being used.
        Dim info As New Map()

        'map the first column to level
        Dim levelPair As New MapPair()
        levelPair.FromName = "Level"
        levelPair.ToName = "BOMIndicator-41FF056B-8EEF-47E2-8F9E-490BC0C52C71"

        'map the second column to number
        Dim numberPair As New MapPair()
        numberPair.FromName = "Number"
        numberPair.ToName = "Number"

        'map the third column to type
        Dim typePair As New MapPair()
        typePair.FromName = "Type"
        typePair.ToName = "ItemClass"

        info.PairArray = New MapPair() {levelPair, numberPair, typePair}

        Dim filenameAndURL As FileNameAndURL = Nothing
        Using fs As FileStream = New FileStream(filename, FileMode.Open, FileAccess.Read)
            Dim partSize As Long = m_connection.PartSizeInBytes
            Dim contents As Byte() = New Byte(partSize) {}
            Dim bytesRead As Integer
            While True
                bytesRead = fs.Read(contents, 0, partSize)
                If bytesRead <= 0 Then
                    Exit While
                End If

                Dim packageName As String = Nothing
                If filenameAndURL IsNot Nothing Then
                    packageName = filenameAndURL.Name
                End If
                filenameAndURL = packageSvc.UploadPackagePart(packageName, ".csv", If(bytesRead = partSize, contents, contents.Take(bytesRead).ToArray()))
            End While
        End Using

        Dim createResult As PkgItemsAndBOM = packageSvc.ImportFromPackage(FileFormat.CSV_LEVEL, info, filenameAndURL.Name)

        For Each item As PkgItem In createResult.PkgItemArray
            ' to keep things simple, this sample only handles cases where we are 
            ' importing new items.  It does not handle complex cases like when an item needs updating.
            If item.Resolution IsNot Nothing AndAlso item.Resolution.ResolutionMethod <> ResolutionMethod.Create Then
                MessageBox.Show("There are conflicts in the import.  This function can only be used for creating new Items.")
                Return
            End If
        Next

        packageSvc.CommitImportedData(createResult)

        MessageBox.Show("Import completed")
        RefreshItemList()
    End Sub
End Class