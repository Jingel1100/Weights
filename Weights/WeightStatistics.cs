using System;
using System.Collections.Generic;
using System.IO;
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
        }
        
        public float LostWeight;
        public float HighestWeight;
        public float LowestWeight;
        public float Startweight;
        public string Startdate;
        public float AverageWeight;
        public float LatestWeight;

    }
}
