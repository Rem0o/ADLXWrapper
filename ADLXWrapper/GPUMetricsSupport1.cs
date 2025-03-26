using ADLXWrapper.Bindings;

namespace ADLXWrapper
{
    public class GPUMetricsSupport1 : ADLXInterfaceWrapper<IADLXGPUMetricsSupport1>
    {
        private SWIGTYPE_p_bool _boolPtr;

        public GPUMetricsSupport1(IADLXGPUMetricsSupport1 nativeInterface) : base(nativeInterface)
        {
            _boolPtr = ADLX.new_boolP().DisposeWith(ADLX.delete_boolP, Disposable);
        }

        public bool IsSupportedGPUUsage()
        {
            NativeInterface.IsSupportedGPUUsage(_boolPtr).ThrowIfError("Is Supported GPU Usage");
            return ADLX.boolP_value(_boolPtr);
        }

        public bool IsSupportedGpuTotalBoardPower()
        {
            NativeInterface.IsSupportedGPUTotalBoardPower(_boolPtr).ThrowIfError("Is Supported GPU total board Power");
            return ADLX.boolP_value(_boolPtr);
        }

        public bool IsSupportedGPUTemperature()
        {
            NativeInterface.IsSupportedGPUTemperature(_boolPtr).ThrowIfError("Is Supported GPU Temperature");
            return ADLX.boolP_value(_boolPtr);
        }

        public bool IsSupportedGPUHotspotTemperature()
        {
            NativeInterface.IsSupportedGPUHotspotTemperature(_boolPtr).ThrowIfError("Is Supported GPU Hotspot Temperature");
            return ADLX.boolP_value(_boolPtr);
        }

        public bool IsSupportedFanSpeed()
        {
            NativeInterface.IsSupportedGPUFanSpeed(_boolPtr).ThrowIfError("Is Supported Fan Speed");
            return ADLX.boolP_value(_boolPtr);
        }

        public bool IsSupportedGPUMemoryTemperature()
        {
            NativeInterface.IsSupportedGPUUsage(_boolPtr).ThrowIfError("Is Supported Memory temperature");
            return ADLX.boolP_value(_boolPtr);
        }

        public bool IsSupportedNPUFrequency()
        {
            NativeInterface.IsSupportedNPUFrequency(_boolPtr).ThrowIfError("Is Supported NPU frequency");
            return ADLX.boolP_value(_boolPtr);
        }

        public bool IsSupportedNPUActivityLevel()
        {
            NativeInterface.IsSupportedNPUActivityLevel(_boolPtr).ThrowIfError("Is Supported NPU activity level");
            return ADLX.boolP_value(_boolPtr);
        }
    }
}