Requirements:
- Vault Server
- Visual Studio 2010 or higher



Overview:
VaultDLLSample illustrates how to make the Vault API available to non .NET applications such as unmanged C++ and VB 6.

This sample consists of twoprojects:
- VaultAPIWrapper:  A C++ project which converts the managed code from VaultAPIWrapper into unmanaged code and exposes the functionality via DLL exports.
- VaultList:  An unmanaged C++ project which imports the DLL functions from VaultAPIWrapper and lists out the contents of a vault to the command console.  

This example doesn't wrap all of the API functions.  Only the functions needed by VaultList are wrapped.



To Use:
If you don't have WSE 3.0, download and install it from Microsoft.  

Next open VaultDLLSample.sln in Visual Studio.  Edit VaultList.cpp to log in to your Autodesk DM server using your username and password.  Set VaultList as your start up project.  Compile and run.



Other Ideas:
This example is just one way to interface Vault with non .NET applications.  

Here are some other ideas that may be better suited to your needs:
- VaultAPIWrapper could be registered with the GAC.
- VaultAPIWrapper could be a registered COM DLL.
- VaultAPIWrapper could use SAFEARRAYS instead of std:vector to transfer data.
- VaultList could be a VB application or CAD plug-in.
