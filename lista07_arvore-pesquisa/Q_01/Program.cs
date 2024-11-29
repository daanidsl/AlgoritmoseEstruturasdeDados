using System;

namespace Q_01
{
    class Aluno
    {
        private string nome;
        private int nota;
        public Aluno(string nome, int nota)
        {
            this.nome = nome;
            this.nota = nota;
        }
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public int Nota
        {
            get { return nota; }
            set { nota = value; }
        }
    }
    class Program
    {
        static int PesquisaBinaria(Aluno [] alunos, string nome)
        {
            int dir = alunos.Length - 1, esq = 0, meio;

            while (esq <= dir)
            {
                meio = (esq + dir) / 2;
                if (nome.CompareTo(alunos[meio].Nome) == 0)
                {
                    return meio;
                }
                else if (nome.CompareTo(alunos[meio].Nome) > 0)
                {
                    esq = meio + 1;
                }
                else
                {
                    dir = meio - 1;
                }
            }
            return -1;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Informe N:");
            int n = int.Parse(Console.ReadLine());

            Aluno[] alunos = new Aluno[n];
            string nome; int nota; int i = 0;

            do
            {
                string dados = Console.ReadLine();
                string[] dadosalunos = dados.Split(',');
                nome = dadosalunos[0];
                nota = int.Parse(dadosalunos[1]);
                alunos[i] = new Aluno(nome, nota);
                i++;

            } while (i < n);

            char novaconsulta; 

            do
            {
                Console.WriteLine("Informe o nome:");
                nome = Console.ReadLine();

                int pesquisa = PesquisaBinaria(alunos, nome);

                if (pesquisa != -1)
                {
                    Console.WriteLine("Nota: " + alunos[pesquisa].Nota);
                }
                else
                {
                    Console.WriteLine("Aluno nao consta na base");
                }

                Console.WriteLine("Continuar?[S ou N]");
                novaconsulta = char.Parse(Console.ReadLine());

            } while (novaconsulta == 'S');
        }
    }
}
