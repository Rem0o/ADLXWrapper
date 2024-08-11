using ADLXWrapper.Bindings;
using System;
using System.Linq;

namespace ADLXWrapper
{

    public class ManualFanTuning : ADLXInterfaceQueryWrapper<IADLXManualFanTuning>
    {
        private IADLXManualFanTuningStateList _list;
        private IADLXManualFanTuningState[] _states;
        private (int t, int s)[] _resetList;
        private bool _resetZeroRPM = false;
        private SWIGTYPE_p_int _intPtr;
        private SWIGTYPE_p_bool _boolPtr;
        private readonly IADLXInterface _interface;
        private readonly ADLXExt _ext;

        private static IADLXManualFanTuning QueryManualFanTuning(IADLXInterface @interface)
        {
            var manualFanTuningPtr = ADLX.new_manualFanTuningP_Ptr();
            @interface.QueryInterface(IADLXManualFanTuning.IID(), ADLX.CastManualFanTuningVoidPtr(manualFanTuningPtr)).ThrowIfError("Query ManualFanTuning interface");
            var fanTuning = ADLX.manualFanTuningP_Ptr_value(manualFanTuningPtr);
            ADLX.delete_manualFanTuningP_Ptr(manualFanTuningPtr);
            return fanTuning;
        }

        public ManualFanTuning(IADLXInterface @interface, ADLXExt ext) : base(@interface, QueryManualFanTuning)
        {
            _interface = @interface.DisposeWith(Disposable);
            _ext = ext;

            _boolPtr = ADLX.new_boolP().DisposeWith(ADLX.delete_boolP, Disposable);
            SupportsTargetFanSpeed = NativeInterface.IsSupportedTargetFanSpeed(_boolPtr) == ADLX_RESULT.ADLX_OK && ADLX.boolP_value(_boolPtr);
            SupportsZeroRPM = NativeInterface.IsSupportedZeroRPM(_boolPtr) == ADLX_RESULT.ADLX_OK && ADLX.boolP_value(_boolPtr);

            _intPtr = ADLX.new_intP().DisposeWith(ADLX.delete_intP, Disposable);
            var listPtr = ADLX.new_fanTuningStateListP_Ptr();
            NativeInterface.GetFanTuningStates(listPtr).ThrowIfError("Couldn't get fan tuning states");
            _list = ADLX.fanTuningStateListP_Ptr_value(listPtr).DisposeInterfaceWith(Disposable);
            ADLX.delete_fanTuningStateListP_Ptr(listPtr);

            _resetZeroRPM = SupportsZeroRPM && GetZeroRPMState();

            var statePtr = ADLX.new_fanTuningStateP_Ptr();
            _states = Enumerable.Range((int)_list.Begin(), (int)(_list.End() - _list.Begin())).Select(i =>
            {
                _list.At((uint)i, statePtr).ThrowIfError($"Couldn't get state {i}");
                return ADLX.fanTuningStateP_Ptr_value(statePtr).DisposeInterfaceWith(Disposable);
            }).ToArray();
            ADLX.delete_fanTuningStateP_Ptr(statePtr);

            _resetList = _states.Select(x =>
            {
                x.GetTemperature(_intPtr).ThrowIfError("GetTemperature");
                var t = ADLX.intP_value(_intPtr);
                x.GetFanSpeed(_intPtr).ThrowIfError("GetFanSpeed");
                var s = ADLX.intP_value(_intPtr);
                return (t, s);
            }).ToArray();

            var speedRangePtr = ADLX.new_adlx_intRangeP();
            var tempRangePtr = ADLX.new_adlx_intRangeP();
            NativeInterface.GetFanTuningRanges(speedRangePtr, tempRangePtr).ThrowIfError("Couldn't get fan speed range.");

            using (ADLX_IntRange speedRange = ADLX.adlx_intRangeP_value(speedRangePtr))
                SpeedRange = new Range(speedRange);

            using (ADLX_IntRange tempRange = ADLX.adlx_intRangeP_value(tempRangePtr))
                TempRange = new Range(tempRange);

            ADLX.delete_adlx_intRangeP(speedRangePtr);
            ADLX.delete_adlx_intRangeP(tempRangePtr);
        }

        public bool SupportsTargetFanSpeed { get; }

        public bool SupportsZeroRPM { get; }

        public Range SpeedRange { get; }

        public Range TempRange { get; }

        public void Reset()
        {
            if (SupportsZeroRPM)
                SetZeroRPM(_resetZeroRPM);

            SetFanTuningStates(_resetList);
        }

        public void SetTargetFanSpeed(int speedRPM)
        {
            NativeInterface.SetTargetFanSpeed(speedRPM)
                .ThrowIfError($"Couldn't set fan speed with targetFanSpeed {speedRPM}, range ({SpeedRange.Min},{SpeedRange.Max})");
        }

        public void SetFanTuningStates(int speedPercent)
        {
            for (int i = 0; i < _states.Length; i++)
                _states[i].SetFanSpeed(speedPercent).ThrowIfError("Set fan speed");

            NativeInterface.SetFanTuningStates(_list)
                .ThrowIfError($"Couldn't set fan speed with tuning states {speedPercent} %");
        }

        public void SetFanTuningStates2(int speedPercent)
        {
            _ext.SetSpeed(this.NativeInterface, speedPercent, _list).ThrowIfError($"Couldn't set fan speed with tuning states {speedPercent} %");
        }

        public void SetFanTuningStates(int[] speedPercent)
        {
            for (int i = 0; i < _states.Length; i++)
                _states[i].SetFanSpeed(speedPercent[i]).ThrowIfError("Set fan speed");

            NativeInterface.SetFanTuningStates(_list)
                .ThrowIfError($"Couldn't set fan speed with tuning states {speedPercent} %");
        }

        public void SetFanTuningStates((int temp, int speed)[] states)
        {
            for (int i = 0; i < _states.Length; i++)
            {
                IADLXManualFanTuningState state = _states[i];
                state.SetTemperature(states[i].temp).ThrowIfError("Set temperature");
                state.SetFanSpeed(states[i].speed).ThrowIfError("Set fan speed");
            }

            NativeInterface.SetFanTuningStates(_list).ThrowIfError($"Couldn't set fan speed with tuning states {states}");
        }

        public void SetZeroRPM(bool enabled)
        {
            NativeInterface.SetZeroRPMState(enabled).ThrowIfError("SetZeroRPMState");
        }

        public int[] GetCurrentState()
        {
            var states = _states.Select(x =>
            {
                x.GetFanSpeed(_intPtr).ThrowIfError("Couldn't get control state");
                return ADLX.intP_value(_intPtr);
            });

            return states.ToArray();
        }

        public bool GetZeroRPMState()
        {
            NativeInterface.GetZeroRPMState(_boolPtr).ThrowIfError("Couldn't get zero RPM state");
            return ADLX.boolP_value(_boolPtr);
        }
    }
}
