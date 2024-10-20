using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q_01
{
    class Celula
    {
        private int elemento;
        private Celula prox;

        public Celula(int elemento)
        {
            this.elemento = elemento;
            this.prox = null;
        }
        public Celula()
        {
            this.elemento = 0;
            this.prox = null;
        }
        public Celula Prox
        {
            get { return prox; }
            set { prox = value; }
        }
        public int Elemento
        {
            get { return elemento; }
            set { elemento = value; }
        }
    }
    class Pilha
    {
        private Celula topo;
        public Pilha()
        {
            topo = null;
        }
        public Celula Topo
        {
            get { return topo; }
            set { topo = value; }
        }
        public void Inserir(char x)
        {
            Celula tmp = new Celula(x);
            tmp.Prox = topo;
            topo = tmp;
            tmp = null;
        }
        public int Remover()
        {
            if (topo == null)
            {
                throw new Exception("Erro");
            }
            int elemento = topo.Elemento;
            Celula tmp = topo;
            topo = topo.Prox;
            tmp.Prox = null;
            tmp = null;
            return elemento;
        }
        public bool EstaVazia()
        {
            bool vazia = true;
            for (Celula i = topo; i != null; i = i.Prox)
            {
                vazia = false;
            }
            return vazia;
        }
        public void Mostrar()
        {
            for (Celula i = topo; i != null; i = i.Prox)
            {
                Console.Write(i.Elemento);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Informe a sequencia:");
            string sequencia = Console.ReadLine();
            char caractere;
            Pilha pilha = new Pilha();

            for (int i = 0; i < sequencia.Length; i++)
            {
                caractere = sequencia[i];

                if (caractere == '(' || caractere == '[')
                {
                    pilha.Inserir(caractere);
                }

                else if (caractere == ')')
                {
                    if (pilha.EstaVazia() == true || pilha.Topo.Elemento != '(')
                    {
                        pilha.Inserir(caractere);
                    }
                    pilha.Remover();
                }

                else if (caractere == ']')
                {
                    if (pilha.EstaVazia() == true || pilha.Topo.Elemento != '[')
                    {
                        pilha.Inserir(caractere);
                    }
                    pilha.Remover();
                }
            }

            if (pilha.EstaVazia() == true)
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
