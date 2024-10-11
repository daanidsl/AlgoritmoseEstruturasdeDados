using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q_03
{
    class Pilha
    {
        private char[] array;
        private int n;
        public Pilha(int tamanho)
        {
            array = new char[tamanho];
            n = 0;
        }
        public void InserirFim(char caractere)
        {
            if (n >= array.Length)
            {
                throw new Exception("Erro!");
            }

            array[n] = caractere;
            n++;
        }

        public char Inicio()
        {
            if (n == 0)
            {
                throw new Exception("Erro!");
            }

            return array[n - 1];
        }

        public void RemoverFim()
        {
            if (n == 0)
            {
                throw new Exception("Erro!");
            }
            n--;
        }
        public int ObterTamanho()
        {
            return n;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Pilha pilha = new Pilha(100);

            Console.WriteLine("Informe a sequencia:");
            string sequencia = Console.ReadLine();
            char caractere;

            for (int i = 0; i < sequencia.Length; i++)
            {
                caractere = sequencia[i];

                if (caractere == '(' || caractere == '[')
                {
                    pilha.InserirFim(caractere);
                }

                else if (caractere == ')')
                {
                    if (pilha.ObterTamanho() == 0 || pilha.Inicio() != '(')
                    {
                        pilha.InserirFim(caractere);
                    }
                    pilha.RemoverFim();
                }

                else if (caractere == ']')
                {
                    if (pilha.ObterTamanho() == 0 || pilha.Inicio() != '[')
                    {
                        pilha.InserirFim(caractere);
                    }
                    pilha.RemoverFim();
                }
            }

            if (pilha.ObterTamanho() == 0)
            {
                Console.Write("Sequencia bem formada!");
            }
            else
            {
                Console.Write("Sequencia mal formada!");
            }

            Console.ReadLine();
        }
    }
}