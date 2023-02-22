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
Imports System.Windows.Forms
Imports System.Xml
Imports System.Web.Services.Protocols

''' <summary>
''' Parses the data from a server error.
''' </summary>
Public Class ErrorHandler

    ''' <summary>
    '''  Returns the ADMS error in string format.  Null is returned if it's not an ADMS error.
    ''' </summary>
    Public Shared Function GetErrorCodeString(ByVal e As Exception) As String
        Dim se As SoapException = TryCast(e, SoapException)

        If se IsNot Nothing Then
            Try
                Return se.Detail("sl:sldetail")("sl:errorcode").InnerText
            Catch
            End Try
        End If

        Return Nothing
    End Function

    Public Shared Sub HandleError(ByVal e As Exception)
        Dim soapEx As SoapException = TryCast(e, SoapException)

        If soapEx Is Nothing Then
            ' error was not thrown by the server
            MessageBox.Show(e.ToString(), "Error")
            Return
        End If

        ' parse the XML data returned from the server.
        Dim elementDetail As XmlElement = soapEx.Detail("sl:sldetail")

        Dim errorCode As Long = -1
        Dim restrictions As New List(Of Integer)()


        If elementDetail Is Nothing OrElse elementDetail.ChildNodes Is Nothing Then
            ' catch cases where the error code is 0
            MessageBox.Show(e.ToString())
            Return
        End If

        For Each node As XmlNode In elementDetail.ChildNodes
            If node.Name = "sl:errorcode" Then
                errorCode = Long.Parse(node.InnerText)
            ElseIf node.Name = "sl:restrictions" Then
                For Each node2 As XmlNode In node.ChildNodes
                    If node2.Name <> "sl:restriction" Then
                        Continue For
                    End If

                    restrictions.Add(Integer.Parse(node2.Attributes("sl:code").Value))
                Next
            End If
        Next

        If errorCode = 1387 AndAlso restrictions.Count > 0 Then
            ' print restriction data
            Dim msgString As String = ""

            For Each restricCode As Integer In restrictions
                msgString += "Restriction Code = " & restricCode.ToString() & Environment.NewLine
            Next

            MessageBox.Show(msgString, "Server Error")
        Else
            MessageBox.Show("Error Code = " & errorCode, "Server Error")
        End If

    End Sub
End Class
