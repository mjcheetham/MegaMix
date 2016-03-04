
// Cpp_MFCAppView.h : interface of the CCpp_MFCAppView class
//

#pragma once


class CCpp_MFCAppView : public CView
{
protected: // create from serialization only
	CCpp_MFCAppView();
	DECLARE_DYNCREATE(CCpp_MFCAppView)

// Attributes
public:
	CCpp_MFCAppDoc* GetDocument() const;

// Operations
public:

// Overrides
public:
	virtual void OnDraw(CDC* pDC);  // overridden to draw this view
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
protected:
	virtual BOOL OnPreparePrinting(CPrintInfo* pInfo);
	virtual void OnBeginPrinting(CDC* pDC, CPrintInfo* pInfo);
	virtual void OnEndPrinting(CDC* pDC, CPrintInfo* pInfo);

// Implementation
public:
	virtual ~CCpp_MFCAppView();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// Generated message map functions
protected:
	afx_msg void OnFilePrintPreview();
	afx_msg void OnRButtonUp(UINT nFlags, CPoint point);
	afx_msg void OnContextMenu(CWnd* pWnd, CPoint point);
	DECLARE_MESSAGE_MAP()
};

#ifndef _DEBUG  // debug version in Cpp_MFCAppView.cpp
inline CCpp_MFCAppDoc* CCpp_MFCAppView::GetDocument() const
   { return reinterpret_cast<CCpp_MFCAppDoc*>(m_pDocument); }
#endif

