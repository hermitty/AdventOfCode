using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2021.Day13
{
    public class Paper
    {
        private int xSize;
        private int ySize;
        private string[,] map;
        public Paper(string[] locations, IEnumerable<(char, int)> instructions)
        {
            xSize = locations.Select(x => int.Parse(x.Split(',')[0])).Max() + 1;
            ySize = locations.Select(x => int.Parse(x.Split(',')[1])).Max() + 1;
            map = new string[xSize, ySize];

            FillMap(locations);
            FoldPaper(instructions);
        }

        public void Display()
        {
            for (int i = 0; i < ySize; i++)
            {
                for (int j = 0; j < xSize; j++)
                {
                    var value = map[j, i] == "#" ? map[j, i] : ".";
                    Console.Write(value);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public int Count()
        {
            var count = 0;
            for (var x = 0; x < xSize; x++)
            {
                for (var y = 0; y < ySize; y++)
                {
                    if (map[x, y] == "#")
                        count++;
                }
            }

            return count;
        }

        private void FillMap(string[] locations)
        {
            foreach (var item in locations)
            {
                var value = item.Split(',');
                var x = int.Parse(value[0]);
                var y = int.Parse(value[1]);
                map[x, y] = "#";
            }
        }

        private void FoldPaper(IEnumerable<(char, int)> instructions)
        {
            foreach (var command in instructions)
            {
                if (command.Item1 == 'x')
                {
                    for (var x = command.Item2; x < xSize; x++)
                    {
                        for (var y = 0; y < ySize; y++)
                        {
                            if (map[x, y] == "#")
                                map[command.Item2 - (x - command.Item2), y] = "#";
                        }
                    }
                    xSize = command.Item2;
                }
                else
                {
                    for (var x = 0; x < xSize; x++)
                    {
                        for (var y = command.Item2; y < ySize; y++)
                        {
                            if (map[x, y] == "#")
                                map[x, command.Item2 - (y - command.Item2)] = "#";
                        }
                    }
                    ySize = command.Item2;
                }

            }
        }
    }
}
