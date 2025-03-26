// 
// Copyright (c) 2021 - 2023 Advanced Micro Devices, Inc. All rights reserved.
//
//-------------------------------------------------------------------------------------------------

%module(directors="1") ADLX
%{

#include <Windows.h>
#include "../ADLX/SDK/Include/ADLXDefines.h"
#include "../ADLX/SDK/Include/ICollections.h"
#include "../ADLX/SDK/Include/IDisplays.h"
#include "../ADLX/SDK/Include/ISystem.h"
#include "../ADLX/SDK/Include/ILog.h"
#include "../ADLX/SDK/Include/IGPUTuning.h"
#include "../ADLX/SDK/Include/IGPUManualFanTuning.h"
#include "../ADLX/SDK/Include/IGPUManualGFXTuning.h"
#include "../ADLX/SDK/Include/IGPUManualPowerTuning.h"
#include "../ADLX/SDK/Include/IGPUManualVRAMTuning.h"
#include "../ADLX/SDK/Include/IGPUPresetTuning.h"
#include "../ADLX/SDK/Include/IGPUTuning.h"
#include "../ADLX/SDK/Include/IPerformanceMonitoring.h"
#include "../ADLX/SDK/Include/IPerformanceMonitoring1.h"
#include "../ADLX/SDK/Include/IPerformanceMonitoring2.h"
#include "../ADLX/SDK/ADLXHelper/Windows/Cpp/ADLXHelper.h"
#include "ADLXExt.h"
#include "SafeADLXHelper.h"

typedef     int64_t             adlx_int64;
typedef     int32_t             adlx_int32;
typedef     int16_t             adlx_int16;
typedef     int8_t              adlx_int8;
typedef     uint64_t            adlx_uint64;
typedef     uint32_t            adlx_uint32;
typedef     uint16_t            adlx_uint16;
typedef     uint8_t             adlx_uint8;
typedef     size_t              adlx_size;
typedef     void*               adlx_handle;
typedef     double              adlx_double;
typedef     float               adlx_float;
typedef     void                adlx_void;
typedef     long                adlx_long;
typedef		char*				adlx_string;
typedef     adlx_int32          adlx_int;
typedef     unsigned long       adlx_ulong;
typedef     adlx_uint32         adlx_uint;
typedef     bool                adlx_bool;
typedef wchar_t WCHAR;    // wc,   16-bit UNICODE character
typedef WCHAR TCHAR;

// Microsoft
#define ADLX_CORE_LINK          __declspec(dllexport)
#define ADLX_STD_CALL           __stdcall
#define ADLX_CDECL_CALL         __cdecl
#define ADLX_FAST_CALL          __fastcall
#define ADLX_INLINE              __inline
#define ADLX_FORCEINLINE         __forceinline
#define ADLX_NO_VTABLE          __declspec(novtable)

//IID's
#define ADLX_DECLARE_IID(X) static ADLX_INLINE const wchar_t* IID()  { return X; }
#define ADLX_IS_IID(X, Y) (!wcscmp (X, Y))
#define ADLX_DECLARE_ITEM_IID(X) static ADLX_INLINE const wchar_t* ITEM_IID()  { return X; }

using namespace adlx;
%}

typedef     int64_t             adlx_int64;
typedef     int32_t             adlx_int32;
typedef     int16_t             adlx_int16;
typedef     int8_t              adlx_int8;
typedef     uint64_t            adlx_uint64;
typedef     uint32_t            adlx_uint32;
typedef     uint16_t            adlx_uint16;
typedef     uint8_t             adlx_uint8;
typedef     size_t              adlx_size;
typedef     void*               adlx_handle;
typedef     double              adlx_double;
typedef     float               adlx_float;
typedef     void                adlx_void;
typedef     long                adlx_long;
typedef     adlx_int32          adlx_int;
typedef     unsigned long       adlx_ulong;
typedef     adlx_uint32         adlx_uint;
typedef		char*				adlx_string;
typedef     bool                adlx_bool;
typedef wchar_t WCHAR;    // wc,   16-bit UNICODE character
typedef WCHAR TCHAR;

// Microsoft
#define ADLX_CORE_LINK          __declspec(dllexport)
#define ADLX_STD_CALL           __stdcall
#define ADLX_CDECL_CALL         __cdecl
#define ADLX_FAST_CALL          __fastcall
#define ADLX_INLINE              __inline
#define ADLX_FORCEINLINE         __forceinline
#define ADLX_NO_VTABLE          __declspec(novtable)

//IID's
#define ADLX_DECLARE_IID(X) static ADLX_INLINE const wchar_t* IID()  { return X; }
#define ADLX_IS_IID(X, Y) (!wcscmp (X, Y))

#define ADLX_DECLARE_ITEM_IID(X) static ADLX_INLINE const wchar_t* ITEM_IID()  { return X; }

/* Callback to turn on director wrapping */
%feature("director") IADLXDisplayListChangedListener;

