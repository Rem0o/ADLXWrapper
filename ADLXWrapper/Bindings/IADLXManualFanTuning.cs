//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (https://www.swig.org).
// Version 4.2.1
//
// Do not make changes to this file unless you know what you are doing - modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------

namespace ADLXWrapper.Bindings {

public class IADLXManualFanTuning : IADLXInterface {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal IADLXManualFanTuning(global::System.IntPtr cPtr, bool cMemoryOwn) : base(ADLXPINVOKE.IADLXManualFanTuning_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(IADLXManualFanTuning obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  internal static global::System.Runtime.InteropServices.HandleRef swigRelease(IADLXManualFanTuning obj) {
    if (obj != null) {
      if (!obj.swigCMemOwn)
        throw new global::System.ApplicationException("Cannot release ownership as memory is not owned");
      global::System.Runtime.InteropServices.HandleRef ptr = obj.swigCPtr;
      obj.swigCMemOwn = false;
      obj.Dispose();
      return ptr;
    } else {
      return new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
    }
  }

  protected override void Dispose(bool disposing) {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          ADLXPINVOKE.delete_IADLXManualFanTuning(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      base.Dispose(disposing);
    }
  }

  public new static SWIGTYPE_p_wchar_t IID() {
    global::System.IntPtr cPtr = ADLXPINVOKE.IADLXManualFanTuning_IID();
    SWIGTYPE_p_wchar_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_wchar_t(cPtr, false);
    return ret;
  }

  public virtual ADLX_RESULT GetFanTuningRanges(ADLX_IntRange speedRange, ADLX_IntRange temperatureRange) {
    ADLX_RESULT ret = (ADLX_RESULT)ADLXPINVOKE.IADLXManualFanTuning_GetFanTuningRanges(swigCPtr, ADLX_IntRange.getCPtr(speedRange), ADLX_IntRange.getCPtr(temperatureRange));
    return ret;
  }

  public virtual ADLX_RESULT GetFanTuningStates(SWIGTYPE_p_p_adlx__IADLXManualFanTuningStateList ppStates) {
    ADLX_RESULT ret = (ADLX_RESULT)ADLXPINVOKE.IADLXManualFanTuning_GetFanTuningStates(swigCPtr, SWIGTYPE_p_p_adlx__IADLXManualFanTuningStateList.getCPtr(ppStates));
    return ret;
  }

  public virtual ADLX_RESULT GetEmptyFanTuningStates(SWIGTYPE_p_p_adlx__IADLXManualFanTuningStateList ppStates) {
    ADLX_RESULT ret = (ADLX_RESULT)ADLXPINVOKE.IADLXManualFanTuning_GetEmptyFanTuningStates(swigCPtr, SWIGTYPE_p_p_adlx__IADLXManualFanTuningStateList.getCPtr(ppStates));
    return ret;
  }

  public virtual ADLX_RESULT IsValidFanTuningStates(IADLXManualFanTuningStateList pStates, ref int errorIndex) {
    ADLX_RESULT ret = (ADLX_RESULT)ADLXPINVOKE.IADLXManualFanTuning_IsValidFanTuningStates(swigCPtr, IADLXManualFanTuningStateList.getCPtr(pStates), ref errorIndex);
    return ret;
  }

  public virtual ADLX_RESULT SetFanTuningStates(IADLXManualFanTuningStateList pStates) {
    ADLX_RESULT ret = (ADLX_RESULT)ADLXPINVOKE.IADLXManualFanTuning_SetFanTuningStates(swigCPtr, IADLXManualFanTuningStateList.getCPtr(pStates));
    return ret;
  }

  public virtual ADLX_RESULT IsSupportedZeroRPM(ref bool supported) {
    ADLX_RESULT ret = (ADLX_RESULT)ADLXPINVOKE.IADLXManualFanTuning_IsSupportedZeroRPM(swigCPtr, ref supported);
    return ret;
  }

  public virtual ADLX_RESULT GetZeroRPMState(ref bool isSet) {
    ADLX_RESULT ret = (ADLX_RESULT)ADLXPINVOKE.IADLXManualFanTuning_GetZeroRPMState(swigCPtr, ref isSet);
    return ret;
  }

  public virtual ADLX_RESULT SetZeroRPMState(bool set) {
    ADLX_RESULT ret = (ADLX_RESULT)ADLXPINVOKE.IADLXManualFanTuning_SetZeroRPMState(swigCPtr, set);
    return ret;
  }

  public virtual ADLX_RESULT IsSupportedMinAcousticLimit(ref bool supported) {
    ADLX_RESULT ret = (ADLX_RESULT)ADLXPINVOKE.IADLXManualFanTuning_IsSupportedMinAcousticLimit(swigCPtr, ref supported);
    return ret;
  }

  public virtual ADLX_RESULT GetMinAcousticLimitRange(ADLX_IntRange tuningRange) {
    ADLX_RESULT ret = (ADLX_RESULT)ADLXPINVOKE.IADLXManualFanTuning_GetMinAcousticLimitRange(swigCPtr, ADLX_IntRange.getCPtr(tuningRange));
    return ret;
  }

  public virtual ADLX_RESULT GetMinAcousticLimit(ref int value) {
    ADLX_RESULT ret = (ADLX_RESULT)ADLXPINVOKE.IADLXManualFanTuning_GetMinAcousticLimit(swigCPtr, ref value);
    return ret;
  }

  public virtual ADLX_RESULT SetMinAcousticLimit(int value) {
    ADLX_RESULT ret = (ADLX_RESULT)ADLXPINVOKE.IADLXManualFanTuning_SetMinAcousticLimit(swigCPtr, value);
    return ret;
  }

  public virtual ADLX_RESULT IsSupportedMinFanSpeed(ref bool supported) {
    ADLX_RESULT ret = (ADLX_RESULT)ADLXPINVOKE.IADLXManualFanTuning_IsSupportedMinFanSpeed(swigCPtr, ref supported);
    return ret;
  }

  public virtual ADLX_RESULT GetMinFanSpeedRange(ADLX_IntRange tuningRange) {
    ADLX_RESULT ret = (ADLX_RESULT)ADLXPINVOKE.IADLXManualFanTuning_GetMinFanSpeedRange(swigCPtr, ADLX_IntRange.getCPtr(tuningRange));
    return ret;
  }

  public virtual ADLX_RESULT GetMinFanSpeed(ref int value) {
    ADLX_RESULT ret = (ADLX_RESULT)ADLXPINVOKE.IADLXManualFanTuning_GetMinFanSpeed(swigCPtr, ref value);
    return ret;
  }

  public virtual ADLX_RESULT SetMinFanSpeed(int value) {
    ADLX_RESULT ret = (ADLX_RESULT)ADLXPINVOKE.IADLXManualFanTuning_SetMinFanSpeed(swigCPtr, value);
    return ret;
  }

  public virtual ADLX_RESULT IsSupportedTargetFanSpeed(ref bool supported) {
    ADLX_RESULT ret = (ADLX_RESULT)ADLXPINVOKE.IADLXManualFanTuning_IsSupportedTargetFanSpeed(swigCPtr, ref supported);
    return ret;
  }

  public virtual ADLX_RESULT GetTargetFanSpeedRange(ADLX_IntRange tuningRange) {
    ADLX_RESULT ret = (ADLX_RESULT)ADLXPINVOKE.IADLXManualFanTuning_GetTargetFanSpeedRange(swigCPtr, ADLX_IntRange.getCPtr(tuningRange));
    return ret;
  }

  public virtual ADLX_RESULT GetTargetFanSpeed(ref int value) {
    ADLX_RESULT ret = (ADLX_RESULT)ADLXPINVOKE.IADLXManualFanTuning_GetTargetFanSpeed(swigCPtr, ref value);
    return ret;
  }

  public virtual ADLX_RESULT SetTargetFanSpeed(int value) {
    ADLX_RESULT ret = (ADLX_RESULT)ADLXPINVOKE.IADLXManualFanTuning_SetTargetFanSpeed(swigCPtr, value);
    return ret;
  }

}

}
