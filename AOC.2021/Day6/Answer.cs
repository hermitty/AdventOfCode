using AOC.Helper;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC._2021.Day6
{
    public class Answer : IAnswer
    {
        
        public object Task1()
        {
            var input = File.ReadAllLines("Day6/input.txt").ToArray();

            var fishes = new List<LaternFish>();
            var leftDaysToBirth = input[0].Split(',').Select(x => int.Parse(x));

            foreach (var days in leftDaysToBirth)
            {
                fishes.Add(new LaternFish(days));
            }

            for (int i = 0; i < 80; i++)
            {
                var newFishes = new List<LaternFish>();
                foreach (var fish in fishes)
                {
                    if (fish.ShouldGiveBirth())
                        newFishes.Add(new LaternFish());
                    fish.GetOlder();
                }
                fishes.AddRange(newFishes);
            }

            return fishes.Count;
        }

        public object Task2()
        {
            var input = File.ReadAllLines("Day6/input.txt").ToArray();
            var leftDaysToBirth = input[0].Split(',').Select(x => int.Parse(x));
            var numberOfFishes = new long[9];

            foreach (var left in leftDaysToBirth)
            {
                numberOfFishes[left]++;
            }

            for (int i = 0; i < 256; i++)
            {
                var howManyShouldBeBorn = numberOfFishes[0];
                numberOfFishes = SwitchFishADays(numberOfFishes);
                numberOfFishes[8] = howManyShouldBeBorn;
                numberOfFishes[6] += howManyShouldBeBorn;
            }

            long sum = 0;
            foreach (var item in numberOfFishes)
            {
                sum += item;
            }

            return sum;
        }

        private long[] SwitchFishADays(long[] fishes)
        {
            for (int i = 0; i < fishes.Length - 1; i++)
            {
                fishes[i] = fishes[i + 1];
            }
            return fishes;
        }
    }
}
