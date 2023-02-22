/*=====================================================================
  
  This file is part of the Autodesk Vault API Code Samples.

  Copyright (C) Autodesk Inc.  All rights reserved.

THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
PARTICULAR PURPOSE.
=====================================================================*/


#include "stdafx.h"
#include "Utils.h"
#include <vcclr.h>

void Utils::MangToUnMangString(System::String^ managedStr, std::wstring& unmangStr)
{
    if ( managedStr == nullptr )
    {
        unmangStr.clear();
        return;
    }

    pin_ptr<const wchar_t> s = PtrToStringChars( managedStr );
	unmangStr.assign(s, managedStr->Length);
}

void Utils::MangToUnMangDateTime(System::DateTime^ managedDT, tm& unmangDT)
{
    unmangDT.tm_sec   = managedDT->Second;
    unmangDT.tm_min   = managedDT->Minute;
    unmangDT.tm_hour  = managedDT->Hour;
    unmangDT.tm_mday  = managedDT->Day;
    unmangDT.tm_mon   = managedDT->Month - 1;     // [1-12]
    unmangDT.tm_year  = managedDT->Year - 1900;   // [1-9999]
    unmangDT.tm_wday  = (int)managedDT->DayOfWeek;     // [0-6]  [Sun-Sat]
    unmangDT.tm_yday  = managedDT->DayOfYear - 1; // [1-366]
    unmangDT.tm_isdst = 0; 
}

void Utils::MangToUnmangFile(Autodesk::Connectivity::WebServices::File^ managed,
                             _File& unmanaged)
{
	unmanaged.Id = managed->Id;
	MangToUnMangString( managed->Name, unmanaged.Name );
	unmanaged.MasterId = managed->MasterId;
	unmanaged.VersionNumber = managed->VerNum;
	unmanaged.MaxCkInVersionNumber = managed->MaxCkInVerNum;
	MangToUnMangDateTime( managed->CkInDate, unmanaged.CheckInDate );
	MangToUnMangString( managed->Comm, unmanaged.Comment );
	MangToUnMangDateTime( managed->CreateDate, unmanaged.CreateDate );
	unmanaged.CreateUserId = managed->CreateUserId;
	unmanaged.Checksum = managed->Cksum;
	unmanaged.FileSize = managed->FileSize;
	MangToUnMangString( managed->CreateUserName, unmanaged.CreateUserName );
	unmanaged.IsCheckedOut = managed->CheckedOut;
	unmanaged.FolderId = managed->FolderId;
	MangToUnMangString( managed->CkOutSpec, unmanaged.CheckedOutSpec );
	MangToUnMangString( managed->CkOutMach, unmanaged.CheckedOutMachine );
    unmanaged.fileStatus  = (__int64)managed->FileStatus;
	unmanaged.FileClass = (__int64)managed->FileClass;
	unmanaged.Cloaked = managed->Cloaked;
	unmanaged.CkOutUserId = managed->CkOutUserId;
	unmanaged.Hidden = managed->Hidden;
	unmanaged.IsOnSite = managed->IsOnSite;
	
}

void Utils::MangToUnmangFolder(
	Autodesk::Connectivity::WebServices::Folder^ managed,
	_Folder& unmanaged
	)
{
	unmanaged.Id = managed->Id;
	MangToUnMangString( managed->Name, unmanaged.Name );
	MangToUnMangString( managed->FullName, unmanaged.FullName );
	unmanaged.ParentId = managed->ParId;
	MangToUnMangDateTime( managed->CreateDate, unmanaged.CreateDate );
	unmanaged.CreateUserId = managed->CreateUserId;
	unmanaged.IsLibrary = managed->IsLib;
	MangToUnMangString( managed->CreateUserName, unmanaged.CreateUserName );
	unmanaged.NumChildren = managed->NumClds;
	MangToUnMangString( managed->FullUncName, unmanaged.FullUncName );
	unmanaged.Cloaked = managed->Cloaked;
}

