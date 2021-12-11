using AOC.Helper;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC._2021.Day10
{
    public class Answer : IAnswer
    {
        private readonly BracketValidator bracketValidator = new BracketValidator();
        public object Task1()
        {
            var result = File.ReadAllLines("Day10/input.txt").ToArray()
                .Select(line => bracketValidator.GetCorruptedBracket(line))
                .Where(coruptedBracket => coruptedBracket != null)
                .Sum(coruptedBracket => coruptedBracket switch
                {
                    '>' => 25137,
                    ']' => 57,
                    '}' => 1197,
                    ')' => 3
                });

            return result;
        }

        public object Task2()
        {
            var input = File.ReadAllLines("Day10/input.txt").ToArray();
            var score = input
                .Where(line => bracketValidator.GetCorruptedBracket(line) == null)
                .Select(line => bracketValidator.GetIncompleteBrackets(line))
                .Select(incompleteBracket => incompleteBracket
                .Aggregate(0L, (sum, ch) => sum * 5 + ch switch
                {
                    '>' => 4,
                    ']' => 2,
                    '}' => 3,
                    ')' => 1,
                }))
                .ToList();

            score.Sort();
            var result = score[score.Count / 2];
            return result;
        }
    }
}
