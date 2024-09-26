using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q_06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> musicas = new LinkedList<string>();
            int opcao;

            do
            {
                Console.Write("1) Inserir fim\n2) Inserir inicio\n3) Inserir depois\n4) Remover inicio\n5) Remover fim\n6) Remover especifica\n7) Listar\n8) Pesquisar\n9) Sair\n");
                opcao = int.Parse(Console.ReadLine());

                string musica;

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Informe musica:");
                        musica = Console.ReadLine();
                        musicas.AddLast(musica);
                        break;
                    case 2:
                        Console.WriteLine("Informe musica:");
                        musica = Console.ReadLine();
                        musicas.AddFirst(musica);
                        break;
                    case 3:
                        Console.WriteLine("Informe musica:");
                        musica = Console.ReadLine();
                        Console.WriteLine("Informe musica que consta na lista:");
                        string m2 = Console.ReadLine();
                        musicas.AddAfter(musicas.Find(m2), musica);
                        break;
                    case 4:
                        musicas.RemoveFirst();
                        break;
                    case 5:
                        musicas.RemoveLast();
                        break;
                    case 6:
                        Console.WriteLine("Informe musica:");
                        musica = Console.ReadLine();
                        musicas.Remove(musica);
                        break;
                    case 7:
                        foreach(string m in musicas)
                        {
                            Console.WriteLine(m);
                        }
                        break;
                    case 8:
                        Console.WriteLine("Informe musica:");
                        musica = Console.ReadLine();
                        if (musicas.Contains(musica))
                        {
                            Console.WriteLine("A musica esta na lista");
                        }
                        else
                        {
                            Console.WriteLine("A musica nao esta na lista");
                        }
                        break;
                    case 9:
                        Console.WriteLine("Fim!");
                        break;
                    default:
                        break;
                }

            } while (opcao != 9);
        }
    }
}
