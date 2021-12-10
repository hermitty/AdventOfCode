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
            var input = File.ReadAllLines("Day10/input.txt").ToArray();
            var mistakes = 0;
            var pointsDic = new Dictionary<char, int>
            {
                { '>', 25137 },
                { ']', 57 },
                { '}', 1197 },
                { ')', 3 }
            };

            foreach (var line in input)
            {
                var coruptedBracket = bracketValidator.GetCorruptedBracket(line);
                if (coruptedBracket != null)
                    mistakes += pointsDic[(char)coruptedBracket]; ;
            }

            return mistakes; 
        }

        public object Task2()
        {
            var input = File.ReadAllLines("Day10/input.txt").ToArray();
            var score = new List<long>();
            var pointsDic = new Dictionary<char, int>
            {
                { '>', 4 },
                { ']', 2 },
                { '}', 3 },
                { ')', 1 }
            };
          
            foreach (var line in input)
            {
                if (bracketValidator.GetCorruptedBracket(line) != null)
                    continue;

                var incompleteBrackets = bracketValidator.GetIncompleteBrackets(line);
                var point = 0L;

                foreach (var bracket in incompleteBrackets)
                {
                    point *= 5;
                    point += pointsDic[bracket];
                }
                score.Add(point);
            }

            score.Sort();
            var result = score[score.Count / 2];  
            return result;
        }
    }
}
