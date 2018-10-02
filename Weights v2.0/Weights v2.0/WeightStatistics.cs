using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weights_v2._0
{
    class WeightStatistics
    {
        public WeightStatistics()
        {
            HighestWeight = float.MinValue;
            LowestWeight = float.MaxValue;
        }

        public static bool ShowStatistics(string username, WeightStatistics stats, WeightBook book)
        {
            Console.Clear();                // header for showing statistics.
            Console.WriteLine();
            Console.WriteLine("  Weight Book Statistics: ");
            Console.WriteLine();

                                            // Read info from "WeightBook(username).txt" file. 
            try                             
            {
                float startWeight = book.ReadStartWeight(username);
                string startDate = book.ReadStartDate(username);
                string latestDate = book.dates.LastOrDefault();
                int count = (book.dates.Count() - 1);
                float[] weights = book.WriteWeights();
                string[] dates = book.WriteDates();

                // Write stored info to console in two columns.
                Console.WriteLine("  Stored dates and weights: "); 
                Console.WriteLine();
                Console.WriteLine("  Dates " + "/t" + " Weights ");
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine("  " + dates[i] + "/t {0:f2}", weights[i]);  
                }
                Console.WriteLine();

                // Compute and Write statistics to console.
                stats = book.ComputeStatistics(stats);     
                Console.WriteLine();
                Console.Write("  Start Weight   :   {0:f2}", startWeight);
                Console.WriteLine(" at " + startDate);
                Console.Write("  Latest weight  :   {0:f2}", stats.LatestWeight);
                Console.WriteLine(" at " + latestDate);
                Console.WriteLine();
                Console.WriteLine("  Highest weight :   {0:f2}", stats.HighestWeight);
                Console.WriteLine("  Lowest weight  :   {0:f2}", stats.LowestWeight);
                Console.Write("  Lost weight    :   {0:f2}", stats.LostWeight);
                Console.WriteLine(" lost over {0} weeks ", count);
                Console.Write("  Average        :   {0:f2}", stats.AverageWeight);
                Console.WriteLine(" a week ");
                Console.WriteLine();

                Console.WriteLine();

                return MainMenu.BackToMenu();

            }
            catch (Exception)
            {
                Console.WriteLine("  A WeightBook with this name could not be found. ");
                return MainMenu.BackToMenu();
            }
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
