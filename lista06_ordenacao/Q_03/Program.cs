using System;
using System.IO;
using System.Net.NetworkInformation;
using System.Text;

namespace Q_03
{
    class ClassificacaoOlimpiadas
    {
        private string nomePais;
        private int medalhaOuro, medalhaPrata, medalhaBronze, totalMedalhas;
        public ClassificacaoOlimpiadas(string nomePais, int medalhaOuro, int medalhaPrata, int medalhaBronze, int totalMedalhas)
        {
            this.nomePais = nomePais;
            this.medalhaOuro = medalhaOuro;
            this.medalhaPrata = medalhaPrata;
            this.medalhaBronze = medalhaBronze;
            this.totalMedalhas = totalMedalhas;
        }
        public string NomePais
        {
            get { return nomePais; }
            set { nomePais = value; }
        }
        public int MedalhaOuro
        {
            get { return medalhaOuro; }
            set { medalhaOuro = value; }
        }
        public int MedalhaPrata
        {
            get { return medalhaPrata; }
            set { medalhaPrata = value; }
        }
        public int MedalhaBronze
        {
            get { return medalhaBronze; }
            set { medalhaBronze = value; }
        }
        public int TotalMedalhas
        {
            get { return totalMedalhas; }
            set { totalMedalhas = value; }
        }
        public override string ToString()
        {
            return $"{nomePais}, {medalhaOuro}, {medalhaPrata}, {medalhaBronze}, {totalMedalhas}";
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
            return cont / 10;
        }
        static void Main(string[] args)
        {
            try
            {
                StreamReader arq = new StreamReader("olimpiadas.txt", Encoding.UTF8);
                int num = Linhas(arq); 
                arq.Close();

                ClassificacaoOlimpiadas[] classificacao = new ClassificacaoOlimpiadas[num];
                arq = new StreamReader("olimpiadas.txt", Encoding.UTF8);

                for (int i = 0; i < num; i++)
                {
                    string nomePais = arq.ReadLine();
                    arq.ReadLine();
                    int medalhaOuro = int.Parse(arq.ReadLine());
                    arq.ReadLine();
                    int medalhaPrata = int.Parse(arq.ReadLine());
                    arq.ReadLine();
                    int medalhaBronze = int.Parse(arq.ReadLine());
                    arq.ReadLine();
                    int totalMedalhas = int.Parse(arq.ReadLine());
                    arq.ReadLine();

                    classificacao[i] = new ClassificacaoOlimpiadas(nomePais, medalhaOuro, medalhaPrata, medalhaBronze, totalMedalhas);
                }

                arq.Close();

                Mergesort(classificacao, 0, classificacao.Length - 1);

                foreach (var pais in classificacao)
                {
                    Console.WriteLine(pais);
                }
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exceção: " + e.Message);
            }
        }
        static void Mergesort(ClassificacaoOlimpiadas[] vet, int esq, int dir)
        {
            if (esq < dir)
            {
                int meio = (esq + dir) / 2;
                Mergesort(vet, esq, meio);
                Mergesort(vet, meio + 1, dir);
                Intercalar(vet, esq, meio, dir);
            }
        }
        static void Intercalar(ClassificacaoOlimpiadas[] vet, int esq, int meio, int dir)
        {
            int nEsq = meio - esq + 1;
            int nDir = dir - meio;

            ClassificacaoOlimpiadas[] vetEsq = new ClassificacaoOlimpiadas[nEsq];
            ClassificacaoOlimpiadas[] vetDir = new ClassificacaoOlimpiadas[nDir];

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
                if (vetEsq[iEsq].MedalhaOuro > vetDir[iDir].MedalhaOuro ||
                (vetEsq[iEsq].MedalhaOuro == vetDir[iDir].MedalhaOuro && vetEsq[iEsq].MedalhaPrata > vetDir[iDir].MedalhaPrata) ||
                (vetEsq[iEsq].MedalhaOuro == vetDir[iDir].MedalhaOuro && vetEsq[iEsq].MedalhaPrata == vetDir[iDir].MedalhaPrata && vetEsq[iEsq].MedalhaBronze > vetDir[iDir].MedalhaBronze) ||
                (vetEsq[iEsq].MedalhaOuro == vetDir[iDir].MedalhaOuro && vetEsq[iEsq].MedalhaPrata == vetDir[iDir].MedalhaPrata && vetEsq[iEsq].MedalhaBronze == vetDir[iDir].MedalhaBronze && vetEsq[iEsq].NomePais.CompareTo(vetDir[iDir].NomePais) < 0))
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
