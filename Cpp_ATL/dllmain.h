// dllmain.h : Declaration of module class.

class CCpp_ATLModule : public ATL::CAtlDllModuleT< CCpp_ATLModule >
{
public :
	DECLARE_LIBID(LIBID_Cpp_ATLLib)
	DECLARE_REGISTRY_APPID_RESOURCEID(IDR_CPP_ATL, "{59D7E172-BC91-4431-A782-670C51A6089B}")
};

extern class CCpp_ATLModule _AtlModule;
