using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q_02
{
    class Produto
    {
        private string nome;
        private int quant;
        private double preco;
        
        public Produto(string nome, int quant, double preco)
        {
            this.nome = nome;
            this.quant = quant;
            this.preco = preco;
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public int Quantidade
        {
            get { return quant; }
            set { quant = value; }
        }

        public double Preco
        {
            get { return preco; }
            set { preco = value; }
        }
        public override String ToString()
        {
            return "[nome: " + nome + ", quantidade: " + quant + ", preco: " + preco + "]";
        }
    }
    class Lista
    {
        private Produto[] array;
        private int n;
        public Lista(int tamanho)
        {
            array = new Produto[tamanho];
            n = 0;
        }
        public void InserirFim(Produto produto)
        {
            if (n >= array.Length)
            {
                throw new Exception("Erro!");
            }

            array[n] = produto;
            n++;
        }
        public Produto RemoverItem(string nome)
        {
            if (n == 0)
            {
                throw new Exception("Erro!");
            }

            Produto resp = null; int pos = 0;

            for (int i = 0; i < n; i++)
            {
                if (array[i].Nome == nome)
                {
                    pos = i;
                }
            }

            resp = array[pos];

            for (int i = pos; i < n - 1; i++)
            {
                array[i] = array[i + 1];
            }

            n--;
            return resp;
        }
        public void Listar()
        {
            Console.WriteLine("Lista de Produtos:");
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine(array[i].ToString());
            }

        }
        public bool Pesquisar(string nome)
        {
            bool cadastrado = false;

            for (int i = 0; i < n; i++)
            {
                if (array[i].Nome == nome)
                {
                    cadastrado = true;
                }
            }

            return cadastrado;
        }
    }
    class Teste
    {
        static void Main(string[] args)
        {
            Lista lista = new Lista(100);
            int opcao;
            do
            {
                Console.Write("1) Inserir um produto no final da lista.\n2) Remover um produto especifico da lista.\n3) Listar os dados de todos os produtos da lista.\n4) Pesquisar se um produto ja consta na lista.\n5) Sair\n");
                opcao = int.Parse(Console.ReadLine());
                string nomeproduto; int quant; double preco;

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Digite o nome do produto:");
                        nomeproduto = Console.ReadLine();
                        Console.WriteLine("Digite a quantidade:");
                        quant = int.Parse(Console.ReadLine());
                        Console.WriteLine("Digite o preco:");
                        preco = double.Parse(Console.ReadLine());
                        Produto produto = new Produto(nomeproduto, quant, preco);
                        lista.InserirFim(produto);
                        break;
                    case 2:
                        Console.WriteLine("Digite o nome do produto a remover:");
                        nomeproduto = Console.ReadLine();
                        lista.RemoverItem(nomeproduto);
                        break;
                    case 3:
                        lista.Listar();
                        break;
                    case 4:
                        Console.WriteLine("Digite o nome que deseja pesquisar:");
                        nomeproduto = Console.ReadLine();
                        if (lista.Pesquisar(nomeproduto) == true)
                        {
                            Console.WriteLine("Produto Cadastrado.");
                        }
                        else
                        {
                            Console.WriteLine("Produto não Cadastrado.");
                        }
                        break;
                    case 5:
                        Console.WriteLine("O programa sera encerrado.");
                        break;
                    default:
                        break;
                } 
            } while (opcao != 5);
        }
    }
}
