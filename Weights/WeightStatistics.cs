using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weights
{
    class WeightStatistics
    {
        public WeightStatistics()
        {
            HighestWeight = float.MinValue;
            LowestWeight = float.MaxValue;
            Startweight = 63.2f;            // = first line of BookWianneWeights.txt
        }

        public float LostWeight;
        public float HighestWeight;
        public float LowestWeight;
        public float Startweight;
    }
}
