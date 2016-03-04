
// Cpp_MFCAppView.cpp : implementation of the CCpp_MFCAppView class
//

#include "stdafx.h"
// SHARED_HANDLERS can be defined in an ATL project implementing preview, thumbnail
// and search filter handlers and allows sharing of document code with that project.
#ifndef SHARED_HANDLERS
#include "Cpp_MFCApp.h"
#endif

#include "Cpp_MFCAppDoc.h"
#include "Cpp_MFCAppView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CCpp_MFCAppView

IMPLEMENT_DYNCREATE(CCpp_MFCAppView, CView)

BEGIN_MESSAGE_MAP(CCpp_MFCAppView, CView)
	// Standard printing commands
	ON_COMMAND(ID_FILE_PRINT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, &CCpp_MFCAppView::OnFilePrintPreview)
	ON_WM_CONTEXTMENU()
	ON_WM_RBUTTONUP()
END_MESSAGE_MAP()

// CCpp_MFCAppView construction/destruction

CCpp_MFCAppView::CCpp_MFCAppView()
{
	// TODO: add construction code here

}

CCpp_MFCAppView::~CCpp_MFCAppView()
{
}

BOOL CCpp_MFCAppView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return CView::PreCreateWindow(cs);
}

// CCpp_MFCAppView drawing

void CCpp_MFCAppView::OnDraw(CDC* /*pDC*/)
{
	CCpp_MFCAppDoc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);
	if (!pDoc)
		return;

	// TODO: add draw code for native data here
}


// CCpp_MFCAppView printing


void CCpp_MFCAppView::OnFilePrintPreview()
{
#ifndef SHARED_HANDLERS
	AFXPrintPreview(this);
#endif
}

BOOL CCpp_MFCAppView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// default preparation
	return DoPreparePrinting(pInfo);
}

void CCpp_MFCAppView::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add extra initialization before printing
}

void CCpp_MFCAppView::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add cleanup after printing
}

void CCpp_MFCAppView::OnRButtonUp(UINT /* nFlags */, CPoint point)
{
	ClientToScreen(&point);
	OnContextMenu(this, point);
}

void CCpp_MFCAppView::OnContextMenu(CWnd* /* pWnd */, CPoint point)
{
#ifndef SHARED_HANDLERS
	theApp.GetContextMenuManager()->ShowPopupMenu(IDR_POPUP_EDIT, point.x, point.y, this, TRUE);
#endif
}


// CCpp_MFCAppView diagnostics

#ifdef _DEBUG
void CCpp_MFCAppView::AssertValid() const
{
	CView::AssertValid();
}

void CCpp_MFCAppView::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

CCpp_MFCAppDoc* CCpp_MFCAppView::GetDocument() const // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CCpp_MFCAppDoc)));
	return (CCpp_MFCAppDoc*)m_pDocument;
}
#endif //_DEBUG


// CCpp_MFCAppView message handlers
