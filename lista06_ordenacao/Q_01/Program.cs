using System;
using System.Diagnostics;

namespace Q_01
{
    class Program
    {
        static void Selecao(int[] vet, int n)
        {
            Console.WriteLine("Seleção");
            int contmovimentacoes = 0, contcomparacoes = 0;
            for (int i = 0; i < (n - 1); i++)
            {
                int menor = i;
                for (int j = (i + 1); j < n; j++)
                {
                    contcomparacoes++;
                    if (vet[menor] > vet[j])
                    {
                        menor = j;
                    }
                }
                int temp = vet[menor];
                vet[menor] = vet[i];
                vet[i] = temp;
                contmovimentacoes += 3;
            }
            Console.WriteLine("Movimentações: " + contmovimentacoes);
            Console.WriteLine("Comparações: " + contcomparacoes);
        }

        static void Bolha(decimal[] vet, int n)
        {
            Console.WriteLine("Bolha");
            long contmovimentacoes = 0, contcomparacoes = 0;
            decimal temp;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = n - 1; j > i; j--)
                {
                    contcomparacoes++;
                    if (vet[j] < vet[j - 1])
                    {
                        temp = vet[j];
                        vet[j] = vet[j - 1];
                        vet[j - 1] = temp;
                        contmovimentacoes += 3;
                    }
                }
            }
            Console.WriteLine("Movimentações: " + contmovimentacoes);
            Console.WriteLine("Comparações: " + contcomparacoes);
        }

        static void Insercao(decimal[] vet, int n)
        {
            Console.WriteLine("Inserção");
            long contmovimentacoes = 0, contcomparacoes = 0;
            for (int i = 1; i < vet.Length; i++)
            {
                decimal tmp = vet[i];
                int j = i - 1;
                contcomparacoes+=2;
                while ((j >= 0) && (vet[j] > tmp))
                {
                    vet[j + 1] = vet[j];
                    j--;
                    contmovimentacoes++;
                }
                vet[j + 1] = tmp;
                contmovimentacoes+=2;
            }
            Console.WriteLine("Movimentações: " + contmovimentacoes);
            Console.WriteLine("Comparações: " + contcomparacoes);
        }
        static void Quicksort(decimal[] vet, int esq, int dir, ref long contcomparacoes, ref long contmovimentacoes)
        {
            int i = esq, j = dir;
            decimal pivo = vet[(esq + dir) / 2];
            while (i <= j)
            {
                while (vet[i] < pivo)
                {
                    i++;
                    contcomparacoes++;
                }
                while (vet[j] > pivo)
                {
                    j--;
                    contcomparacoes++;
                }
                if (i <= j)
                {
                    Trocar(vet, i, j);
                    i++;
                    j--;
                    contmovimentacoes += 3;
                }
                contcomparacoes++;
            }
            contcomparacoes += 2;
            if (esq < j)
            {
                Quicksort(vet, esq, j, ref contcomparacoes, ref contmovimentacoes);
            }
            if (i < dir)
            {
                Quicksort(vet, i, dir, ref contcomparacoes, ref contmovimentacoes);
            }

            if (esq == 0 && dir == vet.Length - 1)
            {
                Console.WriteLine("Quicksort");
                Console.WriteLine("Movimentações: " + contmovimentacoes);
                Console.WriteLine("Comparações: " + contcomparacoes);
            }
        }
        static void Trocar(decimal[] array, int i, int j)
        {
            decimal temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        static void Mergesort(decimal[] vet, int esq, int dir, ref long contcomparacoes, ref long contmovimentacoes)
        {
            if (esq < dir)
            {
                int meio = (esq + dir) / 2;
                Mergesort(vet, esq, meio, ref contcomparacoes, ref contmovimentacoes);
                Mergesort(vet, meio + 1, dir, ref contcomparacoes, ref contmovimentacoes);
                Intercalar(vet, esq, meio, dir, ref contcomparacoes, ref contmovimentacoes);
            }
            if (esq == 0 && dir == vet.Length - 1)
            {
                Console.WriteLine("Mergesort");
                Console.WriteLine("Movimentações: " + contmovimentacoes);
                Console.WriteLine("Comparações: " + contcomparacoes);
            }
        }
        static void Intercalar(decimal[] vet, int esq, int meio, int dir, ref long contcomparacoes, ref long contmovimentacoes)
        {
            int nEsq = meio - esq + 1;
            int nDir = dir - meio;

            decimal[] vetEsq = new decimal[nEsq + 1];
            decimal[] vetDir = new decimal[nDir + 1];

            vetEsq[nEsq] = decimal.MaxValue;
            vetDir[nDir] = decimal.MaxValue;

            int iEsq, iDir, i;
            for (iEsq = 0; iEsq < nEsq; iEsq++)
            {
                vetEsq[iEsq] = vet[esq + iEsq];
                contmovimentacoes++;
            }

            for (iDir = 0; iDir < nDir; iDir++)
            {
                vet[iDir] = vet[(meio + 1) + iDir];
                contmovimentacoes++;
            }

            for (iEsq = 0, iDir = 0, i = esq; i <= dir; i++)
            {
                contcomparacoes++;
                vet[i] = (vetEsq[iEsq] <= vetDir[iDir]) ? vetEsq[iEsq++] : vetDir[iDir++];
                contmovimentacoes++;
            }
        }
        static void HeapSort(decimal[] vet, int n)
        {
            long contmovimentacoes = 0, contcomparacoes = 0;
            int ultimo;
            for (ultimo = 1; ultimo < n; ultimo++)
            {
                Construir(vet, ultimo, ref contmovimentacoes, ref contcomparacoes);
            }
            ultimo = n - 1;
            while (ultimo > 0)
            {
                Trocar(vet, 0, ultimo--, ref contmovimentacoes);
                Reconstruir(vet, ultimo + 1, ref contmovimentacoes, ref contcomparacoes);
            }
            Console.WriteLine("Movimentações: " + contmovimentacoes);
            Console.WriteLine("Comparações: " + contcomparacoes);
        }
        static void Construir(decimal[] vet, int ultimo, ref long contmovimentacoes, ref long contcomparacoes)
        {
            contcomparacoes++;
            for (int i = ultimo; i > 0 && vet[i] > vet[(i - 1) / 2]; i = (i - 1) / 2)
            {
                Trocar(vet, i, (i - 1) / 2, ref contmovimentacoes);
            }
        }
        static void Reconstruir(decimal[] vet, int tamHeap, ref long contmovimentacoes, ref long contcomparacoes)
        {
            int i = 0;
            while (HasFilho(i, tamHeap))
            {
                int filho = GetMaiorFilho(vet, i, tamHeap, ref contcomparacoes);
                contcomparacoes++;
                if (vet[i] < vet[filho])
                {
                    Trocar(vet, i, filho, ref contmovimentacoes);
                    i = filho;
                }
                else
                {
                    i = tamHeap;
                }
            }
        }
        static bool HasFilho(int i, int tamHeap)
        {
            return (i < tamHeap / 2);
        }
        static void Trocar(decimal[] vet, int i, int j, ref long contmovimentacoes)
        {
            decimal temp = vet[i];
            vet[i] = vet[j];
            vet[j] = temp;
            contmovimentacoes += 3;
        }
        static int GetMaiorFilho(decimal[] vet, int i, int tamHeap, ref long contcomparacoes)
        {
            int filho;
            contcomparacoes++;
            if ((2 * i + 1) == (tamHeap - 1) || vet[2 * i + 1] > vet[2 * i + 2])
            {
                filho = 2 * i + 1;
            }
            else
            {
                filho = 2 * i + 2;
            }
            return filho;
        }
        static void CountingSort(int[] vet, int n)
        {
            int[] count = new int[GetMaior(vet, n) + 1];
            int[] ordenado = new int[n];

            for (int i = 0; i < n; count[vet[i]]++, i++) ;
            for (int i = 1; i < count.Length; count[i] += count[i - 1], i++) ;
            for (int i = n - 1; i >= 0; ordenado[count[vet[i]] - 1] = vet[i], count[vet[i]]--, i--) ;
            for (int i = 0; i < n; vet[i] = ordenado[i], i++) ;
        }
        static int GetMaior(int[] array, int n)
        {
            int maior = array[0];
            for (int i = 1; i < n; i++)
            {
                if (array[i] > maior)
                    maior = array[i];
            }
            return maior;
        }
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();

            int[] vetaleatorio = new int[500000];
            int[] vetcrescente = new int[500000];
            decimal[] vetdecrescente = new decimal[500000];

            Random rnd = new Random();
            for (int i = 0; i < vetaleatorio.Length; i++)
            {
                vetaleatorio[i] = rnd.Next(0, 500000);
            }

            for (int i = 0; i < vetcrescente.Length; i++)
            {
                vetcrescente[i] = i;
            }

            for (int i = 0; i < vetdecrescente.Length; i++)
            {
                vetdecrescente[i] = vetdecrescente.Length - i;
            }
            long contcomparacoes = 0, contmovimentacoes = 0;
            stopWatch.Start();
            //Selecao(vetaleatorio, vetaleatorio.Length);
            //Bolha(vetaleatorio, vetaleatorio.Length);
            //Insercao(vetaleatorio, vetaleatorio.Length);
            //Quicksort(vetdecrescente, 0, vetdecrescente.Length - 1, ref contcomparacoes, ref contmovimentacoes);
            //Mergesort(vetaleatorio, 0, vetaleatorio.Length-1, ref contcomparacoes, ref contmovimentacoes);
            //HeapSort(vetdecrescente, vetdecrescente.Length);
            CountingSort(vetaleatorio, vetaleatorio.Length);
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("Tempo " + elapsedTime);
            stopWatch.Reset();
            Console.ReadLine();
        }
    }
}