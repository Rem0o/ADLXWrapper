using ADLXWrapper.Bindings;

namespace ADLXWrapper
{
    public class GPUTuningService : ADLXInterfaceWrapper<IADLXGPUTuningServices>
    {
        private readonly ADLXExt _ext;

        public GPUTuningService(IADLXGPUTuningServices services, ADLXExt ext) : base(services) => _ext = ext;

        public bool IsManualFanTuningSupported(GPU gpu)
        {
            bool value = false;
            NativeInterface.IsSupportedManualFanTuning(gpu.NativeInterface, ref value).ThrowIfError("IsSupportedManualFanTuning");

            return value;
        }

        public ManualFanTuning GetManualFanTuning(GPU gpu)
        {
            var interfacePtr = ADLX.new_adlxInterfaceP_Ptr();
            NativeInterface.GetManualFanTuning(gpu.NativeInterface, interfacePtr).ThrowIfError("GetManualFanTuning");
            var @interface = ADLX.adlxInterfaceP_Ptr_value(interfacePtr);
            ADLX.delete_adlxInterfaceP_Ptr(interfacePtr);

            return new ManualFanTuning(@interface, _ext);
        }

        public ManualPowerTuning GetPowerTuning(GPU gpu)
        {
            var interfacePtr = ADLX.new_adlxInterfaceP_Ptr();
            NativeInterface.GetManualPowerTuning(gpu.NativeInterface, interfacePtr).ThrowIfError("GetManualPowerTuning");
            var @interface = ADLX.adlxInterfaceP_Ptr_value(interfacePtr);
            ADLX.delete_adlxInterfaceP_Ptr(interfacePtr);

            return new ManualPowerTuning(@interface, null);
        }
    }
}
