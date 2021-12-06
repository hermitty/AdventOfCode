using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2021.Day4
{
    public class Card
    {
        public int[,] Value { get; set; } = new int[5, 5];

        public void AddLine(int[] values, int lineNumber)
        {
            for (int col = 0; col < 5; col++)
            {
                Value[lineNumber, col] = values[col];
            }
        }

        public int Sum()
        {
            var sum = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (Value[i, j] > 0)
                        sum += Value[i, j];
                }
            }
            return sum;
        }

        public void FindValue(int number)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (Value[i, j] == number)
                        Value[i, j] = -50;
                }
            }
        }

        public bool IsBingo()
        {
            for (int i = 0; i < 5; i++)
            {
                if (CheckColumn(i) || CheckRow(i))
                    return true;
            }
            return false;
        }

        private bool CheckColumn(int number)
        {
            var sum = 0;
            for (int i = 0; i < 5; i++)
            {
                sum += Value[number, i];
            }
            if (sum == -250)
                return true;
            return false;
        }

        private bool CheckRow(int number)
        {
            var sum = 0;
            for (int i = 0; i < 5; i++)
            {
                sum += Value[i, number];
            }
            if (sum == -250)
                return true;
            return false;
        }
    }
}
