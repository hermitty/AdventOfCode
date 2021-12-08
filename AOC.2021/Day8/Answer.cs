using AOC.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC._2021.Day8
{
    public class Answer : IAnswer
    {
        public object Task1()
        {
            var input = File.ReadAllLines("Day8/input.txt").ToArray();
            var outputValues = input.Select(x => x.Split('|')[1]);
            var sum = 0;
            foreach (var output in outputValues)
            {
                var count = output.Split(' ').Where(x => x.Count() == 7 || x.Count() == 4 || x.Count() == 3 || x.Count() == 2).Count();
                sum += count;
            }
            return sum;
        }

        public object Task2()
        {
            var input = File.ReadAllLines("Day8/input.txt").ToArray();
            var values = new string[10];
            var sum = 0;
            values[8] = "abcdefg";

            foreach (var line in input)
            {
                var numbers = line.Split(' ').Select(x => x.Sort()).ToList();

                values[1] = numbers.Where(x => x.Has(2)).First();
                values[7] = numbers.Where(x => x.Has(3)).First();
                values[4] = numbers.Where(x => x.Has(4)).First();
                values[6] = numbers.Where(x => x.Has(6) && !x.ContainsAll(values[7])).First();
                values[3] = numbers.Where(x => x.Has(5) && x.ContainsAll(values[7])).First();
                var c = values[8].Minus(values[6]);
                var a = values[7].Minus(values[1]);
                var e = values[8].Minus(values[3]).Minus(values[4]);
                values[5] = numbers.Where(x => x.Has(5) && !x.Contains(c) && !x.Contains(e)).First();
                values[2] = numbers.Where(x => x.Has(5)).Select(x => x).Where(x => x != values[5] && x != values[3]).First();
                values[9] = numbers.Where(x => x.Has(6)).Select(x => x).Where(x => x != values[6] && !x.Contains(e)).First();
                values[0] = numbers.Where(x => x.Has(6)).Select(x => x).Where(x => x != values[6] && x != values[9]).First();

                var outputValues = line.Split('|')[1].Split(' ').Where(x => x != "").Select(x => x.Sort()).ToList();
                var number1000 = Array.IndexOf(values, values.Where(x => x == outputValues[0]).First());
                var number0100 = Array.IndexOf(values, values.Where(x => x == outputValues[1]).First());
                var number0010 = Array.IndexOf(values, values.Where(x => x == outputValues[2]).First());
                var number0001 = Array.IndexOf(values, values.Where(x => x == outputValues[3]).First());

                var number = 1000 * number1000 + 100 * number0100 + 10 * number0010 + number0001;
                sum += number;
            }

            return sum;
        }
    }
}
