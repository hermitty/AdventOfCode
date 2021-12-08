using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2021.Day8
{
    public static class Extensions
    {
        public static string Sort(this string input)
        {
            char[] characters = input.ToArray();
            Array.Sort(characters);
            return new string(characters);
        }

        public static bool ContainsAll(this string input, string value)
        {
            foreach (var letter in value)
            {
                if (!input.Contains(letter))
                    return false;
            }
            return true;
        }

        public static string Minus(this string input, string value)
        { 
            foreach (var letter in value)
            {
                if (input.Contains(letter))
                    input = input.Replace(letter.ToString(), "");
            }
            return input;
        }

        public static bool Has(this string input, int value) => input.Count() == value;
    }
}
