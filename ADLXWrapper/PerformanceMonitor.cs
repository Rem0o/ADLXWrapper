using ADLXWrapper.Bindings;
using System;

namespace ADLXWrapper
{
    public class PerformanceMonitor : ADLXInterfaceWrapper<IADLXPerformanceMonitoringServices>
    {
        private readonly ADLXExt _ext;
        private SWIGTYPE_p_p_adlx__IADLXGPUMetrics _metricPtr;
        private SWIGTYPE_p_p_adlx__IADLXGPUMetricsSupport _metricSupportPtr;

        private readonly SWIGTYPE_p_p_adlx__IADLXGPUMetricsList _metricsList;
        private readonly GPUMetricsStruct emptyStruct = default;
        private readonly GPUMetricsStruct1 emptyStruct1 = default;

        public PerformanceMonitor(IADLXPerformanceMonitoringServices performanceMonitor, ADLXExt ext) : base(performanceMonitor)
        {
            _metricPtr = ADLX.new_metricsP_Ptr().DisposeWith(ADLX.delete_metricsP_Ptr, Disposable);
            _metricsList = ADLX.new_gpuMetricsListP_Ptr().DisposeWith(ADLX.delete_gpuMetricsListP_Ptr, Disposable);
            _metricSupportPtr = ADLX.new_metricsSupportP_Ptr().DisposeWith(ADLX.delete_metricsSupportP_Ptr, Disposable);
            _ext = ext;
        }

        public GPUMetricsSupport GetSupportedGPUMetrics(GPU gpu)
        {
            NativeInterface.GetSupportedGPUMetrics(gpu.NativeInterface, _metricSupportPtr).ThrowIfError("Get Supported GPU Metrics");
            return new GPUMetricsSupport(ADLX.metricsSupportP_Ptr_value(_metricSupportPtr));
        }

        public GPUMetricsSupport1 GetSupportedGPUMetrics1(GPU gpu)
        {
            NativeInterface.GetSupportedGPUMetrics(gpu.NativeInterface, _metricSupportPtr).ThrowIfError("Get Supported GPU Metrics1");
            var _metricSupport1Ptr = ADLX.CastGPUMetricsSupportToGPUMetricsSupport1(_metricSupportPtr);

            return new GPUMetricsSupport1(ADLX.metricsSupport1P_Ptr_value(_metricSupport1Ptr));
        }

        public GPUMetrics GetGPUMetrics(GPU gpu)
        {
            NativeInterface.GetCurrentGPUMetrics(gpu.NativeInterface, _metricPtr).ThrowIfError("Get GPU Metrics");
            IADLXGPUMetrics metrics = ADLX.metricsP_Ptr_value(_metricPtr);

            return new GPUMetrics(metrics);
        }

        public GPUMetrics1 GetGPUMetrics1(GPU gpu)
        {
            NativeInterface.GetCurrentGPUMetrics(gpu.NativeInterface, _metricPtr).ThrowIfError("Get GPU Metrics1");
            var _metric1Ptr = ADLX.CastGPUMetricsToGPUMetrics1(_metricPtr);
            IADLXGPUMetrics1 metrics1 = ADLX.metrics1P_Ptr_value(_metric1Ptr);

            return new GPUMetrics1(metrics1);
        }

        public GPUMetricsStruct GetGPUMetricsStruct(GPU gpu)
        {
            GPUMetricsStruct metrics = default;
            var res = _ext.GetCurrentMetrics(NativeInterface, gpu.NativeInterface, ref metrics);

            if (res.HasError() && metrics == emptyStruct)
            {
                throw new ADLXEception(res, "Get GPU Metrics Struct");
            }

            return metrics;
        }

        public GPUMetricsStruct1 GetGPUMetricsStruct1(GPU gpu)
        {
            GPUMetricsStruct1 metrics1 = default;
            var res = _ext.GetCurrentMetrics1(NativeInterface, gpu.NativeInterface, ref metrics1);

            if (res.HasError() && metrics1 == emptyStruct1)
            {
                throw new ADLXEception(res, "Get GPU Metrics Struct");
            }
            return metrics1;
        }


        public IDisposable StartTracking(int samplingIntervalMs, int? maxHistorySize = null)
        {
            NativeInterface.SetSamplingInterval(samplingIntervalMs).ThrowIfError("Sampling interval");
            if (maxHistorySize.HasValue)
                NativeInterface.SetMaxPerformanceMetricsHistorySize(maxHistorySize.Value).ThrowIfError("History Size");

            NativeInterface.StartPerformanceMetricsTracking().ThrowIfError("Start performance tracking");

            return new ActionDisposable(() =>
            {
                NativeInterface.StopPerformanceMetricsTracking().ThrowIfError("Couldn't stop performance metrics tracking");
                NativeInterface.ClearPerformanceMetricsHistory().ThrowIfError("Clear performance metrics");
            });
        }

        public GPUMetrics GetGPUMetricsFromTracking(GPU gpu)
        {
            NativeInterface.GetGPUMetricsHistory(gpu.NativeInterface, 1, 0, _metricsList).ThrowIfError("Couldn't get GPU metrics history");
            var list = ADLX.gpuMetricsListP_Ptr_value(_metricsList);
            list.At(0, _metricPtr).ThrowIfError("GPUMetricsHistory list at");
            list.DisposeInterface();

            return new GPUMetrics(ADLX.metricsP_Ptr_value(_metricPtr));
        }

        public Range GetHistorySizeRange()
        {
            using (ADLX_IntRange range = new ADLX_IntRange())
            {
                NativeInterface.GetMaxPerformanceMetricsHistorySizeRange(range);
                return new Range(range);
            }
        }

        public GPUMetricsStruct GetGPUMetricsStructFromTracking(GPU gpu)
        {
            GPUMetricsStruct metrics = default;
            _ext.GetCurrentMetricsStructFromTracking(NativeInterface, gpu.NativeInterface, ref metrics).ThrowIfError("Couldn't get GPU metrics from tracking");

            return metrics;
        }

        public GPUMetricsStruct1 GetGPUMetricsStruct1FromTracking(GPU gpu)
        {
            GPUMetricsStruct1 metrics1 = default;
            _ext.GetCurrentMetrics1StructFromTracking(NativeInterface, gpu.NativeInterface, ref metrics1).ThrowIfError("Couldn't get GPU metrics 1 from tracking");

            return metrics1;
        }
    }
}