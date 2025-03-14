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

                CheckAllMetrics(disposables, wrapper);

                disposables.Dispose();
                wrapper.Terminate();

                disposables = new CompositeDisposable();

                Console.WriteLine("");
                Console.WriteLine("ADLXWrapper Init with WithIncompatibleDriver");
                wrapper.InitializeWithIncompatibleDriver();

                CheckAllMetrics(disposables, wrapper);
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

        private static void CheckAllMetrics(CompositeDisposable disposables, ADLXWrapper wrapper)
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

            var supported = pm.GetSupportedGPUMetrics(gpus.FirstOrDefault()).DisposeWith(disposables);

            // writeline all supported metrics
            Console.WriteLine($"Detected GPU: {gpus.FirstOrDefault().Name}");
            Console.WriteLine("Supported metrics:");
            Console.WriteLine($"GPU temp: {supported.IsSupportedGPUTemperature()}");
            Console.WriteLine($"GPU total board power: {supported.IsSupportedGpuTotalBoardPower()}");
            Console.WriteLine($"GPU fan: {supported.IsSupportedFanSpeed()}");
            Console.WriteLine($"GPU hotspot: {supported.IsSupportedGPUHotspotTemperature()}");

            // same for fan control

            var tuning = ss.GetGPUTuningService().DisposeWith(disposables);
            var fanTuning = tuning.GetManualFanTuning(gpus.FirstOrDefault()).DisposeWith(disposables);

            // supports zeroRpm
            Console.WriteLine($"Fan control:");
            Console.WriteLine($"Supports zero RPM: {fanTuning.SupportsZeroRPM}");
            Console.WriteLine($"Supports target fan speed: {fanTuning.SupportsTargetFanSpeed}");
            // fan speed range
            Console.WriteLine($"Fan speed range: {fanTuning.SpeedRange.Min}-{fanTuning.SpeedRange.Max}");
        }
    }
}
