﻿using System;
using System.IO;

namespace Children_sRatingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var childInMemoryKrzysztof = new InMemoryChild("Krzysztof");
            var childSavedKrzysztof = new SavedChild("Krzysztof");
            childInMemoryKrzysztof.RateAdded += OnRateAdded;
            childSavedKrzysztof.RateAdded += OnRateAdded;

            Console.WriteLine("Enter a float value from a range 1-6");
            Console.WriteLine("To add a half grade use '+' for example '2+'");
            Console.WriteLine("Type 'a' to add or 'r' to remove.");
            Console.WriteLine("Type 's' to see the current stats, 'l' to see lists or 'q' to exit.");
            Console.WriteLine(" ");
            Console.WriteLine("Type 'memory' to save statistics in computer's cache or 'save' to be saved in a file.");
            Console.WriteLine("I suggest using 'memory' to test the application and the 'file' for normal use.");
            var inputMain = Console.ReadLine();
            if (inputMain == "memory")
            {
            AddMemoryRate(childInMemoryKrzysztof);
            }
            else if (inputMain == "file")
            {
            AddSavedRate(childSavedKrzysztof);
            }
        }

        private static void AddMemoryRate(IChildren childInMemoryKrzysztof)
        {
            Console.WriteLine("Select a command:'a', 'r', 's', 'l' or 'q'.");
            while (true)
            {
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }
                else if (input == "a")
                {
                    Console.WriteLine("Enter a value.");
                    var input2 = Console.ReadLine();
                    childInMemoryKrzysztof.AddRating(input2);
                    Console.WriteLine("Select a command:'a', 'r', 's', 'l' or 'q'.");
                }
                else if (input == "r")
                {

                    Console.WriteLine("Enter a value.");
                    var input2 = Console.ReadLine();
                    childInMemoryKrzysztof.RemoveRating(input2);
                    Console.WriteLine("Select a command:'a', 'r', 's', 'l' or 'q'.");
                }
                else if (input == "s")
                {
                    var statKrzysztof = childInMemoryKrzysztof.GetStatistics();

                    Console.WriteLine($"Krzysztof's average rating is: {statKrzysztof.Average:N2}");
                    Console.WriteLine($"Krzysztof's max rating is: {statKrzysztof.High:N2}");
                    Console.WriteLine($"Krzysztof's min rating is: {statKrzysztof.Low:N2}");
                    Console.WriteLine("Select a command:'a', 'r', 's', 'l' or 'q'.");
                }
                else if (input == "l")
                {
                    var n = 1;
                    foreach (var item in childInMemoryKrzysztof.RatingLists)
                    {
                        Console.WriteLine($"No.{n}:  {item}");
                        n++;
                    }
                    Console.WriteLine("Select a command:'a', 'r', 's', 'l' or 'q'.");
                }
                else
                {
                    throw new ArgumentException($"Argument out of rate range: '{input}'.");
                }
            }
        }

        private static void AddSavedRate(IChildren childSavedKrzysztof)
        {
            Console.WriteLine("Select a command:'a', 'r', 's', 'l' or 'q'.");
            while (true)
            {
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }
                else if (input == "a")
                {
                    Console.WriteLine("Enter a value.");
                    var input2 = Console.ReadLine();
                    childSavedKrzysztof.AddRating(input2);
                    Console.WriteLine("Select a command:'a', 'r', 's' or 'q'.");
                }
                else if (input == "r")
                {
                    Console.WriteLine("Enter a value.");
                    var input2 = Console.ReadLine();
                    childSavedKrzysztof.RemoveRating(input2);
                    Console.WriteLine("Select a command:'a', 'r', 's' or 'q'.");
                }
                else if (input == "s")
                {
                    var statKrzysztof = childSavedKrzysztof.GetStatistics();

                    Console.WriteLine($"Krzysztof's average rating is: {statKrzysztof.Average:N2}");
                    Console.WriteLine($"Krzysztof's max rating is: {statKrzysztof.High:N2}");
                    Console.WriteLine($"Krzysztof's min rating is: {statKrzysztof.Low:N2}");
                }
                else if (input == "l")
                {
                    throw new NotImplementedException("This command is not available");
                }
                else
                {
                    throw new ArgumentException($"Argument out of rate range: '{input}'.");
                }
            }
        }

        static void OnRateAdded(object sender, EventArgs args)
        {
            Console.WriteLine("Oh no! You're not getting a reward today");
        }
    }
}