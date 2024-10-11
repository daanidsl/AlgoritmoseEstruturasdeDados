using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q_04
{
    class Fila
    {
        private string[] array;
        private int primeiro, ultimo, tamanho;
        public Fila (int n)
        {
            array = new string[n + 1];
            primeiro = ultimo = 0;
            tamanho = 0;
        }
        public int ObterTamanho()
        {
            return tamanho;
        }
        public string AutorizarDecolagem()
        {
            if(primeiro == ultimo)
            {
                throw new Exception("Erro!");
            }

            string resp = array[primeiro];
            primeiro = (primeiro + 1) % array.Length;
            tamanho--;
            return resp;
        }
        public void AdicionarAviao(string identificador)
        {
            if(((ultimo + 1) % array.Length) == primeiro)
            {
                throw new Exception("Erro!");
            }
            array[ultimo] = identificador; 
            ultimo = (ultimo + 1) % array.Length;
            tamanho++;
        }
        public void Listar()
        {
            int i = primeiro;
            while (i != ultimo)
            {
                Console.WriteLine(array[i]);
                i = (i + 1) % array.Length;
            }
        }
        public string ObterPrimeiro()
        {
            if (tamanho == 0){
                return null;
            }
            else
            {
                return array[primeiro];
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Fila fila = new Fila(5);
            int opcao;
            do
            {
                Console.Write("1) Exibir quantidade de avioes\n2) Autorizar decolagem\n3) Adicionar aviao\n4) Listar fila\n5) Exibir primeiro da fila\n6) Sair\n");
                opcao = int.Parse(Console.ReadLine());
                string identificador;

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Quantidade de avioes: " + fila.ObterTamanho());
                        break;
                    case 2:
                        Console.WriteLine("O aviao " + fila.AutorizarDecolagem() + " decolou");
                        break;
                    case 3:
                        Console.WriteLine("Digite o identificador do aviao:");
                        identificador = Console.ReadLine();
                        fila.AdicionarAviao(identificador);
                        break;
                    case 4:
                        fila.Listar();
                        break;
                    case 5:
                        Console.WriteLine("Primeiro aviao da fila: " + fila.ObterPrimeiro());
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