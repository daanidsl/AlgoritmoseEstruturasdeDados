using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q_05
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
        private Arquivo[] array;
        private int primeiro;
        private int ultimo;
        public Fila(int tamanho)
        {
            array = new Arquivo[tamanho + 1];
            primeiro = ultimo = 0;
        }
        public void InserirArq(Arquivo arq)
        {
            if (((ultimo + 1) % array.Length) == primeiro)
            {
                throw new Exception("Erro");
            }
            array[ultimo] = arq;
            ultimo = (ultimo + 1) % array.Length;
        }
        public Arquivo ExecutarImpressao()
        {
            if (primeiro == ultimo)
            {
                throw new Exception("Erro");
            }
            Arquivo resp = array[primeiro];
            primeiro = (primeiro + 1) % array.Length;
            return resp;
        }
        public void ExibirFila()
        {
            int i = primeiro;
            while (i != ultimo)
            {
                Console.WriteLine(array[i].ToString());
                i = (i + 1) % array.Length;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Fila fila = new Fila(100);
            int opcao;
            do
            {
                Console.Write("1. Inserir arquivo na fila de impressao\n2. Executar impressao\n3. Exibir fila de impressao\n4. Sair\n");
                opcao = int.Parse(Console.ReadLine());
                string nomearq; int quant;

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Digite o nome do arquivo:");
                        nomearq = Console.ReadLine();
                        Console.WriteLine("Digite a quantidade de paginas:");
                        quant = int.Parse(Console.ReadLine());
                        Arquivo arquivo = new Arquivo(nomearq, quant);
                        fila.InserirArq(arquivo);
                        break;
                    case 2:
                        fila.ExecutarImpressao();
                        break;
                    case 3:
                        fila.ExibirFila();
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