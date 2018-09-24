using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weights
{
    class WeightBook
    {
        public WeightBook(string name)    // constructor
        {
            string bookName = name;
            weights = new List<float>();
            dates = new List<string>();
        }

        public WeightStatistics ComputeStatistics()
        {
            WeightStatistics stats = new WeightStatistics();
            
            float start = stats.Startweight;
            float last = weights.LastOrDefault(); 
            foreach (float weight in weights)
            {
                stats.HighestWeight = Math.Max(weight, stats.HighestWeight);
                stats.LowestWeight = Math.Min(weight, stats.LowestWeight);
                
            }

            stats.LostWeight = start - last;

            return stats;
        } 

        //public void AddName(string name)
        // {
        //   names.Add(name);
        //}

        public void AddWeight(float weight)     // method to Add Weight to a list
        {
            weights.Add(weight);
        }

        public void AddDate(string date)        // method to Add Date to a list
        {
            dates.Add(date);
        }

        //List<string> names;
        List<float> weights;
        List<string> dates;
    }
}