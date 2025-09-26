using ADLXWrapper.Bindings;
using System;

namespace ADLXWrapper
{
    public class ADLXResultException : ADLXEception
    {
        public ADLXResultException(ADLX_RESULT result, string message) : base($"Result: {result} {Environment.NewLine}{message}")
        {
            ADLXResult = result;
        }

        public ADLX_RESULT? ADLXResult { get; private set; }

    }

    public class ADLXEception : Exception
    {
        public ADLXEception(string message) : base(message)
        {

        }
    }
}
