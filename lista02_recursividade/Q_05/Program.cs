using System;

namespace Q_05
{
    internal class Program
    {
        static int Negativos (int[] vet, int n)
        {
            int quant = 0;

            if (n == 1)
            {
                if (vet[0] < 0)
                {
                    quant = 1;
                }
            }

            else
            {
                if (vet[n - 1] < 0)
                {
                    quant = 1 + Negativos(vet, n - 1);
                }
                else
                {
                    quant = Negativos(vet, n - 1);
                }
            }

            return quant;
        }
        static void Main(string[] args)
        {
            int[] vet = { 0, -28, 1, -4, 2, -6, 10, 8 };
            int n = vet.Length;

            Console.Write("Quantidade de números negativos: " + Negativos(vet, n));
            Console.ReadLine();
        }
    }
}
