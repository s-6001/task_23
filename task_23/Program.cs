using System;
using System.Threading;
using System.Threading.Tasks;

namespace task_23
{
    class Program
    {
        static int n;
        static void Factorial(int n)
        {
            Console.WriteLine("Factorial начал работу");
            ulong result = 1;
            for (int i = 1; i <= n; i++)
            {
                result = result * (ulong)i;
            }
            Thread.Sleep(100);
            Console.WriteLine("Факториал числа {1} равен {0}", result, n);
            Console.WriteLine("Factorial окончил работу");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Main начал работу.");
            bool mistake = false;
            Console.Write("Введите число для вычисления факториала: ");
            try
            {
                n = Int32.Parse(Console.ReadLine());
            }
            catch
            {
                mistake = true;
                Console.WriteLine("Не удалось распознать число.");
            }
            if (mistake == false)
            {

                FactorialAsync();   // вызов асинхронного метода
            }
            ulong result2 = 1;  //проверка в методе Main
            for (int i = 1; i <= n; i++)
            {
                result2 = result2 * (ulong)i;
            }
            Console.WriteLine("Проверка в методе Main. Факториал числа {1} равен {0}", result2, n);
            Console.WriteLine("Main окончил работу.");
            Console.ReadKey();
        }
        static async void FactorialAsync()  //асинхронный метод
        {
            Console.WriteLine("FactorialAsync начал работу");
            await Task.Run(() => Factorial(n));
            Console.WriteLine("FactorialAsync окончил работу");
        }
    }
}