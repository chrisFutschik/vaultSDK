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

Imports Autodesk.Connectivity.WebServices
Imports Autodesk.DataManagement.Client.Framework.Vault.Currency.Entities
Imports Autodesk.DataManagement.Client.Framework.Vault.Currency.Properties

''' <summary>
''' A list box item which contains a File object
''' </summary>
Public Class ListBoxFileItem
    Private m_file As FileIteration
    Public ReadOnly Property File() As FileIteration
        Get
            Return m_file
        End Get
    End Property

    Public Sub New(f As FileIteration)

        m_file = f
    End Sub

    ''' <summary>
    ''' Determines the text displayed in the ListBox
    ''' </summary>
    Public Overrides Function ToString() As String
        Return Me.m_file.EntityName
    End Function
End Class


''' <summary>
''' A list box item which contains a BOMInst and BOMComp object
''' </summary>
Class ListBoxBOMInstItem
    Public BOMInst As BOMInst
    Public BOMComp As BOMComp

    Public Sub New(inst As BOMInst, comp As BOMComp)
        BOMInst = inst
        BOMComp = comp
    End Sub

    Public Overrides Function ToString() As String
        Return Convert.ToString(BOMComp.Name) & " (Qty. " & Convert.ToString((BOMInst.Quant * BOMComp.BaseQty)) & " " & Convert.ToString(BOMComp.BaseUOM) & ")"
    End Function
End Class


''' <summary>
''' A list box item which contains a BOMCompAttr and BOMComp object 
''' </summary>
Class ListBoxBOMCompAttrItem
    Public BOMCompAttr As BOMCompAttr
    Public BOMProp As BOMProp

    Public Sub New(attribute As BOMCompAttr, [property] As BOMProp)
        BOMCompAttr = attribute
        BOMProp = [property]
    End Sub

    Public Overrides Function ToString() As String
        Return Convert.ToString(BOMProp.DispName) & " = " & Convert.ToString(BOMCompAttr.Val)
    End Function
End Class

''' <summary>
''' A list box item which contains a PropDef object 
''' </summary>
Class ListBoxPropDefItem
    Public PropDef As PropDef

    Public Sub New(propDef As PropDef)
        Me.PropDef = propDef
    End Sub

    Public Overrides Function ToString() As String
        Return PropDef.DispName
    End Function
End Class

''' <summary>
''' A list box item which contains a SrchCond and PropDef object 
''' </summary>
Class ListBoxSrchCondItem
    Public SrchCond As SrchCond
    Public PropDef As PropDef

    Public Sub New(srchCond As SrchCond, propDef As PropDef)
        Me.SrchCond = srchCond
        Me.PropDef = propDef
    End Sub

    Public Overrides Function ToString() As String
        Dim conditionName As String = Condition.GetCondition(SrchCond.SrchOper).DisplayName
        Return [String].Format("{0} {1} {2}", PropDef.DispName, conditionName, SrchCond.SrchTxt)
    End Function
End Class
