using System;
using System.IO;
using System.Linq;

namespace advent_of_code_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var unsortedInput = @"C:\Users\Wezno\source\repos\advent_of_code_4\advent_of_code_4\input.txt";
            var sortedInput = @"C:\Users\Wezno\source\repos\advent_of_code_4\advent_of_code_4\sorted_input.txt";
            File.WriteAllLines(sortedInput, File.ReadLines(unsortedInput).OrderBy(s => s));
        }
    }
}
