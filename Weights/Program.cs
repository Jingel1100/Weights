using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
                    Console.Clear();
                    Console.WriteLine("  Weight Plan Statistics: ");
                    //WeightStatistics stats = book.ComputeStatistics();

                    //Console.WriteLine("Highest weight: " + stats.HighestWeight);
                    //Console.WriteLine("Lowest weight: " + stats.LowestWeight);
                    //Console.WriteLine("Lost weight: " + stats.LostWeight);

                    Console.WriteLine("...");
                    return Back();

                case "4":
                    Environment.Exit(0);
                    return false;

                default:
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("  !** Please enter a valid number. **! ");
                    Console.WriteLine();
                    return true;
            }
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
            string convNewWeight = Console.ReadLine();
            float newWeight = float.Parse(convNewWeight);

            Console.Write("  Enter date of new weight: ");
            string newDate = Console.ReadLine();

            try
            {
                Console.WriteLine("  Adding new weight and date... ");
                string newContent = "  " + newDate + " , " + convNewWeight;
                File.AppendAllText("WeightBook" + newName + ".txt", newContent + Environment.NewLine);
                                              
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
            WeightBook book = new WeightBook(name);

            Console.Write("  Enter your start weight (e.g.: 63,5): ");
            float weight = float.Parse(Console.ReadLine());
            book.AddWeight(weight);

            //convert float to string for save

            Console.Write("  Enter your start date (e.g.: 23-09-2018): ");
            string date = Console.ReadLine();
            book.AddDate(date);

            // save to new file
            try
            {
                Console.WriteLine("  Saving data...");
                StreamWriter outputStream = File.CreateText("WeightBook" + name + ".txt");
                outputStream.WriteLine();
                outputStream.WriteLine("  " + name + "'s Weight Book. ");
                outputStream.WriteLine();
                outputStream.WriteLine("  Start weight: {0:f} ", weight);
                outputStream.WriteLine("  Start date: " + date);
                outputStream.WriteLine();
                outputStream.Close();
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
