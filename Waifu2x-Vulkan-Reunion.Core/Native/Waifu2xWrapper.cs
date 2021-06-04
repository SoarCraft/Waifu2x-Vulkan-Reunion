//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 4.0.2
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------

public class Waifu2xWrapper : global::System.IDisposable {
    private global::System.Runtime.InteropServices.HandleRef swigCPtr;
    protected bool swigCMemOwn;

    internal Waifu2xWrapper(global::System.IntPtr cPtr, bool cMemoryOwn) {
        swigCMemOwn = cMemoryOwn;
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
    }

    internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Waifu2xWrapper obj) {
        return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
    }

    ~Waifu2xWrapper() {
        Dispose(false);
    }

    public void Dispose() {
        Dispose(true);
        global::System.GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing) {
        lock (this) {
            if (swigCPtr.Handle != global::System.IntPtr.Zero) {
                if (swigCMemOwn) {
                    swigCMemOwn = false;
                    libWaifu2xPINVOKE.delete_Waifu2xWrapper(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
        }
    }

    public Waifu2xWrapper() : this(libWaifu2xPINVOKE.new_Waifu2xWrapper(), true) {
    }

    public void setInput(string input) {
        libWaifu2xPINVOKE.Waifu2xWrapper_setInput(swigCPtr, input);
        if (libWaifu2xPINVOKE.SWIGPendingException.Pending)
            throw libWaifu2xPINVOKE.SWIGPendingException.Retrieve();
    }

    public void setOutput(string output) {
        libWaifu2xPINVOKE.Waifu2xWrapper_setOutput(swigCPtr, output);
        if (libWaifu2xPINVOKE.SWIGPendingException.Pending)
            throw libWaifu2xPINVOKE.SWIGPendingException.Retrieve();
    }

    public void setNoise(int p_noise) {
        libWaifu2xPINVOKE.Waifu2xWrapper_setNoise(swigCPtr, p_noise);
    }

    public void setScale(int p_scale) {
        libWaifu2xPINVOKE.Waifu2xWrapper_setScale(swigCPtr, p_scale);
    }

    public void setTileSize(IntVector size) {
        libWaifu2xPINVOKE.Waifu2xWrapper_setTileSize(swigCPtr, IntVector.getCPtr(size));
        if (libWaifu2xPINVOKE.SWIGPendingException.Pending)
            throw libWaifu2xPINVOKE.SWIGPendingException.Retrieve();
    }

    public void setModel(string p_model) {
        libWaifu2xPINVOKE.Waifu2xWrapper_setModel(swigCPtr, p_model);
        if (libWaifu2xPINVOKE.SWIGPendingException.Pending)
            throw libWaifu2xPINVOKE.SWIGPendingException.Retrieve();
    }

    public void setGpu(IntVector gpu) {
        libWaifu2xPINVOKE.Waifu2xWrapper_setGpu(swigCPtr, IntVector.getCPtr(gpu));
        if (libWaifu2xPINVOKE.SWIGPendingException.Pending)
            throw libWaifu2xPINVOKE.SWIGPendingException.Retrieve();
    }

    public void setJobsLoad(int load) {
        libWaifu2xPINVOKE.Waifu2xWrapper_setJobsLoad(swigCPtr, load);
    }

    public void setJobProc(IntVector proc) {
        libWaifu2xPINVOKE.Waifu2xWrapper_setJobProc(swigCPtr, IntVector.getCPtr(proc));
        if (libWaifu2xPINVOKE.SWIGPendingException.Pending)
            throw libWaifu2xPINVOKE.SWIGPendingException.Retrieve();
    }

    public void setJobSave(int save) {
        libWaifu2xPINVOKE.Waifu2xWrapper_setJobSave(swigCPtr, save);
    }

    public void setTtaMode(int mode) {
        libWaifu2xPINVOKE.Waifu2xWrapper_setTtaMode(swigCPtr, mode);
    }

    public void setFormat(string p_format) {
        libWaifu2xPINVOKE.Waifu2xWrapper_setFormat(swigCPtr, p_format);
        if (libWaifu2xPINVOKE.SWIGPendingException.Pending)
            throw libWaifu2xPINVOKE.SWIGPendingException.Retrieve();
    }

    public int execute() {
        int ret = libWaifu2xPINVOKE.Waifu2xWrapper_execute(swigCPtr);
        return ret;
    }

}
