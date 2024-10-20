using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q_02
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
        public void Inserir(int x)
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
        public void Mostrar()
        {
            Console.Write("Octal: ");
            for(Celula i = topo; i != null; i = i.Prox)
            {
                Console.Write(i.Elemento);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Informe um numero:");
            int numero = int.Parse(Console.ReadLine());

            Pilha pilha = new Pilha();
            int octal;

            do
            {
                octal = numero % 8;
                pilha.Inserir(octal);
                numero = numero / 8;

            } while (numero > 0);

            pilha.Mostrar();
        }
    }
}
