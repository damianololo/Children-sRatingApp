// using System;

// namespace Children_sRatingApp
// {
// internal class ConsoleLogic
//     {
//         public static void AddRate(Child childKrzysztof)
//         {
//             while (true)
//             {
//                 var input = Console.ReadLine();

//                 if (input == "q")
//                 {
//                     break;
//                 }
//                 else if (input == "a")
//                 {
//                     Console.WriteLine("Enter a value.");
//                     var input2 = Console.ReadLine();
//                     childKrzysztof.AddRating(input2);
//                     Console.WriteLine("Select a command:'a', 'r', 's' or 'q'.");
//                 }
//                 else if (input == "r")
//                 {

//                     Console.WriteLine("Enter a value.");
//                     var input2 = Console.ReadLine();
//                     childKrzysztof.RemoveRating(input2);
//                     Console.WriteLine("Select a command:'a', 'r', 's' or 'q'.");
//                 }
//                 else if (input == "s")
//                 {
//                     var statKrzysztof = childKrzysztof.GetStatistics();

//                     Console.WriteLine($"Krzysztof's average rating is: {statKrzysztof.Average:N2}");
//                     Console.WriteLine($"Krzysztof's max rating is: {statKrzysztof.High:N2}");
//                     Console.WriteLine($"Krzysztof's min rating is: {statKrzysztof.Low:N2}");
//                 }
//                 else if (input == "l")
//                 {
//                     var n = 1;
//                     foreach (var item in childKrzysztof.RatingLists)
//                     {
//                         Console.WriteLine($"No.{n}:  {item}");
//                         n++;
//                     }
//                 }
//                 else
//                 {
//                     throw new ArgumentException($"Argument out of rate range: '{input}'.");
//                     //Console.WriteLine("Wrong command! Select a command:'a', 'r', 's' or 'q'.");
//                 }
//             }
//         }
//     }
// }