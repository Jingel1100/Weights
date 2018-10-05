using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weights_v2._0
{
    class WeightBook
    {
        public WeightBook()    // constructor
        {
            weights = new List<float>();
            dates = new List<string>();
        }

        public WeightStatistics ComputeStatistics(WeightStatistics stats)
        {
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

        internal void Reset()
        {
            weights = null;
            dates = null;
        }

        public string[] WriteDates()
        {
            string[] writeDates = dates.ToArray();
            return writeDates;
        }        // convert Dates from list to array

        public float[] WriteWeights()
        {
            float[] writeWeights = weights.ToArray();
            return writeWeights;
        }       // convert Weights from list to array

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
    
        internal static bool AddNewWeightAndDate(string username)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("  Adding info to Weight Book: ");
            Console.WriteLine();

            //Add a new weight and date.
            Console.Write("  Enter a new weight (e.g.: 78,4): ");
            string newWeight = Console.ReadLine();

            Console.Write("  Enter the date of new weight: ");
            string newDate = Console.ReadLine();

            try
            {
                Console.WriteLine("  Adding new weight and date... ");
                File.AppendAllText("WeightBook" + username + "_Weights.txt", newWeight + Environment.NewLine);
                File.AppendAllText("WeightBook" + username + "_Dates.txt", newDate + Environment.NewLine);
                Console.WriteLine("  Weight and Date have been added. ");
                return MainMenu.BackToMenu();
            }
            catch (Exception)
            {
                Console.WriteLine("  Adding weight and date failed. ");
                return MainMenu.BackToMenu();
            }
        }

        internal static bool CreateNewWeightBook(string username)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("  Create a new Weight Book: ");      //Create a new files for user with weights and dates
            Console.WriteLine();

            Console.Write("  Enter your start weight (e.g.: 63,5): ");
            float weight = float.Parse(Console.ReadLine());

            Console.Write("  Enter your start date (e.g.: 23-09-2018): ");
            string date = Console.ReadLine();

            // save to new file
            try
            {
                Console.WriteLine("  Saving data...");
                StreamWriter outputStreamDate = File.CreateText("WeightBook" + username + "_Dates.txt");
                outputStreamDate.WriteLine(date);
                outputStreamDate.Close();
                Console.WriteLine();
                StreamWriter outputStreamWeight = File.CreateText("WeightBook" + username + "_Weights.txt");
                outputStreamWeight.WriteLine(weight);
                outputStreamWeight.Close();
                Console.WriteLine();

                Console.WriteLine("  You created a new Weight Plan. ");
                return MainMenu.BackToMenu();
            }
            catch (Exception)
            {
                Console.WriteLine("  Saving the data failed. ");
                return MainMenu.BackToMenu();
            }
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
