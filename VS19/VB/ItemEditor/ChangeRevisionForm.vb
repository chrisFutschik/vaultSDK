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
''' Summary description for ChangeRevisionForm.
''' </summary>
Public Class ChangeRevisionForm
    Inherits System.Windows.Forms.Form

    Public ReadOnly Property SelectedRevisionNumber() As String
        Get
            If m_primaryRadioButton.Checked Then
                Return m_primaryRadioButton.Text
            ElseIf m_secondaryRadioButton.Checked Then
                Return m_secondaryRadioButton.Text
            ElseIf m_tertiaryRadioButton.Checked Then
                Return m_tertiaryRadioButton.Text
            ElseIf m_customRadioButton.Checked Then
                Return m_customTextBox.Text
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public Sub New(item As Item, connection As VDF.Vault.Currency.Connections.Connection)
        '
        ' Required for Windows Form Designer support
        '
        InitializeComponent()

        Dim revDefIds As Long() = connection.WebServiceManager.RevisionService.GetRevisionDefinitionIdsByMasterIds(New Long() {item.MasterId})
        Dim revNumbers As StringArray = connection.WebServiceManager.RevisionService.GetNextRevisionNumbersByMasterIds(New Long() {item.MasterId}, revDefIds)(0)

        Me.m_primaryRadioButton.Text = revNumbers.Items(0)
        Me.m_secondaryRadioButton.Text = revNumbers.Items(1)
        Me.m_tertiaryRadioButton.Text = revNumbers.Items(2)
    End Sub

    Private Sub m_okButton_Click(sender As Object, e As System.EventArgs) Handles m_okButton.Click
        DialogResult = DialogResult.OK
    End Sub
End Class