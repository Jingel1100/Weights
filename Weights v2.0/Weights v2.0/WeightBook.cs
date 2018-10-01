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
            Console.WriteLine("  Create a new Weight Book: ");
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

    }
}
