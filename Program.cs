using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество элементов массива: ");
            int n = getNumber(10, 100);
            
            var arr = new int[n];
            
            Console.Write("\nВведите делитель: ");
            int d = getNumber(1, int.MaxValue);

            //fillArr(arr);
            fillArrManual(arr);
            printArr(arr);
            printDevidables(arr, d);

            Console.ReadKey();
        }

        public static void printArr(int[] arr)
        {
            Console.Write("\nИсходный массив: [");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
                if (i < arr.Length - 1 )
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine("]");
        }

        public static void fillArr(int[] arr)
        {
            var random = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(-50, 50);
            }
        }

        public static void fillArrManual(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("Введите значение элемента массива: ");
                arr[i] = getNumber(-50, 50);
            }
        }

        public static bool isDevided(int n, int d)
        {
            return n % d == 0;
        }

        public static int getNumber(int min, int max)
        {
            int result;
            for (; ; )
            {
                bool isIntNumber = int.TryParse(Console.ReadLine(), out result);
                if (isIntNumber)
                {
                    if (result < min || result > max)
                    {
                        Console.Write("\nПовторите ввод, число должно быть в пределах ({0} ... {1}): ", min, max);
                        continue;
                    }
                    break;
                }
                else
                {
                    Console.Write("\nОшибка ввода, повторите: ");
                }
            }
            return result;
        }

        public static void printDevidables(int[] arr, int d)
        {
            int counter = 0;
            Console.Write("\nЭлементы массива, кратные {0}: ", d);
            for (int i = 0; i < arr.Length; i++)
            {
                if (isDevided(arr[i], d))
                {
                    counter++;
                    if (counter == 1)
                    {
                        Console.Write(arr[i]);
                    }
                    else
                    {
                        Console.Write(", " + arr[i]);
                    }
                }
                if (i == arr.Length - 1)
                {
                    Console.WriteLine("\n");
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("нет кратных элементов!\n");
            }
        }
    }
}
