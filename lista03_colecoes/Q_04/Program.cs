using System;
using System.Collections.Generic;

namespace Q_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> decolagem = new Queue<string>();
            int opcao;

            do
            {
                Console.Write("1) Exibir quantidade de avioes\n2) Autorizar decolagem\n3) Adicionar aviao\n4) Listar fila\n5) Exibir primeiro da fila\n6) Sair\n");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Quantidade de avioes: " + decolagem.Count);
                        break;
                    case 2:
                        Console.WriteLine("O aviao " + decolagem.Peek() + " decolou");
                        decolagem.Dequeue();
                        break;
                    case 3:
                        Console.WriteLine("Digite o identificador do aviao:");
                        string id = Console.ReadLine();
                        decolagem.Enqueue(id);
                        break;
                    case 4:
                        foreach (string item in decolagem)
                            Console.WriteLine(item);
                        break;
                    case 5:
                        Console.WriteLine("Primeiro aviao da fila: " + decolagem.Peek());
                        break;
                    case 6:
                        Console.WriteLine("Fim");
                        break;
                    default:
                        break;
                }

            } while (opcao != 6);
        }
    }
}
