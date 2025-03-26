using System.Runtime.InteropServices;

namespace ADLXWrapper
{
    [StructLayout(LayoutKind.Sequential)]
    public struct GPUMetricsStruct1
    {
        public double GPUTemperature;
        public double GPUHotspotTemperature;
        public double GPUTotalBoardPower;
        public int GPUFanSpeed;

        public double GPUMemoryTemperature;
        public int NPUFreuqency;
        public int NPUActivityLevel;

        public override bool Equals(object obj)
        {
            if (obj is GPUMetricsStruct1 other)
            {
                return GPUTemperature == other.GPUTemperature &&
                       GPUHotspotTemperature == other.GPUHotspotTemperature &&
                       GPUTotalBoardPower == other.GPUTotalBoardPower &&
                       GPUFanSpeed == other.GPUFanSpeed &&
                       GPUMemoryTemperature == other.GPUMemoryTemperature &&
                       NPUFreuqency == other.NPUFreuqency &&
                       NPUActivityLevel == other.NPUActivityLevel;
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
            hash = hash * 23 + GPUMemoryTemperature.GetHashCode();
            hash = hash * 23 + NPUFreuqency.GetHashCode();
            hash = hash * 23 + NPUActivityLevel.GetHashCode();
            return hash;
        }

        public static bool operator ==(GPUMetricsStruct1 a, GPUMetricsStruct1 b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(GPUMetricsStruct1 a, GPUMetricsStruct1 b)
        {
            return !a.Equals(b);
        }

        public override string ToString()
        {
            return $"GPUTemperature: {GPUTemperature}, GPUMemoryTemperature: {GPUMemoryTemperature}, GPUHotspotTemperature: {GPUHotspotTemperature}, GPUTotalBoardPower: {GPUTotalBoardPower}, GPUFanSpeed: {GPUFanSpeed}, NPUFrequency: {NPUFreuqency}, NPUActivityLevel: {NPUActivityLevel}";
        }
    }
}