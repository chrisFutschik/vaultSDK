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
Imports System.Reflection

Imports Autodesk.Connectivity.Extensibility.Framework
Imports Autodesk.Connectivity.Explorer.Extensibility
Imports Autodesk.Connectivity.WebServices
Imports Autodesk.Connectivity.WebServicesTools

<Assembly: AssemblyCompany("Autodesk")> 
<Assembly: AssemblyProduct("JobProcessorApiSamples")> 
<Assembly: AssemblyDescription("A sample that queues and handles a job")> 
<Assembly: ApiVersion("16.0")> 
<Assembly: ExtensionId("50A18DD5-892A-477e-911E-1D6E3C647036")> 

Namespace JobProcessorApiSamples
    Public Class QueuePublishJobCommandExtension
        Implements IExplorerExtension

        Public Sub QueuePublishJobCommandHandler(s As Object, e As CommandItemEventArgs)
            ' Queue a ShareDwf job
            '
            Const PublishJobTypeName As String = "MyCompany.File.Publish"
            Const PublishJob_FileMasterId As String = "FileMasterId"
            Const PublishJob_FileName As String = "FileName"

            For Each vaultObj As ISelection In e.Context.CurrentSelectionSet
                Dim paramList As JobParam() = New JobParam(1) {}
                Dim masterIdParam As New JobParam()
                masterIdParam.Name = PublishJob_FileMasterId
                masterIdParam.Val = vaultObj.Id.ToString()
                paramList(0) = masterIdParam

                Dim fileNameParam As New JobParam()
                fileNameParam.Name = PublishJob_FileName
                fileNameParam.Val = vaultObj.Label
                paramList(1) = fileNameParam

                ' Add the job to the queue
                '
                e.Context.Application.Connection.WebServiceManager.JobService.AddJob( _
                    PublishJobTypeName, _
                    [String].Format("Publish File - {0}", fileNameParam.Val), _
                    paramList, 10)
            Next
        End Sub

        Public Function ResourceCollectionName() As String
            Return [String].Empty
        End Function

        Public Sub OnStartup(application As IApplication) Implements IExplorerExtension.OnStartup
            ' NoOp;
        End Sub

        Public Function CommandSites() As IEnumerable(Of CommandSite) Implements IExplorerExtension.CommandSites
            Dim sites As New List(Of CommandSite)()

            ' Describe user history command item
            '
            Dim queuePublishJobCmdItem As New CommandItem("Command.QueuePublishJob", "Queue Publish Job")
            queuePublishJobCmdItem.NavigationTypes = New SelectionTypeId() {SelectionTypeId.File}
            queuePublishJobCmdItem.MultiSelectEnabled = False
            AddHandler queuePublishJobCmdItem.Execute, AddressOf QueuePublishJobCommandHandler

            ' deploy user history command on file context menu
            '
            Dim queuePublishContextMenu As New CommandSite("Menu.FileContextMenu", "Queue Publish Job")
            queuePublishContextMenu.Location = CommandSiteLocation.FileContextMenu
            queuePublishContextMenu.DeployAsPulldownMenu = False
            queuePublishContextMenu.AddCommand(queuePublishJobCmdItem)
            sites.Add(queuePublishContextMenu)

            Return sites
        End Function


        Public Function DetailTabs() As IEnumerable(Of DetailPaneTab) Implements IExplorerExtension.DetailTabs
            Return Nothing
        End Function

        Public Sub OnLogOn(application As IApplication) Implements IExplorerExtension.OnLogOn
            
        End Sub

        Public Sub OnLogOff(application As IApplication) Implements IExplorerExtension.OnLogOff
        End Sub

        Public Sub OnShutdown(application As IApplication) Implements IExplorerExtension.OnShutdown
            ' NoOp;
        End Sub

#Region "IExtension Members"


        Public Function HiddenCommands() As IEnumerable(Of String) Implements IExplorerExtension.HiddenCommands
            Return Nothing
        End Function

#End Region


        Public Function CustomEntityHandlers() As IEnumerable(Of CustomEntityHandler) Implements IExplorerExtension.CustomEntityHandlers
            Return Nothing
        End Function
    End Class
End Namespace
