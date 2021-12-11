using AOC.Helper;
using System.IO;
using System.Linq;

namespace AOC._2021.Day11
{
    public class Answer : IAnswer
    {
        public object Task1()
        {
            var input = File.ReadAllLines("Day11/input.txt").ToArray();
            var octopusMap = new OctopusMap(input);
            var flashCount = 0;
            for (var i = 0; i < 100; i++)
            {
                octopusMap.NextStep();
                flashCount+=octopusMap.CountFlashers();
            }
    
            return flashCount;
        }

        public object Task2()
        {
            var input = File.ReadAllLines("Day11/input.txt").ToArray();
            var octopusMap = new OctopusMap(input);
            var i = 0;
            for (; octopusMap.CountFlashers() != 100; i++) 
                octopusMap.NextStep();

            return i;
        }
    }
}
