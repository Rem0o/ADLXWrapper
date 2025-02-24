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

public class SafeADLXHelper : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal SafeADLXHelper(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(SafeADLXHelper obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  internal static global::System.Runtime.InteropServices.HandleRef swigRelease(SafeADLXHelper obj) {
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

  ~SafeADLXHelper() {
    Dispose(false);
  }

  public void Dispose() {
    Dispose(true);
    global::System.GC.SuppressFinalize(this);
  }

  protected virtual void Dispose(bool disposing) {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          ADLXPINVOKE.delete_SafeADLXHelper(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public SafeADLXHelper() : this(ADLXPINVOKE.new_SafeADLXHelper(), true) {
  }

  public ADLX_RESULT Initialize() {
    ADLX_RESULT ret = (ADLX_RESULT)ADLXPINVOKE.SafeADLXHelper_Initialize(swigCPtr);
    return ret;
  }

  public ADLX_RESULT InitializeWithIncompatibleDriver() {
    ADLX_RESULT ret = (ADLX_RESULT)ADLXPINVOKE.SafeADLXHelper_InitializeWithIncompatibleDriver(swigCPtr);
    return ret;
  }

  public ADLX_RESULT Terminate() {
    ADLX_RESULT ret = (ADLX_RESULT)ADLXPINVOKE.SafeADLXHelper_Terminate(swigCPtr);
    return ret;
  }

  public IADLXSystem GetSystemServices() {
    global::System.IntPtr cPtr = ADLXPINVOKE.SafeADLXHelper_GetSystemServices(swigCPtr);
    IADLXSystem ret = (cPtr == global::System.IntPtr.Zero) ? null : new IADLXSystem(cPtr, false);
    return ret;
  }

}

}
