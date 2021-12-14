using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2021.Day14
{
    public static class Extensions
    {
        public static void IncreaseOrAdd<T>(this Dictionary<T, long> dict, T key, long value)
        {
            if (dict.ContainsKey(key))
                dict[key] += value;
            else
                dict.Add(key, value);
        }
    }
}
