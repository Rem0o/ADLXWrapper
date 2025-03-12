using ADLXWrapper.Bindings;

namespace ADLXWrapper
{
    public class PerformanceMonitor : ADLXInterfaceWrapper<IADLXPerformanceMonitoringServices>
    {
        private readonly ADLXExt _ext;
        private SWIGTYPE_p_p_adlx__IADLXGPUMetrics _metricPtr;
        private SWIGTYPE_p_p_adlx__IADLXGPUMetricsSupport _metricSupportPtr;
        private SWIGTYPE_p_double _doublePtr;
        private SWIGTYPE_p_int _intPtr;
        private readonly SWIGTYPE_p_p_adlx__IADLXGPUMetricsList _metricsList;
        private readonly GPUMetricsStruct emptyStruct = default;

        public PerformanceMonitor(IADLXPerformanceMonitoringServices performanceMonitor, ADLXExt ext) : base(performanceMonitor)
        {
            _metricPtr = ADLX.new_metricsP_Ptr().DisposeWith(ADLX.delete_metricsP_Ptr, Disposable);
            _doublePtr = ADLX.new_doubleP().DisposeWith(ADLX.delete_doubleP, Disposable);
            _intPtr = ADLX.new_intP().DisposeWith(ADLX.delete_intP, Disposable);
            _metricsList = ADLX.new_gpuMetricsListP_Ptr().DisposeWith(ADLX.delete_gpuMetricsListP_Ptr, Disposable);
            _metricSupportPtr = ADLX.new_metricsSupportP_Ptr().DisposeWith(ADLX.delete_metricsSupportP_Ptr, Disposable);
            _ext = ext;
        }

        public GPUMetricsSupport GetSupportedGPUMetrics(GPU gpu)
        {
            NativeInterface.GetSupportedGPUMetrics(gpu.NativeInterface, _metricSupportPtr).ThrowIfError("Get Supported GPU Metrics");
            return new GPUMetricsSupport(ADLX.metricsSupportP_Ptr_value(_metricSupportPtr));
        }

        public GPUMetrics GetGPUMetrics(GPU gpu)
        {
            NativeInterface.GetCurrentGPUMetrics(gpu.NativeInterface, _metricPtr).ThrowIfError("Get GPU Metrics");
            IADLXGPUMetrics metrics = ADLX.metricsP_Ptr_value(_metricPtr);

            return new GPUMetrics(metrics, _intPtr, _doublePtr);
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

        /*
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

            return new GPUMetrics(_metricPtr, _intPtr, _doublePtr);
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
            _ext.GetLatestMetricsFromTracking(NativeInterface, gpu.NativeInterface, ref metrics);

            return metrics;
        }
        */
    }
}