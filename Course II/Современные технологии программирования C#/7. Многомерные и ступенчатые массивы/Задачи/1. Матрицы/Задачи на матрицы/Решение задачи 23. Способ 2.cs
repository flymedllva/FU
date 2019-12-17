using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace z6
{
    class Program
    {
        static void Main(string[] args)
        {
            int N, M,temp;
            Random x = new Random();

            Console.WriteLine("Введите N: ");
            N = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите M: ");
            M = int.Parse(Console.ReadLine());
            
            string[] B = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            int[] C = new int[26];
            string[,] A = new string[N, M];

            for (int i = 0; i < N; i++ )
            {
                for (int j = 0; j < M; j++)
                {
                    temp =  x.Next(0, 26);
                    if (C[temp] == 0)
                    {

                        A[i, j] = B[temp];
                        C[temp] += 1;
                    }
                    else
                        A[i, j] = "*";
                }
            }

            Console.WriteLine("\nРезультирующая матрица: \n");

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    Console.Write("{0,5}", A[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
