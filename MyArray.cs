using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4
{
    /// <summary>
    /// Класс одномерного массива
    /// </summary>
    public class MyArray
    {
        private int[] _arr;

        public int this[int ndx]
        {
            get => _arr[ndx];
            set
            {
                _arr[ndx] = value;
            }
        }

        public MyArray(int n) => _arr = new int[n];

        public MyArray(int n, int start, int offset)
        {
            _arr = new int[n];
            for (int i = 0; i < _arr.Length; i++)
            {
                _arr[i] = start + offset * i;
            }
        }

        public MyArray(int n, (int min, int max) range)
        {
            _arr = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < _arr.Length; i++)
            {
                _arr[i] = rnd.Next(range.min, range.max);
            }
        }

        public int Count
        {
            get => _arr.Length;
        }

        public int Sum
        {
            get
            {
                int sum = 0;
                for (int i = 0; i < _arr.Length; i++)
                {
                    sum += _arr[i];
                }
                return sum;
            }
        }


        public int[] Inverse
        {
            get
            {
                int[] result = new int[_arr.Length];
                for (int i = 0; i < _arr.Length; i++)
                {
                    result[i] = -_arr[i];
                }
                return result;
            }
        }

        public int Max
        {
            get
            {
                int max = int.MinValue;
                for (int i = 0; i < _arr.Length; i++)
                {
                    if (_arr[i] > max) max = _arr[i];
                }
                return max;
            }
        }

        public int MaxCount
        {
            get
            {
                int maxCount = 0;
                for (int i = 0; i < _arr.Length; i++)
                {
                    if (_arr[i] == Max) maxCount++;
                }
                return maxCount;
            }
        }

        public void Multi(int x)
        {
            for (int i = 0; i < _arr.Length; i++)
            {
                _arr[i] *= x;
            }
        }

        public void Multi(double x)
        {
            for (int i = 0; i < _arr.Length; i++)
            {
                _arr[i] = (int)(_arr[i] * x);
            }
        }

        public void Print()
        {
            foreach (int a in _arr) Console.Write($"{a}\t");
            Console.WriteLine();
        }
    }
}