%include stdint.i
%include carrays.i
%include windows.i
%include typemaps.i
%include cs_struct.i

%cs_struct(GPUMetricsStruct, GPUMetricsStruct);
%cs_struct(GPUMetricsStruct1, GPUMetricsStruct1);
//%typemap(csclassmodifiers) SWIGTYPE "public partial class"

%include "../ADLX/SDK/Include/ADLXDefines.h"
%include "../ADLX/SDK/Include/ADLXStructures.h"
%include "../ADLX/SDK/Include/ICollections.h"
%include "../ADLX/SDK/Include/IDisplays.h"
%include "../ADLX/SDK/Include/ISystem.h"
%include "../ADLX/SDK/Include/ILog.h"
%include "../ADLX/SDK/Include/IGPUTuning.h"
%include "../ADLX/SDK/Include/IGPUManualFanTuning.h"
%include "../ADLX/SDK/Include/IGPUManualGFXTuning.h"
%include "../ADLX/SDK/Include/IGPUManualPowerTuning.h"
%include "../ADLX/SDK/Include/IGPUManualVRAMTuning.h"
%include "../ADLX/SDK/Include/IGPUPresetTuning.h"
%include "../ADLX/SDK/Include/IGPUTuning.h"
%include "../ADLX/SDK/Include/IPerformanceMonitoring.h"
%include "../ADLX/SDK/Include/IPerformanceMonitoring1.h"
%include "../ADLX/SDK/Include/IPerformanceMonitoring2.h"
%include "../ADLX/SDK/ADLXHelper/Windows/Cpp/ADLXHelper.h"
%include "ADLXExt.h"
%include "SafeADLXHelper.h"

using namespace adlx;

// T* pointer
%include cpointer.i

%pointer_functions(adlx_int, intP);
%pointer_functions(double, doubleP);
%pointer_functions(bool, boolP);
%pointer_functions(WCHAR, wcharP);
%pointer_functions(adlx_uint, uintP);
%pointer_functions(ADLX_DISPLAY_TYPE, displayTypeP);
%pointer_functions(ADLX_DISPLAY_CONNECTOR_TYPE, disConnectTypeP);
%pointer_functions(ADLX_DISPLAY_SCAN_TYPE, disScanTypeP);
%pointer_functions(adlx_size, adlx_sizeP);
%pointer_functions(ADLX_IntRange, adlx_intRangeP);
%pointer_functions(ADLX_GPU_TYPE, gpuTypeP);

// T** pointers
%pointer_functions(IADLXDisplayServices*, displaySerP_Ptr);
%pointer_functions(IADLXDisplayList*, displayListP_Ptr);
%pointer_functions(IADLXDisplay*, displayP_Ptr);
%pointer_functions(IADLXDisplayChangedHandling*, displayChangeHandlP_Ptr);
%pointer_functions(IADLXGPU*, gpuP_Ptr);
%pointer_functions(IADLXGPUList*, gpuListP_Ptr);
%pointer_functions(IADLXList*, adlxListP_Ptr);
%pointer_functions(IADLXInterface*, adlxInterfaceP_Ptr);
%pointer_functions(IADLXGPUTuningServices*, gpuTuningP_Ptr);
%pointer_functions(IADLXManualFanTuning*, manualFanTuningP_Ptr);
%pointer_functions(IADLXManualPowerTuning*, manualPowerTuningP_Ptr);
%pointer_functions(IADLXPerformanceMonitoringServices*, performanceP_Ptr);
%pointer_functions(IADLXManualFanTuningStateList*, fanTuningStateListP_Ptr);
%pointer_functions(IADLXManualFanTuningState*, fanTuningStateP_Ptr);
%pointer_functions(IADLXGPUMetrics*, metricsP_Ptr);
%pointer_functions(IADLXGPUMetrics1*, metrics1P_Ptr);
%pointer_functions(IADLXGPUMetricsSupport*, metricsSupportP_Ptr);
%pointer_functions(IADLXGPUMetricsSupport1*, metricsSupport1P_Ptr);
%pointer_functions(adlx_string, stringP_Ptr);
%pointer_functions(IADLXGPUMetricsList*, gpuMetricsListP_Ptr);

// Interface cast
%define %pointer_cast(TYPE1,TYPE2,NAME)
%inline %{
TYPE2 NAME(TYPE1 x) {
   return (TYPE2) x;
}
%}
%enddef

%pointer_cast(IADLXManualFanTuning**, void**, CastManualFanTuningVoidPtr);
%pointer_cast(IADLXManualPowerTuning**, void**, CastManualPowerTuningVoidPtr);

%pointer_cast(IADLXGPUMetrics**, IADLXGPUMetrics1**, CastGPUMetricsToGPUMetrics1);
%pointer_cast(IADLXGPUMetricsSupport**, IADLXGPUMetricsSupport1**, CastGPUMetricsSupportToGPUMetricsSupport1);