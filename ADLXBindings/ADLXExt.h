#pragma once
#include "../ADLX/SDK/Include/ADLX.h"
#include "../ADLX/SDK/Include/IGPUManualFanTuning.h"
#include "../ADLX/SDK/Include/IPerformanceMonitoring.h"

struct GPUMetricsStruct {
	adlx_double GPUTemperature;
	adlx_double GPUHotspotTemperature;
	adlx_double GPUTotalBoardPower;
	adlx_int GPUFanSpeed;
};

class ADLXExt
{
public:
	ADLXExt();

	~ADLXExt();


	ADLX_RESULT SetSpeed(adlx::IADLXManualFanTuning* fanTuning, int speed, adlx::IADLXManualFanTuningStateList* list);

	ADLX_RESULT GetCurrentMetrics(adlx::IADLXPerformanceMonitoringServices* services, adlx::IADLXGPU* gpu, GPUMetricsStruct* metricsStruct);

private:
	adlx::IADLXManualFanTuningState* m_oneState = nullptr;

	adlx::IADLXGPUMetrics** m_metricsPtr = nullptr;

	adlx::IADLXGPUMetricsList** m_metricsListPtr = nullptr;

};

