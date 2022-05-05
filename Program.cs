using System;
using System.Collections.Generic;
using System.IO;
using GeekBrainsLib;

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
                StreamReader fs = new StreamReader(filename);
                List<int> result = new List<int>();
                while (!fs.EndOfStream)
                {
                    result.Add(int.Parse(fs.ReadLine()));
                }
                fs.Close();
                return result.ToArray();
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }

    class MyCoolArray
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


        public MyCoolArray(int n) => _arr = new int[n];

        public MyCoolArray(int n, int start, int offset)
        {
            _arr = new int[n];
            for (int i = 0; i < _arr.Length; i++)
            {
                _arr[i] = start + offset * (i + 1);
            }
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

        public int[] MaxCount
        {
            get
            {
                int[] resultCount = new int[_arr.Length];
                int[] mass = new int[Max + 1];
                foreach (var a in _arr) mass[a]++;
                int ndx = 0;
                for(int i=0; i < mass.Length; i++)
                {
                    if (i == _arr[ndx])
                    {
                        resultCount[ndx] = mass[i];
                        ndx++;
                    }
                }
                return resultCount;
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
            for (int i = 0; i < _arr.Length; i++)
            {
                if (i == _arr.Length / 2)
                    Console.WriteLine();
                Console.Write($"{_arr[i]}\t");
            }
            Console.WriteLine();
        }

    }

    struct Account
    {
        public string login;
        public string password;
    }

    class Program
    {
        static void Main(string[] args)
        {

            Exercise1();
            Console.SetCursorPosition(0, 5);
            Exercise2();
            Exercise3();
            Exercise4();

            Console.ReadKey();
        }


        static void Exercise1()
        {
            Console.WriteLine("Работа метода");
            SetArray();
        }
        static void Exercise2()
        {
            Console.WriteLine("Работа класса");
            Console.WriteLine($"Найденое число пар элементов массива: {MyStaticArray.GetPairCount(20, 3)}");
            MyStaticArray.ReadArrayFromFile(@"C:\Users\Alexander\Desktop\array.txt");
        }

        static void Exercise3()
        {
            Console.Clear();
            Console.WriteLine("========================");
            Console.WriteLine("Класс работы с массивом");
            Console.WriteLine("========================");
            Console.WriteLine("Задание параметров массива:");
            Console.Write("Размерность массива: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Начальное значение: ");
            int strt = int.Parse(Console.ReadLine());
            Console.Write("Шаг: ");
            int offset = int.Parse(Console.ReadLine());
            MyCoolArray coolArray = new MyCoolArray(n, strt, offset);
            bool isWork = true;
            while (isWork)
            {
                Console.Clear();
                coolArray.Print();
                Console.WriteLine("1) Вывести сумму элементов");
                Console.WriteLine("2) Выполнить инверсию");
                Console.WriteLine("3) Умножить массив на число");
                Console.WriteLine("4) Вывести количество максимальных элементов");
                Console.WriteLine("0) Назад");
                Console.Write("Введите номер меню: ");
                if (int.TryParse(Console.ReadLine(), out int ndx))
                {
                    Console.Clear();
                    switch (ndx)
                    {
                        default:
                            break;
                        case 1:
                            {
                                coolArray.Print();
                                Console.WriteLine($"Сумма элементов массива = {coolArray.Sum}");
                                Console.ReadKey();
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("Обратный массив");
                                int[] inversArr = coolArray.Inverse;
                                for (int i = 0; i < inversArr.Length; i++)
                                {
                                    if (i == inversArr.Length / 2)
                                        Console.WriteLine();
                                    Console.Write($"{inversArr[i]}\t");
                                }
                                Console.ReadKey();
                                break;
                            }
                        case 3:
                            {
                                Console.Write("Введите множитель: ");
                                if (int.TryParse(Console.ReadLine(), out int x))
                                {
                                    coolArray.Multi(x);
                                    Console.Clear();
                                    Console.WriteLine($"Результат умножения элементов массива на {x}");
                                    coolArray.Print();
                                    Console.Write($"Сохранить результат?(y/n): ");
                                    if (Console.ReadLine() == "n") coolArray.Multi((double)1 / x);
                                }
                                break;
                            }
                        case 4:
                            {
                                var m = coolArray.MaxCount;
                                break;
                            }
                    }
                }

            }
        }

        static void Exercise4()
        {
            Account origin = new Account { login = "root", password = "GeekBrains" };
            Account[] users = ReadUsersData(@"C:\Users\melnikova.SNIA\Desktop\users.txt");
            foreach (var user in users)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{user.login} -> ");
                if (!user.Equals(origin))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("доступ запрещен!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("доступ разрешен!");
                }
            }
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

        static Account[] ReadUsersData(string filename)
        {
            if (!File.Exists(filename))
                throw new ArgumentException();

            List<Account> result = new List<Account>();
            StreamReader fs = new StreamReader(filename);
            while (!fs.EndOfStream)
            {
                string login = fs.ReadLine();
                string password = fs.ReadLine();
                result.Add(new Account
                {
                    login = login,
                    password = password
                });
            }

            return result.ToArray();
        }
    }
}
