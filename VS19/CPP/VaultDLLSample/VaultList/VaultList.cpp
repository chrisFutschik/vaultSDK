/*=====================================================================
  
  This file is part of the Autodesk Vault API Code Samples.

  Copyright (C) Autodesk Inc.  All rights reserved.

THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
PARTICULAR PURPOSE.
=====================================================================*/

// VaultList.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <conio.h>

#include "..\VaultAPIWrapper\VaultAPIWrapper.h"

void PrintFolder(const _Folder &parentFolder, _WebServiceManager *mgr);

int _tmain(int argc, _TCHAR* argv[])
{
	wprintf(L"Signing In\n");

	_WebServiceManager *mgr = new _WebServiceManager(
		L"localhost", L"Vault", L"Administrator", L"");

	_Folder root = mgr->GetFolderRoot();

	PrintFolder(root, mgr);

	delete mgr;
	wprintf(L"\nProgram Complete.  Hit any key to exit.\n");
	_getch();
}


void PrintFolder(const _Folder &parentFolder, _WebServiceManager *mgr)
{
    // get all of the files in the folder and print them out
    std::vector<_File> files = mgr->GetLatestFilesByFolderId(parentFolder.Id,false);
    std::vector<_File>::iterator fileIter;
    for (fileIter = files.begin(); fileIter != files.end(); fileIter++)
    {
        _File file = *fileIter;
        wprintf(L"%s/%s\n", parentFolder.FullName.c_str(), file.Name.c_str());
    }

    // get all of the sub-folder and recurse
    std::vector<_Folder> folders = mgr->GetFoldersByParentId(parentFolder.Id,true);
    std::vector<_Folder>::iterator folderIter;
    for (folderIter = folders.begin(); folderIter != folders.end(); folderIter++)
    {
        _Folder childFolder = *folderIter;
        PrintFolder(childFolder, mgr);
    }

    files.clear();
    folders.clear();

}