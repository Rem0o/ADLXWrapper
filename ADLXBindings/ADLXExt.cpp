#include "ADLXExt.h"
using namespace adlx;

ADLXExt::ADLXExt()
{
}

ADLXExt::~ADLXExt()
{
}

ADLX_RESULT ADLXExt::SetSpeed(adlx::IADLXManualFanTuning* fanTuning, int speed, adlx::IADLXManualFanTuningStateList* list)
{
	ADLX_RESULT res;
	for (unsigned int i = list->Begin(); i < list->End(); i++)
	{
		IADLXManualFanTuningStatePtr oneState;
		res = list->At(i, &oneState);
		if (!ADLX_SUCCEEDED(res)) {
			return res;
		}

		res = oneState->SetFanSpeed(speed);

		if (!ADLX_SUCCEEDED(res)) {
			return res;
		}
	}

	return fanTuning->SetFanTuningStates(list);
}

ADLX_RESULT ADLXExt::GetCurrentMetrics(adlx::IADLXPerformanceMonitoringServices* services, adlx::IADLXGPU* gpu, GPUMetricsStruct* metricsStruct)
{
	ADLX_RESULT res = ADLX_OK;
	IADLXGPUMetricsPtr current;

	res = services->GetCurrentGPUMetrics(gpu, &current);
	if (!ADLX_SUCCEEDED(res))
	{
		return res;
	}

	if (!current)
	{
		return ADLX_FAIL;
	}

	res = current->GPUFanSpeed(&metricsStruct->GPUFanSpeed);
	res = current->GPUHotspotTemperature(&metricsStruct->GPUHotspotTemperature);
	res = current->GPUTemperature(&metricsStruct->GPUTemperature);
	res = current->GPUTotalBoardPower(&metricsStruct->GPUTotalBoardPower);
	res = current->GPUIntakeTemperature(&metricsStruct->GPUIntakeTemperature);

	return res;
}

ADLX_RESULT ADLXExt::GetCurrentMetrics3(adlx::IADLXPerformanceMonitoringServices* services, adlx::IADLXGPU* gpu, GPUMetricsStruct3* metricsStruct3)
{
	ADLX_RESULT res = ADLX_OK;
	IADLXGPUMetricsPtr metrics;

	res = services->GetCurrentGPUMetrics(gpu, &metrics);
	if (!ADLX_SUCCEEDED(res))
	{
		return res;
	}

	IADLXGPUMetrics3Ptr current3(metrics);

	if (!current3)
	{
		return ADLX_NOT_SUPPORTED;
	}

	res = current3->GPUFanSpeed(&metricsStruct3->GPUFanSpeed);
	res = current3->GPUHotspotTemperature(&metricsStruct3->GPUHotspotTemperature);
	res = current3->GPUTemperature(&metricsStruct3->GPUTemperature);
	res = current3->GPUTotalBoardPower(&metricsStruct3->GPUTotalBoardPower);
	res = current3->GPUIntakeTemperature(&metricsStruct3->GPUIntakeTemperature);
	res = current3->GPUMemoryTemperature(&metricsStruct3->GPUMemoryTemperature);
	res = current3->NPUFrequency(&metricsStruct3->NPUFrequency);
	res = current3->NPUActivityLevel(&metricsStruct3->NPUActivityLevel);
	res = current3->GPUFanDuty(&metricsStruct3->GPUFanDuty);

	return res;
}

ADLX_RESULT ADLXExt::GetCurrentMetrics1(adlx::IADLXPerformanceMonitoringServices* services, adlx::IADLXGPU* gpu, GPUMetricsStruct1* metricsStruct1)
{
	ADLX_RESULT res = ADLX_OK;
	IADLXGPUMetricsPtr metrics;

	res = services->GetCurrentGPUMetrics(gpu, &metrics);
	if (!ADLX_SUCCEEDED(res))
	{
		return res;
	}

	IADLXGPUMetrics1Ptr current1(metrics);

	if (!current1)
	{
		return ADLX_NOT_SUPPORTED;
	}

	res = current1->GPUFanSpeed(&metricsStruct1->GPUFanSpeed);
	res = current1->GPUHotspotTemperature(&metricsStruct1->GPUHotspotTemperature);
	res = current1->GPUTemperature(&metricsStruct1->GPUTemperature);
	res = current1->GPUTotalBoardPower(&metricsStruct1->GPUTotalBoardPower);
	res = current1->GPUIntakeTemperature(&metricsStruct1->GPUIntakeTemperature);
	res = current1->GPUMemoryTemperature(&metricsStruct1->GPUMemoryTemperature);
	res = current1->NPUFrequency(&metricsStruct1->NPUFrequency);
	res = current1->NPUActivityLevel(&metricsStruct1->NPUActivityLevel);

	return res;
}

