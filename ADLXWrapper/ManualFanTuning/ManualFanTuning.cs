using ADLXWrapper.Bindings;

namespace ADLXWrapper
{
    public class ManualFanTuning : ADLXInterfaceQueryWrapper<IADLXManualFanTuning>
    {
        private bool _resetZeroRPM = false;
        private readonly ADLXExt _ext;
        private readonly GPUTuningService _gpuTuningService;
        private readonly GPU _gpu;

        private static IADLXManualFanTuning QueryManualFanTuning(IADLXInterface @interface)
        {
            var manualFanTuningPtr = ADLX.new_manualFanTuningP_Ptr();
            @interface.QueryInterface(IADLXManualFanTuning.IID(), ADLX.CastManualFanTuningVoidPtr(manualFanTuningPtr)).ThrowIfError("Query ManualFanTuning interface");
            var fanTuning = ADLX.manualFanTuningP_Ptr_value(manualFanTuningPtr);
            ADLX.delete_manualFanTuningP_Ptr(manualFanTuningPtr);
            return fanTuning;
        }

        public ManualFanTuning(IADLXInterface @interface, ADLXExt ext, GPUTuningService gpuTuningService, GPU gpu) : base(@interface, QueryManualFanTuning)
        {
            _ext = ext;
            _gpuTuningService = gpuTuningService;
            _gpu = gpu;

            bool isSupported = default;
            SupportsTargetFanSpeed = NativeInterface.IsSupportedTargetFanSpeed(ref isSupported) == ADLX_RESULT.ADLX_OK && isSupported;
            SupportsMinimumFanSpeed = NativeInterface.IsSupportedMinFanSpeed(ref isSupported) == ADLX_RESULT.ADLX_OK && isSupported;

            if (SupportsTargetFanSpeed && SupportsMinimumFanSpeed)
            {
                TargetFanSpeed = new TargetFanSpeed(NativeInterface, _gpuTuningService, _gpu);
            }

            SupportsZeroRPM = NativeInterface.IsSupportedZeroRPM(ref isSupported) == ADLX_RESULT.ADLX_OK && isSupported;
            _resetZeroRPM = SupportsZeroRPM && GetZeroRPMState();

            var listPtr = ADLX.new_fanTuningStateListP_Ptr();
            var tuningStatesResult = NativeInterface.GetFanTuningStates(listPtr);

            SupportsFanTuningStates = tuningStatesResult == ADLX_RESULT.ADLX_OK;

            if (SupportsFanTuningStates)
            {
                var list = ADLX.fanTuningStateListP_Ptr_value(listPtr).DisposeInterfaceWith(Disposable);
                FanTuningStates = new FanTuningStates(list, NativeInterface, _ext, _gpuTuningService, _gpu).DisposeWith(Disposable);
            }

            ADLX.delete_fanTuningStateListP_Ptr(listPtr);
        }

        public bool SupportsTargetFanSpeed { get; }
        public bool SupportsMinimumFanSpeed { get; }
        public bool SupportsFanTuningStates { get; }
        public bool SupportsZeroRPM { get; }

        public TargetFanSpeed TargetFanSpeed { get; }
        public FanTuningStates FanTuningStates { get; }

        public void SetZeroRPM(bool enabled)
        {
            Extensions.ExecuteWithResetRetry(() => NativeInterface.SetZeroRPMState(enabled), () => _gpuTuningService.ResetToFactory(_gpu), "SetZeroRPMState");
        }

        public bool GetZeroRPMState()
        {
            bool zeroRpm = default;
            NativeInterface.GetZeroRPMState(ref zeroRpm).ThrowIfError("Couldn't get zero RPM state");
            return zeroRpm;
        }

        public void Reset()
        {
            if (SupportsZeroRPM)
                SetZeroRPM(_resetZeroRPM);

            if (SupportsFanTuningStates)
                FanTuningStates.Reset();
        }
    }
}
