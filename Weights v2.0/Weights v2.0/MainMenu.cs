using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weights_v2._0
{
    class MainMenu
    {
        internal string username;
        WeightStatistics stats = new WeightStatistics();
        Errors error = new Errors();

        public MainMenu(string name)            // constructor
        {
            username = name;
        }

        internal bool Menu(string username)
        {
            //Start Menu
            string choice = StartMenu();
            //Menu choices
            switch (choice)
            {
                case "1":
                    return WeightBook.CreateNewWeightBook(username);

                case "2":
                    return WeightBook.AddNewWeightAndDate(username);

                case "3":
                    return WeightStatistics.ShowStatistics(username);

                case "4":
                    return ExitProgram();

                default:
                    return Errors.NonValidAction();
            }
        }

        private bool ExitProgram()
        {
            Environment.Exit(0);
            return false;
        }

       
        private string StartMenu()
        {
            Console.WriteLine();
            Console.WriteLine("  {0} Weight Book", username);
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

        public static bool BackToMenu()
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
