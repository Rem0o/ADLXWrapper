using System;

namespace ADLXWrapper
{
    public class ActionDisposable : IDisposable
    {
        private Action _action;

        public ActionDisposable(Action action)
        {
            _action = action;
        }

        public void Dispose()
        {
            _action?.Invoke();
            _action = null;
        }
    }
}
