#pragma once

#include "../ADLX/SDK/Include/ADLX.h"
#include "../ADLX/SDK/ADLXHelper/Windows/Cpp/ADLXHelper.h"

class SafeADLXHelper
{
public:
  
    SafeADLXHelper();
    virtual ~SafeADLXHelper();

    ADLX_RESULT Initialize();
	ADLX_RESULT InitializeWithIncompatibleDriver();
    ADLX_RESULT Terminate();
 
    adlx::IADLXSystem* GetSystemServices();

private:
    ADLXHelper _adlxHelper;

}; //class SafeADLXHelper
