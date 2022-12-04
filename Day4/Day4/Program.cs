using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            // File path to text document 
            string filePath = @"C:\Users\agadd\Documents\Adam\GitHub\AdventofCode\data\day_4_input.txt";

            var lines = File.ReadAllLines(filePath);

            int completeOverlap = 0;
            int partialOverlap = 0;

            foreach (string pair in lines)
            {
                var elf1 = Enumerable.Range(int.Parse(pair.Split(',')[0].Split('-')[0]), (int.Parse(pair.Split(',')[0].Split('-')[1]) + 1) - int.Parse(pair.Split(',')[0].Split('-')[0])).ToList();
                var elf2 = Enumerable.Range(int.Parse(pair.Split(',')[1].Split('-')[0]), (int.Parse(pair.Split(',')[1].Split('-')[1]) + 1) - int.Parse(pair.Split(',')[1].Split('-')[0])).ToList();

                Console.WriteLine($"Elf 1: {pair.Split(',')[0]}");
                Console.WriteLine($"Elf 2: {pair.Split(',')[1]}");

                // part 1
                if (elf1.Contains(elf2.First()) && elf1.Contains(elf2.Last()))
                {
                    Console.WriteLine("Elf 2 is englufed by Elf 1");
                    completeOverlap++;
                    continue;
                    
                }
                if (elf2.Contains(elf1.First()) && elf2.Contains(elf1.Last()))
                {
                    Console.WriteLine("Elf 1 is englufed by Elf 2");
                    completeOverlap++;
                    continue;
                }
                // part 1

                // part 2
                if (elf2.Contains(elf1.First()) && !elf2.Contains(elf1.Last()) 
                    || elf2.Contains(elf1.Last()) && !elf2.Contains(elf1.First())
                    || elf1.Contains(elf2.First()) && !elf1.Contains(elf2.Last())
                    || elf1.Contains(elf2.Last()) && !elf1.Contains(elf2.First())
                    )
                {
                    partialOverlap++;
                    continue;
                }


            }

            Console.WriteLine(completeOverlap);
            Console.WriteLine(partialOverlap);
            Console.WriteLine($"Part 1: {completeOverlap}");
            Console.WriteLine($"Part 2: {partialOverlap + completeOverlap}");

            Console.ReadKey();
        }
    }
}
