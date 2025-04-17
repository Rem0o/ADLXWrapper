using ADLXWrapper.Bindings;

namespace ADLXWrapper
{
    public class GPUMetricsSupport1 : ADLXInterfaceWrapper<IADLXGPUMetricsSupport1>
    {
        public GPUMetricsSupport1(IADLXGPUMetricsSupport1 nativeInterface) : base(nativeInterface)
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
            NativeInterface.IsSupportedGPUUsage(ref value).ThrowIfError("Is Supported Memory temperature");
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
    }
}