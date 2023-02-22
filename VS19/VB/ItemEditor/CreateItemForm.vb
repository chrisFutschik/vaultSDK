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
Imports System.ComponentModel
Imports System.Windows.Forms

Imports Autodesk.Connectivity.WebServices
Imports Autodesk.Connectivity.WebServicesTools
Imports VDF = Autodesk.DataManagement.Client.Framework

''' <summary>
''' Summary description for CreateItemForm.
''' </summary>
Public Class CreateItemForm
    Inherits System.Windows.Forms.Form

    Public ReadOnly Property ItemTitle As String
        Get
            Return m_itemTitleTextBox.Text
        End Get
    End Property

    Public ReadOnly Property Category As Cat
        Get
            Dim listobject As ListCategory = DirectCast(m_itemTypeComboBox.SelectedItem, ListCategory)
            Return listobject.Category
        End Get
    End Property

    Public Sub New(connection As VDF.Vault.Currency.Connections.Connection)
        '
        ' Required for Windows Form Designer support
        '
        InitializeComponent()

        Dim catSvc As CategoryService = connection.WebServiceManager.CategoryService

        Dim categories As Cat() = catSvc.GetCategoriesByEntityClassId("ITEM", True)
        For Each category As Cat In categories
            m_itemTypeComboBox.Items.Add(New ListCategory(category))
        Next
    End Sub

    Private Sub m_okButton_Click(sender As Object, e As System.EventArgs) Handles m_okButton.Click
        DialogResult = DialogResult.OK
    End Sub

End Class

' Wraps the ItemTyp object to display in combo box
Public Class ListCategory
    Public Category As Cat

    Public Sub New(category As Cat)
        Me.Category = category
    End Sub

    Public Overrides Function ToString() As String
        Return Me.Category.Name
    End Function

End Class
