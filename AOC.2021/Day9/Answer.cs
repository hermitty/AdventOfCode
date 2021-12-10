using AOC.Helper;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC._2021.Day9
{
    public class Answer : IAnswer
    {
        public object Task1()
        {
            var input = File.ReadAllLines("Day9/input.txt").ToArray();
            var smokeMap = new SmokeMap(input);
            var sum = 0;

            for (int x = 0; x < smokeMap.XSize; x++)
                for (int y = 0; y < smokeMap.YSize; y++)
                    if (smokeMap.AreNeighboursHigher(x, y))
                        sum += smokeMap.Value(x, y) + 1;

            return sum;
        }

        public object Task2()
        {
            var input = File.ReadAllLines("Day9/input.txt").ToArray();
            var smokeMap = new SmokeMap(input);
            var sumList = new List<int>();

            for (int x = 0; x < smokeMap.XSize; x++)
            {
                for (int y = 0; y < smokeMap.YSize; y++)
                {
                    if (smokeMap.AreNeighboursHigher(x, y))
                    {
                        var pool = smokeMap.GetLowestPool(x, y);
                        sumList.Add(pool.Cast<int>().Sum());
                    }
                }
            }

            var result = GetThreeMaxValues(sumList).Aggregate((a, x) => a * x);

            return result;
        }

        private List<int> GetThreeMaxValues(List<int> list)
        {
            var result = new List<int>();
            for (int i = 0; i < 3; i++)
            {
                result.Add(list.Max());
                list.Remove(list.Max());
            }

            return result;
        }
    }
}
