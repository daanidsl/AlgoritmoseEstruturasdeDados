using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Q_05
{
    class Celula
    {
        private double elemento;
        private Celula prox;
        public Celula(double elemento)
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
        public double Elemento
        {
            get { return elemento; }
            set { elemento = value; }
        }
    }
    class Lista
    {
        private Celula primeiro, ultimo;
        public Lista()
        {
            primeiro = new Celula();
            ultimo = primeiro;
        }
        public int Tamanho()
        {
            int tam = 0;
            for(Celula i = primeiro; i != ultimo; i = i.Prox)
            {
                tam++;
            }
            return tam;
        }
        public void InserirInicio(double x)
        {
            Celula tmp = new Celula(x);
            tmp.Prox = primeiro.Prox;
            primeiro.Prox = tmp;
            if(primeiro == ultimo)
            {
                ultimo = tmp;
            }
            tmp = null;
        }
        public void InserirFim(double x)
        {
            ultimo.Prox = new Celula(x);
            ultimo = ultimo.Prox;
        }
        public double RemoverInicio()
        {
            if(primeiro == ultimo)
            {
                throw new Exception("Erro");
            }
            Celula tmp = primeiro;
            primeiro = primeiro.Prox;
            double elemento = primeiro.Elemento;
            tmp.Prox = null;
            tmp = null;
            return elemento;
        }
        public double RemoverFim()
        {
            if(primeiro == ultimo)
            {
                throw new Exception("Erro");
            }
            Celula i;
            for (i = primeiro; i.Prox != ultimo; i = i.Prox);
            double elemento = ultimo.Elemento;
            ultimo = i;
            i = ultimo.Prox = null;
            return elemento;
        }
        public void Inserir(double x, int pos)
        {
            int tamanho = Tamanho();
            if (pos < 0 || pos > tamanho)
            {
                throw new Exception("Erro");
            }
            else if(pos == 0)
            {
                InserirInicio(x);
            }
            else if(pos == tamanho)
            {
                InserirFim(x);
            }
            else
            {
                Celula i = primeiro;
                for (int j = 0; j < pos; j++, i = i.Prox) ;
                Celula tmp = new Celula(x);
                tmp.Prox = i.Prox;
                i.Prox = tmp;
                tmp = i = null;
            }
        }
        public double Remover(int pos)
        {
            double elemento; int tamanho = Tamanho();
            if (primeiro == ultimo || pos < 0 || pos >= tamanho)
            {
                throw new Exception("Erro");
            }
            else if (pos == 0)
            {
                elemento = RemoverInicio();
            }
            else if (pos == tamanho - 1)
            {
                elemento = RemoverFim();
            }
            else
            {
                Celula i = primeiro;
                for (int j = 0; j < pos; j++, i = i.Prox) ;
                Celula tmp = i.Prox;
                elemento = tmp.Elemento; i.Prox = tmp.Prox;
                tmp.Prox = null; i = tmp = null;
            }
            return elemento;
        }
        public double RemoverItem(double x)
        {
            if (primeiro == ultimo)
            {
                throw new Exception("Erro");
            }

            double elemento = 0; int pos = 0;

            for (Celula i = primeiro.Prox; i != null; i = i.Prox)
            {
                if (i.Elemento == x)
                {
                    if (pos == 0)
                    {
                        elemento = RemoverInicio();
                    }
                    else if (i == ultimo)
                    {
                        elemento = RemoverFim();
                    }
                    else
                    {
                        elemento = Remover(pos);
                    }

                    return elemento; 
                }
                pos++;
            }
            throw new Exception("Erro");
        }
        public int Contar(double x)
        {
            int cont = 0;
            for (Celula i = primeiro.Prox; i != null; i = i.Prox)
            {
                if (i.Elemento == x)
                {
                    cont++;
                }
            }
            return cont;
        }
        public void Mostrar()
        {
            int cont = 0;

            for(Celula i = primeiro.Prox; i != null; i = i.Prox)
            {
                Console.WriteLine(cont + ": " + i.Elemento);
                cont++;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Lista lista = new Lista();
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
                        lista.Inserir(tempo, pos);
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
                        Console.WriteLine("Tempo removido: " + lista.Remover(pos));
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
