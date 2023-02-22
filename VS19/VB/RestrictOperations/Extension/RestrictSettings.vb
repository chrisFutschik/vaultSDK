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
Imports System.IO
Imports System.Text
Imports System.Reflection
Imports System.Xml.Serialization

<XmlRoot()> _
Public Class RestrictSettings
    Public RestrictedOperations As List(Of String)

    Public Sub New()
        RestrictedOperations = New List(Of String)()
    End Sub

    ' figure out the path to this extension
    Private Shared Function GetSettingsPath() As String
        Dim directoryPath As String = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
        Return Path.Combine(directoryPath, "RestrictSettings.xml")
    End Function

    Public Shared Function Load() As RestrictSettings
        Dim retVal As RestrictSettings = Nothing
        Try
            Using reader As New System.IO.StreamReader(GetSettingsPath())
                Dim serializer As New XmlSerializer(GetType(RestrictSettings))
                retVal = DirectCast(serializer.Deserialize(reader), RestrictSettings)
            End Using
        Catch
        End Try

        ' if we run into an error, just return a blank settings
        If retVal Is Nothing Then
            retVal = New RestrictSettings()
        End If

        Return retVal
    End Function

    Public Sub Save()
        Try
            Using writer As New FileStream(GetSettingsPath(), FileMode.Create)
                Dim serializer As New XmlSerializer(GetType(RestrictSettings))
                serializer.Serialize(writer, Me)
            End Using
        Catch
        End Try
    End Sub
End Class