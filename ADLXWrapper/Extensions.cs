using ADLXWrapper.Bindings;
using System;

namespace ADLXWrapper
{
    public static class Extensions
    {
        public static T DisposeWith<T>(this T item, CompositeDisposable compositeDisposable) where T : IDisposable
        {
            compositeDisposable.Add(item);
            return item;
        }

        public static void DisposeInterface<T>(this T item) where T : IADLXInterface
        {
            item.Release();
            item.Dispose();
        }

        public static T DisposeInterfaceWith<T>(this T item, CompositeDisposable compositeDisposable) where T : IADLXInterface
        {
            compositeDisposable.Add(item);
            compositeDisposable.Add(new ActionDisposable(() => item.Release()));
            return item;
        }

        public static T DisposeWith<T>(this T item, Action<T> _disposeAction, CompositeDisposable compositeDisposable)
        {
            compositeDisposable.Add(new ActionDisposable(() => _disposeAction(item)));
            return item;
        }

        public static void ThrowIfError(this ADLX_RESULT result, string message)
        {
            if (result.HasError())
            {
                throw new ADLXResultException(result, message);
            }
        }

        public static bool HasError(this ADLX_RESULT result)
        {
            return result != ADLX_RESULT.ADLX_OK &&
                result != ADLX_RESULT.ADLX_ALREADY_ENABLED &&
                result != ADLX_RESULT.ADLX_ALREADY_INITIALIZED &&
                // when running in a windows service, ADLX may return ADLX_ORPHAN_OBJECTS on user logoff, which should not be treated as an error
                result != ADLX_RESULT.ADLX_ORPHAN_OBJECTS;
        }

        public static void ExecuteWithResetRetry(Func<ADLX_RESULT> operation, Action resetToFactory, string message)
        {
            ADLX_RESULT result = operation();

            if (result == ADLX_RESULT.ADLX_RESET_NEEDED)
            {
                resetToFactory?.Invoke();
                result = operation();
            }

            result.ThrowIfError(message);
        }
    }
}
