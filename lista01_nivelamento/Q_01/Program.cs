using System;

namespace Q_01
{
    class Program
    {
        static void Main(string[] args)
        {
            int atual = 0, cont = 1, maior = 0, anterior = 0, temp = 0, i = 1;

            Console.Write("Digite o número 1: ");
            anterior = int.Parse(Console.ReadLine());

            do
            {
                Console.Write("Digite o número " + (i + 1) + ": ");
                atual = int.Parse(Console.ReadLine());

                if (atual > anterior)
                {
                    cont++;
                }
                else
                {
                    if (cont > maior)
                    {
                        maior = cont;
                    }
                    cont = 1;
                }

                anterior = atual;
                i++;
            }
            while (atual > 0);

            Console.WriteLine("\nMaior sequência crescente recebida: " + maior);
            Console.ReadLine();
        }
    }
}
