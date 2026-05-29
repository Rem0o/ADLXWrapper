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
            List<Exception> exceptions = null;

            while (_disposables.Count > 0 && _disposables.Pop() is IDisposable disposable)
            {
                try
                {
                    disposable.Dispose();
                }
                catch (Exception ex)
                {
                    if (exceptions == null)
                    {
                        exceptions = new List<Exception>();
                    }

                    exceptions.Add(ex);
                }
            }

            _disposables.Clear();

            if (exceptions != null)
            {
                throw new AggregateException("One or more errors occurred while disposing composite resources.", exceptions);
            }
        }
    }
}
