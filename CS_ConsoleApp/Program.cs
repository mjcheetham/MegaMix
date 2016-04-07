using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_ClassLibrary;

namespace CS_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var I = Matrix3.Identity;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(I[i, j]);
                }
                Console.WriteLine();
            }

            var ms = new double[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };
            var M = new Matrix3(ms);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(M[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
