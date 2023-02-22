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
Imports System.Reflection
Imports System.Windows.Forms

Imports Autodesk.Connectivity.Explorer.Extensibility
Imports Autodesk.Connectivity.WebServices
Imports Autodesk.Connectivity.WebServicesTools
Imports VDF = Autodesk.DataManagement.Client.Framework


' These 5 assembly attributes must be specified or your extension will not load. 
<Assembly: AssemblyCompany("Autodesk")> 
<Assembly: AssemblyProduct("HelloWorldCommandExtension")> 
<Assembly: AssemblyDescription("Sample App")> 

' The extension ID needs to be unique for each extension.  
' Make sure to generate your own ID when writing your own extension. 
<Assembly: Autodesk.Connectivity.Extensibility.Framework.ExtensionId("7ADC0766-F085-46d7-A2EB-C68F79CBF4E7")> 

' This number gets incremented for each Vault release.
<Assembly: Autodesk.Connectivity.Extensibility.Framework.ApiVersion("16.0")> 


Namespace HelloWorld

    ''' <summary>
    ''' This class implements the IExtension interface, which means it tells Vault Explorer what 
    ''' commands and custom tabs are provided by this extension.
    ''' </summary>
    Public Class HelloWorldCommandExtension
        Implements IExplorerExtension

