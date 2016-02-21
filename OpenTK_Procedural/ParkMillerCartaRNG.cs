using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTK_Procedural
{
    class ParkMillerCartaRNG
    {
        public UInt32 Seed { get; private set; }
        private UInt32 WalkingNumber;

        public ParkMillerCartaRNG(UInt32 Seed)
        {
            this.Seed = Seed;
            WalkingNumber = Seed;
        }

        public ParkMillerCartaRNG()
        {
            this.Seed = (UInt32)new Random().Next();
            WalkingNumber = Seed;
        }

        public void Reset()
        {
            WalkingNumber = Seed;
        }

        public UInt32 Generate()
        {
            UInt32 hi, lo;
            lo = 16807 * (WalkingNumber & 0xFFFF);
            hi = 16807 * (WalkingNumber >> 16);
            lo += (hi & 0x7FFF) << 16;
            lo += hi >> 15;
            lo = (lo & 0x7FFFFFFF) + (lo >> 31);
            WalkingNumber = lo;
            return WalkingNumber;
        }

        public double GeneratePercent()
        {
            return ((double)Generate() / 0x7FFFFFFF);
        }

        public int GenerateRanged(int Min, int Max)
        {
            return Min + (int)(GeneratePercent() * (Max - Min));
        }

        public int GenerateOffseted(int Previous, double OffsetTimes, int Ceil, int Floor)
        {
            int Min = (int)Math.Min(Previous + (Previous * OffsetTimes), Ceil);
            int Max = (int)Math.Max(Previous - (Previous * OffsetTimes), Floor);
            return GenerateRanged(Min, Max);
        }
    }
}
