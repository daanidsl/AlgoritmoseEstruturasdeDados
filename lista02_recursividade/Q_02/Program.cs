using System;

namespace Q_02
{
    internal class Program
    {
        static int Soma(int m, int n)
        {
            int resultado;
            if (m == n)
            {
                resultado = m;
            }
            else
            {
                resultado = n + Soma(m, n - 1);
            }
            return resultado;
        }
        static void Main(string[] args)
        {
            int m = 4;
            int n = 7;
            Console.Write(Soma(m, n));
            Console.ReadLine();
        }
    }
}
