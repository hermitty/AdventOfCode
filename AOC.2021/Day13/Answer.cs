using AOC.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC._2021.Day13
{
    public class Answer : IAnswer
    {
        public object Task1()
        {
            var input = File.ReadAllLines("Day13/input.txt").ToArray();
            var locations = ReadLocations(input);
            var instructions = ReadInstructions(input);
            var paper = new Paper(locations, new List<(char, int)> { instructions.First() });

            var result = paper.Count();
            return result;
        }

        public object Task2()
        {
            var input = File.ReadAllLines("Day13/input.txt").ToArray();
            var locations = ReadLocations(input);
            var instructions = ReadInstructions(input);
            var paper = new Paper(locations, instructions);

            paper.Display();
            return paper;
        }

        private static string[] ReadLocations(string[] input)
            => input.Where(x => x.Any() && !x.Contains("fold")).ToArray();

        private static IEnumerable<(char, int)> ReadInstructions(string[] input)
            => input.Where(x => x.Contains("fold")).Select(x => (x[11], int.Parse(x.Split('=')[1])));
    }
}
