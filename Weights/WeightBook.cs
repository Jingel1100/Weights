using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weights
{
    class WeightBook
    {
        public WeightBook()    // constructor
        {
            weights = new List<float>();
            dates = new List<string>();
        }
        
        public float ReadStartWeight(string bookName)
        {
            var fileStreamWeights = new FileStream("WeightBook" + bookName + "_Weights.txt", FileMode.Open, FileAccess.Read);
            
            using (StreamReader readWeights = new StreamReader(fileStreamWeights, Encoding.UTF8))
            {
                string lineWeight;
                float newLineWeight;

                while ((lineWeight = readWeights.ReadLine()) != null)
                {
                    newLineWeight = float.Parse(lineWeight);
                    weights.Add(newLineWeight);
                }
            }

            float startWeight = weights.FirstOrDefault();
            return startWeight;
        }

        public string ReadStartDate(string bookName)
        {
            var fileStreamDates = new FileStream("WeightBook" + bookName + "_Dates.txt", FileMode.Open, FileAccess.Read);
            using (StreamReader readDates = new StreamReader(fileStreamDates, Encoding.UTF8))
            {
                string lineDate;

                while ((lineDate = readDates.ReadLine()) != null)
                {
                    dates.Add(lineDate);
                }
            }

            string startDate = dates.FirstOrDefault();
            return startDate;
        }

        public WeightStatistics ComputeStatistics()
        {
            WeightStatistics stats = new WeightStatistics();
            float start = weights.FirstOrDefault();
            int weightsCount = weights.Count() - 1;
            float last = weights.LastOrDefault(); 

            foreach (float weight in weights)
            {
                stats.HighestWeight = Math.Max(weight, stats.HighestWeight);
                stats.LowestWeight = Math.Min(weight, stats.LowestWeight);
            }
            
            stats.LostWeight = start - last;
            stats.AverageWeight = stats.LostWeight / weightsCount;
            stats.Startweight = start;
            stats.Startdate = dates.FirstOrDefault();
            stats.LatestWeight = last;

            return stats;
        } 

        public void AddWeight(float weight)     // method to Add Weight to a list
        {
            weights.Add(weight);
        }

        public void AddDate(string date)        // method to Add Date to a list
        {
            dates.Add(date);
        }

        //List<string> names;
        internal List<float> weights;
        internal List<string> dates;
    }
}