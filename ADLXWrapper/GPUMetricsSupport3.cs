using ADLXWrapper.Bindings;

namespace ADLXWrapper
{
    public class GPUMetricsSupport3 : ADLXInterfaceQueryWrapper<IADLXGPUMetricsSupport3>
    {
        private static IADLXGPUMetricsSupport3 QueryInterface(IADLXInterface @interface)
        {
            var ptr = ADLX.new_adlxInterfaceP_Ptr();
            var voidPtr = new SWIGTYPE_p_p_void(SWIGTYPE_p_p_adlx__IADLXInterface.getCPtr(ptr).Handle, false);
            @interface.QueryInterface(IADLXGPUMetricsSupport3.IID(), voidPtr).ThrowIfError($"Query {nameof(GPUMetricsSupport3)} interface");
            var value = ADLX.adlxInterfaceP_Ptr_value(ptr);
            ADLX.delete_adlxInterfaceP_Ptr(ptr);
            return new IADLXGPUMetricsSupport3(IADLXInterface.getCPtr(value).Handle, false);
        }

        public GPUMetricsSupport3(IADLXGPUMetricsSupport @interface) : base(@interface, QueryInterface)
        {
        }

        public bool IsSupportedGPUUsage()
        {
            bool value = false;
            NativeInterface.IsSupportedGPUUsage(ref value).ThrowIfError("Is Supported GPU Usage");
            return value;
        }

        public bool IsSupportedGpuTotalBoardPower()
        {
            bool value = false;
            NativeInterface.IsSupportedGPUTotalBoardPower(ref value).ThrowIfError("Is Supported GPU total board Power");
            return value;
        }

        public bool IsSupportedGPUTemperature()
        {
            bool value = false;
            NativeInterface.IsSupportedGPUTemperature(ref value).ThrowIfError("Is Supported GPU Temperature");
            return value;
        }

        public bool IsSupportedGPUHotspotTemperature()
        {
            bool value = false;
            NativeInterface.IsSupportedGPUHotspotTemperature(ref value).ThrowIfError("Is Supported GPU Hotspot Temperature");
            return value;
        }

        public bool IsSupportedFanSpeed()
        {
            bool value = false;
            NativeInterface.IsSupportedGPUFanSpeed(ref value).ThrowIfError("Is Supported Fan Speed");
            return value;
        }

        public bool IsSupportedGPUMemoryTemperature()
        {
            bool value = false;
            NativeInterface.IsSupportedGPUMemoryTemperature(ref value).ThrowIfError("Is Supported Memory temperature");
            return value;
        }

        public bool IsSupportedGPUIntakeTemperature()
        {
            bool value = false;
            NativeInterface.IsSupportedGPUIntakeTemperature(ref value).ThrowIfError("Is Supported Intake Temperature");
            return value;
        }

        public bool IsSupportedNPUFrequency()
        {
            bool value = false;
            NativeInterface.IsSupportedNPUFrequency(ref value).ThrowIfError("Is Supported NPU frequency");
            return value;
        }

        public bool IsSupportedNPUActivityLevel()
        {
            bool value = false;
            NativeInterface.IsSupportedNPUActivityLevel(ref value).ThrowIfError("Is Supported NPU activity level");
            return value;
        }

        public bool IsSupportedFanDuty()
        {
            bool value = false;
            NativeInterface.IsSupportedGPUFanDuty(ref value).ThrowIfError("Is Supported Fan Duty");
            return value;
        }
    }
}