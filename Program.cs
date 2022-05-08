using System;
using System.Collections.Generic;
using System.IO;
using GeekBrainsLib;
using ArrayLib;

namespace HomeWork4
{
    /// <summary>
    /// Статический класс взаимодействия с одномерным массивом
    /// </summary>
    class MyStaticArray
    {
        /// <summary>
        /// Нахождение количества пар элементов
        /// </summary>
        /// <param name="arr">массив</param>
        /// <param name="pairValue">поисковое значение</param>
        /// <returns></returns>
        public static int GetPairCount(int[] arr, int pairValue)
        {
            int count = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] % pairValue == 0 ^ arr[i + 1] % pairValue == 0)
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Чтение массива из файла
        /// </summary>
        /// <param name="filePath">путь до файла</param>
        /// <returns></returns>
        public static int[] ReadArrayFromFile(string filePath)
        {
            try
            {
                StreamReader fs = new StreamReader(filePath);
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

    /// <summary>
    /// Струкура данных пользователя
    /// </summary>
    struct Account
    {
        public string login;
        public string password;
    }

    class Program
    {
        static void Main(string[] args)
        {
            ConsoleUI consoleUI = new ConsoleUI("Мельников Александр", "Практическое задание 4", 5);
            Console.ForegroundColor = ConsoleColor.White;
            bool isWork = true;
            while (isWork)
            {
                Console.Clear();
                consoleUI.PrintUserInfo();
                consoleUI.PrintMenu();
                if (int.TryParse(Console.ReadLine(), out int ndx))
                {
                    Console.Clear();
                    switch (ndx)
                    {
                        default:
                            break;
                        case 1:
                            {
                                Exercise1();
                                break;
                            }
                        case 2:
                            {
                                Exercise2();
                                break;
                            }
                        case 3:
                            {
                                Exercise3();
                                break;
                            }
                        case 4:
                            {
                                Exercise4();
                                break;
                            }
                        case 5:
                            {
                                Exercise5();
                                break;
                            }
                        case 0:
                            {
                                isWork = false;
                                break;
                            }
                    }
                }
                else
                {
                    Console.Clear();
                    ModifiedConsole.Print("Формат ввода неверен!");
                    ModifiedConsole.Pause();
                }
            }
        }

        /// <summary>
        /// Заполнение массива случайными числами используя метод SetArray()
        /// </summary>
        static void Exercise1()
        {
            Console.WriteLine("Нахождение пар элементов массива с использованием метода");
            SetArray();
            Console.WriteLine("Для продолжения нажмите любую клавишу...");
            ModifiedConsole.Pause();
        }

        /// <summary>
        ///  Реализация Exercise1 с ипользованием статического класса
        /// </summary>
        static void Exercise2()
        {
            bool isWork = true;
            while (isWork)
            {
                Console.Clear();
                Console.WriteLine("Пример работы с массивом через статический класс");
                Console.WriteLine("1) -> Нахождение пар элементов");
                Console.WriteLine("2) -> Чтение массива из файла");
                Console.WriteLine("0) -> Назад");
                Console.Write("Введите номер пункта: ");
                if (int.TryParse(Console.ReadLine(), out int ndx))
                {
                    Console.Clear();
                    switch (ndx)
                    {
                        default:
                            break;
                        case 1:
                            {
                                Console.Write("Введите количество эдементво массива: ");
                                int n = int.Parse(Console.ReadLine());
                                int[] array = new int[n];
                                Random rnd = new Random();
                                for (int i = 0; i < array.Length; i++)
                                {
                                    array[i] = rnd.Next(-10000, 10000);
                                }
                                PrintArray(array);
                                Console.WriteLine($"Найденое число пар элементов массива, деленных на 3: {MyStaticArray.GetPairCount(array, 3)}");
                                break;
                            }
                        case 2:
                            {
                                string filePath = Environment.CurrentDirectory + @"\Files\Array.txt";
                                Console.WriteLine($"Чтение массива из {filePath}");
                                Console.WriteLine("Нажмите любую клавишу чтобы прочитать массив");
                                Console.ReadKey();
                                Console.Clear();
                                int[] array = MyStaticArray.ReadArrayFromFile(filePath);
                                if (array != null)
                                    PrintArray(array);
                                break;
                            }
                        case 0:
                            {
                                isWork = false;
                                break;
                            }
                    }
                }
                else
                {
                    Console.Clear();
                    ModifiedConsole.Print("Формат ввода неверен!");
                }
                Console.WriteLine("Для продолжения нажмите любую клавишу...");
                ModifiedConsole.Pause();
            }
        
        }

        /// <summary>
        /// Реализация взаимодействия с написанным классом массива
        /// </summary>
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
            GbArray coolArray = new GbArray(n, strt, offset);
            bool isWork = true;
            while (isWork)
            {
                Console.Clear();
                coolArray.Print();
                Console.WriteLine("1) Вывести сумму элементов");
                Console.WriteLine("2) Выполнить инверсию");
                Console.WriteLine("3) Умножить массив на число");
                Console.WriteLine("4) Вывести количество максимальных элементов");
                Console.WriteLine("5) Подсчет частоты вхождения элементов массива");
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
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("Обратный массив");
                                int[] inversArr = coolArray.Inverse;
                                PrintArray(inversArr);
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
                                Console.Write("Перезаполнить массив случайными числами?(y/n): ");
                                if (Console.ReadLine() == "y")
                                {
                                    Console.Write("Минимальное значение: ");
                                    int min = int.Parse(Console.ReadLine());
                                    Console.Write("Максимальное значение: ");
                                    int max = int.Parse(Console.ReadLine());
                                    coolArray = new GbArray(n, (min, max));
                                }
                                Console.Clear();
                                coolArray.Print();
                                Console.WriteLine($"Максимальное число массива: {coolArray.Max} <--> Количество в массиве: {coolArray.MaxCount}");
                                break;
                            }
                        case 5: 
                            {

                                Console.Write("Перезаполнить массив случайными числами?(y/n): ");
                                if (Console.ReadLine() == "y")
                                {
                                    Console.Write("Минимальное значение: ");
                                    int min = int.Parse(Console.ReadLine());
                                    Console.Write("Максимальное значение: ");
                                    int max = int.Parse(Console.ReadLine());
                                    coolArray = new GbArray(n, (min, max));
                                }
                                Console.Clear();
                                coolArray.Print();
                                Console.WriteLine("Частота вхождения элементво в массив (неотрицательных)");
                                foreach(var elem in coolArray.GetElementsFrequency()) 
                                {
                                    Console.WriteLine($"Количество {elem.Key} = {elem.Value}");
                                }
                                break;
                            }
                        case 0: 
                            {
                                isWork = false;
                                break;
                            }
                    }
                    Console.WriteLine("Для продолжения нажмите любую клавишу...");
                    ModifiedConsole.Pause();
                }

            }
        }

        /// <summary>
        ///  Решение задачи с логинами из урока 2. Логины и пароли считываются из файла в массив. 
        ///  Создание структуры Account, содержащую Login и Password
        /// </summary>
        static void Exercise4()
        {
            Account origin = new Account { login = "root", password = "GeekBrains" };
            Account[] users = ReadUsersData(Environment.CurrentDirectory + @"\Files\Users.txt");
            Console.WriteLine("Считывание данных пользователей из файла");
            Console.WriteLine(Environment.CurrentDirectory + @"\Files\Users.txt");
            Console.WriteLine();
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
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Для продолжения нажмите любую клавишу...");
            ModifiedConsole.Pause();
        }

        /// <summary>
        /// Пример работы собственной коллекции Dictionary 
        /// </summary>
        static void Exercise5()
        {
            Console.Clear();
            Console.WriteLine("========================");
            Console.WriteLine("Класс работы с двумерным массивом");
            Console.WriteLine("========================");
            Console.WriteLine("Задание параметров массива:");

            Console.WriteLine("Размерность массива");
            Console.Write("Количество строк: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Количество столбцов: ");
            int l = int.Parse(Console.ReadLine());
            Console.Write("Минимальное значение: ");
            int min = int.Parse(Console.ReadLine());
            Console.Write("Максимальное значение: ");
            int max = int.Parse(Console.ReadLine());
            MyDictionary dictionary;

            if (n == l)
                dictionary = new MyDictionary(n, (min, max));
            else
                dictionary = new MyDictionary(n, l, (min, max));

            bool isWork = true;
            while (isWork)
            {
                Console.Clear();
                dictionary.Print();
                Console.WriteLine("1) Вывести сумму элементов");
                Console.WriteLine("2) Вывести сумму элементов больше заданного");
                Console.WriteLine("3) Минимальный элемент массива");
                Console.WriteLine("4) Максимальный элемент массива");
                Console.WriteLine("5) Номер максимального элемента массива");
                Console.WriteLine("6) Взаимодействие с файлом");
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
                                dictionary.Print();
                                Console.WriteLine($"Сумма элементов массива = {dictionary.Sum()}");
                                break;
                            }
                        case 2:
                            {
                                dictionary.Print();
                                Console.Write("Введите элемент массива: ");
                                if (int.TryParse(Console.ReadLine(), out int num))
                                {
                                    Console.WriteLine($"Сумма элементов массива = {dictionary.Sum(num)}");
                                }
                                else
                                {
                                    Console.Clear();
                                    ModifiedConsole.Print("Формат ввода неверен!");
                                }
                                break;
                            }
                        case 3:
                            {
                                dictionary.Print();
                                Console.WriteLine($"Минимальный эемент массива: {dictionary.Min}");
                                break;
                            }
                        case 4:
                            {
                                dictionary.Print();
                                Console.WriteLine($"Минимальный эемент массива: {dictionary.Max}");
                                break;
                            }
                        case 5:
                            {
                                dictionary.Print();
                                dictionary.MaxPosition(out int x, out int y);
                                Console.WriteLine($"Номер максимального элемента массива: [{x},{y}]");
                                break;
                            }
                        case 6:
                            {

                                Console.WriteLine("1) Считать из файла");
                                Console.WriteLine("2) Записать в файл");
                                Console.Write("Введите номер: ");
                                if (int.TryParse(Console.ReadLine(), out int num))
                                {
                                    switch (num)
                                    {
                                        default:
                                            break;
                                        case 1:
                                            {
                                                
                                                string filePath = Environment.CurrentDirectory + @"\Files\Dictionary.txt";
                                                Console.WriteLine($"Чтение массива из {filePath}");
                                                Console.WriteLine("Нажмите любую клавишу чтобы прочитать массив");
                                                Console.ReadKey();
                                                MyDictionary tmp = MyDictionary.Read(filePath);
                                                Console.Clear();
                                                if (tmp != null)
                                                {
                                                    Console.WriteLine("Результат считывания из файла");
                                                    tmp.Print();
                                                    Console.Write("Перезаписать начальный массив? (y/n): ");
                                                    if(Console.ReadLine() == "y") 
                                                    {
                                                        dictionary = tmp;
                                                    }
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Не удалось считать массив из файла");
                                                }
                                                break;
                                            }
                                        case 2:
                                            {
                                                string filePath = Environment.CurrentDirectory + @"\Files\Dictionary.txt";
                                                Console.WriteLine($"Запись массива в {filePath}");
                                                Console.WriteLine("Нажмите любую клавишу чтобы записать массив");
                                                Console.ReadKey();
                                                Console.Clear();
                                                if (dictionary.Write(filePath)) 
                                                {
                                                    Console.WriteLine("Массив успешно записан в файл");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Произошла ошибка при записи в файл");
                                                }
                                                break;
                                            }
                                    }
                                }
                                break;
                            }
                        case 0:
                            {
                                isWork = false;
                                break;
                            }
                    }
                    Console.WriteLine("Для продолжения нажмите любую клавишу...");
                    ModifiedConsole.Pause();
                }

            }
        }

        /// <summary>
        /// Метод задания массива и заполнения случайными числами
        /// </summary>
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
                    if (mass[i - 1] % 3 == 0 ^ mass[i] % 3 == 0)
                    {
                        count++;
                    }

                }
            }
            Console.WriteLine();
            Console.WriteLine($"Найденое число пар элементов массива: {count}");
        }

        /// <summary>
        /// Считывание данных пользователей из файла
        /// </summary>
        /// <param name="filePath">путь до файла</param>
        /// <returns></returns>
        static Account[] ReadUsersData(string filePath)
        {
            if (!File.Exists(filePath))
                throw new ArgumentException();

            List<Account> result = new List<Account>();
            StreamReader fs = new StreamReader(filePath);
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

        /// <summary>
        /// Вывод массива в консоль
        /// </summary>
        /// <param name="arr">массив</param>
        static void PrintArray(int[] arr)
        {
            foreach (int a in arr) Console.Write($"{a}\t");
            Console.WriteLine();
        }
    }
}
