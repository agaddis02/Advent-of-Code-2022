using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            // File path to text document 
            string filePath = @"C:\Users\agadd\Documents\Adam\GitHub\AdventofCode\data\day_2_input.txt";

            IDictionary<char, int> rollValueMapping =  new Dictionary<char, int> 
            {
                {'A', 1}
                , {'X', 1}
                , {'B', 2}
                , {'Y', 2}
                , {'C', 3}
                , {'Z', 3}
            };
            // Part 1
            IDictionary<string, string> winLossDecider = new Dictionary<string, string>
            {
                {"AX", "DD" }
                , {"AY", "LW"}
                , {"AZ", "WL"}
                , {"BX", "WL"}
                , {"BY", "DD"}
                , {"BZ", "LW"}
                , {"CX", "LW"}
                , {"CY", "WL"}
                , {"CZ", "DD"}
            };
            // Part 1 


            IDictionary<char, int> winLossValueMapping = new Dictionary<char, int>
            {
                {'L', 0}
                , {'D', 3}
                , {'W', 6}

            };

            char outcome = 'L';
            int myScore = 0;
            int elfScore = 0;

            var lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {

                //Console.WriteLine($"Scoring values for This Hand: {line}");
                Tuple<int, int> scores = score_round(line.Replace(" ", String.Empty), rollValueMapping, winLossDecider, winLossValueMapping);
                myScore += scores.Item1;
                //elfScore += scores.Item2;
                //Console.WriteLine($"Human scored: {scores.Item1}");
                //Console.WriteLine($"Elf scored: {scores.Item2}");
            }
            // Part 1 Total Score
            Console.WriteLine($"My Total Score: {myScore}");

            Console.ReadKey();


            // part 2
            IDictionary<string, string> winLossDecider2 = new Dictionary<string, string>
            {
                {"AX", "AZL" }
                , {"AY", "AXD"}
                , {"AZ", "AYW"}
                , {"BX", "BXL"}
                , {"BY", "BYD"}
                , {"BZ", "BZW"}
                , {"CX", "CYL"}
                , {"CY", "CZD"}
                , {"CZ", "CXW"}
            };
            // reset my score
            myScore = 0;
            foreach (string line in lines)
            {

                Console.WriteLine($"Scoring values for This Hand: {line}");
                int scores = score_round_2(line.Replace(" ", String.Empty), rollValueMapping, winLossDecider2, winLossValueMapping);
                myScore += scores;
            }

            Console.WriteLine($"My Total Score From Part 2: {myScore}");

            Console.ReadKey();


        }

        static Tuple<int, int> score_round(string hand, IDictionary<char, int> handValueMap, IDictionary<string, string> WLDecider, IDictionary<char, int> WLValue)
        {
            int myHandValue;
            int myOutcomeValue;
            int elfHandValue;
            int elfOutcomeValue;
            string matchOutcome;

            char elf = hand[0];
            char me = hand[1];

            handValueMap.TryGetValue(me, out myHandValue);
            handValueMap.TryGetValue(elf, out elfHandValue);
            WLDecider.TryGetValue(hand, out matchOutcome);
            WLValue.TryGetValue(matchOutcome[0], out elfOutcomeValue);
            WLValue.TryGetValue(matchOutcome[1], out myOutcomeValue);

            int myScore = myHandValue + myOutcomeValue;
            int elfScore = elfHandValue + elfOutcomeValue;



            return Tuple.Create(myScore, elfScore);
        }
        static int score_round_2(string hand, IDictionary<char, int> handValueMap, IDictionary<string, string> WLDecider, IDictionary<char, int> WLValue)
        {
            int myHandValue;
            int myOutcomeValue;
            string matchOutcome;

            
            
            WLDecider.TryGetValue(hand, out matchOutcome);
            handValueMap.TryGetValue(matchOutcome[1], out myHandValue);
            WLValue.TryGetValue(matchOutcome[2], out myOutcomeValue);

            return myHandValue + myOutcomeValue;
        }
    }
}
