using ADLXWrapper.Bindings;
using System;

namespace ADLXWrapper
{
    public class ADLXEception : Exception
    {
        public ADLXEception(ADLX_RESULT result, string message) : this($"Result: {result} {Environment.NewLine}{message}")
        {

        }

        public ADLXEception(string message) : base(message)
        {

        }
    }
}
