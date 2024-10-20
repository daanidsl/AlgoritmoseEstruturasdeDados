using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q_03
{
    class Arquivo
    {
        private string nome;
        private int numpag;
        public Arquivo(string nome, int numpag)
        {
            this.nome = nome;
            this.numpag = numpag;
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public int NumPag
        {
            get { return numpag; }
            set { numpag = value; }
        }
        public override String ToString()
        {
            return "nome: " + nome + ", numero paginas: " + numpag;
        }
    }
    class Fila
    {
        private Celula primeiro, ultimo;
        public Fila()
        {
            primeiro = new Celula();
            ultimo = primeiro;
        }
        public void Inserir(Arquivo arq)
        {
            ultimo.Prox = new Celula(arq);
            ultimo = ultimo.Prox;
        }
        public Arquivo Remover()
        {
            if (primeiro == ultimo)
            {
                throw new Exception("Erro!");
            }
            Celula tmp = primeiro;
            primeiro = primeiro.Prox;
            Arquivo elemento = primeiro.Elemento;
            tmp.Prox = null;
            tmp = null;
            return elemento;
        }
        public void Mostrar()
        {
            for (Celula i = primeiro.Prox; i != null; i = i.Prox)
            {
                Console.WriteLine(i.Elemento.ToString());
            }
        }
    }
    class Celula
    {
        private Arquivo elemento;
        private Celula prox;
        public Celula(Arquivo elemento)
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
        public Arquivo Elemento
        {
            get { return elemento; }
            set { elemento = value; }
        }
    }
    
    class Teste
    {
        static void Main(string[] args)
        {
            Fila fila = new Fila();
            int opcao;
            do
            {
                Console.Write("1. Inserir arquivo na fila de impressao\n2. Executar impressao\n3. Exibir fila de impressao\n4. Sair\n");
                opcao = int.Parse(Console.ReadLine());

                string nome; int quant;

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Digite o nome do arquivo:");
                        nome = Console.ReadLine();
                        Console.WriteLine("Digite a quantidade de paginas:");
                        quant = int.Parse(Console.ReadLine());
                        Arquivo arquivo = new Arquivo(nome, quant);
                        fila.Inserir(arquivo);
                        break;
                    case 2:
                        fila.Remover();
                        break;
                    case 3:
                        fila.Mostrar();
                        break;
                    case 4:
                        Console.WriteLine("O programa sera encerrado.");
                        break;
                    default:
                        break;
                }

            } while (opcao != 4);
        }
    }
}
