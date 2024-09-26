using System;

namespace Q_07
{
    class Estacionamento
    {
        private string nome;
        private int numVagasLivres;
        private string[] vagas;

        public Estacionamento(string nome, int numTotalVagas)
        {
            this.nome = nome;
            numVagasLivres = numTotalVagas;
            vagas = new string[numTotalVagas];
        }

        public int Estacionar(string placa)
        {
            if (numVagasLivres != 0)
            {
                for (int i = 0; i < vagas.Length; i++)
                {
                    if (vagas[i] == null)
                    {
                        vagas[i] = placa;
                        numVagasLivres--;
                        return i;
                    }
                }
            }
            return -1;
        }

        public int BuscarNumVaga(string placa)
        {
            for (int i = 0; i < vagas.Length; i++)
            {
                if (vagas[i] == placa)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Retirar(string placa)
        {
            for (int i = 0; i < vagas.Length; i++)
            {
                if (vagas[i] == placa)
                {
                    vagas[i] = null;
                    numVagasLivres++;
                    return;
                }
            }
        }

        public int NumVagasLivres
        {
            get { return this.numVagasLivres; }
        }

        public void ExibirOcupacao()
        {
            for (int i = 0; i < vagas.Length; i++)
            {
                if (vagas[i] == null)
                {
                    Console.WriteLine("Vaga " + i + " está vazia");
                }
                else
                {
                    Console.WriteLine("Vaga " + i + " - placa: " + vagas[i]);
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Estacionamento estacionamento = new Estacionamento("Estacionamento", 30);
            estacionamento.Estacionar("A123");
            estacionamento.Estacionar("B687");
            estacionamento.Estacionar("C910");
            estacionamento.Estacionar("D031");
            estacionamento.Estacionar("E381");

            estacionamento.ExibirOcupacao();
            Console.WriteLine("Vaga da placa A123: " + estacionamento.BuscarNumVaga("A123"));
            estacionamento.Retirar("C910");
            estacionamento.ExibirOcupacao();

            estacionamento.Estacionar("F456");
            estacionamento.Estacionar("G789");
            estacionamento.Estacionar("H012");
            estacionamento.ExibirOcupacao();
            Console.WriteLine("Quantidade de vagas livres: " + estacionamento.NumVagasLivres);
            Console.ReadLine();
        }
    }
}
