using AOC.Helper;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC._2021.Day4
{

    public class Answer : IAnswer
    {
        public object Task1()
        {
            var input = File.ReadAllLines("Day4/input.txt").ToArray();
            var (cards, numbers) = ReadData(input);
            var answer = 0;

            foreach (var number in numbers)
                foreach (var singleCard in cards)
                {
                    singleCard.FindValue(number);
                    if (singleCard.IsBingo())
                    {
                        answer = singleCard.Sum() * number;
                        return answer;
                    }
                }

            return answer ;
        }

        public object Task2()
        {
            var input = File.ReadAllLines("Day4/input.txt").ToArray();
            var (cards, numbers) = ReadData(input);
            var lastNumber = 0;

            Card last = null;
            List<Card> lastCards = null;
            foreach (var number in numbers)
            {
                lastCards = new List<Card>();
                foreach (var singleCard in cards)
                {
                    singleCard.FindValue(number);
                    if (singleCard.IsBingo())
                        lastCards.Add(singleCard);
                }

                if (lastCards.Any())
                {
                    lastCards.ForEach(x => cards.Remove(x));
                    last = lastCards.Last();
                    lastCards = new List<Card>();
                    lastNumber = number;
                }
            }
            var answer = last.Sum() * lastNumber;

            return answer;
        }

        private (List<Card>, IEnumerable<int>) ReadData(string[] input)
        {
            var cards = new List<Card>();
            var numbers = input[0].Split(',').Select(x => int.Parse(x));
            var card = new Card();
            var lineNumber = 0;

            for (int i = 2; i < input.Length; i++)
            {
                if (input[i] == "")
                {
                    lineNumber = 0;
                    cards.Add(card);
                    card = new Card();
                    continue;
                }
                var a = input[i].Split(' ').Where(x => x != "").ToList();

                var line = a.Select(x => int.Parse(x)).ToArray();
                card.AddLine(line, lineNumber);

                lineNumber++;

            }
            cards.Add(card);
            return (cards, numbers);
        }
    }
}
