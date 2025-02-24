#include "SafeADLXHelper.h"

SafeADLXHelper::SafeADLXHelper()
{
}

SafeADLXHelper::~SafeADLXHelper()
{
	Terminate();
}

ADLX_RESULT SafeADLXHelper::Initialize()
{
	try
	{
		return _adlxHelper.Initialize();
	}
	catch (...) 
	{
		return ADLX_FAIL;
	}
}

ADLX_RESULT SafeADLXHelper::InitializeWithIncompatibleDriver()
{
	try
	{
		return _adlxHelper.InitializeWithIncompatibleDriver();
	}
	catch (...)
	{
		return ADLX_FAIL;
	}
}

ADLX_RESULT SafeADLXHelper::Terminate()
{
	try
	{
		return _adlxHelper.Terminate();
	}
	catch (...) 
	{
		return ADLX_FAIL;
	}
}

adlx::IADLXSystem* SafeADLXHelper::GetSystemServices()
{
	return _adlxHelper.GetSystemServices();
}
