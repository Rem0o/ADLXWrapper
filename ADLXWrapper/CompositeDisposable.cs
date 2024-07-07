using System;
using System.Collections.Generic;

namespace ADLXWrapper
{
    public class CompositeDisposable : IDisposable
    {
        private readonly Stack<IDisposable> _disposables = new Stack<IDisposable>();
        public CompositeDisposable() { }

        public void Add(IDisposable item)
        {
            _disposables.Push(item);
        }

        public void Dispose()
        {
            while (_disposables.Count > 0 && _disposables.Pop() is IDisposable disposable)
            {
                disposable.Dispose();
            }

            _disposables.Clear();
        }
    }
}
