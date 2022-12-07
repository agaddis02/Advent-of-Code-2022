using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Day3
{
    class Program
    {
        static void Main(string[] args)


        {
            // File path to text document 
            string filePath = @"C:\Users\agadd\Documents\Adam\GitHub\AdventofCode\data\day_3_input.txt";

            var lines = File.ReadAllLines(filePath);
            // Part 1 
            int priorites = 0;
            foreach (string rucksack in lines)
            {
                int start = 0;
                int mid = rucksack.Length / 2;
                int end = rucksack.Length - 1;
                string compartment1 = rucksack.Substring(start, mid);
                string compartment2 = rucksack.Substring(mid);
                Console.WriteLine($"Rucksack full: {rucksack}");
                Console.WriteLine($"Comparment # 1: {compartment1}");
                Console.WriteLine($"Comparment # 2: {compartment2}");

                var countC1 = compartment1.GroupBy(c => c)
                  .Select(g => new { g.Key, Count = g.Count() });
                var countC2 = compartment2.GroupBy(c => c)
                 .Select(g => new { g.Key, Count = g.Count() });

                var dict = countC1.ToDictionary(g => g.Key);

                foreach (var result in countC2)
                {
                    Console.WriteLine("{0} = {1}", result.Key, result.Count);

                    if (dict.ContainsKey(result.Key))
                    {
                        int letterValue = (int)Enum.Parse(typeof(alphabet), result.Key.ToString());
                        priorites += letterValue;
                        Console.WriteLine($"The Matching Character is: {result.Key}");
                        Console.WriteLine($"Enum lookup: {(int)Enum.Parse(typeof(alphabet), result.Key.ToString())}");
                    }
                }

            }

            Console.WriteLine($"Total Priorties {priorites}");
            Console.ReadKey();
            // Part 1

            // Part 2 
            priorites = 0;
            int counter = 1;
            string line1 = "";
            string line2 = "";
            string line3 = "";
            foreach (string rucksack in lines)
            {

                if (counter == 1 )
                {
                    line1 = rucksack;
                    counter++;
                    continue;
                }
                if (counter == 2)
                {
                    line2 = rucksack;
                    counter++;
                    continue;
                }
                line3 = rucksack;
                List<char> matches = new List<char>();

                var countC1 = line1.GroupBy(c => c)
                  .Select(g => new { g.Key, Count = g.Count() });
                var countC2 = line2.GroupBy(c => c)
                 .Select(g => new { g.Key, Count = g.Count() });
                var countC3 = line3.GroupBy(c => c)
                 .Select(g => new { g.Key, Count = g.Count() });

                var dict = countC1.ToDictionary(g => g.Key);

                foreach (var result in countC2)
                {
                    Console.WriteLine("{0} = {1}", result.Key, result.Count);

                    if (dict.ContainsKey(result.Key))
                    {
                        matches.Add(result.Key);

                        //int letterValue = (int)Enum.Parse(typeof(alphabet), result.Key.ToString());
                        //priorites += letterValue;
                        //Console.WriteLine($"The Matching Character is: {result.Key}");
                        //Console.WriteLine($"Enum lookup: {(int)Enum.Parse(typeof(alphabet), result.Key.ToString())}");
                    }
                }

                foreach (var result in countC3)
                {
                    if (matches.Contains(result.Key))
                    {
                        int letterValue = (int)Enum.Parse(typeof(alphabet), result.Key.ToString());
                        priorites += letterValue;
                        Console.WriteLine($"The Matching Character is: {result.Key}");
                        Console.WriteLine($"Enum lookup: {(int)Enum.Parse(typeof(alphabet), result.Key.ToString())}");
                    }
                }

                if (counter == 3)
                {
                    counter = 1;
                    continue;
                }
            }
            Console.WriteLine($"Total Priorties {priorites}");
            Console.ReadKey();
            // Part 2
        }

        public enum alphabet
        {
            a=1, b=2, c=3, d=4, e=5, f=6, g=7, h=8, i=9, j=10, k=11, l=12, m=13, n=14, o=15, p=16, q=17, r=18, s=19, t=20, u=21, v=22, w=23, x=24, y=25, z=26
            ,A=27, B=28, C=29, D=30, E=31, F=32, G=33, H=34, I=35, J=36, K=37, L=38, M=39, N=40, O=41, P=42, Q=43, R=44, S=45, T=46, U=47, V=48, W=49, X=50, Y=51, Z=52
        }
    }
}


