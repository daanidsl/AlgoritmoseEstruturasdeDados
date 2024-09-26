using System;
using System.Collections.Generic;

namespace Q_01
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcao;
            List<double> tempos = new List<double>();
            do
            {
                Console.Write("1) Inserir inicio\n2) Inserir fim\n3) Inserir posicao especifica\n4) Remover inicio\n5) Remover fim\n6) Remover posicao especifica\n7) Remover tempo especifico\n8) Pesquisar\n9) Mostrar\n10) Mostrar ordem crescente\n11) Mostrar ordem decrescente\n12) Encerrar\n");
                opcao = int.Parse(Console.ReadLine());
                double tempo; int pos;

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Informe o tempo:");
                        tempo = double.Parse(Console.ReadLine());
                        tempos.Insert(0, tempo);
                        break;
                    case 2:
                        Console.WriteLine("Informe o tempo:");
                        tempo = double.Parse(Console.ReadLine());
                        tempos.Add(tempo);
                        break;
                    case 3:
                        Console.WriteLine("Informe o tempo:");
                        tempo = double.Parse(Console.ReadLine());
                        Console.WriteLine("Informe a posicao:");
                        pos = int.Parse(Console.ReadLine());
                        tempos.Insert(pos, tempo);
                        break;
                    case 4:
                        tempos.RemoveAt(0);
                        break;
                    case 5:
                        int cont = tempos.Count;
                        Console.WriteLine("Tempo removido: " + tempos[cont-1]);
                        tempos.RemoveAt(cont-1);
                        break;
                    case 6:
                        Console.WriteLine("Informe a posicao:");
                        pos = int.Parse(Console.ReadLine());
                        Console.WriteLine("Tempo removido: " + tempos[pos]);
                        tempos.RemoveAt(pos);
                        break;
                    case 7:
                        Console.WriteLine("Informe o tempo:");
                        tempo = double.Parse(Console.ReadLine());
                        tempos.RemoveAt(tempos.IndexOf(tempo));
                        Console.WriteLine("Tempo removido: " + tempo);
                        break;
                    case 8:
                        Console.WriteLine("Informe o tempo:");
                        tempo = double.Parse(Console.ReadLine());
                        int quant = 0;
                        foreach(double t in tempos)
                        {
                            if(t == tempo)
                            {
                                quant++;
                            }
                        }
                        Console.WriteLine("Quantidade: " + quant);
                        break;
                    case 9:
                        for(int i = 0; i < tempos.Count; i++)
                        {
                            Console.WriteLine(i + ": " + tempos[i]);
                        }
                        break;
                    case 10:
                        tempos.Sort();
                        for (int i = 0; i < tempos.Count; i++)
                        {
                            Console.WriteLine(i + ": " + tempos[i]);
                        }
                        break;
                    case 11:
                        tempos.Sort();
                        tempos.Reverse();
                        for (int i = 0; i < tempos.Count; i++)
                        {
                            Console.WriteLine(i + ": " + tempos[i]);
                        }
                        break;
                    case 12:
                        Console.WriteLine("Fim");
                        break;
                    default:
                        break;
                }
            } while (opcao != 12);
        }
    }
}
