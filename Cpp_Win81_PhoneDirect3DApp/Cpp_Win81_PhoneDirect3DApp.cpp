#include "pch.h"
#include "Cpp_Win81_PhoneDirect3DApp.h"
#include "BasicTimer.h"

using namespace Windows::ApplicationModel;
using namespace Windows::ApplicationModel::Core;
using namespace Windows::ApplicationModel::Activation;
using namespace Windows::UI::Core;
using namespace Windows::System;
using namespace Windows::Foundation;
using namespace Windows::Graphics::Display;
using namespace concurrency;

Cpp_Win81_PhoneDirect3DApp::Cpp_Win81_PhoneDirect3DApp() :
	m_windowClosed(false),
	m_windowVisible(true)
{
}

void Cpp_Win81_PhoneDirect3DApp::Initialize(CoreApplicationView^ applicationView)
{
	applicationView->Activated +=
		ref new TypedEventHandler<CoreApplicationView^, IActivatedEventArgs^>(this, &Cpp_Win81_PhoneDirect3DApp::OnActivated);

	CoreApplication::Suspending +=
		ref new EventHandler<SuspendingEventArgs^>(this, &Cpp_Win81_PhoneDirect3DApp::OnSuspending);

	CoreApplication::Resuming +=
		ref new EventHandler<Platform::Object^>(this, &Cpp_Win81_PhoneDirect3DApp::OnResuming);

	m_renderer = ref new CubeRenderer();
}

void Cpp_Win81_PhoneDirect3DApp::SetWindow(CoreWindow^ window)
{
	window->VisibilityChanged +=
		ref new TypedEventHandler<CoreWindow^, VisibilityChangedEventArgs^>(this, &Cpp_Win81_PhoneDirect3DApp::OnVisibilityChanged);

	window->Closed += 
		ref new TypedEventHandler<CoreWindow^, CoreWindowEventArgs^>(this, &Cpp_Win81_PhoneDirect3DApp::OnWindowClosed);

	window->PointerPressed +=
		ref new TypedEventHandler<CoreWindow^, PointerEventArgs^>(this, &Cpp_Win81_PhoneDirect3DApp::OnPointerPressed);

	window->PointerMoved +=
		ref new TypedEventHandler<CoreWindow^, PointerEventArgs^>(this, &Cpp_Win81_PhoneDirect3DApp::OnPointerMoved);

	window->PointerReleased +=
		ref new TypedEventHandler<CoreWindow^, PointerEventArgs^>(this, &Cpp_Win81_PhoneDirect3DApp::OnPointerReleased);

	m_renderer->Initialize(CoreWindow::GetForCurrentThread());
}

void Cpp_Win81_PhoneDirect3DApp::Load(Platform::String^ entryPoint)
{
}

void Cpp_Win81_PhoneDirect3DApp::Run()
{
	BasicTimer^ timer = ref new BasicTimer();

	while (!m_windowClosed)
	{
		if (m_windowVisible)
		{
			timer->Update();
			CoreWindow::GetForCurrentThread()->Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessAllIfPresent);
			m_renderer->Update(timer->Total, timer->Delta);
			m_renderer->Render();
			m_renderer->Present(); // This call is synchronized to the display frame rate.
		}
		else
		{
			CoreWindow::GetForCurrentThread()->Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessOneAndAllPending);
		}
	}
}

void Cpp_Win81_PhoneDirect3DApp::Uninitialize()
{
}

void Cpp_Win81_PhoneDirect3DApp::OnVisibilityChanged(CoreWindow^ sender, VisibilityChangedEventArgs^ args)
{
	m_windowVisible = args->Visible;
}

void Cpp_Win81_PhoneDirect3DApp::OnWindowClosed(CoreWindow^ sender, CoreWindowEventArgs^ args)
{
	m_windowClosed = true;
}

void Cpp_Win81_PhoneDirect3DApp::OnPointerPressed(CoreWindow^ sender, PointerEventArgs^ args)
{
	// Insert your code here.
}

void Cpp_Win81_PhoneDirect3DApp::OnPointerMoved(CoreWindow^ sender, PointerEventArgs^ args)
{
	// Insert your code here.
}

void Cpp_Win81_PhoneDirect3DApp::OnPointerReleased(CoreWindow^ sender, PointerEventArgs^ args)
{
	// Insert your code here.
}

void Cpp_Win81_PhoneDirect3DApp::OnActivated(CoreApplicationView^ applicationView, IActivatedEventArgs^ args)
{
	CoreWindow::GetForCurrentThread()->Activate();
}

void Cpp_Win81_PhoneDirect3DApp::OnSuspending(Platform::Object^ sender, SuspendingEventArgs^ args)
{
	// Save app state asynchronously after requesting a deferral. Holding a deferral
	// indicates that the application is busy performing suspending operations. Be
	// aware that a deferral may not be held indefinitely. After about five seconds,
	// the app will be forced to exit.
	SuspendingDeferral^ deferral = args->SuspendingOperation->GetDeferral();
	m_renderer->ReleaseResourcesForSuspending();

	create_task([this, deferral]()
	{
		// Insert your code here.

		deferral->Complete();
	});
}
 
void Cpp_Win81_PhoneDirect3DApp::OnResuming(Platform::Object^ sender, Platform::Object^ args)
{
	// Restore any data or state that was unloaded on suspend. By default, data
	// and state are persisted when resuming from suspend. Note that this event
	// does not occur if the app was previously terminated.
	 m_renderer->CreateWindowSizeDependentResources();
}

IFrameworkView^ Direct3DApplicationSource::CreateView()
{
	return ref new Cpp_Win81_PhoneDirect3DApp();
}

[Platform::MTAThread]
int main(Platform::Array<Platform::String^>^)
{
	auto direct3DApplicationSource = ref new Direct3DApplicationSource();
	CoreApplication::Run(direct3DApplicationSource);
	return 0;
}