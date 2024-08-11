using ADLXWrapper.Bindings;
using System;

namespace ADLXWrapper
{
    public class ManualPowerTuning : ADLXInterfaceQueryWrapper<IADLXGPUTuningServices>
    {
        public ManualPowerTuning(IADLXInterface nativeInterface, Func<IADLXInterface, IADLXGPUTuningServices> query) : base(nativeInterface, query)
        {
        }

        private static IADLXManualPowerTuning QueryManualPowerTuning(IADLXInterface @interface)
        {
            var manualPowerTuning = ADLX.new_manualPowerTuningP_Ptr();
            @interface.QueryInterface(IADLXManualPowerTuning.IID(), ADLX.CastManualPowerTuningVoidPtr(manualPowerTuning)).ThrowIfError("Query ManualPowerTuning interface");
            var fanTuning = ADLX.manualPowerTuningP_Ptr_value(manualPowerTuning);
            ADLX.delete_manualPowerTuningP_Ptr(manualPowerTuning);
            return fanTuning;
        }

    }
}
