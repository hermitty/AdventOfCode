using AOC.Helper;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC._2021.Day12
{
    public class Answer : IAnswer
    {
        public object Task1()
        {
            var input = File.ReadAllLines("Day12/input.txt").ToArray();
            var connections = ExtractConnections(input);
            var paths = new List<List<string>>();

            CreateSinglePaths(paths, new List<string> { "start" }, connections);

            return paths.Count;
        }

        public object Task2()
        {
            var input = File.ReadAllLines("Day12/input.txt").ToArray();
            var connections = ExtractConnections(input);
            var paths = new List<List<string>>();

            CreateSinglePathsWithOneDouble(paths, new List<string>() { "start" }, connections);

            return paths.Count;
        }

        private void CreateSinglePaths(ICollection<List<string>> paths, List<string> singlePath, IReadOnlyDictionary<string, List<string>> connections)
        {
            if (singlePath.Last() == "end")
            {
                paths.Add(singlePath);
                return;
            }

            foreach (var nextValue in connections[singlePath.Last()]
                         .Where(value => IsBigCave(value) || IsNotVisitedBefore(singlePath, value)))
            {
                CreateSinglePaths(paths, new List<string>(singlePath) { nextValue }, connections);
            }
        }

        private void CreateSinglePathsWithOneDouble(List<List<string>> paths, List<string> singlePath, Dictionary<string, List<string>> connections)
        {
            if (singlePath.Last() == "end")
            {
                paths.Add(singlePath);
                return;
            }

            foreach (var nextValue in connections[singlePath.Last()]
                         .Where(value => value != "start"
                                         && (IsBigCave(value)
                                             || IsNotVisitedBefore(singlePath, value)
                                             || IsNoSmallCaveDouble(singlePath))))
            {
                CreateSinglePathsWithOneDouble(paths, new List<string>(singlePath) { nextValue }, connections);
            }
        }

        private bool IsNoSmallCaveDouble(List<string> singlePath)
        {
            return !singlePath
                .Where(x => x.Any(char.IsLower))
                .GroupBy(x => x)
                .Select(g => new { Value = g.Key, Count = g.Count() })
                .Any(x => x.Count > 1);
        }

        private bool IsBigCave(string value) => value.Any(char.IsUpper);

        private bool IsNotVisitedBefore(List<string> visitedCaves, string currentCave) =>
            visitedCaves.All(visited => visited != currentCave);

        private Dictionary<string, List<string>> ExtractConnections(string[] input)
        {
            var connections = new Dictionary<string, List<string>>();
            foreach (var connection in input)
            {
                var first = connection.Split('-')[0];
                var sec = connection.Split('-')[1];

                var firstValue = connections.GetValueOrDefault(first);
                if (firstValue == null)
                    connections.Add(first, new List<string>() { sec });
                else if (!firstValue.Contains(sec))
                    firstValue.Add(sec);

                var secValue = connections.GetValueOrDefault(sec);
                if (secValue == null)
                    connections.Add(sec, new List<string>() { first });
                else if (!secValue.Contains(first))
                    secValue.Add(first);
            }

            return connections;
        }
    }
}
