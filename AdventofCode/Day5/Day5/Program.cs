using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\agadd\Documents\Adam\GitHub\AdventofCode\data\day_5_input.txt";

            IDictionary<int, List<char>> crates = new Dictionary<int, List<char>>();

            // pulls out the stations
            foreach (var value in File.ReadAllLines(filePath).ToArray().GetValue(8).ToString())
            {
                if (value != ' ')
                {
                    Console.WriteLine("This is: " + value);
                    crates.Add(value, null);
                }
                
            }

            foreach (string line in File.ReadAllLines(filePath))
            {
                if (!line.StartsWith("["))
                {
                    break;
                }

                string formatted = line.Replace("[", String.Empty).Replace("]", String.Empty);
                Console.WriteLine(formatted);

                foreach (char crate in formatted.Trim())
                {
                    Console.WriteLine("this is: " + crate);
                }



            }
            Console.ReadKey();

        }
    }
}
