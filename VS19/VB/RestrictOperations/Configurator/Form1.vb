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

Imports RestrictOperations

Partial Public Class Form1
    Inherits Form
    ' File commands

    ' Folder Events

    ' Item Events

    ' Change Order Events
    Private m_commands As New List(Of String)() From { _
     "AddFile", _
     "CheckinFile", _
     "CheckoutFile", _
     "DeleteFile", _
     "DownloadFile", _
     "UpdateFileLifecycleState", _
     "AddFolder", _
     "DeleteFolder", _
     "AddItem", _
     "CommitItem", _
     "ItemRollbackLifeCycleStates", _
     "DeleteItem", _
     "EditItem", _
     "PromoteItem", _
     "UpdateItemLifecycleState", _
     "AddChangeOrder", _
     "CommitChangeOrder", _
     "DeleteChangeOrder", _
     "EditChangeOrder", _
     "UpdateChangeOrderLifecycleState", _
     "UpdateCustomEntityLifecycleState" _
    }

    Public Sub New()
        InitializeComponent()


        m_tableLayoutPanel.ColumnCount = 1
        m_tableLayoutPanel.RowCount = 0

        Dim settings As RestrictSettings = RestrictSettings.Load()
        For Each command As String In m_commands
            Dim checkbox As New CheckBox()
            checkbox.Text = command & " Command"
            checkbox.Tag = command
            checkbox.Height = 20
            checkbox.AutoSize = True

            If settings.RestrictedOperations.Contains(command) Then
                checkbox.Checked = True
            Else
                checkbox.Checked = False
            End If

            AddHandler checkbox.CheckedChanged, New EventHandler(AddressOf checkbox_CheckedChanged)


            m_tableLayoutPanel.Controls.Add(checkbox)
        Next
    End Sub

    Private Sub checkbox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        ' do a complete update of the settings file

        Dim settings As New RestrictSettings()
        For Each c As Control In m_tableLayoutPanel.Controls
            Dim checkbox As CheckBox = TryCast(c, CheckBox)
            If c Is Nothing Then
                Continue For
            End If

            If checkbox.Checked Then
                settings.RestrictedOperations.Add(DirectCast(checkbox.Tag, String))
            End If
        Next

        settings.Save()
    End Sub
End Class
