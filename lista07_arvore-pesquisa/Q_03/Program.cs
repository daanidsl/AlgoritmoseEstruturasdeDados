using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q_03
{
    class No
    {
        private string elemento;
        private No esq, dir;
        public No(string elemento)
        {
            this.elemento = elemento;
            esq = null;
            dir = null;
        }
        public No(string elemento, No esq, No dir)
        {
            this.elemento = elemento;
            this.esq = esq;
            this.dir = dir;
        }
        public string Elemento
        {
            get { return elemento; }
            set { elemento = value; }
        }
        public No Esq
        {
            get { return esq; }
            set { esq = value; }
        }
        public No Dir
        {
            get { return dir; }
            set { dir = value; }
        }
    }
    class ArvoreBinaria
    {
        private No raiz;
        public ArvoreBinaria()
        {
            raiz = null;
        }
        public void Inserir(string x)
        {
            raiz = Inserir(x, raiz);
        }
        private No Inserir(string x, No i)
        {
            if (i == null)
            {
                i = new No(x);
            }
            else if (x.CompareTo(i.Elemento) < 0)
            {
                i.Esq = Inserir(x, i.Esq);
            }
            else if (x.CompareTo(i.Elemento) > 0)
            {
                i.Dir = Inserir(x, i.Dir);
            }
            else
            {
                throw new Exception("Erro");
            }
            return i;
        }
        public void Remover(string x)
        {
            raiz = Remover(x, raiz);
        }
        private No Remover(string x, No i)
        {
            if (i == null)
            {
                throw new Exception("Erro");
            }
            else if (x.CompareTo(i.Elemento) < 0)
            {
                i.Esq = Remover(x, i.Esq);
            }
            else if (x.CompareTo(i.Elemento) > 0)
            {
                i.Dir = Remover(x, i.Dir);
            }
            else if (i.Dir == null)
            {
                i = i.Esq;
            }
            else if (i.Esq == null)
            {
                i = i.Dir;
            }
            else
            {
                i.Esq = MaiorEsq(i, i.Esq);
            }
            return i;
        }
        No MaiorEsq(No i, No j)
        {
            if (j.Dir == null)
            {
                i.Elemento = j.Elemento;
                j = j.Esq;
            }
            else
            {
                j.Dir = MaiorEsq(i, j.Dir);
            }
            return j;
        }
        public bool Pesquisar(string x)
        {
            return Pesquisar(x, raiz);
        }
        private bool Pesquisar(string x, No i)
        {
            bool resp;
            if (i == null)
            {
                resp = false;
            }
            else if (x.CompareTo(i.Elemento) == 0)
            {
                resp = true;
            }
            else if (x.CompareTo(i.Elemento) < 0)
            {
                resp = Pesquisar(x, i.Esq);
            }
            else
            {
                resp = Pesquisar(x, i.Dir);
            }
            return resp;
        }
        public void CaminharCentral()
        {
            CaminharCentral(raiz);
        }
        private void CaminharCentral(No i)
        {
            if (i != null)
            {
                CaminharCentral(i.Esq);
                Console.Write(i.Elemento + " ");
                CaminharCentral(i.Dir);
            }
        }
        public void CaminharPos()
        {
            CaminharPos(raiz);
        }
        private void CaminharPos(No i)
        {
            if (i != null)
            {
                CaminharPos(i.Esq);
                CaminharPos(i.Dir);
                Console.Write(i.Elemento + " ");
            }
        }
        public void CaminharPre()
        {
            CaminharPre(raiz);
        }
        private void CaminharPre(No i)
        {
            if (i != null)
            {
                Console.Write(i.Elemento + " ");
                CaminharPre(i.Esq);
                CaminharPre(i.Dir);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ArvoreBinaria arvorebinaria = new ArvoreBinaria();
            int opcao;
            do
            {
                Console.Write("1.Inserir\n2.Remover\n3.Pesquisar\n4.Caminhamento central\n5.Caminhamento pos-ordem\n6.Caminhamento pre-ordem\n7.Sair\n");
                opcao = int.Parse(Console.ReadLine());
                string nome;

                switch (opcao)
                {
                    case 1:
                        nome = Console.ReadLine();
                        arvorebinaria.Inserir(nome);
                        break;
                    case 2:
                        nome = Console.ReadLine();
                        arvorebinaria.Remover(nome);
                        break;
                    case 3:
                        nome = Console.ReadLine();
                        if (arvorebinaria.Pesquisar(nome) == false)
                        {
                            Console.WriteLine("Elemento nao encontrado");
                        }
                        else
                        {
                            Console.WriteLine("Elemento consta na arvore");
                        }
                        break;
                    case 4:
                        arvorebinaria.CaminharCentral();
                        Console.WriteLine();
                        break;
                    case 5:
                        arvorebinaria.CaminharPos();
                        Console.WriteLine();
                        break;
                    case 6:
                        arvorebinaria.CaminharPre();
                        Console.WriteLine();
                        break;
                    default:
                        break;
                }

            } while (opcao != 7);
        }
    }
}