ADLX_RESULT ADLXExt::GetCurrentMetrics3StructFromTracking(adlx::IADLXPerformanceMonitoringServices* services, adlx::IADLXGPU* gpu, GPUMetricsStruct3* metricsStruct)
{
	IADLXGPUMetricsListPtr metricsList;
	ADLX_RESULT res = services->GetGPUMetricsHistory(gpu, 0, 0, &metricsList);
	if (!ADLX_SUCCEEDED(res))
	{
		return res;
	}

	if (metricsList->Size() == 0)
	{
		return ADLX_FAIL;
	}

	IADLXGPUMetricsPtr metrics;
	res = metricsList->At(0, &metrics);

	if (!ADLX_SUCCEEDED(res))
	{
		return res;
	}

	IADLXGPUMetrics3Ptr current(metrics);
	if (!current)
	{
		return ADLX_NOT_SUPPORTED;
	}

	current->GPUFanSpeed(&metricsStruct->GPUFanSpeed);
	current->GPUHotspotTemperature(&metricsStruct->GPUHotspotTemperature);
	current->GPUTemperature(&metricsStruct->GPUTemperature);
	current->GPUTotalBoardPower(&metricsStruct->GPUTotalBoardPower);
	current->GPUMemoryTemperature(&metricsStruct->GPUMemoryTemperature);
	current->GPUIntakeTemperature(&metricsStruct->GPUIntakeTemperature);
	current->NPUFrequency(&metricsStruct->NPUFrequency);
	current->NPUActivityLevel(&metricsStruct->NPUActivityLevel);
	current->GPUFanDuty(&metricsStruct->GPUFanDuty);

	return res;
}

ADLX_RESULT ADLXExt::GetCurrentMetricsStructFromTracking(adlx::IADLXPerformanceMonitoringServices* services, adlx::IADLXGPU* gpu, GPUMetricsStruct* metricsStruct)
{
	IADLXGPUMetricsListPtr metricsList;
	ADLX_RESULT res = services->GetGPUMetricsHistory(gpu, 0, 0, &metricsList);
	if (!ADLX_SUCCEEDED(res))
	{
		return res;
	}

	if (metricsList->Size() == 0)
	{
		return ADLX_FAIL;
	}

	IADLXGPUMetricsPtr current;
	res = metricsList->At(0, &current);

	if (!ADLX_SUCCEEDED(res))
	{
		return res;
	}

	if (!current)
	{
		return ADLX_FAIL;
	}

	current->GPUFanSpeed(&metricsStruct->GPUFanSpeed);
	current->GPUHotspotTemperature(&metricsStruct->GPUHotspotTemperature);
	current->GPUTemperature(&metricsStruct->GPUTemperature);
	current->GPUTotalBoardPower(&metricsStruct->GPUTotalBoardPower);
	current->GPUIntakeTemperature(&metricsStruct->GPUIntakeTemperature);

	return res;
}

ADLX_RESULT ADLXExt::GetCurrentMetrics1StructFromTracking(adlx::IADLXPerformanceMonitoringServices* services, adlx::IADLXGPU* gpu, GPUMetricsStruct1* metricsStruct)
{
	IADLXGPUMetricsListPtr metricsList;
	ADLX_RESULT res = services->GetGPUMetricsHistory(gpu, 0, 0, &metricsList);
	if (!ADLX_SUCCEEDED(res))
	{
		return res;
	}

	if (metricsList->Size() == 0)
	{
		return ADLX_FAIL;
	}

	IADLXGPUMetricsPtr metrics;
	res = metricsList->At(0, &metrics);

	if (!ADLX_SUCCEEDED(res))
	{
		return res;
	}

	IADLXGPUMetrics1Ptr current(metrics);
	if (!current)
	{
		return ADLX_NOT_SUPPORTED;
	}

	current->GPUFanSpeed(&metricsStruct->GPUFanSpeed);
	current->GPUHotspotTemperature(&metricsStruct->GPUHotspotTemperature);
	current->GPUTemperature(&metricsStruct->GPUTemperature);
	current->GPUTotalBoardPower(&metricsStruct->GPUTotalBoardPower);
	current->GPUMemoryTemperature(&metricsStruct->GPUMemoryTemperature);
	current->GPUIntakeTemperature(&metricsStruct->GPUIntakeTemperature);
	current->NPUFrequency(&metricsStruct->NPUFrequency);
	current->NPUActivityLevel(&metricsStruct->NPUActivityLevel);

	return res;
}