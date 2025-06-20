using ADLXWrapper.Bindings;
using System;
using System.Linq;

namespace ADLXWrapper
{
    public class FanTuningStates : CompositeDisposable
    {
        private IADLXManualFanTuningState[] _states;
        private (int t, int s)[] _resetList = Array.Empty<(int t, int s)>();
        private readonly IADLXManualFanTuningStateList _list;
        private readonly IADLXManualFanTuning _manualFanTuning;
        private readonly ADLXExt _ext;

        public FanTuningStates(IADLXManualFanTuningStateList list, IADLXManualFanTuning manualFanTuning, ADLXExt ext)
        {
            _list = list;
            _manualFanTuning = manualFanTuning;
            _ext = ext;

            var statePtr = ADLX.new_fanTuningStateP_Ptr();
            _states = Enumerable.Range((int)_list.Begin(), (int)(_list.End() - _list.Begin())).Select(i =>
            {
                _list.At((uint)i, statePtr).ThrowIfError($"Couldn't get state {i}");
                return ADLX.fanTuningStateP_Ptr_value(statePtr).DisposeInterfaceWith(this);
            }).ToArray();
            ADLX.delete_fanTuningStateP_Ptr(statePtr);

            _resetList = _states.Select(x =>
            {
                int t = default;
                x.GetTemperature(ref t).ThrowIfError("GetTemperature");
                int s = default;
                x.GetFanSpeed(ref s).ThrowIfError("GetFanSpeed");
                return (t, s);
            }).ToArray();

            var speedRangePtr = ADLX.new_adlx_intRangeP();
            var tempRangePtr = ADLX.new_adlx_intRangeP();
            manualFanTuning.GetFanTuningRanges(speedRangePtr, tempRangePtr).ThrowIfError("Couldn't get fan speed range.");

            using (ADLX_IntRange speedRange = ADLX.adlx_intRangeP_value(speedRangePtr))
                SpeedRange = new Range(speedRange);

            using (ADLX_IntRange tempRange = ADLX.adlx_intRangeP_value(tempRangePtr))
                TempRange = new Range(tempRange);

            ADLX.delete_adlx_intRangeP(speedRangePtr);
            ADLX.delete_adlx_intRangeP(tempRangePtr);
        }

        public Range SpeedRange { get; }
        public Range TempRange { get; }

        public int[] GetCurrentState()
        {
            var states = _states.Select(x =>
            {
                int speed = default;
                x.GetFanSpeed(ref speed).ThrowIfError("Couldn't get control state");
                return speed;
            });

            return states.ToArray();
        }

        public void SetFanTuningStates(int speedPercent)
        {
            for (int i = 0; i < _states.Length; i++)
                _states[i].SetFanSpeed(speedPercent).ThrowIfError("Set fan speed");

            _manualFanTuning.SetFanTuningStates(_list)
                .ThrowIfError($"Couldn't set fan speed with tuning states {speedPercent} %");
        }

        public void SetFanTuningStates2(int speedPercent)
        {
            _ext.SetSpeed(_manualFanTuning, speedPercent, _list).ThrowIfError($"Couldn't set fan speed with tuning states {speedPercent} %");
        }

        public void SetFanTuningStates(int[] speedPercent)
        {
            for (int i = 0; i < _states.Length; i++)
                _states[i].SetFanSpeed(speedPercent[i]).ThrowIfError("Set fan speed");

            _manualFanTuning.SetFanTuningStates(_list)
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

            _manualFanTuning.SetFanTuningStates(_list).ThrowIfError($"Couldn't set fan speed with tuning states {states}");
        }

        internal void Reset()
        {
            SetFanTuningStates(_resetList);
        }
    }
}
