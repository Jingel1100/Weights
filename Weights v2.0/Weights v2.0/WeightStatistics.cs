using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Weights_v2._0
{
    class WeightStatistics
    {
        public WeightStatistics()       // constructor
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
                    // Declerations and Initialisation
                    float startWeight = book.ReadStartWeight(username);
                    string startDate = book.ReadStartDate(username);
                    string latestDate = book.dates.LastOrDefault();
                    int count = (book.dates.Count() - 1);
                    float[] weights = book.WriteWeights();
                    string[] dates = book.WriteDates();
                    stats = book.ComputeStatistics(stats);
                    float lostWeight = stats.LostWeight;
                    float average = stats.AverageWeight;

                    if (average < 0)
                    {
                        average *= -1;
                    }

                    // Write stored info to console in two columns.

                    Console.WriteLine("  Stored dates and weights: ");
                    Console.WriteLine();
                    Console.WriteLine("  Dates " + "      " + " Weights ");
                    for (int i = 0; i < (dates.Length); i++)
                    {
                        Console.Write("  " + dates[i]);
                        Console.WriteLine("      " + weights[i]);
                    }
                    Console.WriteLine();

                    // Write statistics to console.

                    Console.WriteLine();
                    Console.Write("  Start Weight   :   {0:f}", startWeight);
                    Console.WriteLine(" at " + startDate);
                    Console.Write("  Latest weight  :   {0:f}", stats.LatestWeight);
                    Console.WriteLine(" at " + latestDate);
                    Console.WriteLine();
                    Console.WriteLine("  Highest weight :   {0:f}", stats.HighestWeight);
                    Console.WriteLine("  Lowest weight  :   {0:f}", stats.LowestWeight);

                    // Is there weightloss or gain?
                    if (lostWeight < 0)
                    {
                        lostWeight *= -1;
                        Console.WriteLine("  Gained weight  :   {0:f}", lostWeight);
                    }
                    else
                    {
                        Console.WriteLine("  Lost weight    :   {0:f}", lostWeight);
                    }

                    Console.Write("  Average        :   {0:f}", average);
                    Console.WriteLine();

                    Console.WriteLine();

                    book.Reset();

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
