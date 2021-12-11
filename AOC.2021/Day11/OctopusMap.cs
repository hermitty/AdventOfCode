using System.Linq;

namespace AOC._2021.Day11
{
    public class OctopusMap
    {
        private int[,] octopusMap;
        private readonly int xSize;
        private readonly int ySize;

        public OctopusMap(string[] map)
        {
            xSize = map.Length;
            ySize = map.First().Length;
            octopusMap = CreateMap(map);
        }
        public void NextStep()
        {
            IncreaseEnergyLevel();

            if (!LightersExist())
                return;

            var checkedLighters = new bool[xSize, ySize];

            for (var x = 0; x < xSize; x++)
            {
                for (var y = 0; y < ySize; y++)
                {
                    if (octopusMap[x, y] != 0 || checkedLighters[x, y])
                        continue;

                    checkedLighters[x, y] = true;
                    IncreaseNeighborsLight(x, y, checkedLighters);
                }
            }

        }

        public int CountFlashers()
        {
            var counter = 0;
            for (var x = 0; x < xSize; x++)
            {
                for (var y = 0; y < ySize; y++)
                {
                    if (octopusMap[x, y] == 0)
                        counter++;
                }
            }

            return counter;
        }

        private int[,] CreateMap(string[] input)
        {
            var map = new int[xSize, ySize];
            for (var x = 0; x < ySize; x++)
            {
                for (var y = 0; y < ySize; y++)
                {
                    map[x, y] = int.Parse(input[x].Substring(y, 1));
                }
            }

            return map;
        }

        private void IncreaseEnergyLevel()
        {
            for (var x = 0; x < xSize; x++)
            {
                for (var y = 0; y < ySize; y++)
                {
                    IncreaseValue(x, y);
                }
            }
        }

        private void IncreaseValue(int x, int y)
        {
            if (octopusMap[x, y] == 9)
                octopusMap[x, y] = 0;
            else
                octopusMap[x, y]++;
        }

        private void IncreaseNeighborsLight(int x, int y, bool[,] checkedLighters)
        {
            GiveEnergyToNeighbor(x, y - 1, checkedLighters);
            GiveEnergyToNeighbor(x, y + 1, checkedLighters);
            GiveEnergyToNeighbor(x + 1, y, checkedLighters);
            GiveEnergyToNeighbor(x + 1, y - 1, checkedLighters);
            GiveEnergyToNeighbor(x + 1, y + 1, checkedLighters);
            GiveEnergyToNeighbor(x - 1, y, checkedLighters);
            GiveEnergyToNeighbor(x - 1, y - 1, checkedLighters);
            GiveEnergyToNeighbor(x - 1, y + 1, checkedLighters);
        }

        private void GiveEnergyToNeighbor(int x, int y, bool[,] checkedLighters)
        {
            if (!IndexExists(x, y) || octopusMap[x, y] == 0)
                return;

            IncreaseValue(x, y);

            if (octopusMap[x, y] != 0)
                return;

            checkedLighters[x, y] = true;
            IncreaseNeighborsLight(x, y, checkedLighters);
        }

        private bool IndexExists(int x, int y)
            => x >= 0 && x < xSize && y >= 0 && y < ySize;

        private bool LightersExist()
        {
            for (var x = 0; x < xSize; x++)
            {
                for (var y = 0; y < ySize; y++)
                {
                    if (octopusMap[x, y] == 0)
                        return true;
                }
            }

            return false;
        }
    }
}