#Region "IExtension Members"

        ''' <summary>
        ''' This function tells Vault Explorer what custom commands this extension provides.
        ''' Part of the IExtension interface.
        ''' </summary>
        ''' <returns>A collection of CommandSites, which are collections of custom commands.</returns>
        Public Function CommandSites() As IEnumerable(Of CommandSite) Implements IExplorerExtension.CommandSites
            ' Create the Hello World command object.
            ' this command is active when a File is selected

            ' this command is not active if there are multiple entities selected
            Dim helloWorldCmdItem As New CommandItem("HelloWorldCommand", "Hello World...") With { _
             .NavigationTypes = New SelectionTypeId() {SelectionTypeId.File, SelectionTypeId.FileVersion}, _
             .MultiSelectEnabled = False _
            }

            ' The HelloWorldCommandHandler function is called when the custom command is executed.
            AddHandler helloWorldCmdItem.Execute, AddressOf HelloWorldCommandHandler

            ' Create a command site to hook the command to the Advanced toolbar
            Dim toolbarCmdSite As New CommandSite("HelloWorldCommand.Toolbar", "Hello World Menu") With { _
             .Location = CommandSiteLocation.AdvancedToolbar, _
             .DeployAsPulldownMenu = False _
            }
            toolbarCmdSite.AddCommand(helloWorldCmdItem)

            ' Create another command site to hook the command to the right-click menu for Files.
            Dim fileContextCmdSite As New CommandSite("HelloWorldCommand.FileContextMenu", "Hello World Menu") With { _
             .Location = CommandSiteLocation.FileContextMenu, _
             .DeployAsPulldownMenu = False _
            }
            fileContextCmdSite.AddCommand(helloWorldCmdItem)

            ' Now the custom command is available in 2 places.

            ' Gather the sites in a List.
            Dim sites As New List(Of CommandSite)()
            sites.Add(toolbarCmdSite)
            sites.Add(fileContextCmdSite)

            ' Return the list of CommandSites.
            Return sites
        End Function


        ''' <summary>
        ''' This function tells Vault Explorer what custom tabs this extension provides.
        ''' Part of the IExtension interface.
        ''' </summary>
        ''' <returns>A collection of DetailTabs, each object represents a custom tab.</returns>
        Public Function DetailTabs() As IEnumerable(Of DetailPaneTab) Implements IExplorerExtension.DetailTabs
            ' Create a DetailPaneTab list to return from method
            Dim fileTabs As New List(Of DetailPaneTab)()

            ' Create Selection Info tab for Files
            Dim filePropertyTab As New DetailPaneTab("File.Tab.PropertyGrid", "Selection Info", SelectionTypeId.File, GetType(MyCustomTabControl))

            ' The propertyTab_SelectionChanged is called whenever our tab is active and the selection changes in the 
            ' main grid.
            AddHandler filePropertyTab.SelectionChanged, AddressOf propertyTab_SelectionChanged
            fileTabs.Add(filePropertyTab)

            ' Create Selection Info tab for Folders
            Dim folderPropertyTab As New DetailPaneTab("Folder.Tab.PropertyGrid", "Selection Info", SelectionTypeId.Folder, GetType(MyCustomTabControl))
            AddHandler folderPropertyTab.SelectionChanged, AddressOf propertyTab_SelectionChanged
            fileTabs.Add(folderPropertyTab)

            ' Create Selection Info tab for Items
            Dim itemPropertyTab As New DetailPaneTab("Item.Tab.PropertyGrid", "Selection Info", SelectionTypeId.Item, GetType(MyCustomTabControl))
            AddHandler itemPropertyTab.SelectionChanged, AddressOf propertyTab_SelectionChanged
            fileTabs.Add(itemPropertyTab)

            ' Create Selection Info tab for Change Orders
            Dim coPropertyTab As New DetailPaneTab("Co.Tab.PropertyGrid", "Selection Info", SelectionTypeId.ChangeOrder, GetType(MyCustomTabControl))
            AddHandler coPropertyTab.SelectionChanged, AddressOf propertyTab_SelectionChanged
            fileTabs.Add(coPropertyTab)

            ' Return tabs
            Return fileTabs
        End Function




        ''' <summary>
        ''' This function is called after the user logs in to the Vault Server.
        ''' Part of the IExtension interface.
        ''' </summary>
        ''' <param name="application">Provides information about the running application.</param>
        Public Sub OnLogOn(application As IApplication) Implements IExplorerExtension.OnLogOn
            
        End Sub

        ''' <summary>
        ''' This function is called after the user is logged out of the Vault Server.
        ''' Part of the IExtension interface.
        ''' </summary>
        ''' <param name="application">Provides information about the running application.</param>
        Public Sub OnLogOff(application As IApplication) Implements IExplorerExtension.OnLogOff
            
        End Sub

        ''' <summary>
        ''' This function is called before the application is closed.
        ''' Part of the IExtension interface.
        ''' </summary>
        ''' <param name="application">Provides information about the running application.</param>
        Public Sub OnShutdown(application As IApplication) Implements IExplorerExtension.OnShutdown
            ' Although this function is empty for this project, it's still needs to be defined 
            ' because it's part of the IExtension interface.
        End Sub

        ''' <summary>
        ''' This function is called after the application starts up.
        ''' Part of the IExtension interface.
        ''' </summary>
        ''' <param name="application">Provides information about the running application.</param>
        Public Sub OnStartup(application As IApplication) Implements IExplorerExtension.OnStartup
            ' Although this function is empty for this project, it's still needs to be defined 
            ' because it's part of the IExtension interface.
        End Sub

        ''' <summary>
        ''' This function tells Vault Exlorer which default commands should be hidden.
        ''' Part of the IExtension interface.
        ''' </summary>
        ''' <returns>A collection of command names.</returns>
        Public Function HiddenCommands() As IEnumerable(Of String) Implements IExplorerExtension.HiddenCommands
            ' This extension does not hide any commands.
            Return Nothing
        End Function

        ''' <summary>
        ''' This function allows the extension to define special behavior for Custom Entity types.
        ''' Part of the IExtension interface.
        ''' </summary>
        ''' <returns>A collection of CustomEntityHandler objects.  Each object defines special behavior
        ''' for a specific Custom Entity type.</returns>
        Public Function CustomEntityHandlers() As IEnumerable(Of CustomEntityHandler) Implements IExplorerExtension.CustomEntityHandlers
            ' This extension does not provide special Custom Entity behavior.
            Return Nothing
        End Function

#End Region


        ''' <summary>
        ''' This is the function that is called whenever the custom command is executed.
        ''' </summary>
        ''' <param name="s">The sender object.  Usually not used.</param>
        ''' <param name="e">The event args.  Provides additional information about the environment.</param>
        Private Sub HelloWorldCommandHandler(s As Object, e As CommandItemEventArgs)
            Try
                ' The Context part of the event args tells us information about what is selected.
                ' Run some checks to make sure that the selection is valid.
                If e.Context.CurrentSelectionSet.Count() = 0 Then
                    MessageBox.Show("Nothing is selected")
                ElseIf e.Context.CurrentSelectionSet.Count() > 1 Then
                    MessageBox.Show("This function does not support multiple selections")
                Else
                    ' we only have one item selected, which is the expected behavior

                    Dim selection As ISelection = e.Context.CurrentSelectionSet.First()                   
                    Dim mgr As WebServiceManager = e.Context.Application.Connection.WebServiceManager

                    ' Look of the File object.  How we do this depends on what is selected.
                    Dim selectedFile As File = Nothing
                    If selection.TypeId = SelectionTypeId.File Then
                        ' our ISelection.Id is really a File.MasterId
                        selectedFile = mgr.DocumentService.GetLatestFileByMasterId(selection.Id)
                    ElseIf selection.TypeId = SelectionTypeId.FileVersion Then
                        ' our ISelection.Id is really a File.Id
                        selectedFile = mgr.DocumentService.GetFileById(selection.Id)
                    End If

                    If selectedFile Is Nothing Then
                        MessageBox.Show("Selection is not a file.")
                    Else
                        ' this is the message we hope to see
                        MessageBox.Show([String].Format("Hello World! The file size is: {0} bytes", selectedFile.FileSize))
                    End If
                End If
            Catch ex As Exception
                ' If something goes wrong, we don't want the exception to bubble up to Vault Explorer.
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Sub

        ''' <summary>
        ''' This function is called whenever our custom tab is active and the selection has changed in the main grid.
        ''' </summary>
        ''' <param name="sender">The sender object.  Usually not used.</param>
        ''' <param name="e">The event args.  Provides additional information about the environment.</param>
        Private Sub propertyTab_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
            Try
                ' The event args has our custom tab object.  We need to cast it to our type.
                Dim tabControl As MyCustomTabControl = TryCast(e.Context.UserControl, MyCustomTabControl)

                ' Send selection to the tab so that it can display the object.
                tabControl.SetSelectedObject(e.Context.SelectedObject)
            Catch ex As Exception
                ' If something goes wrong, we don't want the exception to bubble up to Vault Explorer.
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Sub
    End Class
End Namespace
