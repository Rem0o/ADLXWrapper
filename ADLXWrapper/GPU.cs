using ADLXWrapper.Bindings;

namespace ADLXWrapper
{
    public class GPU : ADLXInterfaceWrapper<IADLXGPU>
    {
        public GPU(IADLXGPU gpu) : base(gpu)
        {
            var namePtr = ADLX.new_stringP_Ptr();
            var uniqueIdPtr = ADLX.new_intP();
            NativeInterface.Name(namePtr).ThrowIfError("Couldn't get GPU name");
            Name = ADLX.stringP_Ptr_value(namePtr);
            NativeInterface.UniqueId(uniqueIdPtr).ThrowIfError("Couldn't get Unique ID");
            UniqueId = ADLX.intP_value(uniqueIdPtr);

            ADLX.delete_stringP_Ptr(namePtr);
            ADLX.delete_intP(uniqueIdPtr);
        }

        public string Name { get; }

        public int UniqueId { get; }
    }
}
