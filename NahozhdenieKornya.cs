using System;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, e, y;
            e = 0.0001;
            Console.WriteLine("Введите начало отрезка a:");
            a = Convert.ToDouble(Console.ReadLine());
            double a1 = a;
            double a2 = a;
            double a3 = a;
            Console.WriteLine("Введите конец отрезка b:");
            b = Convert.ToDouble(Console.ReadLine());
            double b1 = b;

            while (a < b) //Метод Итераций
            {
                Console.WriteLine(Convert.ToString(a));
                a += e;
                if (Math.Tan(0.4 * a + 0.4) - a * a > -e*10 && Math.Tan(0.4 * a + 0.4) - a * a < e*10)
                {
                    Console.WriteLine("^Корень^ методом итераций");
                    break;
                }
            }
            double c;

            while (a1 < b)   //Метод деления отрезка пополам
            {
                c = (a1 + b) / 2;
                if ((Math.Tan(0.4 * a1 + 0.4) - a1 * a1) * (Math.Tan(0.4 * c + 0.4) - c * c) < 0)
                {
                    b = c;
                }
                else
                {
                    a1 = c;
                }
                if (b - a1 < e)
                {
                    Console.WriteLine(Convert.ToString(a1));
                    Console.WriteLine(Convert.ToString("^Корень^ методом бисекций"));
                    break;
                }
            }

            while (true)   // Метод касательных
            {
              
                if ((Math.Tan(0.4 * a2 + 0.4) - a2 * a2 > -e && Math.Tan(0.4 * a2 + 0.4) - a2 * a2 < e) && (a2 > a3 && a2 < b1))
                {
                    Console.WriteLine(Convert.ToString(a2));
                    Console.WriteLine("^Корень^ методом касательных");
                    break;
                }
                a2 = a2 - (Math.Tan(0.4 * a2 + 0.4) - a2 * a2) / (-2 * a2 + 0.4 / Math.Pow(Math.Cos(0.4 * a2 + 0.4), 2));
            }
        }
    }
}
