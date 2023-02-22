'=====================================================================

'  This file is part of the Autodesk Vault API Code Samples.

'  Copyright (C) Autodesk Inc.  All rights reserved.

'THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'=====================================================================

Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Linq

Imports Autodesk.Connectivity.WebServices
Imports Autodesk.Connectivity.WebServicesTools
Imports VDF = Autodesk.DataManagement.Client.Framework

''' <summary>
''' This is our main form.
''' </summary>
Public Class Form1
    Inherits System.Windows.Forms.Form
    

    Public Sub New()
        '
        ' Required for Windows Form Designer support
        '
        InitializeComponent()

    End Sub

    ''' <summary>
    ''' The main entry point for the application.
    ''' </summary>
    <STAThread()> _
    Private Shared Sub Main()
        Dim appobject As New Form1()

        Application.Run(appobject)
    End Sub

    Private Sub button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button1.Click
        ListAllFiles()
    End Sub

    ''' <summary>
    ''' This function lists all the files in the Vault and displays them in the form's ListBox.
    ''' </summary>
    Public Sub ListAllFiles()
        ' For demonstration purposes, the information is hard-coded.
        Dim results As VDF.Vault.Results.LogInResult = VDF.Vault.Library.ConnectionManager.LogIn("localhost", "Vault", "Administrator", "", VDF.Vault.Currency.Connections.AuthenticationFlags.Standard, Nothing)

        If Not results.Success Then
            Return
        End If

        Dim connection As VDF.Vault.Currency.Connections.Connection = results.Connection

        Try
            ' Start at the root Folder.
            Dim root As VDF.Vault.Currency.Entities.Folder = connection.FolderManager.RootFolder

            Me.m_listBox.Items.Clear()

            ' Call a function which prints all files in a Folder and sub-Folders.
            PrintFilesInFolder(root, connection)
        Catch ex As Exception
            MessageBox.Show(ex.ToString(), "Error")
            Return
        End Try

        VDF.Vault.Library.ConnectionManager.LogOut(connection)
    End Sub


    ''' <summary>
    ''' Prints all the files in the current Folder and any sub Folders.
    ''' </summary>
    ''' <param name="parentFolder">The folder we want to print.</param>
    ''' <param name="connection">The manager object for making Vault Server calls.</param>
    Private Sub PrintFilesInFolder(parentFolder As VDF.Vault.Currency.Entities.Folder, connection As VDF.Vault.Currency.Connections.Connection)
        ' get all the Files in the current Folder.
        Dim childFiles As File() = connection.WebServiceManager.DocumentService.GetLatestFilesByFolderId(parentFolder.Id, False)

        ' print out any Files we find.
        If childFiles IsNot Nothing AndAlso childFiles.Any() Then
            For Each file As File In childFiles
                ' print the full path, which is Folder name + File name.
                Me.m_listBox.Items.Add((Convert.ToString(parentFolder.FullName) & "/") + file.Name)
            Next
        End If

        ' check for any sub Folders.
        Dim folders As IEnumerable(Of VDF.Vault.Currency.Entities.Folder) = connection.FolderManager.GetChildFolders(parentFolder, False, False)
        If folders IsNot Nothing AndAlso folders.Any() Then
            For Each folder As VDF.Vault.Currency.Entities.Folder In folders
                ' recursively print the files in each sub-Folder
                PrintFilesInFolder(folder, connection)
            Next
        End If
    End Sub

End Class
