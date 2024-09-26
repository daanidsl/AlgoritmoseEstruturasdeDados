using System;

namespace Q_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite um valor para n: ");
            int n = int.Parse(Console.ReadLine());
            int cont = 1;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write(cont + " ");
                    cont++;
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
   