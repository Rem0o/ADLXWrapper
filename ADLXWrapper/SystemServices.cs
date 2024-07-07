using ADLXWrapper.Bindings;
using System.Collections.Generic;

namespace ADLXWrapper
{
    public class SystemServices : Wrapper<IADLXSystem>
    {
        private readonly ADLXExt _ext;

        public SystemServices(IADLXSystem iADLXSystem, ADLXExt ext) : base(iADLXSystem)
        {
            _ext = ext;
        }

        public IReadOnlyList<GPU> GetGPUs()
        {
            var gpuListPtr = ADLX.new_gpuListP_Ptr();
            NativeInterface.GetGPUs(gpuListPtr).ThrowIfError("Couldn't get GPU list");

            var gpuList = ADLX.gpuListP_Ptr_value(gpuListPtr);

            List<GPU> gpus = new List<GPU>();
            SWIGTYPE_p_p_adlx__IADLXGPU gpuPtr = ADLX.new_gpuP_Ptr();
            for (uint i = gpuList.Begin(); i < gpuList.End(); i++)
            {
                gpuList.At(i, gpuPtr).ThrowIfError($"Couldn't get gpu at index {i}");
                gpus.Add(new GPU(ADLX.gpuP_Ptr_value(gpuPtr)));
            }
            ADLX.delete_gpuP_Ptr(gpuPtr);
            gpuList.DisposeInterface();
            ADLX.delete_gpuListP_Ptr(gpuListPtr);

            return gpus;
        }

        public GPUTuningService GetGPUTuningService()
        {
            var ptr = ADLX.new_gpuTuningP_Ptr();
            NativeInterface.GetGPUTuningServices(ptr).ThrowIfError("GetGPUTuningService");
            var tuning = ADLX.gpuTuningP_Ptr_value(ptr);
            return new GPUTuningService(tuning, _ext);
        }

        public PerformanceMonitor GetPerformanceMonitor()
        {
            var ptr = ADLX.new_performanceP_Ptr();
            NativeInterface.GetPerformanceMonitoringServices(ptr).ThrowIfError("GetPerformanceMonitor");
            var performanceMonitor = ADLX.performanceP_Ptr_value(ptr);
            return new PerformanceMonitor(performanceMonitor, _ext);
        }
    }
}
