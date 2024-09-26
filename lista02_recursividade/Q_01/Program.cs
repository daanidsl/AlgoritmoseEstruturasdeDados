using System;

namespace Q_01
{
    internal class Program
    {
        static int Potencia(int i, int j, int k)
        {
            if(i + k <= j)
            {
                return i + Potencia(i + k, j, k);
            }

            return i;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Resultado: " + Potencia(2,12,3));
            Console.ReadLine();
        }
    }
}