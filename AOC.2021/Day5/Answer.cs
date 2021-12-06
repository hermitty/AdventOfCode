using AOC.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC._2021.Day5
{
    public class Answer : IAnswer
    {
        public object Task1()
        {
            var answer = 0;
            var input = File.ReadAllLines("Day5/input.txt").ToArray();
            var wires = TransformData(input);
            int[,] map = new int[1000, 1000];

            foreach (var wire in wires)
            {
                if (wire.IsVertical())
                    answer += AddVertical(map, wire);
                else if (wire.IsHorizontal())
                    answer += AddHorizontal(map, wire);
            }

            //Display(map);

            return answer;
        }

        public object Task2()
        {
            var answer = 0;
            var input = File.ReadAllLines("Day5/input.txt").ToArray();
            var wires = TransformData(input);
            int[,] map = new int[1000, 1000];

            foreach (var wire in wires)
            {
                if (wire.IsVertical())
                    answer += AddVertical(map, wire);
                else if (wire.IsHorizontal())
                    answer += AddHorizontal(map, wire);
                else
                    answer += AddDiagonal(map, wire);
            }

            //Display(map);

            return answer;
        }

        private int AddDiagonal(int[,] map, Vent wire)
        {
            var doubles = 0;
            var Xadd = wire.From.Item1 < wire.To.Item1 ? true : false;
            var Yadd = wire.From.Item2 < wire.To.Item2 ? true : false;

            for (int x = wire.From.Item1, y = wire.From.Item2; ;)
            {
                map[y, x]++;

                if (map[y, x] == 2) 
                    doubles++;

                if (x == wire.To.Item1 && y == wire.To.Item2)
                    break;
                
                if (Xadd) x++; else x--;
                if (Yadd) y++; else y--;
            }

            return doubles;
        }

        private int AddHorizontal(int[,] map, Vent wire)
        {
            var doubles = 0;
            var (from, to) = MinAndMax(wire.From.Item1, wire.To.Item1);
            for (int i = from; i < to + 1; i++)
            {
                map[wire.From.Item2, i]++;
                if (map[wire.From.Item2, i] == 2)
                    doubles++;
            }

            return doubles;
        }

        private int AddVertical(int[,] map, Vent wire)
        {
            var doubles = 0;
            var (from, to) = MinAndMax(wire.From.Item2, wire.To.Item2);
            for (int i = from; i < to + 1; i++)
            {
                map[i, wire.From.Item1]++;
                if (map[i, wire.From.Item1] == 2)
                    doubles++;
            }

            return doubles;
        }

        private List<Vent> TransformData(string[] input)
        {
            var data = new List<Vent>();
            foreach (var item in input)
            {
                var location = item.Split(" -> ");
                var newWire = new Vent()
                {
                    From = new Tuple<int, int>(int.Parse(location[0].Split(',')[0]), int.Parse(location[0].Split(',')[1])),
                    To = new Tuple<int, int>(int.Parse(location[1].Split(',')[0]), int.Parse(location[1].Split(',')[1]))
                };
                data.Add(newWire);
            }

            return data;
        }

        private (int, int) MinAndMax(int first, int sec) => first < sec ? (first, sec) : (sec, first);

        private void Display(int[,] map)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(map[i, j].ToString());
                }
                Console.WriteLine();
            }
        }
    }
}
