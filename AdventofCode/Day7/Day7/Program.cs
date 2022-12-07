/*
 * Linked List Solution
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

string file = "../../../../../Data/day_7_input.txt";

IDictionary<object, object> structure = new Dictionary<object, object>();

var input = File.ReadAllLines(file);
var directories = new Dictionary<string, int>();
var currentDirectoryPath = new LinkedList<string>();
var result2 = 0;
var totalSpace = 70000000;
var neededSpace = 30000000;



foreach (var line in input)
{
    var commands = line.Split(' ');

    //command
    if (line.StartsWith("$"))
    {
        if (commands[1] == "cd")
        {
            switch (commands[2])
            {
                case "/":
                    currentDirectoryPath.Clear();
                    if (!directories.ContainsKey("/")) directories.Add("/", 0);
                    currentDirectoryPath.AddLast("/");
                    break;
                case "..":
                    currentDirectoryPath.RemoveLast();
                    break;
                default:
                    currentDirectoryPath.AddLast(commands[2]);
                    break;
            }
        }
        //ls can be ignored
    }
    //directory
    else if (line.StartsWith("dir"))
    {
        var directory = string.Join("", currentDirectoryPath) + commands[1];
        if (!directories.ContainsKey(directory)) directories.Add(directory, 0);
    }
    //must be a file
    else
    {
        for (var i = 0; i < currentDirectoryPath.Count; i++)
        {
            var folders = "";
            for (var j = 0; j <= i; j++)
            {
                folders += currentDirectoryPath.ElementAt(j);
            }
            directories[folders] += Convert.ToInt32(commands[0]);
        }
    }
}

var result = directories.Where(kvp => kvp.Value <= 100000).Sum(kvp => kvp.Value);




//Part2 starts here;
var sortedDirectories = directories.OrderBy(x => x.Value).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
var currentAvailableSpace = totalSpace - directories["/"];
var spaceNeededToBeFreedUp = neededSpace - currentAvailableSpace;

result2 = sortedDirectories.First(kvp => kvp.Value > spaceNeededToBeFreedUp).Value;

Console.WriteLine($"Part 1: {result}");
Console.WriteLine($"Part 2: {result2}");

Console.ReadKey();
