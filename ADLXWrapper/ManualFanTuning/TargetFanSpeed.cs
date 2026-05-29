using ADLXWrapper.Bindings;

namespace ADLXWrapper
{
    public class TargetFanSpeed
    {
        private readonly IADLXManualFanTuning _manualFanTuning;
        private readonly GPUTuningService _gpuTuningService;
        private readonly GPU _gpu;

        public TargetFanSpeed(IADLXManualFanTuning manualFanTuning, GPUTuningService gpuTuningService, GPU gpu)
        {
            _manualFanTuning = manualFanTuning;
            _gpuTuningService = gpuTuningService;
            _gpu = gpu;

            var speedRangePtr = ADLX.new_adlx_intRangeP();
            _manualFanTuning.GetTargetFanSpeedRange(speedRangePtr).ThrowIfError("Couldn't get fan speed range.");
            using (ADLX_IntRange speedRange = ADLX.adlx_intRangeP_value(speedRangePtr))
                TargetFanSpeedRange = new Range(speedRange);

            _manualFanTuning.GetMinFanSpeedRange(speedRangePtr).ThrowIfError("Couldn't get minimum fan speed range.");
            using (ADLX_IntRange speedRange = ADLX.adlx_intRangeP_value(speedRangePtr))
                MinimumFanSpeedRange = new Range(speedRange);

            ADLX.delete_adlx_intRangeP(speedRangePtr);
        }

        public Range TargetFanSpeedRange { get; }
        public Range MinimumFanSpeedRange { get; }

        public void SetTargetFanSpeed(int speedRPM)
        {
            Extensions.ExecuteWithResetRetry(
                () => _manualFanTuning.SetTargetFanSpeed(speedRPM),
                () => _gpuTuningService.ResetToFactory(_gpu),
                $"Couldn't set fan speed with targetFanSpeed {speedRPM}, range ({TargetFanSpeedRange.Min}, {TargetFanSpeedRange.Max})");
        }

        public void SetMinimumFanSpeed(int speedRPM)
        {
            Extensions.ExecuteWithResetRetry(
                () => _manualFanTuning.SetMinFanSpeed(speedRPM),
                () => _gpuTuningService.ResetToFactory(_gpu),
                $"Couldn't set fan speed with minimumFanSpeed {speedRPM}, range ({MinimumFanSpeedRange.Min}, {MinimumFanSpeedRange.Max})");
        }
    }
}
