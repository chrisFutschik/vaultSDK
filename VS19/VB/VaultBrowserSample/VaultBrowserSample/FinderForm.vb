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


Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Configuration
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Globalization
Imports System.Text
Imports System.Windows.Forms

Imports Autodesk.Connectivity.WebServices
Imports Autodesk.Connectivity.WebServicesTools
Imports VDF = Autodesk.DataManagement.Client.Framework


''' <summary>
''' The form containg our Vault file finder sample utility.
''' </summary>
Public Class FinderForm
    Inherits System.Windows.Forms.Form
    Private Const BUFFERSIZE As Integer = 16384

    Private m_connection As VDF.Vault.Currency.Connections.Connection

    Public Sub New(connection As VDF.Vault.Currency.Connections.Connection)

        '
        ' Required for Windows Form Designer support
        '
        InitializeComponent()

        '
        ' Form configuration and intialization
        '
        m_connection = connection

        InitializePropertyComboBox()


        InitializeConditionComboBox()
    End Sub

    ''' <summary>
    ''' Intializes the combox box containing the searchable properties available.
    ''' </summary>
    Private Sub InitializePropertyComboBox()

        'get the entire extended list of properties
        Dim defs As PropDef() = m_connection.WebServiceManager.PropertyService.GetPropertyDefinitionsByEntityClassId(VDF.Vault.Currency.Entities.EntityClassIds.Files)

        If defs IsNot Nothing AndAlso defs.Length > 0 Then
            Array.Sort(defs, New PropertyDefinitionSorter())

            'wait to draw the combo box until we've added all of the properties
            m_propertyComboBox.BeginUpdate()

            m_propertyComboBox.Items.Clear()

            For Each def As PropDef In defs
                'create a list item type that will hold the property
                Dim item As New ListBoxPropDefItem(def)

                m_propertyComboBox.Items.Add(item)
            Next

            'indicate that we've finished updated the combobox and it can now be re-drawn

            m_propertyComboBox.EndUpdate()
        End If

    End Sub

    Private Sub InitializeConditionComboBox()

        'wait to draw the combo box until we've populated it with conditions
        m_conditionComboBox.BeginUpdate()

        'populate the combo box with the conditions
        m_conditionComboBox.Items.AddRange(New Condition() {Condition.CONTAINS, Condition.EQUALS, Condition.DOES_NOT_CONTAIN, Condition.IS_EMPTY, Condition.IS_NOT_EMPTY, Condition.LESS_THAN_OR_EQUAL, _
         Condition.LESS_THAN, Condition.GREATER_THAN_OR_EQUAL, Condition.GREATER_THAN, Condition.NOT_EQUAL})

        'indicated that we're finished populating the combobox and that it can be re-drawn
        m_conditionComboBox.EndUpdate()

    End Sub

#Region "PropertyDefinitionSorter Class"
    ''' <summary>
    ''' Used for sorting collections of PropertyDefinition's.
    ''' </summary>
    Private Class PropertyDefinitionSorter
        Implements IComparer
        ''' <summary>
        ''' Class (static) constructor that creates a static Comparer class instane used for sorting PropertyDefinition's.
        ''' </summary>
        Shared Sub New()


            m_comparer = New Comparer(Application.CurrentCulture)
        End Sub

        Private Shared m_comparer As Comparer

        Public Function Compare(x As Object, y As Object) As Integer Implements IComparer.Compare
            Dim propDefX As PropDef = TryCast(x, PropDef)
            Dim propDefY As PropDef = TryCast(y, PropDef)

            SyncLock m_comparer


                Return m_comparer.Compare(propDefX.DispName, propDefY.DispName)
            End SyncLock

        End Function

    End Class
#End Region

    Private Sub OpenFile()
        If m_searchResultsListBox.SelectedItem IsNot Nothing Then
            Dim fileItem As ListBoxFileItem = DirectCast(m_searchResultsListBox.SelectedItem, ListBoxFileItem)
            OpenFileCommand.Execute(fileItem.File, m_connection)
        End If
    End Sub

    Private Sub m_addCriteriaButton_Click(sender As System.Object, e As System.EventArgs) Handles m_addCriteriaButton.Click
        'get a local reference of the currently selected PropertyDefinition object
        Dim propertyItem As ListBoxPropDefItem = TryCast(m_propertyComboBox.SelectedItem, ListBoxPropDefItem)
        Dim [property] As PropDef
        [property] = If((propertyItem Is Nothing), Nothing, propertyItem.PropDef)

        'get local reference of the condition combo boxes currently selected item
        Dim condition As Condition = TryCast(m_conditionComboBox.SelectedItem, Condition)

        If [property] Is Nothing OrElse condition Is Nothing Then
            Return
        End If

        'create a SearchCondition object
        Dim searchCondition As New SrchCond()
        searchCondition.PropDefId = [property].Id
        searchCondition.PropTyp = PropertySearchType.SingleProperty
        searchCondition.SrchOper = condition.Code
        searchCondition.SrchTxt = m_valueTextBox.Text

        'create the list item to contain the condition
        Dim searchItem As New ListBoxSrchCondItem(searchCondition, [property])

        'add the SearchCondition object to the search criteria list box
        m_criteriaListBox.Items.Add(searchItem)
    End Sub

    Private Sub m_removeCriteriaButton_Click(sender As System.Object, e As System.EventArgs) Handles m_removeCriteriaButton.Click
        'remove the currently selected search condition item from the list box
        If m_criteriaListBox.SelectedItem IsNot Nothing Then
            m_criteriaListBox.Items.RemoveAt(m_criteriaListBox.SelectedIndex)
        End If
    End Sub

    Private Sub m_findButton_Click(sender As System.Object, e As System.EventArgs) Handles m_findButton.Click
        'make sure search conditions have been added
        If m_criteriaListBox.Items.Count > 0 Then
            'clear out previous search results if they exist
            m_searchResultsListBox.Items.Clear()

            'build our array of SearchConditions to use for the file search
            Dim conditions As SrchCond() = New SrchCond(m_criteriaListBox.Items.Count - 1) {}

            For i As Integer = 0 To m_criteriaListBox.Items.Count - 1
                conditions(i) = DirectCast(m_criteriaListBox.Items(i), ListBoxSrchCondItem).SrchCond
            Next

            Dim bookmark As String = String.Empty
            Dim status As SrchStatus = Nothing

            'search for files
            Dim fileList As New List(Of File)()

            While status Is Nothing OrElse fileList.Count < status.TotalHits
                Dim files As File() = m_connection.WebServiceManager.DocumentService.FindFilesBySearchConditions(conditions, Nothing, Nothing, True, True, bookmark, _
                 status)

                If files IsNot Nothing Then
                    fileList.AddRange(files)
                End If
            End While

            If fileList.Count > 0 Then
                'iterate through found files and display them in the search results list box
                For Each file As File In fileList
                    'create the list item that will wrap the File
                    Dim fileItem As New ListBoxFileItem(New VDF.Vault.Currency.Entities.FileIteration(m_connection, file))

                    m_searchResultsListBox.Items.Add(fileItem)
                Next
            End If

            'update the items count label
            m_itemsCountLabel.Text = If((fileList.Count > 0), fileList.Count & " Items", "0 Items")
        End If
    End Sub

    Private Sub m_searchResultsListBox_DoubleClick(sender As System.Object, e As System.EventArgs) Handles m_searchResultsListBox.DoubleClick
        OpenFile()
    End Sub
End Class
