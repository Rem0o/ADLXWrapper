using System.Runtime.InteropServices;

namespace ADLXWrapper
{
    [StructLayout(LayoutKind.Sequential)]
    public struct GPUMetricsStruct3
    {
        public double GPUTemperature;
        public double GPUHotspotTemperature;
        public double GPUIntakeTemperature;
        public double GPUTotalBoardPower;
        public int GPUFanSpeed;

        public double GPUMemoryTemperature;
        public int NPUFrequency;
        public int NPUActivityLevel;

        public int GPUFanDuty;

        public override bool Equals(object obj)
        {
            if (obj is GPUMetricsStruct3 other)
            {
                return GPUTemperature == other.GPUTemperature &&
                       GPUHotspotTemperature == other.GPUHotspotTemperature &&
                       GPUIntakeTemperature == other.GPUIntakeTemperature &&
                       GPUTotalBoardPower == other.GPUTotalBoardPower &&
                       GPUFanSpeed == other.GPUFanSpeed &&
                       GPUMemoryTemperature == other.GPUMemoryTemperature &&
                       NPUFrequency == other.NPUFrequency &&
                       NPUActivityLevel == other.NPUActivityLevel &&
                       GPUFanDuty == other.GPUFanDuty;
            }

            return false;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + GPUTemperature.GetHashCode();
            hash = hash * 23 + GPUHotspotTemperature.GetHashCode();
            hash = hash * 23 + GPUIntakeTemperature.GetHashCode();
            hash = hash * 23 + GPUTotalBoardPower.GetHashCode();
            hash = hash * 23 + GPUFanSpeed.GetHashCode();
            hash = hash * 23 + GPUMemoryTemperature.GetHashCode();
            hash = hash * 23 + NPUFrequency.GetHashCode();
            hash = hash * 23 + NPUActivityLevel.GetHashCode();
            hash = hash * 23 + GPUFanDuty.GetHashCode();
            return hash;
        }

        public static bool operator ==(GPUMetricsStruct3 a, GPUMetricsStruct3 b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(GPUMetricsStruct3 a, GPUMetricsStruct3 b)
        {
            return !a.Equals(b);
        }

        public override string ToString()
        {
            return $"GPUTemperature: {GPUTemperature}, GPUMemoryTemperature: {GPUMemoryTemperature}, GPUHotspotTemperature: {GPUHotspotTemperature}, GPUIntakeTemperature: {GPUIntakeTemperature}, GPUTotalBoardPower: {GPUTotalBoardPower}, GPUFanSpeed: {GPUFanSpeed}, GPUFanDuty: {GPUFanDuty}, NPUFrequency: {NPUFrequency}, NPUActivityLevel: {NPUActivityLevel}";
        }
    }
}