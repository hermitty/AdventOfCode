using System;

namespace AOC._2021.Day5
{
    public class Vent
    {
        public Tuple<int, int> From { get; set; }
        public Tuple<int, int> To { get; set; }

        public bool IsHorizontal() => From.Item2 == To.Item2;
        public bool IsVertical() => From.Item1 == To.Item1;
    }
}
