using ADLXWrapper.Bindings;

namespace ADLXWrapper
{
    public class GPUMetricsSupport : ADLXInterfaceWrapper<IADLXGPUMetricsSupport>
    {
        public GPUMetricsSupport(IADLXGPUMetricsSupport nativeInterface) : base(nativeInterface)
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
    }
}