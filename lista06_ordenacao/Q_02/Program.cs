using System;
using System.IO;
using System.Text;

namespace Q_02
{
    class Jogador
    {
        private string nome, universidade, cidadeNasc, estadoNasc;
        private int id, altura, peso, anoNasc;
        public Jogador(string nome, string universidade, string cidadeNasc, string estadoNasc, int id, int altura, int peso, int anoNasc)
        {
            this.nome = nome;
            this.universidade = universidade;
            this.cidadeNasc = cidadeNasc;
            this.estadoNasc = estadoNasc;
            this.id = id;
            this.altura = altura;
            this.peso = peso;
            this.anoNasc = anoNasc;
        }
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public string Universidade
        {
            get { return universidade; }
            set { universidade = value; }
        }
        public string CidadeNasc
        {
            get { return cidadeNasc; }
            set { cidadeNasc = value; }
        }
        public string EstadoNasc
        {
            get { return estadoNasc; }
            set { estadoNasc = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int Altura
        {
            get { return altura; }
            set { altura = value; }
        }
        public int Peso
        {
            get { return peso; }
            set { peso = value; }
        }
        public int AnoNasc
        {   get { return anoNasc; }
            set { anoNasc = value; }
        }

        public override string ToString()
        {
            return $"{id},{nome},{altura},{peso},{universidade},{anoNasc},{cidadeNasc},{estadoNasc}";
        }
    }

    class Program
    {
        static int Linhas(StreamReader arq)
        {
            int cont = 0;
            string linha;
            while ((linha = arq.ReadLine()) != null)
            {
                cont++;
            }
            return cont;
        }

        static void Dados(int num, StreamReader arq, Jogador[] jogadores)
        {
            string nome, universidade, cidadeNasc, estadoNasc;
            int id, altura, peso, anoNasc;

            arq.ReadLine();
            for (int i = 0; i < num; i++)
            {
                string linha = arq.ReadLine();
                string[] partes = linha.Split(',');

                if (partes.Length == 8)
                {
                    id = int.Parse(partes[0]);
                    nome = partes[1];
                    altura = int.Parse(partes[2]);
                    peso = int.Parse(partes[3]);
                    universidade = partes[4];
                    anoNasc = int.Parse(partes[5]);
                    cidadeNasc = partes[6];
                    estadoNasc = partes[7];

                    jogadores[i] = new Jogador(nome, universidade, cidadeNasc, estadoNasc, id, altura, peso, anoNasc);
                }
            }
        }

        static void Main(string[] args)
        {
            try
            {
                StreamReader arq = new StreamReader("players.csv", Encoding.UTF8);
                int num = Linhas(arq) - 1; 
                arq.Close();

                Jogador[] jogadores = new Jogador[num];
                arq = new StreamReader("players.csv", Encoding.UTF8);
                Dados(num, arq, jogadores);

                Mergesort(jogadores, 0, jogadores.Length - 1);

                foreach (var jogador in jogadores)
                {
                    Console.WriteLine(jogador);
                }

                arq.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exceção: " + e.Message);
            }
        }

        static void Mergesort(Jogador[] vet, int esq, int dir)
        {
            if (esq < dir)
            {
                int meio = (esq + dir) / 2;
                Mergesort(vet, esq, meio);
                Mergesort(vet, meio + 1, dir);
                Intercalar(vet, esq, meio, dir);
            }
        }

        static void Intercalar(Jogador[] vet, int esq, int meio, int dir)
        {
            int nEsq = meio - esq + 1;
            int nDir = dir - meio;

            Jogador[] vetEsq = new Jogador[nEsq];
            Jogador[] vetDir = new Jogador[nDir];

            for (int i = 0; i < nEsq; i++)
            {
                vetEsq[i] = vet[esq + i];
            }

            for (int i = 0; i < nDir; i++)
            {
                vetDir[i] = vet[meio + 1 + i];
            }

            int iEsq = 0, iDir = 0, k = esq;

            while (iEsq < nEsq && iDir < nDir)
            {
                if (vetEsq[iEsq].AnoNasc < vetDir[iDir].AnoNasc ||
                    (vetEsq[iEsq].AnoNasc == vetDir[iDir].AnoNasc && vetEsq[iEsq].Nome.CompareTo(vetDir[iDir].Nome) < 0))
                {
                    vet[k++] = vetEsq[iEsq++];
                }
                else
                {
                    vet[k++] = vetDir[iDir++];
                }
            }

            while (iEsq < nEsq)
            {
                vet[k++] = vetEsq[iEsq++];
            }

            while (iDir < nDir)
            {
                vet[k++] = vetDir[iDir++];
            }
        }
    }
}