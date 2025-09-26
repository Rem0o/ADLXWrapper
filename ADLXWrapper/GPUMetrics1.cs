using ADLXWrapper.Bindings;

namespace ADLXWrapper
{
    public class GPUMetrics1 : ADLXInterfaceQueryWrapper<IADLXGPUMetrics1>
    {
        private static IADLXGPUMetrics1 QueryInterface(IADLXInterface @interface)
        {
            var ptr = ADLX.new_metrics1P_Ptr();
            @interface.QueryInterface(IADLXGPUMetrics1.IID(), ADLX.CastGPUMetrics1VoidPtr(ptr)).ThrowIfError($"Query {nameof(GPUMetrics1)} interface");
            var value = ADLX.metrics1P_Ptr_value(ptr);
            ADLX.delete_metrics1P_Ptr(ptr);
            return value;
        }


        public GPUMetrics1(IADLXGPUMetrics metrics) : base(metrics, QueryInterface)
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