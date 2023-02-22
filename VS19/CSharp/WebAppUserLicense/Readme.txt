Overview:
WebAppUserLicense sample demonstrates using Autodesk ID login to obtain the license and connect to Vault.

WebAppUserLicense sample contains the following features/concepts:
    - Login to Autodesk account and get token
    - Call LogInWithUserLicense API to connect to Vault with the user license
    - Login to Vault use Autodesk account(need admin to link the Autodesk account in Vault first)
    - Call Vault SDK from a web app to get folders and files and properties 
    
To use:
1. Before build and run this sample, please visit https://forge.autodesk.com/ for create a new Forge app
   and get the client id. Select any APIs you want. Note the callback URL for the app. The URL must be able
   to handle the callback from Forge server and get the token from the callback. For this sample you can 
   just set it to "http://localhost/WebAppExample/Default.aspx" so you can run the sample without modify the code.
   
2. Please make sure AdSSOServices.dll is in search path so the web app can load it. You can update the 
   system environment PATH to include the path to Autodesk Vault 2022 SDK\bin\x64, or copy the dll to 
   existing path location, e.g., C:\Windows\. If the dll can't be found in PATH, you may see 
   "Could not load file or assembly" error for 'Autodesk.Connectivity.AdSSOWrapper' on the web page 
   when run the sample.
   
3. Open WebAppUserLicense.sln in Visual Studio. Update your Forge app's client ID into line 15 of Default.aspx.cs. 
   Build and run the project, it will open the browser and show the login page. Login your Autodesk ID that
   has valid license, and you can login to Vault after the Autodesk ID login finish.
