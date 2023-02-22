/*=====================================================================
  
  This file is part of the Autodesk Vault API Code Samples.

  Copyright (C) Autodesk Inc.  All rights reserved.

THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
PARTICULAR PURPOSE.
=====================================================================*/

#pragma once
#pragma warning(disable: 4945)
#pragma warning(disable: 4251)

// The following ifdef block is the standard way of creating macros which make exporting 
// from a DLL simpler. All files within this DLL are compiled with the VAULTAPIEXPORT_EXPORTS
// symbol defined on the command line. this symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see 
// VAULTAPIWRAPPER_EXPORTS functions as being imported from a DLL, whereas this DLL sees symbols
// defined with this macro as being exported.

#ifdef VAULTAPIWRAPPER_API
	#undef VAULTAPIWRAPPER_API
#endif

#ifdef VAULTAPIWRAPPER_EXPORTS
#define VAULTAPIWRAPPER_API __declspec(dllexport)
#else
#define VAULTAPIWRAPPER_API __declspec(dllimport)
#endif

#include <vector>

struct VAULTAPIWRAPPER_API _File
{
public:
	enum _FileClassification
	{
		None = 0,
		DesignVisualization = 1,
		DesignDocument = 2,
		ConfigurationMember = 3,
		ConfigurationFactory = 4,
		ElectricalProject = 5,
		DesignSubstitute = 6,
		DesignRepresentation = 7,
		DesignPresentation = 8
	};
	enum _FileStatus 
	{
		Unknown = 1,
		NeedsUpdating  =2,
		UpToDate =3
	};

	_File() {}
	_File(
		__int64 id,
		const std::wstring& name,
		__int64 masterId,
		__int32 versionNumber,
		__int32 maxCkInVersionNumber,
		tm checkInDate,
		const std::wstring& comment,
		tm createDate,
		__int64 createUserId,
		__int32 checksum,
		__int64 fileSize,
		const std::wstring& createUserName,
		bool isCheckedOut,
		__int64 checkedOutfolderId,
		const std::wstring& checkedOutSpec,
		const std::wstring& checkedOutMachine,
		__int64 FileClass,
		__int64 fileStatus,
		bool Cloaked,
		__int64 CkOutUserId,
		bool hidden,
		bool isOnSite,
		bool locked
		);

	__int64 Id;
	std::wstring Name;
	std::wstring Comment;
	std::wstring CreateUserName;
	std::wstring CheckedOutSpec;
	std::wstring CheckedOutMachine;
	__int64 MasterId;
	__int32 VersionNumber;
	__int32 MaxCkInVersionNumber;
	tm CheckInDate;
	tm CreateDate;
	__int64 CreateUserId;
	__int32 Checksum;
	__int64 FileSize;
	bool IsCheckedOut;
	__int64 FolderId;
	__int64 FileClass;
	__int64 fileStatus;
	bool Cloaked;
	__int64 CkOutUserId;
	bool Hidden;
	bool IsOnSite;
	bool Locked;
};


struct VAULTAPIWRAPPER_API _Folder
{
public:
	_Folder()	{}
	_Folder(
		__int64 id, 
		const std::wstring& name, 
		const std::wstring& fullName, 
		__int64 parentId, 
		tm createDate,
		__int64 createUserId, 
		bool isActive, 
		bool isLibrary, 
		const std::wstring& createUserName,
		__int32 numChildren,
		const std::wstring& fullUncName,
		bool cloaked
		);

	__int64 Id;
	std::wstring Name;
	std::wstring FullName;
	std::wstring CreateUserName;
	std::wstring FullUncName;
	__int64 ParentId;
	tm CreateDate;
	__int64 CreateUserId;
	bool IsActive;
	bool IsLibrary;
	__int32 NumChildren;
	bool Cloaked;
};

class VAULTAPIWRAPPER_API _WebServiceManager {
public:

	_WebServiceManager(std::wstring server, std::wstring vault, std::wstring username, std::wstring password);
	~_WebServiceManager(void);

	_Folder GetFolderRoot();
	std::vector<_Folder> GetFoldersByParentId(__int64 parentFolderId,bool recurse);
    std::vector<_File> GetLatestFilesByFolderId(__int64 folderId,bool includeHidden);

private:
	class Impl;
	Impl* m_pImpl; 
};
