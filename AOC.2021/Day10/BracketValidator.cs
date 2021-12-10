using System.Collections.Generic;
using System.Linq;

namespace AOC._2021.Day10
{
    public class BracketValidator
    {
        private readonly Dictionary<char, char> bracketsDic = new Dictionary<char, char>
            {
                { '<', '>' },
                { '[', ']' },
                { '{', '}' },
                { '(', ')' }
            };

        public char? GetCorruptedBracket(string line)
        {
            var stack = new Stack<char>();
            foreach (var sign in line)
            {
                switch (sign)
                {
                    case '<':
                        stack.Push(sign);
                        continue;
                    case '(':
                        stack.Push(sign);
                        continue;
                    case '[':
                        stack.Push(sign);
                        continue;
                    case '{':
                        stack.Push(sign);
                        continue;
                    default:
                        break;
                }
                if (sign == bracketsDic[stack.Peek()])
                    stack.Pop();
                else
                {
                    return sign;
                }
            }
            return null;
        }

        public List<char> GetIncompleteBrackets(string line)
        {
            var stack = new Stack<char>();
            foreach (var sign in line)
            {
                switch (sign)
                {
                    case '<':
                        stack.Push(sign);
                        break;
                    case '(':
                        stack.Push(sign);
                        break;
                    case '[':
                        stack.Push(sign);
                        break;
                    case '{':
                        stack.Push(sign);
                        break;
                    default:
                        stack.Pop();
                        break;
                }
            }

            return stack.Select(x => bracketsDic[x]).ToList();
        }
    }
}
