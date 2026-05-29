using ADLXWrapper.Bindings;

namespace ADLXWrapper
{
    public class GPUMetrics3 : ADLXInterfaceQueryWrapper<IADLXGPUMetrics3>
    {
        private static IADLXGPUMetrics3 QueryInterface(IADLXInterface @interface)
        {
            var ptr = ADLX.new_metrics3P_Ptr();
            @interface.QueryInterface(IADLXGPUMetrics3.IID(), ADLX.CastGPUMetrics3VoidPtr(ptr)).ThrowIfError($"Query {nameof(GPUMetrics3)} interface");
            var value = ADLX.metrics3P_Ptr_value(ptr);
            ADLX.delete_metrics3P_Ptr(ptr);
            return value;
        }


        public GPUMetrics3(IADLXGPUMetrics metrics) : base(metrics, QueryInterface)
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

        public int GetFanDuty()
        {
            int intValue = 0;
            NativeInterface.GPUFanDuty(ref intValue).ThrowIfError("Get fan duty");
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

        public double GetGPUIntakeTemperature()
        {
            double doubleValue = 0;
            NativeInterface.GPUIntakeTemperature(ref doubleValue).ThrowIfError("Get GPU intake temperature");
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