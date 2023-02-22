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


Imports System.Linq
Imports System.IO

Imports ACJE = Autodesk.Connectivity.JobProcessor.Extensibility
Imports ACW = Autodesk.Connectivity.WebServices
Imports ACWT = Autodesk.Connectivity.WebServicesTools
Imports VDF = Autodesk.DataManagement.Client.Framework

Namespace JobProcessorApiSamples
    Public Class FolderPublishJobHandler
        Implements ACJE.IJobHandler
        Private Property TargetFolder() As String
            Get
                Return m_TargetFolder
            End Get
            Set(value As String)
                m_TargetFolder = Value
            End Set
        End Property
        Private m_TargetFolder As String


        Public Sub New()
            TargetFolder = "C:\PublishFolder\"
        End Sub

#Region "IJobHandler Members"

        Public Function CanProcess(jobType As String) As Boolean Implements ACJE.IJobHandler.CanProcess
            If jobType.ToLower().Equals("MyCompany.File.Publish".ToLower()) Then
                Return True
            End If

            Return False
        End Function

        Public Function Execute(context As ACJE.IJobProcessorServices, job As ACJE.IJob) As ACJE.JobOutcome Implements ACJE.IJobHandler.Execute
            Dim fileMasterId As Long = Convert.ToInt64(job.Params("FileMasterId"))

            Try
                
                ' Retrieve the file object from the server
                '
                Dim file As ACW.File = context.Connection.WebServiceManager.DocumentService.GetLatestFileByMasterId(fileMasterId)
                Dim fileIter As VDF.Vault.Currency.Entities.FileIteration  = _
                    context.Connection.FileManager.GetFilesByIterationIds(new long(){ file.Id }).First().Value

                ' Download and publish the file
                '
                Publish(fileIter, context.Connection)
                

                Return ACJE.JobOutcome.Success
            Catch
                Return ACJE.JobOutcome.Failure
            End Try
        End Function

        Public Sub OnJobProcessorStartup(context As ACJE.IJobProcessorServices) Implements ACJE.IJobHandler.OnJobProcessorStartup
        End Sub

        Public Sub OnJobProcessorShutdown(context As ACJE.IJobProcessorServices) Implements ACJE.IJobHandler.OnJobProcessorShutdown
        End Sub

        Public Sub OnJobProcessorWake(context As ACJE.IJobProcessorServices) Implements ACJE.IJobHandler.OnJobProcessorWake
        End Sub

        Public Sub OnJobProcessorSleep(context As ACJE.IJobProcessorServices) Implements ACJE.IJobHandler.OnJobProcessorSleep
        End Sub

#End Region


        Private Sub Publish(fileIter As VDF.Vault.Currency.Entities.FileIteration, connection As VDF.Vault.Currency.Connections.Connection)
            Dim targetDir As System.IO.DirectoryInfo = new System.IO.DirectoryInfo(TargetFolder)
            if Not targetDir.Exists then
                targetDir.Create()
            End If

            Dim downloadSettings As VDF.Vault.Settings.AcquireFilesSettings = new VDF.Vault.Settings.AcquireFilesSettings(connection)
            downloadSettings.LocalPath = new VDF.Currency.FolderPathAbsolute(targetDir.FullName)

            downloadSettings.AddFileToAcquire(fileIter, VDF.Vault.Settings.AcquireFilesSettings.AcquisitionOption.Download)
            connection.FileManager.AcquireFiles(downloadSettings)
        End Sub

        
    End Class
End Namespace

