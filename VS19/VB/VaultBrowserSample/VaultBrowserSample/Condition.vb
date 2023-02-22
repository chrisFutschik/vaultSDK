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
Imports System.Text

Public Class Condition
    Public Shared CONTAINS As New Condition("contains", 1)
    Public Shared DOES_NOT_CONTAIN As New Condition("does not contain", 2)
    Public Shared EQUALS As New Condition("equals", 3)
    Public Shared IS_EMPTY As New Condition("is empty", 4)
    Public Shared IS_NOT_EMPTY As New Condition("is not empty", 5)
    Public Shared LESS_THAN_OR_EQUAL As New Condition("<=", 9)
    Public Shared LESS_THAN As New Condition("<", 8)
    Public Shared GREATER_THAN_OR_EQUAL As New Condition(">=", 7)
    Public Shared GREATER_THAN As New Condition(">", 6)
    Public Shared NOT_EQUAL As New Condition("<>", 10)

    Private Shared m_conditionHash As Dictionary(Of Long, Condition) = Nothing

    Public Shared Function GetCondition(conditionId As Long) As Condition
        If m_conditionHash Is Nothing Then
            m_conditionHash = New Dictionary(Of Long, Condition)()
            m_conditionHash.Add(CONTAINS.Code, CONTAINS)
            m_conditionHash.Add(DOES_NOT_CONTAIN.Code, DOES_NOT_CONTAIN)
            m_conditionHash.Add(EQUALS.Code, EQUALS)
            m_conditionHash.Add(IS_EMPTY.Code, IS_EMPTY)
            m_conditionHash.Add(IS_NOT_EMPTY.Code, IS_NOT_EMPTY)
            m_conditionHash.Add(LESS_THAN_OR_EQUAL.Code, LESS_THAN_OR_EQUAL)
            m_conditionHash.Add(LESS_THAN.Code, LESS_THAN)
            m_conditionHash.Add(GREATER_THAN_OR_EQUAL.Code, GREATER_THAN_OR_EQUAL)
            m_conditionHash.Add(GREATER_THAN.Code, GREATER_THAN)
            m_conditionHash.Add(NOT_EQUAL.Code, NOT_EQUAL)
        End If

        Return m_conditionHash(conditionId)
    End Function

    Private m_code As Long
    Private m_displayName As String

    ''' <summary>
    ''' Value to be displayed in the condition combo box.
    ''' </summary>
    Public ReadOnly Property DisplayName() As String
        Get
            Return m_displayName
        End Get
    End Property

    ''' <summary>
    ''' A code to use when making the web service call.
    ''' </summary>
    Public ReadOnly Property Code() As Long
        Get
            Return m_code
        End Get
    End Property

    Private Sub New(displayName As String, code As Long)
        m_displayName = displayName
        m_code = code
    End Sub

    ''' <summary>
    ''' Returns the current value of the DisplayName property.
    ''' </summary>
    Public Overrides Function ToString() As String
        Return m_displayName
    End Function
End Class
