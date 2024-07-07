using ADLXWrapper.Bindings;
using System;

namespace ADLXWrapper
{
    public abstract class ADLXInterfaceWrapper<T> : Wrapper<T> where T : IADLXInterface
    {
        protected ADLXInterfaceWrapper(T nativeInterface) : base(nativeInterface)
        {
        }

        public override void Dispose()
        {
            int referenceCount = NativeInterface.Release();
            if (referenceCount != 1)
            {
                string name = typeof(T).Name;
                throw new ADLXEception($"{name} still has {referenceCount} references.");
            }

            base.Dispose();
        }
    }

    public abstract class ADLXInterfaceQueryWrapper<T> : Wrapper<T> where T : IADLXInterface
    {
        private readonly IADLXInterface _nativeInterface;

        protected ADLXInterfaceQueryWrapper(IADLXInterface nativeInterface, Func<IADLXInterface, T> query) : base(query(nativeInterface))
        {
            _nativeInterface = nativeInterface.DisposeWith(Disposable);
        }

        public override void Dispose()
        {
            NativeInterface.Release();
            int referenceCount = _nativeInterface.Release();

            if (referenceCount != 1)
            {
                string name = typeof(T).Name;
                throw new ADLXEception($"{name} still has {referenceCount} references.");
            }

            base.Dispose();
        }
    }
}
