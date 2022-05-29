using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Метод Гаусса
            double[,] M = new double[4, 5];
            double a;
            M[0, 0] = 0.4; M[0, 1] = -5.3; M[0, 2] = 4.3; M[0, 3] = -2.7; M[0, 4] = -1.9;
            M[1, 0] = 13.4; M[1, 1] = -4.2; M[1, 2] = -5.4; M[1, 3] = 2.1; M[1, 4] = 6.7;
            M[2, 0] = 16.2; M[2, 1] = -1.2; M[2, 2] = -6.5; M[2, 3] = 4.2; M[2, 4] = 9.2;
            M[3, 0] = 15.3; M[3, 1] = 8.8; M[3, 2] = -6.7; M[3, 3] = -23.8; M[3, 4] = -7.1;
            for (int i = 0; i < 3; i++)
            {
                
                for (int k = 0; k < i + 1; k++)
                {
                    a = M[0, k] / M[i + 1, k];
                    for (int j = 0; j < 5-k; j++)
                    {
                        M[i+1, j+k] = M[i+1, j+k] * a;
                        if (j + k < 5)
                        { 
                            M[i + 1, j + k] = M[i + 1, j + k] - M[0, j + k];

                        }
                    }
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(Math.Round(M[i, j],4) + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("x4="+M[3,4]/ M[3, 3]);
            Console.WriteLine("x3=" + (M[2, 4]- (M[3, 4] / M[3, 3]*M[2,3]) / M[2, 2]));
            Console.WriteLine("x2=" + ((M[1,4]-((M[2, 4] - (M[3, 4] / M[3, 3] * M[2, 3]) / M[2, 2])*M[1,2])-(M[1,3]*(M[3, 4] / M[3, 3])))/M[1,1]));
            Console.WriteLine("x1=" +((M[0,4]-(((M[1, 4] - ((M[2, 4] - (M[3, 4] / M[3, 3] * M[2, 3]) / M[2, 2]) * M[1, 2]) - (M[1, 3] * (M[3, 4] / M[3, 3]))) / M[1, 1])*M[0,1])- (M[2, 4] - (M[3, 4] / M[3, 3] * M[2, 3]) / M[2, 2])*M[0,2]- (M[3, 4] / M[3, 3])*M[0,3])/M[0,0]));

        }
    }
}
