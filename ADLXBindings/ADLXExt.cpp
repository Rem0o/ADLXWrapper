#include "ADLXExt.h"
using namespace adlx;

ADLXExt::ADLXExt()
{
	m_metricsPtr = new adlx::IADLXGPUMetrics * ();
	m_metricsListPtr = new adlx::IADLXGPUMetricsList * ();
}

ADLXExt::~ADLXExt()
{
	delete m_metricsPtr;
	delete m_metricsListPtr;
	m_metricsListPtr = nullptr;
	m_metricsPtr = nullptr;
	m_oneState = nullptr;
}

ADLX_RESULT ADLXExt::SetSpeed(adlx::IADLXManualFanTuning* fanTuning, int speed, adlx::IADLXManualFanTuningStateList* list)
{
	ADLX_RESULT res;
	for (unsigned int i = list->Begin(); i < list->End(); i++)
	{
		res = list->At(i, &m_oneState);
		if (!ADLX_SUCCEEDED(res)) {
			return res;
		}

		res = m_oneState->SetFanSpeed(speed);
		m_oneState->Release();

		if (!ADLX_SUCCEEDED(res)) {
			return res;
		}
	}

	return fanTuning->SetFanTuningStates(list);
}

ADLX_RESULT ADLXExt::GetCurrentMetrics(adlx::IADLXPerformanceMonitoringServices* services, adlx::IADLXGPU* gpu, GPUMetricsStruct* metricsStruct)
{
	ADLX_RESULT res = ADLX_OK;

	res = services->GetCurrentGPUMetrics(gpu, m_metricsPtr);
	if (!ADLX_SUCCEEDED(res))
	{
		return res;
	}

	IADLXGPUMetrics* current = *m_metricsPtr;

	res = current->GPUFanSpeed(&metricsStruct->GPUFanSpeed);
	res = current->GPUHotspotTemperature(&metricsStruct->GPUHotspotTemperature);
	res = current->GPUTemperature(&metricsStruct->GPUTemperature);
	res = current->GPUTotalBoardPower(&metricsStruct->GPUTotalBoardPower);

	current->Release();

	return res;
}
