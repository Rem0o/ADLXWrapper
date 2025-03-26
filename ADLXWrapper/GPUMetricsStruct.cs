using System.Runtime.InteropServices;

namespace ADLXWrapper
{
    [StructLayout(LayoutKind.Sequential)]
    public struct GPUMetricsStruct
    {
        public double GPUTemperature;
        public double GPUHotspotTemperature;
        public double GPUTotalBoardPower;
        public int GPUFanSpeed;

        public override bool Equals(object obj)
        {
            if (obj is GPUMetricsStruct other)
            {
                return GPUTemperature == other.GPUTemperature &&
                       GPUHotspotTemperature == other.GPUHotspotTemperature &&
                       GPUTotalBoardPower == other.GPUTotalBoardPower &&
                       GPUFanSpeed == other.GPUFanSpeed;
            }

            return false;
        }

        public override int GetHashCode()
        {
            // Use a prime number for hashing
            int hash = 17;
            hash = hash * 23 + GPUTemperature.GetHashCode();
            hash = hash * 23 + GPUHotspotTemperature.GetHashCode();
            hash = hash * 23 + GPUTotalBoardPower.GetHashCode();
            hash = hash * 23 + GPUFanSpeed.GetHashCode();
            return hash;
        }

        public static bool operator ==(GPUMetricsStruct a, GPUMetricsStruct b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(GPUMetricsStruct a, GPUMetricsStruct b)
        {
            return !a.Equals(b);
        }

        public override string ToString()
        {
            return $"GPUTemperature: {GPUTemperature}, GPUHotspotTemperature: {GPUHotspotTemperature}, GPUTotalBoardPower: {GPUTotalBoardPower}, GPUFanSpeed: {GPUFanSpeed}";
        }
    }
}