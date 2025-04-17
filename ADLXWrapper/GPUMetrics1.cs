using ADLXWrapper.Bindings;

namespace ADLXWrapper
{
    public class GPUMetrics1 : ADLXInterfaceWrapper<IADLXGPUMetrics1>
    {
        public GPUMetrics1(IADLXGPUMetrics1 metrics) : base(metrics)
        {
        }

        public double GetGPUTotalBoardPower()
        {
            double doubleValue = 0;
            NativeInterface.GPUTotalBoardPower(ref doubleValue).ThrowIfError("Get total board power");
            return doubleValue;
        }

        public double GetGPUPowerUsage()
        {
            double doubleValue = 0;
            NativeInterface.GPUPower(ref doubleValue).ThrowIfError("Get power usage");
            return doubleValue;
        }

        public int GetFanSpeed()
        {
            int intValue = 0;
            NativeInterface.GPUFanSpeed(ref intValue).ThrowIfError("Get fan speed");
            return intValue;
        }

        public double GetHotspotTemperature()
        {
            double doubleValue = 0;
            NativeInterface.GPUHotspotTemperature(ref doubleValue).ThrowIfError("Get hot spot");
            return doubleValue;
        }

        public double GetGPUTemperature()
        {
            double doubleValue = 0;
            NativeInterface.GPUTemperature(ref doubleValue).ThrowIfError("Get GPU temperature");
            return doubleValue;
        }

        public double GetGPUMemoryTemperature()
        {
            double doubleValue = 0;
            NativeInterface.GPUMemoryTemperature(ref doubleValue).ThrowIfError("Get memory temperature power");
            return doubleValue;
        }

        public int GetNPUFrequency()
        {
            int intValue = 0;
            NativeInterface.NPUFrequency(ref intValue).ThrowIfError("Get NPU frequency");
            return intValue;
        }

        public int GetNPUActivityLevel()
        {
            int intValue = 0;
            NativeInterface.NPUActivityLevel(ref intValue).ThrowIfError("Get NPU activity level");
            return intValue;
        }
    }
}