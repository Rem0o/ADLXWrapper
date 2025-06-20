using ADLXWrapper.Bindings;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ADLXWrapper.TestApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                CompositeDisposable disposables = new CompositeDisposable();
                var wrapper = new ADLXWrapper();

                Console.WriteLine("ADLXWrapper Init");
                wrapper.Initialize();

                await CheckAllMetrics(disposables, wrapper);

                disposables.Dispose();
                wrapper.Terminate();

                disposables = new CompositeDisposable();

                Console.WriteLine("");
                Console.WriteLine("ADLXWrapper Init with WithIncompatibleDriver");
                wrapper.InitializeWithIncompatibleDriver();

                await CheckAllMetrics(disposables, wrapper);

                disposables.Dispose();
                wrapper.Terminate();
                wrapper.Dispose();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("");
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
        }

        private static async Task CheckAllMetrics(CompositeDisposable disposables, ADLXWrapper wrapper)
        {
            var ss = wrapper.GetSystemServices().DisposeWith(disposables);
            var gpus = ss.GetGPUs().DisposeWith(l =>
            {
                foreach (var g in l)
                {
                    g.Dispose();
                }
            }, disposables).Where(x => x.Type == ADLX_GPU_TYPE.GPUTYPE_DISCRETE).ToArray();

            var pm = ss.GetPerformanceMonitor().DisposeWith(disposables);

            GPU gpu = gpus.FirstOrDefault();

            var supported = pm.GetSupportedGPUMetrics1(gpu).DisposeWith(disposables);

            pm.StartTracking(500, 100).DisposeWith(disposables);

            for (int i = 0; i < 5; i++)
            {
                await Task.Delay(1000);
                var str = pm.GetGPUMetricsStructFromTracking(gpu);
                Console.WriteLine($"GPU temp: {str.GPUTemperature}");
                Console.WriteLine($"GPU total board power: {str.GPUTotalBoardPower}");
                Console.WriteLine($"GPU fan: {str.GPUFanSpeed}");
                Console.WriteLine($"GPU hotspot: {str.GPUHotspotTemperature}");
            }


            // writeline all supported metrics
            Console.WriteLine($"Detected GPU: {gpu.Name}");
            Console.WriteLine("Supported metrics:");
            Console.WriteLine($"GPU temp: {supported.IsSupportedGPUTemperature()}");
            Console.WriteLine($"GPU total board power: {supported.IsSupportedGpuTotalBoardPower()}");
            Console.WriteLine($"GPU fan: {supported.IsSupportedFanSpeed()}");
            Console.WriteLine($"GPU hotspot: {supported.IsSupportedGPUHotspotTemperature()}");
            Console.WriteLine($"GPU Memory temp: {supported.IsSupportedGPUMemoryTemperature()}");
            Console.WriteLine($"NPU frequency: {supported.IsSupportedNPUFrequency()}");
            Console.WriteLine($"NPU activity level: {supported.IsSupportedNPUActivityLevel()}");

            var metrics = pm.GetGPUMetricsStruct1(gpu);

            // get all metrics
            Console.WriteLine($"Metrics:");
            Console.WriteLine($"GPU temp: {metrics.GPUTemperature}");
            Console.WriteLine($"GPU total board power: {metrics.GPUTotalBoardPower}");
            Console.WriteLine($"GPU fan: {metrics.GPUFanSpeed}");
            Console.WriteLine($"GPU hotspot: {metrics.GPUHotspotTemperature}");
            Console.WriteLine($"GPU Memory temp: {metrics.GPUMemoryTemperature}");
            Console.WriteLine($"NPU frequency: {metrics.NPUFrequency}");
            Console.WriteLine($"NPU activity level: {metrics.NPUActivityLevel}");

            var otherMetrics = pm.GetGPUMetricsStruct(gpu);

            Console.WriteLine($"Metrics:");
            Console.WriteLine($"GPU temp: {otherMetrics.GPUTemperature}");
            Console.WriteLine($"GPU total board power: {otherMetrics.GPUTotalBoardPower}");
            Console.WriteLine($"GPU fan: {otherMetrics.GPUFanSpeed}");
            Console.WriteLine($"GPU hotspot: {otherMetrics.GPUHotspotTemperature}");

            // same for fan control
            var tuning = ss.GetGPUTuningService().DisposeWith(disposables);
            var fanTuning = tuning.GetManualFanTuning(gpu).DisposeWith(disposables);

            // supports zeroRpm
            Console.WriteLine($"Fan control:");
            Console.WriteLine($"Supports zero RPM: {fanTuning.SupportsZeroRPM}");
            Console.WriteLine($"Supports target fan speed: {fanTuning.SupportsTargetFanSpeed}");
            Console.WriteLine($"Supports fan tuning states: {fanTuning.SupportsFanTuningStates}");

            // fan speed range
            if (fanTuning.SupportsFanTuningStates)
            {
                Console.WriteLine($"Fan speed range: {fanTuning.FanTuningStates.SpeedRange.Min}-{fanTuning.FanTuningStates.SpeedRange.Max}");
            }
            else
            {
                Console.WriteLine("Fan speed range: not supported");
            }
        }
    }
}
