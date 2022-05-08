using System;
using System.IO;

namespace ArrayLib
{
    public class GbDictionary
    {
        private int[,] arr;

        public GbDictionary(int[,] arr)
        {
            this.arr = arr;
        }

        public GbDictionary(int n, (int min, int max) range)
        {
            Random rnd = new Random();
            arr = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = rnd.Next(range.min, range.max);
                }
            }
        }

        public GbDictionary(int n, int l, (int min, int max) range)
        {
            Random rnd = new Random();
            arr = new int[n, l];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < l; j++)
                {
                    arr[i, j] = rnd.Next(range.min, range.max);
                }
            }
        }

        public int this[int i, int j]
        {
            get => arr[i, j];
            set
            {
                arr[i, j] = value;
            }
        }

        public int Min
        {
            get
            {
                int min = int.MaxValue;
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        if (arr[i, j] < min) min = arr[i, j];
                    }
                }
                return min;
            }
        }

        public int Max
        {
            get
            {
                int max = int.MinValue;
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        if (arr[i, j] > max) max = arr[i, j];
                    }
                }
                return max;
            }
        }

        public static GbDictionary Read(string fileName)
        {
            if (File.Exists(fileName))
            {

                string[] lines = File.ReadAllLines(fileName);
                int[,] arr = new int[lines.Length, lines.Length];
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] rows = lines[i].Split(' ');
                    for (int j = 0; j < lines.Length; j++)
                    {
                        arr[i, j] = int.Parse(rows[j]);
                    }
                }

                return new GbDictionary(arr);
            }
            else return null;
        }

        public bool Write(string fileName)
        {
            if (arr != null)
            {
                try
                {
                    if (!File.Exists(fileName))
                        File.Create(fileName);
                    string s = "";
                    for (int i = 0; i < arr.GetLength(0); i++)
                    {
                        for (int j = 0; j < arr.GetLength(1); j++)
                            s += $"{arr[i, j]} ";
                        s += "\n";
                    }
                    File.WriteAllText(fileName, s);
                }
                catch
                {
                    return false;
                }
            }
            else return false;

            return true;
        }

        public void MaxPosition(out int x, out int y)
        {
            x = 0; y = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] == Max)
                    {
                        x = i;
                        y = j;
                        return;
                    }
                }
            }

        }

        public int Sum()
        {
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    sum += arr[i, j];
                }
            }
            return sum;
        }

        public int Sum(int given)
        {
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] > given)
                        sum += arr[i, j];
                }
            }
            return sum;
        }

        public void Print()
        {
            string s = "";
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                    s += $"{arr[i, j]}\t";
                s += "\n";
            }
            Console.WriteLine(s);
        }
    }
}
