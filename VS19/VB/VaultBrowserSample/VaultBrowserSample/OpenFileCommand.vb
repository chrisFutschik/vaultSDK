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
Imports System.Diagnostics
Imports System.IO
Imports System.Windows.Forms

Imports ACW = Autodesk.Connectivity.WebServices
Imports ACWT = Autodesk.Connectivity.WebServicesTools
Imports VDF = Autodesk.DataManagement.Client.Framework

Class OpenFileCommand
    Private Shared m_downloadedFiles As New List(Of String)()

    ''' <summary>
    ''' Downloads a file from Vault and opens it.  The program used to load the file is 
    ''' based on the user's OS settings.
    ''' </summary>
    ''' <param name="fileId"></param>
    Public Shared Sub Execute(file As VDF.Vault.Currency.Entities.FileIteration, connection As VDF.Vault.Currency.Connections.Connection)
        Dim filePath As String = Path.Combine(Application.LocalUserAppDataPath, file.EntityName)

        'determine if the file already exists
        If System.IO.File.Exists(filePath) Then
            'we'll try to delete the file so we can get the latest copy
            Try
                System.IO.File.Delete(filePath)

                'remove the file from the collection of downloaded files that need to be removed when the application exits
                If m_downloadedFiles.Contains(filePath) Then
                    m_downloadedFiles.Remove(filePath)
                End If
            Catch generatedExceptionName As System.IO.IOException
                Throw New Exception("The file you are attempting to open already exists and can not be overwritten. This file may currently be open, try closing any application you are using to view this file and try opening the file again.")
            End Try
        End If

        downloadFile(connection, file, Path.GetDirectoryName(filePath))
        m_downloadedFiles.Add(filePath)

        'Create a new ProcessStartInfo structure.
        Dim pInfo As New ProcessStartInfo()
        'Set the file name member. 
        pInfo.FileName = filePath
        'UseShellExecute is true by default. It is set here for illustration.
        pInfo.UseShellExecute = True
        Dim p As Process = Process.Start(pInfo)
    End Sub

    Private Shared Sub downloadFile(connection As VDF.Vault.Currency.Connections.Connection, file As VDF.Vault.Currency.Entities.FileIteration, folderPath As String)
        Dim settings As New VDF.Vault.Settings.AcquireFilesSettings(connection)
        settings.AddEntityToAcquire(file)
        settings.LocalPath = New VDF.Currency.FolderPathAbsolute(folderPath)
        connection.FileManager.AcquireFiles(settings)
    End Sub

    ''' <summary>
    ''' This should be called when the application exits
    ''' </summary>
    Public Shared Sub OnExit()
        ' try and clean up any files which were downloaded
        For Each file As String In m_downloadedFiles
            Try
                System.IO.File.Delete(file)
            Catch generatedExceptionName As Exception
            End Try
        Next
    End Sub
End Class
