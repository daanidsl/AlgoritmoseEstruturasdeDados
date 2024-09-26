using System;

namespace Q_03
{
    internal class Program
    {
        static void Binario(int n)
        {
            if (n / 2 == 0)
            {
                Console.Write(n);
            }
            else
            {
                Binario(n / 2);
                Console.Write(n % 2);
            }
        }
        static void Main(string[] args)
        {
            Binario(4);
            Console.ReadLine();
        }
    }
}
