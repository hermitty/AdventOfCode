using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2021.Day9
{
    public class SmokeMap
    {
        private readonly int[,] smokeMap;
        private readonly int xSize;
        private readonly int ySize;

        public SmokeMap(string[] input)
        {
            xSize = input.Length;
            ySize = input.First().Length;
            smokeMap = CreateMap(input);
        }

        public int XSize => xSize;
        public int YSize => ySize;

        public int Value(int x, int y) => smokeMap[x, y];

        public bool AreNeighboursHigher(int x, int y)
        {
            return IsNeighbourHigher(x - 1, y, smokeMap[x, y])
                && IsNeighbourHigher(x, y - 1, smokeMap[x, y])
                && IsNeighbourHigher(x + 1, y, smokeMap[x, y])
                && IsNeighbourHigher(x, y + 1, smokeMap[x, y]);
        }

        public int[,] GetLowestPool(int x, int y)
        {
            var poolMap = new int[xSize, ySize];
            SearchPool(x, y, poolMap);
            return poolMap;
        }

        private void SearchPool(int x, int y, int[,] poolMap)
        {
            if (!IndexExists(x, y) || smokeMap[x, y] == 9 || poolMap[x, y] == 1)
                return;

            poolMap[x, y] = 1;

            SearchPool(x + 1, y, poolMap);
            SearchPool(x, y + 1, poolMap);
            SearchPool(x, y - 1, poolMap);
            SearchPool(x - 1, y, poolMap);
        }

        private bool IsNeighbourHigher(int x, int y, int value)
        {
            if (!IndexExists(x, y) || value < smokeMap[x, y])
                return true;
            return false;
        }

        private bool IndexExists(int x, int y)
        {
            if (x < 0 || x >= xSize || y < 0 || y >= ySize)
                return false;
            return true;
        }

        private int[,] CreateMap(string[] input)
        {
            var map = new int[XSize, ySize];
            for (int x = 0; x < XSize; x++)
            {
                for (int y = 0; y < ySize; y++)
                {
                    map[x, y] = int.Parse(input[x].Substring(y, 1));
                }
            }

            return map;
        }
    }
}
