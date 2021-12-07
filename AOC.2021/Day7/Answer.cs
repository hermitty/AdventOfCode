using AOC.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC._2021.Day7
{
    public class Answer : IAnswer
    {
        public object Task1()
        {
            var input = File.ReadAllLines("Day7/input.txt").ToArray();
            var location = input[0].Split(',').Select(x=>int.Parse(x));
            var maxLocation = location.Max();
            var minFuel = int.MaxValue;
            for (int i = 0; i < maxLocation + 1; i++)
            {
                var fuel = 0;
                foreach (var loc in location)
                {
                    fuel += Math.Abs(loc - i);
                }

                if (fuel < minFuel)
                    minFuel = fuel;

            }
            return minFuel;
        }

        public object Task2()
        {
            var input = File.ReadAllLines("Day7/input.txt").ToArray();
            var location = input[0].Split(',').Select(x => int.Parse(x));
            var maxLocation = location.Max();
            long minFuel = long.MaxValue;
            for (int i = 0; i < maxLocation + 1; i++)
            {
                long fuel = 0;
                foreach (var loc in location)
                {
                    fuel += CalculateFuel(i, loc);
                }

                if (fuel < minFuel)
                    minFuel = fuel;

            }
            return minFuel;
        }

        private long CalculateFuel(int i, int loc)
        {
            var distance = Math.Abs(loc - i);
            long fuel = Factorial(distance);
            return fuel;
        }

        private long Factorial(long f)
        {
            if (f == 0)
                return 0;
            else
                return f + Factorial(f - 1);
        }
    }
}
