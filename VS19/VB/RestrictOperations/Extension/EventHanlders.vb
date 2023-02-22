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
Imports System.Linq
Imports System.Text

Imports Autodesk.Connectivity.Extensibility.Framework
Imports Autodesk.Connectivity.WebServices

<Assembly: ApiVersion("16.0")> 
<Assembly: ExtensionId("7D12A22D-F4D9-4436-B2CA-CE7FB710EC71")> 

Namespace RestrictOperations
    Public Class EventHandlers
        Implements IWebServiceExtension

#Region "IWebServiceExtension Members"

        Public Sub OnLoad() Implements IWebServiceExtension.OnLoad
            ' register for events here
            ' in this case, we want to register for the GetRestrictions event for all operations

            ' File Events
            AddHandler DocumentService.AddFileEvents.GetRestrictions, AddressOf AddFileEvents_GetRestrictions
            AddHandler DocumentService.CheckinFileEvents.GetRestrictions, AddressOf CheckinFileEvents_GetRestrictions
            AddHandler DocumentService.CheckoutFileEvents.GetRestrictions, AddressOf CheckoutFileEvents_GetRestrictions
            AddHandler DocumentService.DeleteFileEvents.GetRestrictions, AddressOf DeleteFileEvents_GetRestrictions
            AddHandler DocumentService.DownloadFileEvents.GetRestrictions, AddressOf DownloadFileEvents_GetRestrictions
            AddHandler DocumentServiceExtensions.UpdateFileLifecycleStateEvents.GetRestrictions, AddressOf UpdateFileLifecycleStateEvents_GetRestrictions

            ' Folder Events
            AddHandler DocumentService.AddFolderEvents.GetRestrictions, AddressOf AddFolderEvents_GetRestrictions
            AddHandler DocumentService.DeleteFolderEvents.GetRestrictions, AddressOf DeleteFolderEvents_GetRestrictions

            ' Item Events
            AddHandler ItemService.AddItemEvents.GetRestrictions, AddressOf AddItemEvents_GetRestrictions
            AddHandler ItemService.CommitItemEvents.GetRestrictions, AddressOf CommitItemEvents_GetRestrictions
            AddHandler ItemService.ItemRollbackLifeCycleStatesEvents.GetRestrictions, AddressOf ItemRollbackLifeCycleStatesEvents_GetRestrictions
            AddHandler ItemService.DeleteItemEvents.GetRestrictions, AddressOf DeleteItemEvents_GetRestrictions
            AddHandler ItemService.EditItemEvents.GetRestrictions, AddressOf EditItemEvents_GetRestrictions
            AddHandler ItemService.PromoteItemEvents.GetRestrictions, AddressOf PromoteItemEvents_GetRestrictions
            AddHandler ItemService.UpdateItemLifecycleStateEvents.GetRestrictions, AddressOf UpdateItemLifecycleStateEvents_GetRestrictions

            ' Change Order Events
            AddHandler ChangeOrderService.AddChangeOrderEvents.GetRestrictions, AddressOf AddChangeOrderEvents_GetRestrictions
            AddHandler ChangeOrderService.CommitChangeOrderEvents.GetRestrictions, AddressOf CommitChangeOrderEvents_GetRestrictions
            AddHandler ChangeOrderService.DeleteChangeOrderEvents.GetRestrictions, AddressOf DeleteChangeOrderEvents_GetRestrictions
            AddHandler ChangeOrderService.EditChangeOrderEvents.GetRestrictions, AddressOf EditChangeOrderEvents_GetRestrictions
            AddHandler ChangeOrderService.UpdateChangeOrderLifecycleStateEvents.GetRestrictions, AddressOf UpdateChangeOrderLifecycleStateEvents_GetRestrictions

            ' Custom Entity Events
            AddHandler CustomEntityService.UpdateCustomEntityLifecycleStateEvents.GetRestrictions, AddressOf UpdateCustomEntityLifecycleStateEvents_GetRestrictions


        End Sub
