using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\agadd\Documents\Adam\GitHub\AdventofCode\data\day_6_input.txt";

            var lines = File.ReadAllText(filePath);

            int packetMarker = 0;
            int messageMarker = 0;
            //Console.WriteLine(lines.Substring(4, -4));
            for (int i = 0; i <= lines.Length - 4; i++)
            {
                // Creates a substring of the next 4 characters
                string packetCheck = lines.Substring(i, 4);

                Console.WriteLine($"{packetCheck} is {OnlyOnceCheck(packetCheck)} Index of {lines[i]} = {i}");

                // Part 1
                if (!OnlyOnceCheck(packetCheck) && packetMarker == 0)
                {
                    packetMarker = i + 4;
                    continue;
                }

                // part 2
                if ((i <= lines.Length - 14))
                {
                    string messageCheck = lines.Substring(i, 14);
                    Console.WriteLine($"{messageCheck} is {OnlyOnceCheck(messageCheck)} Index of {lines[i]} = {i}");
                    if (!OnlyOnceCheck(messageCheck) && messageMarker == 0)
                    {
                        messageMarker = i + 14;
                        continue;
                    }

                }

            }
            Console.WriteLine(packetMarker);
            Console.WriteLine(messageMarker);
            Console.ReadKey();
        }

        // checks if a string has repeating occurences
        public static bool OnlyOnceCheck(string input)
        {
            return input.GroupBy(x => x).Any(g => g.Count() > 1);
        }
    }
}
