using System;

namespace Q_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite o valor de n: ");
            int n = int.Parse(Console.ReadLine());

            int[] x = new int[n];
            int[] y = new int[n];
            Random rnd = new Random();

            Console.WriteLine("Vetor X: ");
            for(int i = 0; i < x.Length; i++)
            {
                Console.Write("Digite o número " + (i + 1) + " para o vetor X: ");
                x[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("\nVetor Y: ");
            for (int i = 0; i < y.Length; i++)
            {
                Console.Write("Digite o número " + (i + 1) + " para o vetor Y: ");
                y[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("\nSoma entre X e Y: ");
            for (int i = 0; i < y.Length; i++)
            {
                Console.Write((x[i] + y[i]) + " ");
            }

            Console.WriteLine("\nProduto entre X e Y: ");
            for (int i = 0; i < y.Length; i++)
            {
                Console.Write((x[i] * y[i]) + " ");
            }

            Console.WriteLine("\nDiferença entre X e Y: ");
            for (int i = 0; i < x.Length; i++)
            {
                bool existe = false;
                for (int j = 0; j < y.Length; j++)
                {
                    if (x[i] == y[j])
                    {
                        existe = true;
                    }
                }

                if (!existe)
                {
                    Console.Write(x[i] + " ");
                }
            }

            Console.WriteLine("\nInterseção entre X e Y: ");
            for(int i = 0; i < x.Length; i++)
            {
                bool comum = false;

                for(int j = 0; j < y.Length; j++)
                {
                    if (x[i] == y[j])
                    {
                        comum = true;
                    }
                }

                if (comum)
                {
                    Console.Write(x[i] + " ");
                }
            }

            Console.WriteLine("\nUnião entre X e Y: ");
            for (int i = 0; i < x.Length; i++)
            {
                Console.Write(x[i] + " ");
            }
            for (int j = 0; j < y.Length; j++)
            {
                bool existey = false;
                for (int i = 0; i < x.Length; i++)
                {
                    if (y[j] == x[i])
                    {
                        existey = true;
                        break;
                    }
                }

                if (!existey)
                {
                    Console.Write(y[j] + " ");
                }
            }

            Console.ReadLine();
        }
    }
}
