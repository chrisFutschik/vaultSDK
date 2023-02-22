/*=====================================================================
  
  This file is part of the Autodesk Vault API Code Samples.

  Copyright (C) Autodesk Inc.  All rights reserved.

THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
PARTICULAR PURPOSE.
=====================================================================*/


// VaultAPIWrapper.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "Utils.h"
#include <vcclr.h>

using namespace System;
using namespace Autodesk::Connectivity::WebServices;
using namespace Autodesk::Connectivity::WebServicesTools;


class _WebServiceManager::Impl
{
private:
	

public:
	Impl(std::wstring server, std::wstring vault, std::wstring username, std::wstring password)
	{
		ServerIdentities ^serverId = gcnew ServerIdentities();
		serverId->FileServer = gcnew String(server.c_str());

		UserPasswordCredentials ^cred = gcnew UserPasswordCredentials(
			serverId,
			gcnew String(vault.c_str()),
			gcnew String(username.c_str()),
			gcnew String(password.c_str()),
			LicensingAgent::Client);

		m_mgrImpl = gcnew WebServiceManager(cred);
	}

	~Impl()
	{
		delete m_mgrImpl;
	}

	WebServiceManager ^GetManager()
	{
		return m_mgrImpl;
	}

private:
	gcroot<WebServiceManager^> m_mgrImpl;

	// suppress copy/assignment
	Impl(const Impl&); // not implemented
	Impl& operator=(const Impl&); // not implemented
};


_WebServiceManager::_WebServiceManager(
	std::wstring server, std::wstring vault, std::wstring username, std::wstring password)
{
	m_pImpl = new Impl(server, vault, username, password);
}


_WebServiceManager::~_WebServiceManager()
{
	delete m_pImpl;
}


_Folder _WebServiceManager::GetFolderRoot()
{
	_Folder retVal;

    Folder ^managedFolder = m_pImpl->GetManager()->DocumentService->GetFolderRoot();
    Utils::MangToUnmangFolder(managedFolder, retVal);
    
    return retVal;
}

std::vector<_Folder> _WebServiceManager::GetFoldersByParentId(__int64 parentFolderId,bool recurse)
{
	std::vector<_Folder> retFolders;

	array<Folder ^> ^ managedFolders = 
		m_pImpl->GetManager()->DocumentService->GetFoldersByParentId( parentFolderId,recurse );

	if ( managedFolders != nullptr )
	{
		for (int i=0; i<managedFolders->Length; i++)
		{
			_Folder tempFolder;
			Utils::MangToUnmangFolder(managedFolders[i], tempFolder);
			retFolders.push_back(tempFolder);
		}
	}

	return retFolders;
}

std::vector<_File> _WebServiceManager::GetLatestFilesByFolderId(__int64 folderId,bool includeHidden)
{
	std::vector<_File> retFiles;

	array<File ^> ^ managedFiles = 
		m_pImpl->GetManager()->DocumentService->GetLatestFilesByFolderId( folderId,includeHidden);

	// if null then we have no children
	if ( managedFiles != nullptr )
	{
		for (int i=0; i<managedFiles->Length; i++)
		{
			_File retFile;
			Utils::MangToUnmangFile(managedFiles[i], retFile);
			retFiles.push_back(retFile);
		}
	}

	return retFiles;
}

