using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q_06
{
    class Site
    {
        private string nome;
        private string link;
        public Site(string nome, string link)
        {
            this.nome = nome;
            this.link = link;
        }
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public string Link
        {
            get { return link; }
            set { link = value; }
        }
    }
    class Celula
    {
        private Site elemento;
        private Celula prox;
        public Celula(Site elemento)
        {
            this.elemento = elemento;
            this.prox = null;
        }
        public Celula()
        {
            this.elemento = null;
            this.prox = null;
        }
        public Celula Prox
        {
            get { return prox; }
            set { prox = value; }
        }
        public Site Elemento
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
            for (Celula i = primeiro; i != ultimo; i = i.Prox)
            {
                tam++;
            }
            return tam;
        }
        public void InserirInicio(Site x)
        {
            Celula tmp = new Celula(x);
            tmp.Prox = primeiro.Prox;
            primeiro.Prox = tmp;
            if (primeiro == ultimo)
            {
                ultimo = tmp;
            }
            tmp = null;
        }
        public void InserirFim(Site x)
        {
            ultimo.Prox = new Celula(x);
            ultimo = ultimo.Prox;
        }
        public void Inserir(Site x, int pos)
        {
            int tamanho = Tamanho();
            if (pos < 0 || pos > tamanho)
            {
                throw new Exception("Erro");
            }
            else if (pos == 0)
            {
                InserirInicio(x);
            }
            else if (pos == tamanho)
            {
                InserirFim(x);
            }
            else
            {
                Celula i = primeiro;
                for (int j = 0; j < pos; j++)
                {
                    i = i.Prox;
                }
                Celula tmp = new Celula(x);
                tmp.Prox = i.Prox;
                i.Prox = tmp;
            }
        }
        public string RemoverInicio()
        {
            if (primeiro == ultimo)
            {
                throw new Exception("Erro");
            }
            Celula tmp = primeiro;
            primeiro = primeiro.Prox;
            Site elemento = primeiro.Elemento;
            tmp.Prox = null;
            tmp = null;
            return elemento.Nome;
        }
        public string RemoverFim()
        {
            if (primeiro == ultimo)
            {
                throw new Exception("Erro");
            }
            Celula i;
            for (i = primeiro; i.Prox != ultimo; i = i.Prox) ;
            Site elemento = ultimo.Elemento;
            ultimo = i;
            i = ultimo.Prox = null;
            return elemento.Nome;
        }
        public string Remover(int pos)
        {
            string elemento; int tamanho = Tamanho();
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
                elemento = tmp.Elemento.Nome;
                i.Prox = tmp.Prox;
                tmp.Prox = null; i = tmp = null;
            }
            return elemento;
        }
        public void Mostrar()
        {
            for (Celula i = primeiro.Prox; i != null; i = i.Prox)
            {
                Console.WriteLine(i.Elemento.Nome + ": " + i.Elemento.Link);
            }
        }
        public string PesquisarLink(string nome)
        {
            string link = null;
            for (Celula i = primeiro.Prox; i != null; i = i.Prox)
            {
                if (i.Elemento.Nome == nome)
                {
                    link = i.Elemento.Link;
                }
            }
            return link;
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
                Console.Write("Menu:\n1) Inserir um Site no inicio da lista\n2) Inserir um Site no final da lista\n3) Inserir um Site numa posicao especifica da lista\n4) Remover o primeiro Site da lista\n5) Remover o ultimo Site da lista\n6) Remover um Site de uma posicao especifica da lista\n7) Mostrar o nome e o link de todos os sites da lista\n8) Pesquisar o link de um site\n9) Encerrar o programa\n");
                opcao = int.Parse(Console.ReadLine());
                string nome, link;
                int pos;

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Informe o nome do site:");
                        nome = Console.ReadLine();
                        Console.WriteLine("Informe o link do site:");
                        link = Console.ReadLine();
                        Site sitei = new Site(nome, link);
                        lista.InserirInicio(sitei);
                        break;
                    case 2:
                        Console.WriteLine("Informe o nome do site:");
                        nome = Console.ReadLine();
                        Console.WriteLine("Informe o link do site:");
                        link = Console.ReadLine();
                        Site sitef = new Site(nome, link);
                        lista.InserirFim(sitef);
                        break;
                    case 3:
                        Console.WriteLine("Informe o nome do site:");
                        nome = Console.ReadLine();
                        Console.WriteLine("Informe o link do site:");
                        link = Console.ReadLine();
                        Console.WriteLine("Informe a posicao:");
                        pos = int.Parse(Console.ReadLine());
                        Site sitep = new Site(nome, link);
                        lista.Inserir(sitep, pos);
                        break;
                    case 4:
                        Console.WriteLine("Site removido: " + lista.RemoverInicio());
                        break;
                    case 5:
                        Console.WriteLine("Site removido: " + lista.RemoverFim());
                        break;
                    case 6:
                        Console.WriteLine("Informe a posicao:");
                        pos = int.Parse(Console.ReadLine());
                        Console.WriteLine("Site removido: " + lista.Remover(pos));
                        break;
                    case 7:
                        lista.Mostrar();
                        break;
                    case 8:
                        Console.WriteLine("Informe o nome do site:");
                        nome = Console.ReadLine();
                        Console.WriteLine("Link: " + lista.PesquisarLink(nome));
                        break;
                    case 9:
                        Console.WriteLine("O programa sera encerrado.");
                        break;
                    default:
                        break;
                }

            } while (opcao != 9);
        }
    }
}
