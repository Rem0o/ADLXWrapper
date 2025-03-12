using ADLXWrapper.Bindings;

namespace ADLXWrapper
{
    public class GPUMetrics : ADLXInterfaceWrapper<IADLXGPUMetrics>
    {
        private SWIGTYPE_p_int _intPtr;
        private SWIGTYPE_p_double _doublePtr;

        public GPUMetrics(IADLXGPUMetrics metrics, SWIGTYPE_p_int intPtr, SWIGTYPE_p_double doublePtr) : base(metrics)
        {
            _intPtr = intPtr;
            _doublePtr = doublePtr;
        }

        public double GetGPUTotalBoardPower()
        {
            lock (_doublePtr)
            {
                NativeInterface.GPUTotalBoardPower(_doublePtr).ThrowIfError("Get total board power");
                return ADLX.doubleP_value(_doublePtr);
            }
        }

        public double GetGPUPowerUsage()
        {
            lock (_doublePtr)
            {
                NativeInterface.GPUPower(_doublePtr).ThrowIfError("Get power usage");
                return ADLX.doubleP_value(_doublePtr);
            }
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