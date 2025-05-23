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

public class IADLXDisplay : IADLXInterface {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal IADLXDisplay(global::System.IntPtr cPtr, bool cMemoryOwn) : base(ADLXPINVOKE.IADLXDisplay_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(IADLXDisplay obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  internal static global::System.Runtime.InteropServices.HandleRef swigRelease(IADLXDisplay obj) {
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
          ADLXPINVOKE.delete_IADLXDisplay(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      base.Dispose(disposing);
    }
  }

  public new static SWIGTYPE_p_wchar_t IID() {
    global::System.IntPtr cPtr = ADLXPINVOKE.IADLXDisplay_IID();
    SWIGTYPE_p_wchar_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_wchar_t(cPtr, false);
    return ret;
  }

  public virtual ADLX_RESULT ManufacturerID(SWIGTYPE_p_unsigned_int manufacturerID) {
    ADLX_RESULT ret = (ADLX_RESULT)ADLXPINVOKE.IADLXDisplay_ManufacturerID(swigCPtr, SWIGTYPE_p_unsigned_int.getCPtr(manufacturerID));
    return ret;
  }

  public virtual ADLX_RESULT DisplayType(SWIGTYPE_p_adlx__ADLX_DISPLAY_TYPE displayType) {
    ADLX_RESULT ret = (ADLX_RESULT)ADLXPINVOKE.IADLXDisplay_DisplayType(swigCPtr, SWIGTYPE_p_adlx__ADLX_DISPLAY_TYPE.getCPtr(displayType));
    return ret;
  }

  public virtual ADLX_RESULT ConnectorType(SWIGTYPE_p_adlx__ADLX_DISPLAY_CONNECTOR_TYPE connectType) {
    ADLX_RESULT ret = (ADLX_RESULT)ADLXPINVOKE.IADLXDisplay_ConnectorType(swigCPtr, SWIGTYPE_p_adlx__ADLX_DISPLAY_CONNECTOR_TYPE.getCPtr(connectType));
    return ret;
  }

  public virtual ADLX_RESULT Name(SWIGTYPE_p_p_char displayName) {
    ADLX_RESULT ret = (ADLX_RESULT)ADLXPINVOKE.IADLXDisplay_Name(swigCPtr, SWIGTYPE_p_p_char.getCPtr(displayName));
    return ret;
  }

  public virtual ADLX_RESULT EDID(SWIGTYPE_p_p_char edid) {
    ADLX_RESULT ret = (ADLX_RESULT)ADLXPINVOKE.IADLXDisplay_EDID(swigCPtr, SWIGTYPE_p_p_char.getCPtr(edid));
    return ret;
  }

  public virtual ADLX_RESULT NativeResolution(ref int maxHResolution, ref int maxVResolution) {
    ADLX_RESULT ret = (ADLX_RESULT)ADLXPINVOKE.IADLXDisplay_NativeResolution(swigCPtr, ref maxHResolution, ref maxVResolution);
    return ret;
  }

  public virtual ADLX_RESULT RefreshRate(ref double refreshRate) {
    ADLX_RESULT ret = (ADLX_RESULT)ADLXPINVOKE.IADLXDisplay_RefreshRate(swigCPtr, ref refreshRate);
    return ret;
  }

  public virtual ADLX_RESULT PixelClock(SWIGTYPE_p_unsigned_int pixelClock) {
    ADLX_RESULT ret = (ADLX_RESULT)ADLXPINVOKE.IADLXDisplay_PixelClock(swigCPtr, SWIGTYPE_p_unsigned_int.getCPtr(pixelClock));
    return ret;
  }

  public virtual ADLX_RESULT ScanType(SWIGTYPE_p_adlx__ADLX_DISPLAY_SCAN_TYPE scanType) {
    ADLX_RESULT ret = (ADLX_RESULT)ADLXPINVOKE.IADLXDisplay_ScanType(swigCPtr, SWIGTYPE_p_adlx__ADLX_DISPLAY_SCAN_TYPE.getCPtr(scanType));
    return ret;
  }

  public virtual ADLX_RESULT GetGPU(SWIGTYPE_p_p_adlx__IADLXGPU ppGPU) {
    ADLX_RESULT ret = (ADLX_RESULT)ADLXPINVOKE.IADLXDisplay_GetGPU(swigCPtr, SWIGTYPE_p_p_adlx__IADLXGPU.getCPtr(ppGPU));
    return ret;
  }

  public virtual ADLX_RESULT UniqueId(SWIGTYPE_p_size_t uniqueId) {
    ADLX_RESULT ret = (ADLX_RESULT)ADLXPINVOKE.IADLXDisplay_UniqueId(swigCPtr, SWIGTYPE_p_size_t.getCPtr(uniqueId));
    return ret;
  }

}

}
