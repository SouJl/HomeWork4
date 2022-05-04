using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4
{
    class MyStaticArray
    {
        public static int GetPairCount(int length, int pairValue) 
        {
            Random rnd = new Random();
            int[] arr = new int[length];
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(-10000, 10000);
                
                if (i == arr.Length / 2)
                    Console.WriteLine();
                Console.Write($"{arr[i]}\t");
                
                if (i > 0 && i < arr.Length - 1)
                {
                    if (arr[i - 1] % pairValue == 0 && arr[i] % pairValue == 0)
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine();
            return count;
        }

        public static int[] ReadArrayFromFile(string filename)
        {
            try
            {
                List<int> result = new List<int>();
                StreamReader fs = new StreamReader(filename);
                while (!fs.EndOfStream)
                {
                    result.Add(int.Parse(fs.ReadLine()));
                }
                fs.Close();
                return result.ToArray();
            }
            catch(IOException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Работа метода");
            SetArray();
            
            Console.SetCursorPosition(0, 5);
            
            Console.WriteLine("Работа класса");
            Console.WriteLine($"Найденое число пар элементов массива: {MyStaticArray.GetPairCount(20, 3)}");
            MyStaticArray.ReadArrayFromFile(@"C:\Users\Alexander\Desktop\array.txt");
            Console.ReadKey();
        }


        static void SetArray()
        {
            int[] mass = new int[20];
            Random rnd = new Random();
            int count = 0;
            for (int i = 0; i < mass.Length; i++)
            {
                mass[i] = rnd.Next(-10000, 10000);
                
                if (i == mass.Length / 2)
                    Console.WriteLine();

                Console.Write($"{mass[i]}\t");
                if (i > 0 && i < mass.Length - 1)
                {
                    if (mass[i - 1] % 3 == 0 && mass[i] % 3 == 0)
                    {
                        count++;
                    }

                }
            }
            Console.WriteLine();
            Console.WriteLine($"Найденое число пар элементов массива: {count}");
        }


    }
}
