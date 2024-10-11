using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Q_01
{
    class Lista
    {
        private double[] vet;
        private int n;

        public Lista(int tamanho)
        {
            vet = new double[tamanho];
            n = 0;
        }

        public void InserirInicio(double tempo)
        {
            if (n >= vet.Length)
            {
                throw new Exception("Erro!");
            }

            for (int i = n; i > 0; i--)
            {
                vet[i] = vet[i - 1];
            }

            vet[0] = tempo;
            n++;
        }

        public void InserirFim(double tempo)
        {
            if (n >= vet.Length)
            {
                throw new Exception("Erro!");
            }

            vet[n] = tempo;
            n++;
        }
        public void InserirPosicaoEspecifica(double tempo, int pos)
        {
            if (n >= vet.Length || pos < 0 || pos > n)
            {
                throw new Exception("Erro!");
            }
            for (int i = n; i > pos; i--)
            {
                vet[i] = vet[i - 1];
            }

            vet[pos] = tempo;
            n++;
        }
        public double RemoverInicio()
        {
            if (n == 0)
            {
                throw new Exception("Erro!");
            }

            double resp = vet[0];
            n--;

            for (int i = 0; i < n; i++)
            {
                vet[i] = vet[i + 1];
            }
            return resp;
        }
        public double RemoverFim()
        {
            if (n == 0)
            {
                throw new Exception("Erro!");
            }
            n--;
            return vet[n];
        }
        public double RemoverPosicaoEspecifica(int pos)
        {
            if (n == 0 || pos < 0 || pos >= n)
            {
                throw new Exception("Erro!");
            }

            double resp = vet[pos];
            n--;

            for (int i = pos; i < n; i++)
            {
                vet[i] = vet[i + 1];
            }
            return resp;
        }
        public double RemoverItem(double x)
        {
            if (n == 0)
            {
                throw new Exception("Erro!");
            }

            double resp = 0; int pos = 0;

            for (int i = 0; i < n; i++)
            {
                if (vet[i] == x)
                {
                    pos = i;
                }
            }

            resp = vet[pos];

            for (int i = pos; i < n - 1; i++)
            {
                vet[i] = vet[i + 1];
            }

            n--;
            return resp;
        }
        public int Contar(double x)
        {
            if (n == 0)
            {
                throw new Exception("Erro!");
            }

            int quant = 0;

            for (int i = 0; i < n; i++)
            {
                if (x == vet[i])
                {
                    quant++;
                }
            }

            return quant;
        }
        public void Mostrar()
        {
            if (n == 0)
            {
                throw new Exception("Erro!");
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(i + ": " + vet[i]);
            }
        }
    }
    class Program
    {
        static void Main()
        {
            Lista lista = new Lista(100);
            int opcao;
            do
            {
                Console.Write("1) Inserir inicio\n2) Inserir fim\n3) Inserir posicao especifica\n4) Remover inicio\n5) Remover fim\n6) Remover posicao especifica\n7) Remover tempo especifico\n8) Pesquisar\n9) Mostrar\n10) Encerrar\n");
                opcao = int.Parse(Console.ReadLine());
                double tempo; int pos;

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Informe o tempo:");
                        tempo = double.Parse(Console.ReadLine());
                        lista.InserirInicio(tempo);
                        break;
                    case 2:
                        Console.WriteLine("Informe o tempo:");
                        tempo = double.Parse(Console.ReadLine());
                        lista.InserirFim(tempo);
                        break;
                    case 3:
                        Console.WriteLine("Informe o tempo:");
                        tempo = double.Parse(Console.ReadLine());
                        Console.WriteLine("Informe a posicao:");
                        pos = int.Parse(Console.ReadLine());
                        lista.InserirPosicaoEspecifica(tempo, pos);
                        break;
                    case 4:
                        lista.RemoverInicio();
                        break;
                    case 5:
                        Console.WriteLine("Tempo removido: " + lista.RemoverFim());
                        break;
                    case 6:
                        Console.WriteLine("Informe a posicao:");
                        pos = int.Parse(Console.ReadLine());
                        Console.WriteLine("Tempo removido: " + lista.RemoverPosicaoEspecifica(pos));
                        break;
                    case 7:
                        Console.WriteLine("Informe o tempo:");
                        tempo = double.Parse(Console.ReadLine());
                        Console.WriteLine("Tempo removido: " + lista.RemoverItem(tempo));
                        break;
                    case 8:
                        Console.WriteLine("Informe o tempo:");
                        tempo = double.Parse(Console.ReadLine());
                        Console.WriteLine("Quantidade: " + lista.Contar(tempo));
                        break;
                    case 9:
                        lista.Mostrar();
                        break;
                    case 10:
                        Console.WriteLine("Fim");
                        break;
                    default:
                        break;
                }
            } while (opcao != 10);
        }
    }
}