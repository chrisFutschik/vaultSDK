/*=====================================================================
  
  This file is part of the Autodesk Vault API Code Samples.

  Copyright (C) Autodesk Inc.  All rights reserved.

THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
PARTICULAR PURPOSE.
=====================================================================*/

#pragma once

#using <mscorlib.dll>

#include "VaultAPIWrapper.h"


// Various utility functions
class Utils
{
public:
    // converts managed strings to unmanaged strings
    static void MangToUnMangString(System::String^ managedStr, 
                                   std::wstring& unmangStr);

    // converts managed datetime information into an unamanged format
    static void MangToUnMangDateTime(System::DateTime^ managedDT, tm& unmangDT);

    // converts managed File objects to unmanaged
    static void MangToUnmangFile(
		Autodesk::Connectivity::WebServices::File^ managed,
		_File& unmanaged
		);

    // converts managed Folder objects to unmanaged
    static void MangToUnmangFolder(
		Autodesk::Connectivity::WebServices::Folder^ managed,
		_Folder& unmanaged
		);
};
