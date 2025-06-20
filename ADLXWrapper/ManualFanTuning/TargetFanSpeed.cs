using ADLXWrapper.Bindings;

namespace ADLXWrapper
{
    public class TargetFanSpeed
    {
        private readonly IADLXManualFanTuning _manualFanTuning;

        public TargetFanSpeed(IADLXManualFanTuning manualFanTuning)
        {
            _manualFanTuning = manualFanTuning;

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
            _manualFanTuning.SetTargetFanSpeed(speedRPM)
                .ThrowIfError($"Couldn't set fan speed with targetFanSpeed {speedRPM}, range ({TargetFanSpeedRange.Min}, {TargetFanSpeedRange.Max})");
        }

        public void SetMinimumFanSpeed(int speedRPM)
        {
            _manualFanTuning.SetMinFanSpeed(speedRPM)
                .ThrowIfError($"Couldn't set fan speed with minimumFanSpeed {speedRPM}, range ({MinimumFanSpeedRange.Min}, {MinimumFanSpeedRange.Max})");
        }
    }
}
