using System;

namespace Q_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite a quantidade de candidatos a representante: ");
            int quant = int.Parse(Console.ReadLine());

            string [] nomes = new string[quant];

            for(int i = 0; i < nomes.Length; i++)
            {
                Console.Write("Digite o nome do candidato de número " + i + ": ");
                nomes[i] = Console.ReadLine();
            }

            int[] votos = new int[quant];
            int nulo = 0;

            for(int i = 0; i < 60; i++)
            {
                Console.Write("Digite o número do candidato que deseja votar: ");
                int num = int.Parse(Console.ReadLine());

                if (num >= 0 && num < quant)
                {
                    votos[num]++;
                }
                else
                {
                    nulo++;
                }
            }

            int maisvotado = 0, menosvotado = 0;
            int maior = 0, menor = 0;

            for (int i = 0; i < votos.Length; i++)
            {
                if (votos[i] > maior)
                {
                    maior = votos[i];
                    maisvotado = i;
                }

                if (votos[i] < menor)
                {
                    menor = votos[i];
                    menosvotado = i;
                }
            }

            Console.WriteLine();
            Console.WriteLine("O candidato mais votado foi " + nomes[maisvotado] + " com o total de " + maior + " votos");
            Console.WriteLine("O número do candidato menos votado foi " + menosvotado + ", com o total de " + menor + " votos");
            Console.WriteLine("A quantidade de votos nulos foi de " + nulo + " votos");

            Console.ReadLine();
        }
    }
}
