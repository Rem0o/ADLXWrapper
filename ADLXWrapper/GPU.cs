using ADLXWrapper.Bindings;

namespace ADLXWrapper
{
    public class GPU : ADLXInterfaceWrapper<IADLXGPU>
    {
        public GPU(IADLXGPU gpu) : base(gpu)
        {
            var namePtr = ADLX.new_stringP_Ptr();
            var uniqueIdPtr = ADLX.new_intP();
            var typePtr = ADLX.new_gpuTypeP();

            NativeInterface.Type(typePtr);
            NativeInterface.Name(namePtr).ThrowIfError("Couldn't get GPU name");
            Name = ADLX.stringP_Ptr_value(namePtr);
            NativeInterface.UniqueId(uniqueIdPtr).ThrowIfError("Couldn't get Unique ID");
            UniqueId = ADLX.intP_value(uniqueIdPtr);
            Type = ADLX.gpuTypeP_value(typePtr);

            ADLX.delete_stringP_Ptr(namePtr);
            ADLX.delete_intP(uniqueIdPtr);
        }

        public string Name { get; }

        public int UniqueId { get; }

        public ADLX_GPU_TYPE Type { get; }
    }
}
