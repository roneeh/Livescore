using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
            Console.ReadKey();
        }

        private static void Menu()
        {
            Console.WriteLine("-------------- Menu --------------");
            Console.WriteLine("1) Show all the livescores.");
            Console.WriteLine("2) Show all the livescores for a particular country.");
            Console.WriteLine("3) Show fixtures for tomorrow.");
            Console.WriteLine("---------- End of menu ----------");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    ScoreHelpers.ShowResults(ScoreHelpers.ShowResultsList<AllScores>("scores","live","match", null));
                    break;
                case "2":
                    Console.Clear();
                    ScoreHelpers.Country();
                    break;
                case "3":
                    Console.Clear();
                    ScoreHelpers.ShowResults(ScoreHelpers.ShowResultsList<AllScores>("fixtures", "matches", "fixtures", null));
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Please pick a number from the menu.");
                    Console.WriteLine();
                    Menu();
                    break;
            }
        }
    }
}