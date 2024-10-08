﻿using ADLXWrapper.Bindings;

namespace ADLXWrapper.TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var wrapper = new ADLXWrapper();

            wrapper.Initialize();

            using var system = wrapper.GetSystemServices();
            var gpus = system.GetGPUs();

            var gpu = gpus.First();

            var tuning = system.GetGPUTuningService();
            var manualFanTuning = tuning.GetManualFanTuning(gpu);


            foreach (var item in gpus)
            {
                item.Dispose();
            }

            manualFanTuning.Dispose();
            tuning.Dispose();

            wrapper.Terminate();
        }
    }
}