#End Region

        ''' <summary>
        ''' Check the settings file and restrict the operation if needed.
        ''' </summary>
        Private Sub RestrictOperation(ByVal eventArgs As WebServiceCommandEventArgs, ByVal eventName As String)
            Dim settings As RestrictSettings = RestrictSettings.Load()
            If settings.RestrictedOperations.Contains(eventName) Then
                eventArgs.AddRestriction(New ExtensionRestriction("Unknown", "Test restriction"))
            End If
        End Sub

        Private Sub UpdateChangeOrderLifecycleStateEvents_GetRestrictions(ByVal sender As Object, ByVal e As UpdateChangeOrderLifeCycleStateCommandEventArgs)
            RestrictOperation(e, "UpdateChangeOrderLifecycleState")
        End Sub

        Private Sub EditChangeOrderEvents_GetRestrictions(ByVal sender As Object, ByVal e As EditChangeOrderCommandEventArgs)
            RestrictOperation(e, "EditChangeOrder")
        End Sub

        Private Sub DeleteChangeOrderEvents_GetRestrictions(ByVal sender As Object, ByVal e As DeleteChangeOrderCommandEventArgs)
            RestrictOperation(e, "DeleteChangeOrder")
        End Sub

        Private Sub CommitChangeOrderEvents_GetRestrictions(ByVal sender As Object, ByVal e As CommitChangeOrderCommandEventArgs)
            RestrictOperation(e, "CommitChangeOrder")
        End Sub

        Private Sub AddChangeOrderEvents_GetRestrictions(ByVal sender As Object, ByVal e As AddChangeOrderCommandEventArgs)
            RestrictOperation(e, "AddChangeOrder")
        End Sub

        Private Sub UpdateItemLifecycleStateEvents_GetRestrictions(ByVal sender As Object, ByVal e As UpdateItemLifeCycleStateCommandEventArgs)
            RestrictOperation(e, "UpdateItemLifecycleState")
        End Sub

        Private Sub PromoteItemEvents_GetRestrictions(ByVal sender As Object, ByVal e As PromoteItemCommandEventArgs)
            RestrictOperation(e, "PromoteItem")
        End Sub

        Private Sub EditItemEvents_GetRestrictions(ByVal sender As Object, ByVal e As EditItemCommandEventArgs)
            RestrictOperation(e, "EditItem")
        End Sub

        Private Sub DeleteItemEvents_GetRestrictions(ByVal sender As Object, ByVal e As DeleteItemCommandEventArgs)
            RestrictOperation(e, "DeleteItem")
        End Sub

        Private Sub ItemRollbackLifeCycleStatesEvents_GetRestrictions(ByVal sender As Object, ByVal e As ItemRollbackLifeCycleStateCommandEventArgs)
            RestrictOperation(e, "ItemRollbackLifeCycleStates")
        End Sub

        Private Sub CommitItemEvents_GetRestrictions(ByVal sender As Object, ByVal e As CommitItemCommandEventArgs)
            RestrictOperation(e, "CommitItem")
        End Sub

        Private Sub AddItemEvents_GetRestrictions(ByVal sender As Object, ByVal e As AddItemCommandEventArgs)
            RestrictOperation(e, "AddItem")
        End Sub

        Private Sub UpdateFileLifecycleStateEvents_GetRestrictions(ByVal sender As Object, ByVal e As UpdateFileLifeCycleStateCommandEventArgs)
            RestrictOperation(e, "UpdateFileLifecycleState")
        End Sub

        Private Sub DownloadFileEvents_GetRestrictions(ByVal sender As Object, ByVal e As DownloadFileCommandEventArgs)
            RestrictOperation(e, "DownloadFile")
        End Sub

        Private Sub DeleteFolderEvents_GetRestrictions(ByVal sender As Object, ByVal e As DeleteFolderCommandEventArgs)
            RestrictOperation(e, "DeleteFolder")
        End Sub

        Private Sub DeleteFileEvents_GetRestrictions(ByVal sender As Object, ByVal e As DeleteFileCommandEventArgs)
            RestrictOperation(e, "DeleteFile")
        End Sub

        Private Sub CheckoutFileEvents_GetRestrictions(ByVal sender As Object, ByVal e As CheckoutFileCommandEventArgs)
            RestrictOperation(e, "CheckoutFile")
        End Sub

        Private Sub CheckinFileEvents_GetRestrictions(ByVal sender As Object, ByVal e As CheckinFileCommandEventArgs)
            RestrictOperation(e, "CheckinFile")
        End Sub

        Private Sub AddFolderEvents_GetRestrictions(ByVal sender As Object, ByVal e As AddFolderCommandEventArgs)
            RestrictOperation(e, "AddFolder")
        End Sub

        Private Sub AddFileEvents_GetRestrictions(ByVal sender As Object, ByVal e As AddFileCommandEventArgs)
            RestrictOperation(e, "AddFile")
        End Sub

        Private Sub UpdateCustomEntityLifecycleStateEvents_GetRestrictions(ByVal sender As Object, ByVal e As UpdateCustomEntityLifeCycleStateCommandEventArgs)
            RestrictOperation(e, "UpdateCustomEntityLifecycleState")
        End Sub

    End Class
End Namespace
