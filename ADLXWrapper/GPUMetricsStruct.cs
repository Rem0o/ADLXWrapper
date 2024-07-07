﻿using System.Runtime.InteropServices;

namespace ADLXWrapper
{
    [StructLayout(LayoutKind.Sequential)]
    public struct GPUMetricsStruct
    {
        public double GPUTemperature;
        public double GPUHotspotTemperature;
        public int GPUFanSpeed;
    }
}