﻿using ADLXWrapper.Bindings;

namespace ADLXWrapper
{
    public class Range
    {
        public Range(ADLX_IntRange range)
        {
            Min = range.minValue;
            Max = range.maxValue;
            Step = range.step;
        }

        public int Min { get; }
        public int Max { get; }
        public int Step { get; }
    }
}
