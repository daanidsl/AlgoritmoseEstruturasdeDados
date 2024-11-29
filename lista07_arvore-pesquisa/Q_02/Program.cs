using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q_02
{
    class No
    {
        private int elemento;
        private No esq, dir;
        public No(int elemento)
        {
            this.elemento = elemento;
            esq = null;
            dir = null;
        }
        public No(int elemento, No esq, No dir)
        {
            this.elemento = elemento;
            this.esq = esq;
            this.dir = dir;
        }
        public int Elemento
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
        public void Inserir(int x)
        {
            raiz = Inserir(x, raiz);
        }
        private No Inserir(int x, No i)
        {
            if(i == null)
            {
                i = new No(x);
            }
            else if(x < i.Elemento)
            {
                i.Esq = Inserir(x, i.Esq);
            }
            else if(x > i.Elemento)
            {
                i.Dir = Inserir(x, i.Dir);
            }
            else
            {
                throw new Exception("Erro");
            }
            return i;
        }
        public void Remover(int x)
        {
            raiz = Remover(x, raiz);
        }
        private No Remover(int x, No i)
        {
            if(i == null)
            {
                throw new Exception("Erro");
            }
            else if(x < i.Elemento)
            {
                i.Esq = Remover(x, i.Esq);
            }
            else if(x > i.Elemento)
            {
                i.Dir = Remover(x, i.Dir);
            }
            else if(i.Dir == null)
            {
                i = i.Esq;
            }
            else if(i.Esq == null)
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
        public bool Pesquisar(int x)
        {
            return Pesquisar(x, raiz);
        }
        private bool Pesquisar(int x, No i)
        {
            bool resp;
            if(i == null)
            {
                resp = false;
            }
            else if(x == i.Elemento)
            {
                resp = true;
            }
            else if(x < i.Elemento)
            {
                resp = Pesquisar(x, i.Esq);
            }
            else
            {
                resp = Pesquisar(x, i.Dir);
            }
            return resp;
        }
        public int GetMaior()
        {
            if (raiz == null)
            {
                throw new Exception("Erro");
            }

            No i;
            for (i = raiz; i.Dir != null; i = i.Dir) ;
            return i.Elemento;
        }
        public int GetMenor()
        {
            if (raiz == null)
            {
                throw new Exception("Erro");
            }
            No i;
            for (i = raiz; i.Esq != null; i = i.Esq) ;
            return i.Elemento;
        }
        public void CaminharCentral()
        {
            CaminharCentral(raiz);
        }
        private void CaminharCentral(No i)
        {
            if(i != null)
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
            if(i != null)
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
                Console.Write("1.Inserir\n2.Remover\n3.Pesquisar\n4.Mostrar o maior elemento\n5.Mostrar o menor elemento\n6.Caminhamento central\n7.Caminhamento pos-ordem\n8.Caminhamento pre-ordem\r\n9.Sair\n");
                opcao = int.Parse(Console.ReadLine());
                int num;

                switch (opcao)
                {
                    case 1:
                        num = int.Parse(Console.ReadLine());
                        arvorebinaria.Inserir(num);
                        break;
                    case 2:
                        num = int.Parse(Console.ReadLine());
                        arvorebinaria.Remover(num);
                        break;
                    case 3:
                        num = int.Parse(Console.ReadLine());
                        if(arvorebinaria.Pesquisar(num) == false)
                        {
                            Console.WriteLine("Elemento nao encontrado");
                        }
                        else
                        {
                            Console.WriteLine("Elemento consta na arvore");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Maior:" + arvorebinaria.GetMaior());
                        break;
                    case 5:
                        Console.WriteLine("Menor:" + arvorebinaria.GetMenor());
                        break;
                    case 6:
                        arvorebinaria.CaminharCentral();
                        Console.WriteLine();
                        break;
                    case 7:
                        arvorebinaria.CaminharPos();
                        Console.WriteLine();
                        break;
                    case 8:
                        arvorebinaria.CaminharPre();
                        Console.WriteLine();
                        break;
                    default:
                        break;
                }

            } while (opcao != 9);
        }
    }
}
