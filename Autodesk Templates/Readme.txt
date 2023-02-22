The templates included with the Vault 2023 SDK are to help kick-start integration and customization with Vault, using the APIs, or Application
Programming Interfaces. These templates are set up to be ready to run out-of-the-box, but can also be used a base to build upon. Additionally,
A PowerShell template is included in order to add and interact with Custom Jobs, or to connect to a Vault via scripts.

To set up the templates:
* Copy the 'ProjectTemplates' folder to your current user's '\Documents\Visual Studio 2017\Templates\' folder
* Once the templates are copied over, restart or start a new instance of Visual Studio. The templates will now be available to select when creating
  new projects, under the CSharp language.
* If the assembly is signed, it is signed with a Visual Studio generated key. This can also be replaced with a new signature.

The following is some quick info and descriptions of the available templates:
* API-Onboarding-ConsoleApp
	* To set up projects built from this template, select Program.cs and populate the Vault Server address, Vault name, Vault username, and password
          to connect with.
        * Projects created with this template will attempt to connect to a Vault with the given parameters, execute statements within the try block, then
          disconnect and exit.
        * This project will only output binaries inside of its project folder.

* API-Onboarding-JobProcessor
	* This project's build will output to '<windows drive>:\ProgramData\Autodesk\Vault 2023\Extensions'. Vault extensions will 
	  be loaded from this directory.
        * The project should be built using "Debug" configuration to automatically output to the above Vault Extensions directory.
	* After building, to view the newly available custom job, open "Autodesk Job Processor 2023 For Vault" or JobProcessor.exe from …\Vault 2023\Explorer. 
	  Once Job Processor's window appears, navigate to 'Administration' -> 'Job Types…', and observe the listed jobs available and jobs that are 
	  being processed (denoted by a check mark in a box).
	* The Vault SDK help documentation also contains more information regarding creating custom jobs

* API-Onboarding-EventHandlerExtension
	* This project's build will output to '<windows drive>:\ProgramData\Autodesk\Vault 2023\Extensions'. Vault extensions will 
	  be loaded from this directory.
        * The project should be built using "Debug" configuration to automatically output to the above Vault Extensions directory.
	* To debug project, under the 'Debug' properties, set Autodesk Vault 2023 as the Startup Program, and place a breakpoint on the OnLoad() method.
	  Additionally, a breakpoint can be placed on any uncommented event handler to observe its behavior alongside the 2023 Vault Client.
	* Any unused or unwanted events can be commented or removed from the template
	* The Vault SDK help documentation also contains more information regarding handling events
	
As a general note for Vault extensions, the *.vcet.config files should have the same name as the output Assembly name, and ensure the *.vcet.config
file contains the correct namespace, type, and assembly name within the "extension" node's "type" property