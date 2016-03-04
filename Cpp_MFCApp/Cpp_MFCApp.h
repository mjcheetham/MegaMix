
// Cpp_MFCApp.h : main header file for the Cpp_MFCApp application
//
#pragma once

#ifndef __AFXWIN_H__
	#error "include 'stdafx.h' before including this file for PCH"
#endif

#include "resource.h"       // main symbols


// CCpp_MFCAppApp:
// See Cpp_MFCApp.cpp for the implementation of this class
//

class CCpp_MFCAppApp : public CWinAppEx
{
public:
	CCpp_MFCAppApp();


// Overrides
public:
	virtual BOOL InitInstance();
	virtual int ExitInstance();

// Implementation
	UINT  m_nAppLook;
	BOOL  m_bHiColorIcons;

	virtual void PreLoadState();
	virtual void LoadCustomState();
	virtual void SaveCustomState();

	afx_msg void OnAppAbout();
	DECLARE_MESSAGE_MAP()
};

extern CCpp_MFCAppApp theApp;
