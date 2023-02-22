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
Imports System.IO
Imports System.Text

Imports ACW = Autodesk.Connectivity.WebServices
Imports ACWT = Autodesk.Connectivity.WebServicesTools
Imports VDF = Autodesk.DataManagement.Client.Framework

Class AddFileCommand
    ''' <summary>
    ''' Upload a file to Vault
    ''' </summary>
    ''' <param name="filePath">The full path to a local file.</param>
    ''' <param name="folderId">The ID of the Vault folder where the file will be uploaded.</param>
    Public Shared Sub Execute(filePath As String, parent As VDF.Vault.Currency.Entities.Folder, connection As VDF.Vault.Currency.Connections.Connection)
        Using stream As New FileStream(filePath, FileMode.Open, FileAccess.Read)
            connection.FileManager.AddFile(parent, Path.GetFileName(filePath), "Added by Vault Browser", DateTime.Now, Nothing, Nothing, _
             ACW.FileClassification.None, False, stream)
        End Using
    End Sub
End Class
