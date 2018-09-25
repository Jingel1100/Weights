using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace Weights
{
    class Program
    {
        static void Main(string[] args)
        {
            bool menu;
            menu = Program.MainMenu();

            while (menu == true)
            {
                MainMenu(); 
            }
        }

        private static bool MainMenu()
        {
            //Start Menu
            string choice = StartMenu();
            //Menu choices
            switch (choice)
            {
                case "1":
                    return CreateNewWeightPlan();

                case "2":
                    return AddNewWeightAndDate();

                case "3":
                    return ShowStatistics();

                case "4":
                    return Quit();

                default:
                    return NonValidAction();
            }
        }

        private static bool ShowStatistics()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("  Weight Plan Statistics: ");
            Console.WriteLine();

            Console.Write("  Enter your name: ");
            string bookName = Console.ReadLine();

            //Read info from "WeightBook(bookName).txt" file. 
            try
            {
                WeightBook book = new WeightBook();
                float startWeight = book.ReadStartWeight(bookName);
                string startDate = book.ReadStartDate(bookName);
                string latestDate = book.dates.LastOrDefault();
                int count = (book.dates.Count() - 1);

                WeightStatistics stats = book.ComputeStatistics();

                /*Console.WriteLine("  Stored Data: ");     //Tabel 

                DataTable storedData = new DataTable();
                storedData.Columns.Add(" Dates ");
                storedData.Columns.Add(" Weights ");
                string passDate = " ";
                foreach (string date in book.dates)
                {
                    
                    for (int i = 0; i < (book.dates.Count() - 1); i++)
                    {
                        passDate = book.dates[i];
                    }
                    storedData.Rows.Add(passDate);
                }

                Console.WriteLine("  " + storedData);*/
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

                return Back();

            }
            catch (Exception)
            {
                Console.WriteLine("  A WeightBook with this name could not be found. ");
                return Back();
            }
        }

        private static bool Quit()
        {
            Environment.Exit(0);
            return false;
        }

        private static bool NonValidAction()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("  !** Please enter a valid number. **! ");
            Console.WriteLine();
            return true;
        }

        private static string StartMenu()
        {
            Console.WriteLine();
            Console.WriteLine("  Welcome to Weight Plan");
            Console.WriteLine("     MENU:");
            Console.WriteLine("        1. Create a new Weight Plan. ");
            Console.WriteLine("        2. Add a new Weight and date. ");
            Console.WriteLine("        3. Show statistics of a specific Weight Plan. ");
            Console.WriteLine("        4. Quit. ");
            Console.WriteLine();
            Console.Write("  My number of choice: ");
            string choice = Console.ReadLine();
            return choice;
        }

        private static bool AddNewWeightAndDate()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("  Adding info to Weight Plan: ");
            Console.WriteLine();

            //Add a new weight and date.
            Console.Write("  Enter your name: ");
            string newName = Console.ReadLine();

            Console.Write("  Enter new weight (e.g.: 78,4): ");
            string newWeight = Console.ReadLine();
            
            Console.Write("  Enter date of new weight: ");
            string newDate = Console.ReadLine();

            try
            {
                Console.WriteLine("  Adding new weight and date... ");
                File.AppendAllText("WeightBook" + newName + "_Weights.txt", newWeight + Environment.NewLine);
                File.AppendAllText("WeightBook" + newName + "_Dates.txt", newDate + Environment.NewLine);                              
                Console.WriteLine("  Weight and Date have been added. ");
                return Back();
            }
            catch (Exception)
            {
                Console.WriteLine("  Adding weight and date failed. ");
                return Back();
            }
        }

        private static bool CreateNewWeightPlan()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("  Create a new Weight Plan: ");
            Console.WriteLine();

            Console.Write("  Enter your name: ");
            string name = Console.ReadLine();
            
            Console.Write("  Enter your start weight (e.g.: 63,5): ");
            float weight = float.Parse(Console.ReadLine());
          
            Console.Write("  Enter your start date (e.g.: 23-09-2018): ");
            string date = Console.ReadLine();
            
            // save to new file
            try
            {
                Console.WriteLine("  Saving data...");
                StreamWriter outputStreamDate = File.CreateText("WeightBook" + name + "_Dates.txt");
                outputStreamDate.WriteLine(date);
                outputStreamDate.Close();
                Console.WriteLine();
                StreamWriter outputStreamWeight = File.CreateText("WeightBook" + name + "_Weights.txt");
                outputStreamWeight.WriteLine(weight);
                outputStreamWeight.Close();
                Console.WriteLine();

                Console.WriteLine("  You created a new Weight Plan. ");
                return Back();
            }
            catch (Exception)
            {
                Console.WriteLine("  Saving the data failed. ");
                return Back();
            }
        }

        private static bool Back()
        {
            Console.WriteLine("  Press 'M' to go back to the menu. ");
            Console.WriteLine("  Press 'Q' to quit this application. ");
            Console.Write("  Make your choice: ");
            string choice = Console.ReadLine();
            Console.Clear();

            if (choice == "m")
            {
                return true;
            }

            else if (choice == "M")
            {
                return true;
            }

            else
            {
                Environment.Exit(0);
                return false;
            }
        }

    }
}
