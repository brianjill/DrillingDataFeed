using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataParser
{
    public class CsvItem : Item
    {
        public string ActivityTime { get; set; }
        public string FullActivityCode { get; set; }
        public double FullActivityCodeDuration { get; set; }
        public float BitDepth { get; set; }
        public float ModelBitDepth { get; set; }
        public float BlockPos { get; set; }
        public float ModelBlockPos { get; set; }
        public float TotalDepth { get; set; }
        public float HookLoad { get; set; }
        public double TDTorque { get; set; }
        public double ModelTDTorque { get; set; }
        public float TDSpeed { get; set; }
        public float STPPressure { get; set; }
        public float WeightOnBit { get; set; }
        public float BoB { get; set; }
        public float BitSize { get; set; }
        public float AccumTripIn { get; set; }
        public float AccumTripOut { get; set; }
        public float DiffPress { get; set; }
        public float TripTankGL { get; set; }
        public float ROPAvg { get; set; }
        public float ROPCutUnit { get; set; }
        public float SvyInclination { get; set; }
        public float BitTVD { get; set; }
        public float Total_Vol { get; set; }
        public float RotaryTorque { get; set; }
        public float RotarySpeed { get; set; }
        public float TT_Vol { get; set; }
    }
}
