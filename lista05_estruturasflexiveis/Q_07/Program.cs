using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q_07
{
    class CelulaDupla
    {
        private string elemento;
        private CelulaDupla prox;
        private CelulaDupla ant;
        public CelulaDupla(string elemento)
        {
            this.elemento = elemento;
            this.ant = null;
            this.prox = null;
        }
        public CelulaDupla()
        {
            this.elemento = null;
            this.ant = null;
            this.prox = null;
        }
        public CelulaDupla Prox
        {
            get { return prox; }
            set { prox = value; }
        }
        public CelulaDupla Ant
        {
            get { return ant; }
            set { ant = value; }
        }
        public string Elemento
        {
            get { return elemento; }
            set { elemento = value; }
        }
    }
    class ListaDupla
    {
        private CelulaDupla primeiro, ultimo;
        public ListaDupla()
        {
            primeiro = new CelulaDupla();
            ultimo = primeiro;
        }
        public int Tamanho()
        {
            int tamanho = 0;
            for (CelulaDupla i = primeiro; i != ultimo; i = i.Prox)
            {
                tamanho++;
            }
            return tamanho;
        }
        public void InserirInicio(string x)
        {
            CelulaDupla tmp = new CelulaDupla(x);
            tmp.Ant = primeiro;
            tmp.Prox = primeiro.Prox;
            primeiro.Prox = tmp;
            if (primeiro == ultimo)
            {
                ultimo = tmp;
            }
            else
            {
                tmp.Prox.Ant = tmp;
            }
            tmp = null;
        }
        public void InserirFim(string x)
        {
            ultimo.Prox = new CelulaDupla(x);
            ultimo.Prox.Ant = ultimo;
            ultimo = ultimo.Prox;
        }
        public void Inserir(string x, int pos)
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
                CelulaDupla i = primeiro;
                for (int j = 0; j < pos; j++, i = i.Prox) ;
                CelulaDupla tmp = new CelulaDupla(x);
                tmp.Ant = i;
                tmp.Prox = i.Prox;
                tmp.Ant.Prox = tmp.Prox.Ant = tmp;
                tmp = i = null;
            }
        }
        public string RemoverInicio()
        {
            if (primeiro == ultimo)
            {
                throw new Exception("Erro");
            }
            CelulaDupla tmp = primeiro;
            primeiro = primeiro.Prox;
            string elemento = primeiro.Elemento;
            tmp.Prox = primeiro.Ant = null;
            tmp = null;
            return elemento;
        }
        public string RemoverFim()
        {
            if (primeiro == ultimo)
            {
                throw new Exception("Erro");
            }
            string elemento = ultimo.Elemento;
            ultimo = ultimo.Ant;
            ultimo.Prox.Ant = null;
            ultimo.Prox = null;
            return elemento;
        }
        public string RemoverPosicao(int pos)
        {
            string elemento; int tamanho = Tamanho();
            if (primeiro == ultimo)
            {
                throw new Exception("Erro");
            }
            else if (pos < 0 || pos >= tamanho)
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
                CelulaDupla i = primeiro.Prox;
                for (int j = 0; j < pos; j++, i = i.Prox) ;
                i.Ant.Prox = i.Prox;
                i.Prox.Ant = i.Ant;
                elemento = i.Elemento;
                i.Prox = i.Ant = null;
                i = null;
            }
            return elemento;

        }
        public bool Remover(string x)
        {
            bool removeu = false;

            if (primeiro == ultimo)
            {
                removeu = false;
            }

            int pos = 0;

            for (CelulaDupla i = primeiro.Prox; i != null; i = i.Prox)
            {
                if (i.Elemento == x)
                {
                    if(i == primeiro.Prox)
                    {
                        RemoverInicio();
                    }
                    else if(i == ultimo)
                    {
                        RemoverFim();
                    }
                    else
                    {
                        RemoverPosicao(pos);
                    }
                    removeu = true;
                }
                pos++;
            }
            return removeu;
        }
        public void Mostrar()
        {
            Console.WriteLine("Lista:");
            for (CelulaDupla i = primeiro.Prox; i != null; i = i.Prox)
            {
                Console.WriteLine(i.Elemento);
            }
        }
        public void MostrarInverso()
        {
            Console.WriteLine("Lista - ordem inversa:");
            for (CelulaDupla i = ultimo; i != primeiro; i = i.Ant)
            {
                Console.WriteLine(i.Elemento);
            }
        }
        public bool Pesquisar(string x)
        {
            bool estanalista = false;
            for (CelulaDupla i = primeiro.Prox; i != null; i = i.Prox)
            {
                if (i.Elemento == x)
                {
                    estanalista = true;
                }
            }
            return estanalista;
        }
        public string PesquisarAnterior(string x)
        {
            string musicaanterior = null;
            for (CelulaDupla i = primeiro.Prox; i != null; i = i.Prox)
            {
                if (i.Elemento == x)
                {
                    musicaanterior = i.Ant.Elemento;
                }
            }
            return musicaanterior;
        }
        public string PesquisarPosterior(string x)
        {
            string musicaposterior = null;
            for (CelulaDupla i = primeiro.Prox; i != null; i = i.Prox)
            {
                if (i.Elemento == x)
                {
                    if(i.Prox != null)
                    {
                        musicaposterior = i.Prox.Elemento;
                    }
                }
            }
            return musicaposterior;
        }
    }

    class GerenciadorMusica
    {
        static void Main(string[] args)
        {
            ListaDupla listadupla = new ListaDupla();
            int opcao;

            do
            {
                Console.Write("Menu:\n1) Inserir uma musica no final da lista\n2) Inserir uma musica no inicio da lista\n3) Inserir uma musica numa posicao especifica da lista\n4) Remover a musica do inicio da lista\n5) Remover a musica do final da lista\n6) Remover uma musica de uma posicao especifica da lista\n7) Remover uma musica especifica\n8) Listar todas as musicas da lista\n9) Listar todas as musicas da lista na ordem inversa\n10) Pesquisar uma musica na lista\n11) Pesquisar musica anterior\n12) Pesquisar musica posterior\n13) Encerrar o programa\n");
                opcao = int.Parse(Console.ReadLine());

                string musica; int pos;

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Informe a musica");
                        musica = Console.ReadLine();
                        listadupla.InserirFim(musica);
                        break;
                    case 2:
                        Console.WriteLine("Informe a musica");
                        musica = Console.ReadLine();
                        listadupla.InserirInicio(musica);
                        break;
                    case 3:
                        Console.WriteLine("Informe a musica");
                        musica = Console.ReadLine();
                        Console.WriteLine("Informe a posicao");
                        pos = int.Parse(Console.ReadLine());
                        listadupla.Inserir(musica, pos);
                        break;
                    case 4:
                        Console.WriteLine("Musica removida: " + listadupla.RemoverInicio());
                        break;
                    case 5:
                        Console.WriteLine("Musica removida: " + listadupla.RemoverFim());
                        break;
                    case 6:
                        Console.WriteLine("Informe a posicao");
                        pos = int.Parse(Console.ReadLine());
                        Console.WriteLine("Musica removida: " + listadupla.RemoverPosicao(pos));
                        break;
                    case 7:
                        Console.WriteLine("Informe a musica");
                        musica = Console.ReadLine();
                        if(listadupla.Remover(musica) == true)
                        {
                            Console.WriteLine("Musica removida");
                        }
                        else
                        {
                            Console.WriteLine("Musica nao consta na lista");
                        }
                        break;
                    case 8:
                        listadupla.Mostrar();
                        break;
                    case 9:
                        listadupla.MostrarInverso();
                        break;
                    case 10:
                        Console.WriteLine("Informe a musica");
                        musica = Console.ReadLine();
                        if (listadupla.Pesquisar(musica) == true)
                        {
                            Console.WriteLine("A musica esta na lista");
                        }
                        else
                        {
                            Console.WriteLine("A musica nao consta na lista");
                        }
                        break;
                    case 11:
                        Console.WriteLine("Informe a musica");
                        musica = Console.ReadLine();
                        if (listadupla.PesquisarAnterior(musica) != null)
                        {
                            Console.WriteLine("Musica anterior: " + listadupla.PesquisarAnterior(musica));
                        }
                        else
                        {
                            Console.WriteLine("Nao ha musica anterior");
                        }
                        break;
                    case 12:
                        Console.WriteLine("Informe a musica");
                        musica = Console.ReadLine();
                        if (listadupla.PesquisarPosterior(musica) != null)
                        {
                            Console.WriteLine("Musica posterior: " + listadupla.PesquisarPosterior(musica));
                        }
                        else
                        {
                            Console.WriteLine("Nao ha musica posterior");
                        }
                        break;
                    case 13:
                        Console.WriteLine("O programa sera encerrado.");
                        break;
                    default:
                        break;
                }

            } while (opcao != 13);
        }
    }
}
