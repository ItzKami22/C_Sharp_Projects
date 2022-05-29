using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace Simplex
{
    class Simplex
    {
        private double[] c;
        private double[,] A;
        private double[] b;
        private HashSet<int> N = new HashSet<int>();
        private HashSet<int> B = new HashSet<int>();
        private double v = 0;

        public Simplex(double[] c, double[,] A, double[] b)
        {
            int vars = c.Length, constraints = b.Length;

            if (vars != A.GetLength(1))
            {
                throw new Exception("Количество переменных в c не соответствует количеству в A.");
            }

            if (constraints != A.GetLength(0))
            {
                throw new Exception("Количество ограничений в A не совпадает с числом в b.");
            }

            // Расширить вектор коэффициентов max fn с 0 отступом
            this.c = new double[vars + constraints];
            Array.Copy(c, this.c, vars);

            // Расширить матрицу коэффициентов с отступом 0
            this.A = new double[vars + constraints, vars + constraints];
            for (int i = 0; i < constraints; i++)
            {
                for (int j = 0; j < vars; j++)
                {
                    this.A[i + vars, j] = A[i, j];
                }
            }

            // Расширить вектор правой части ограничения с помощью 0 отступов
            this.b = new double[vars + constraints];
            Array.Copy(b, 0, this.b, vars, constraints);

            // Заполнить неосновные и базовые наборы
            for (int i = 0; i < vars; i++)
            {
                N.Add(i);
            }

            for (int i = 0; i < constraints; i++)
            {
                B.Add(vars + i);
            }
        }

        public Tuple<double, double[]> maximize()
        {
            while (true)
            {
                // Найти самый большой коэффициент для ввода var
                int e = -1;
                double ce = 0;
                foreach (var _e in N)
                {
                    if (c[_e] > ce)
                    {
                        ce = c[_e];
                        e = _e;
                    }
                }

                // Если нет коэффициента> 0, больше нечего делать, и мы почти закончили
                if (e == -1) break;

                // Найти самый низкий коэффициент проверки
                double minRatio = double.PositiveInfinity;
                int l = -1;
                foreach (var i in B)
                {
                    if (A[i, e] > 0)
                    {
                        double r = b[i] / A[i, e];
                        if (r < minRatio)
                        {
                            minRatio = r;
                            l = i;
                        }
                    }
                }

                // Неограниченный
                if (double.IsInfinity(minRatio))
                {
                    return Tuple.Create<double, double[]>(double.PositiveInfinity, null);
                }

                pivot(e, l);
            }

            // Количество извлечения и провисание для оптимального решения
            double[] x = new double[b.Length];
            int n = b.Length;
            for (var i = 0; i < n; i++)
            {
                x[i] = B.Contains(i) ? b[i] : 0;
            }

            // Вернуть макс и переменные
            return Tuple.Create<double, double[]>(v, x);
        }

        private void pivot(int e, int l)
        {
            N.Remove(e);
            B.Remove(l);

            b[e] = b[l] / A[l, e];

            foreach (var j in N)
            {
                A[e, j] = A[l, j] / A[l, e];
            }

            A[e, l] = 1 / A[l, e];

            foreach (var i in B)
            {
                b[i] = b[i] - A[i, e] * b[e];

                foreach (var j in N)
                {
                    A[i, j] = A[i, j] - A[i, e] * A[e, j];
                }

                A[i, l] = -1 * A[i, e] * A[e, l];
            }

            v = v + c[e] * b[e];

            foreach (var j in N)
            {
                c[j] = c[j] - c[e] * A[e, j];
            }

            c[l] = -1 * c[e] * A[e, l];

            N.Add(l);
            B.Add(e);
        }
    }

    class MainClass
    {
        static void Main(string[] args)
        {
            var s = new Simplex(
              new[] { 1.0, 3.0, 2.0, 1.0, -2.0, 1.0 },
              new[,] {
          {2.0, 2, 1,0, -3,1},
          {4, 3, 1, 2,-1,2}
    
              },
              new double[] { 10, 7 }
            );

            var answer = s.maximize();
            Console.WriteLine("Maximum of the function:");
            Console.WriteLine(answer.Item1);
            Console.WriteLine("Variables:");
            Console.WriteLine(string.Join(", ", answer.Item2));
        }
    }
}