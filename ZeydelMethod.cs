using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 4;
            double[,] A ={
        {0.4,-5.3,4.3,-2.7, -1.9},
        {13.4,-4.2,-5.4,2.1, 6.7},
        {16.2,-1.2,-6.5,4.2, 9.2},
        {15.3,8.8,-6.7,-23.8, -7.1}
           };
            double e=0.00001;
            double[] xx=new double[4];
            // Функция решения СЛАУ методом зейделя (все итерации)
            void zeidel(double[,] Aa, int nn, double[] x, double ee)
            {
                double[] g = new double[nn];
                for (int i = 0; i < nn; i++) g[i] = 1;
                do
                {
                    for (int q = 0; q < nn; q++)
                    {
                        g[q] = Aa[q,nn];
                        for (int j = 0; j < nn; j++)
                            g[q] -= Aa[q,j] * x[j];
                        g[q] /= Aa[q,q];
                        x[q] += g[q];
                        Console.WriteLine(g.Max());
                    }
                }
                while (Math.Abs(g.Max()) > ee);
                for (int i = 0; i < nn; i++)
                {
                    Console.Write(Math.Round(x[i],4) + "\t");
                }
                if (Double.IsNaN(x[0])) 
                {
                    Console.WriteLine();
                    Console.WriteLine("Ряд не сходится");
                }
                
            }
            zeidel(A, n, xx, e);
        }
    }
}
