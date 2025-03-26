#pragma once
#include "../ADLX/SDK/Include/ADLX.h"
#include "../ADLX/SDK/Include/IGPUManualFanTuning.h"
#include "../ADLX/SDK/Include/IPerformanceMonitoring.h"
#include "../ADLX/SDK/Include/IPerformanceMonitoring2.h"


struct GPUMetricsStruct {
	adlx_double GPUTemperature;
	adlx_double GPUHotspotTemperature;
	adlx_double GPUTotalBoardPower;
	adlx_int GPUFanSpeed;
};

struct GPUMetricsStruct1 {
	adlx_double GPUTemperature;
	adlx_double GPUHotspotTemperature;
	adlx_double GPUTotalBoardPower;
	adlx_int GPUFanSpeed;

	adlx_double GPUMemoryTemperature;
	adlx_int NPUFrequency;
	adlx_int NPUActivityLevel;
};

class ADLXExt
{
public:
	ADLXExt();

	~ADLXExt();


	ADLX_RESULT SetSpeed(adlx::IADLXManualFanTuning* fanTuning, int speed, adlx::IADLXManualFanTuningStateList* list);

	ADLX_RESULT GetCurrentMetrics(adlx::IADLXPerformanceMonitoringServices* services, adlx::IADLXGPU* gpu, GPUMetricsStruct* metricsStruct);
	
	ADLX_RESULT GetCurrentMetrics1(adlx::IADLXPerformanceMonitoringServices* services, adlx::IADLXGPU* gpu, GPUMetricsStruct1* metricsStruct1);

private:
	adlx::IADLXManualFanTuningState* m_oneState = nullptr;

	adlx::IADLXGPUMetrics** m_metricsPtr = nullptr;

	adlx::IADLXGPUMetricsList** m_metricsListPtr = nullptr;

};

