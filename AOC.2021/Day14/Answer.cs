using AOC.Helper;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC._2021.Day14
{
    public class Answer : IAnswer
    {
        public object Task1()
        {
            var input = File.ReadAllLines("Day14/input.txt").ToArray();
            var counter = CalculatePolymer(input, 10);
            var result = SubtractMaxAndMin(counter);

            return result;
        }

        public object Task2()
        {
            var input = File.ReadAllLines("Day14/input.txt").ToArray();
            var counter = CalculatePolymer(input, 40);
            var result = SubtractMaxAndMin(counter);

            return result;
        }

        private long SubtractMaxAndMin(Dictionary<char, long> counter) => counter.Values.Max() - counter.Values.Min();

        private Dictionary<char, long> CalculatePolymer(string[] input, int iterations)
        {
            var polymer = input[0];
            var rules = GetRules(input);
            var pairs = GetPairs(polymer);
            var counter = polymer.GroupBy(x => x).ToDictionary(x => x.Key, y => (long) y.Count());

            for (var i = 0; i < iterations; i++)
            {
                var newPairs = new Dictionary<string, long>();

                foreach (var pair in pairs)
                {
                    var middle = rules[pair.Key];
                    counter.IncreaseOrAdd(middle.First(), pair.Value);
                    newPairs.IncreaseOrAdd(pair.Key.First() + middle, pair.Value);
                    newPairs.IncreaseOrAdd(middle + pair.Key.Last(), pair.Value);
                }

                pairs = newPairs;
            }

            return counter;
        }

        private Dictionary<string, string> GetRules(string[] input)
        {
            var dict = new Dictionary<string, string>();
            for (var i = 2; i < input.Length; i++)
            {
                var values = input[i].Split(" -> ");
                dict.Add(values[0], values[1]);
            }

            return dict;
        }

        private Dictionary<string, long> GetPairs(string polymer)
        {
            var pairs = new Dictionary<string, long>();
            for (var i = 0; i < polymer.Length - 1; i++)
            {
                pairs.Add(polymer[i] + polymer[i + 1].ToString(), 1);
            }

            return pairs;
        }
    }
}



