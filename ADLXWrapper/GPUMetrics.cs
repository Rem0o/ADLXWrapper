using ADLXWrapper.Bindings;

namespace ADLXWrapper
{
    public class GPUMetrics : ADLXInterfaceWrapper<IADLXGPUMetrics>
    {
        private SWIGTYPE_p_int _intPtr;
        private SWIGTYPE_p_double _doublePtr;

        public GPUMetrics(SWIGTYPE_p_p_adlx__IADLXGPUMetrics ptr, SWIGTYPE_p_int intPtr, SWIGTYPE_p_double doublePtr) : base(ADLX.metricsP_Ptr_value(ptr))
        {
            _intPtr = intPtr;
            _doublePtr = doublePtr;
        }

        public int GetFanSpeed()
        {
            lock (_intPtr)
            {
                NativeInterface.GPUFanSpeed(_intPtr).ThrowIfError("Get fan speed");
                return ADLX.intP_value(_intPtr);
            }
        }

        public double GetHotspotTemperature()
        {
            lock (_doublePtr)
            {
                NativeInterface.GPUHotspotTemperature(_doublePtr).ThrowIfError("Get hot spot");
                return ADLX.doubleP_value(_doublePtr);
            }
        }

        public double GetGPUTemperature()
        {
            lock (_doublePtr)
            {
                NativeInterface.GPUTemperature(_doublePtr).ThrowIfError("Get GPU temperature");
                return ADLX.doubleP_value(_doublePtr);
            }
        }
    }
}