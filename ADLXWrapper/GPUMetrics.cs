using ADLXWrapper.Bindings;

namespace ADLXWrapper
{
    public class GPUMetrics : ADLXInterfaceWrapper<IADLXGPUMetrics>
    {
        public GPUMetrics(IADLXGPUMetrics metrics) : base(metrics)
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
    }
}