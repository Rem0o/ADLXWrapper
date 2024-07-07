using ADLXWrapper.Bindings;
using static System.Net.Mime.MediaTypeNames;

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
            try
            {
                _ext.Dispose();
                NativeInterface.Terminate().ThrowIfError("Couldn't terminate ADLX");
            }
            finally
            {
                base.Dispose();
            }
        }
    }
}
