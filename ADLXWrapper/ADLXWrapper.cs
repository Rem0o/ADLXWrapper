using ADLXWrapper.Bindings;

namespace ADLXWrapper
{
    public class ADLXWrapper : Wrapper<ADLXHelper>
    {
        private ADLXExt _ext;

        public ADLXWrapper() : base(new ADLXHelper())
        {
            NativeInterface.Initialize().ThrowIfError("Couldn't initialize ADLX");

            _ext = new ADLXExt();
        }

        public SystemServices GetSystemServices()
        {
            return new SystemServices(NativeInterface.GetSystemServices(), _ext);
        }

        public override void Dispose()
        {
            _ext.Dispose();
            ADLX_RESULT adlxResult = NativeInterface.Terminate();
            base.Dispose();

            adlxResult.ThrowIfError("Couldn't terminate ADLX");
        }
    }
}
