using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q_04
{
    class Celula
    {
        private string elemento;
        private Celula prox;
        public Celula(string elemento)
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
        public string Elemento
        {
            get { return elemento; }
            set { elemento = value; }
        }
    }
    class FilaIC
    {
        private Celula primeiro, ultimo;
        public FilaIC()
        {
            primeiro = new Celula();
            ultimo = primeiro;
        }
        public void Inserir(string x)
        {
            ultimo.Prox = new Celula(x);
            ultimo = ultimo.Prox;
        }
        public string Remover()
        {
            if (primeiro == ultimo)
            {
                throw new Exception("Erro!");
            }
            Celula tmp = primeiro;
            primeiro = primeiro.Prox;
            string elemento = primeiro.Elemento;
            tmp.Prox = null;
            tmp = null;
            return elemento;
        }
        public void Mostrar()
        {
            Console.WriteLine("Fila de Espera IC:");
            for (Celula i = primeiro.Prox; i != null; i = i.Prox)
            {
                Console.WriteLine(i.Elemento);
            }
        }
        public bool Pesquisar(string nome)
        {
            bool estanafila = false;
            for (Celula i = primeiro.Prox; i != null; i = i.Prox)
            {
                if (i.Elemento == nome)
                {
                    estanafila = true;
                }
            }
            return estanafila;
        }
    }
    class FilaMestrado
    {
        private Celula primeiro, ultimo;
        public FilaMestrado()
        {
            primeiro = new Celula();
            ultimo = primeiro;
        }
        public void Inserir(string x)
        {
            ultimo.Prox = new Celula(x);
            ultimo = ultimo.Prox;
        }
        public string Remover()
        {
            if (primeiro == ultimo)
            {
                throw new Exception("Erro!");
            }
            Celula tmp = primeiro;
            primeiro = primeiro.Prox;
            string elemento = primeiro.Elemento;
            tmp.Prox = null;
            tmp = null;
            return elemento;
        }
        public void Mostrar()
        {
            Console.WriteLine("Fila de Espera Mestrado:");
            for(Celula i = primeiro.Prox; i != null; i = i.Prox)
            {
                Console.WriteLine(i.Elemento);
            }
        }
        public bool Pesquisar(string nome)
        {
            bool estanafila = false;
            for (Celula i = primeiro.Prox; i != null; i = i.Prox)
            {
                if(i.Elemento == nome)
                {
                    estanafila = true;
                }
            }
            return estanafila;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            FilaIC filaIC = new FilaIC();
            FilaMestrado filaMestrado = new FilaMestrado();
            int opcao;
            do
            {
                Console.Write("Menu:\n1. Inserir um aluno na fila de espera de bolsas de IC\n2. Inserir um aluno na fila de espera de bolsas de Mestrado\n3. Remover um aluno da fila de bolsas de IC\n4. Remover um aluno da fila de bolsas de Mestrado\n5. Mostrar fila de espera de bolsas de IC\n6. Mostrar fila de espera de bolsas de Mestrado\n7. Pesquisar aluno na fila de espera de bolsas de IC\n8. Pesquisar aluno na fila de espera de bolsas de Mestrado\n9. Sair\n");
                opcao = int.Parse(Console.ReadLine());
                string nome;

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Informe o nome do aluno:");
                        nome = Console.ReadLine();
                        filaIC.Inserir(nome);
                        break;
                    case 2:
                        Console.WriteLine("Informe o nome do aluno:");
                        nome = Console.ReadLine();
                        filaMestrado.Inserir(nome);
                        break;
                    case 3:
                        Console.WriteLine("Aluno removido: " + filaIC.Remover());
                        break;
                    case 4:
                        Console.WriteLine("Aluno removido: " + filaMestrado.Remover());
                        break;
                    case 5:
                        filaIC.Mostrar();
                        break;
                    case 6:
                        filaMestrado.Mostrar();
                        break;
                    case 7:
                        Console.WriteLine("Informe o nome do aluno:");
                        nome = Console.ReadLine();
                        if(filaIC.Pesquisar(nome) == true)
                        {
                            Console.WriteLine("Aluno ja consta na fila de IC");
                        }
                        else
                        {
                            Console.WriteLine("Aluno nao consta na fila de IC");
                        }
                        break;
                    case 8:
                        Console.WriteLine("Informe o nome do aluno:");
                        nome = Console.ReadLine();
                        if (filaMestrado.Pesquisar(nome) == true)
                        {
                            Console.WriteLine("Aluno ja consta na fila de Mestrado");
                        }
                        else
                        {
                            Console.WriteLine("Aluno nao consta na fila de Mestrado");
                        }
                        break;
                    case 9:
                        Console.WriteLine("O programa sera encerrado");
                        break;
                    default:
                        break;
                }

            } while (opcao != 9);
        }
    }
}
