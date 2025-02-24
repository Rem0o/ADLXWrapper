using ADLXWrapper.Bindings;

namespace ADLXWrapper
{
    public class ADLXWrapper : Wrapper<SafeADLXHelper>
    {
        private bool _initialized;
        private ADLXExt _ext;

        public ADLXWrapper() : base(new SafeADLXHelper())
        {
            _ext = new ADLXExt();
        }

        public void Initialize()
        {
            NativeInterface.Initialize().ThrowIfError("Couldn't initialize ADLX");
            _initialized = true;
        }

        public void InitializeWithIncompatibleDriver()
        {
            NativeInterface.InitializeWithIncompatibleDriver().ThrowIfError("Couldn't initialize ADLX with incompatible driver");
            _initialized = true;
        }

        public SystemServices GetSystemServices()
        {
            if (!_initialized)
            {
                throw new ADLXEception("ADLX was not initialized before getting system services");
            }

            return new SystemServices(NativeInterface.GetSystemServices(), _ext);
        }

        public void Terminate()
        {
            _initialized = false;
            NativeInterface.Terminate().ThrowIfError("Couldn't terminate ADLX");
        }

        public override void Dispose()
        {
            _ext?.Dispose();
            base.Dispose();
        }
    }
}
