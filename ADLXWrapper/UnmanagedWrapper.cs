using ADLXWrapper.Bindings;
using System;

namespace ADLXWrapper
{
    public abstract class Wrapper<T> : IDisposable where T : IDisposable
    {
        protected readonly CompositeDisposable Disposable = new CompositeDisposable();
        internal T NativeInterface;

        protected Wrapper(T nativeInterface)
        {
            NativeInterface = nativeInterface.DisposeWith(Disposable);
        }

        public virtual void Dispose()
        {
            Disposable.Dispose();
            NativeInterface = default;
        }
    }
}
