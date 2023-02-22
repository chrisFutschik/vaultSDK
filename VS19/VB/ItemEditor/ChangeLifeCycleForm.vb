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
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Linq

Imports Autodesk.Connectivity.WebServices
Imports Autodesk.Connectivity.WebServicesTools
Imports VDF = Autodesk.DataManagement.Client.Framework

''' <summary>
''' Summary description for ChangeLifeCycleForm.
''' </summary>
Public Class ChangeLifeCycleForm
    Inherits System.Windows.Forms.Form

    Public ReadOnly Property SelectedLifeCycleStateId() As Long
        Get
            Dim listobject As ListLifeCycle = DirectCast(m_lifeCycleListBox.SelectedItem, ListLifeCycle)
            Return listobject.LfCycState.Id
        End Get
    End Property

    Public Sub New(ByVal currentLifeCycleDefId As Long, ByVal currentLifeCycleStateId As Long, ByVal connection As VDF.Vault.Currency.Connections.Connection)
        '
        ' Required for Windows Form Designer support
        '
        InitializeComponent()

        Dim lifeCycleSvc As LifeCycleService = connection.WebServiceManager.LifeCycleService

        ' get all of the life cycle definitions
        Dim definitions As LfCycDef() = lifeCycleSvc.GetAllLifeCycleDefinitions()
        Dim lifeCycleMap As New Dictionary(Of Long, LfCycDef)()

        ' put the life cycle definitions into a hashtable for easy lookup
        For Each definition As LfCycDef In definitions
            lifeCycleMap(definition.Id) = definition
        Next

        Dim currentLifeCycleDef As LfCycDef = lifeCycleMap(currentLifeCycleDefId)

        ' list each life cycle that the current Item can move to
        For Each lifeCycleTrans As LfCycTrans In currentLifeCycleDef.TransArray
            Dim state As LfCycState = currentLifeCycleDef.StateArray.FirstOrDefault(Function(lfState As LfCycState) lfState.Id = lifeCycleTrans.ToId)
            If (Not state Is Nothing) Then
                m_lifeCycleListBox.Items.Add(New ListLifeCycle(state))
            End If
        Next
    End Sub

    Private Sub m_okButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_okButton.Click
        DialogResult = DialogResult.OK
    End Sub

End Class

''' <summary>
''' Used to display life cycles in a list box
''' </summary>
Public Class ListLifeCycle
    Public LfCycState As LfCycState

    Public Sub New(ByVal lifeCycleState As LfCycState)
        Me.LfCycState = lifeCycleState
    End Sub

    Public Overrides Function ToString() As String
        Return Me.LfCycState.DispName
    End Function
End Class