﻿using System;
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
                    Console.WriteLine();
                    Console.WriteLine("  Weight Plan Statistics: ");
                    Console.WriteLine();

                    Console.Write("  Enter your name: ");
                    string bookName = Console.ReadLine();

                    //Read info from "WeightBook(bookName).txt" file. 
                    
                    try
                    {
                        string line;
                        int count = 0;
                        string startDate;
                        float startWeight;
                        WeightBook book = new WeightBook();

                        StreamReader reader = new StreamReader("WeightBook" + bookName + ".txt");
                        while ((line = reader.ReadLine()) != null)
                        {
                            count++;

                            if (count == 1)
                            {
                                string[] bits = line.Split(',');
                                startDate = bits[0];
                                startWeight = float.Parse(bits[1]);
                            }

                            if (count > 1)
                            {
                                string[] bits2 = line.Split(',');
                                book.AddDate(bits2[0]);
                                book.AddWeight(float.Parse(bits2[1]));
                            }
                        }
                        reader.Close();

                        WeightStatistics stats = book.ComputeStatistics();
                        Console.WriteLine();
                        Console.WriteLine("  Startweight: ");
                        Console.WriteLine();
                        Console.WriteLine("  Highest weight: {0:f}", stats.HighestWeight);
                        Console.WriteLine("  Lowest weight: {0:f}", stats.LowestWeight);
                        Console.WriteLine("  Lost weight: {0:f}", stats.LostWeight);
                        Console.WriteLine("  Average    : {0:f}", stats.AverageWeight);

                        Console.WriteLine();
                        return Back();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("  A WeightBook with this name could not be found. ");
                        return Back();
                    }
                    
                case "4":
                    return Quit();

                default:
                    return NonValidAction();
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
                string newContent = newDate + "," + newWeight;
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
            
            Console.Write("  Enter your start weight (e.g.: 63,5): ");
            float weight = float.Parse(Console.ReadLine());
          
            Console.Write("  Enter your start date (e.g.: 23-09-2018): ");
            string date = Console.ReadLine();
            
            // save to new file
            try
            {
                Console.WriteLine("  Saving data...");
                StreamWriter outputStream = File.CreateText("WeightBook" + name + ".txt");
                outputStream.WriteLine(date + "," + weight);
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
