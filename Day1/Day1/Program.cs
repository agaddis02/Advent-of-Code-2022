using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            // File path to text document 
            string filePath = @"C:\Users\agadd\Documents\Adam\GitHub\AdventofCode\data\day_1_input.txt";

            // Create dictionary to store values 
            IDictionary<int, int> elfToCalories = new Dictionary<int, int>();
            
            // keep count of distinct elf 
            int elf = 0;

            // collect each row from text file
            foreach (string line in File.ReadAllLines(filePath))
            {
                // skip empty lines
                if (String.IsNullOrEmpty(line))
                {
                    elf += 1;
                    // Console.WriteLine($"Start counting for New Elf: {elf}");
                    continue;
                }
                int calories = int.Parse(line);
                // check if elf is already accounted for
                if (!elfToCalories.ContainsKey(elf))
                {
                    // if not, add in elf and starting calories
                    elfToCalories.Add(elf, calories);
                    continue;
                }
                // otherwise add on calories to existing elf
                // Console.WriteLine($"adding {calories} to elf {elf}");
                elfToCalories[elf] += calories;
            }

            //foreach (KeyValuePair<int, int> match in elfToCalories)
            //{
            //    Console.WriteLine($"Key: {match.Key}, Value: {match.Value}");
            //}

            /*
              * Part 1: Get Highest calorie
              * 
              */
            var sortedElfs = from pair in elfToCalories orderby pair.Value descending select pair;
            // get highest calorie elf
            Console.WriteLine($"Highest Calorie elf: {sortedElfs.First()}");

            /*
             * Part 2: Get sum of top 3 calories
             * 
             */
            Console.WriteLine("The Top 3 Elf's are:");
            int top3Calories = 0;
            for (int i = 0; i < 3; i++)
            {
                KeyValuePair<int, int> curr = sortedElfs.ElementAt(i);
                Console.WriteLine($"elf number {curr.Key}: {curr.Value}");
                top3Calories += curr.Value;
            }
            Console.WriteLine($"Combined Calories of top 3 elfs: {top3Calories}");
            

            Console.ReadKey();
        }
    }
}
