using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UniversidadeStark
{
    class Curso
    {
        private int codCurso, qtdVagas;
        double notaCorte;
        private string nome;
        private List<Candidato> selecionado;
        private Fila filadeEspera = new Fila();
        public Curso(int codCurso, int qtdVagas, string nome)
        {
            this.CodCurso = codCurso;
            this.qtdVagas = qtdVagas;
            this.nome = nome;
            this.selecionado = new List<Candidato>();
        }
        public Curso() { }
        public int CodCurso
        {
            get { return codCurso; }
            set { codCurso = value; }
        }
        public int QtdVagas
        {
            get { return qtdVagas; }
            set { qtdVagas = value; }
        }
        public double NotaCorte
        {
            get { return notaCorte; }
            set { notaCorte = value; }
        }
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public List<Candidato> Selecionado
        {
            get { return selecionado; }
            set { selecionado = value; }
        }
        public Fila FiladeEspera
        {
            get { return filadeEspera; }
            set { filadeEspera = value; }
        }
    }
    class Fila
    {
        private Candidato[] candidatosEsperando;
        private int primeiro, ultimo, tamanho;
        public Fila()
        {
            candidatosEsperando = new Candidato[10];
            primeiro = ultimo = 0;
            tamanho = 0;
        }
        public bool ObterTamanho()
        {
            if (tamanho < 10)
                return true;
            else
                return false;
        }

        public void AdicionarCandidato(Candidato candidato)
        {
            if (tamanho == candidatosEsperando.Length)
            {
                Console.WriteLine("A fila está cheia!");
                return;
            }
            candidatosEsperando[ultimo] = candidato;
            ultimo = (ultimo + 1) % candidatosEsperando.Length;
            tamanho++;
        }

        public string Listar()
        {
            string lista = "";
            int i = primeiro;
            while (i != ultimo)
            {
                lista += candidatosEsperando[i] + "\n";
                i = (i + 1) % candidatosEsperando.Length;
            }
            return lista;
        }
    }
    class Candidato
    {
        private string nome;
        private double notaRed, notaMat, notaLing, media;
        private int codCursoOp1, codCursoOp2;
        public Candidato()
        {

        }
        public Candidato(string nome, double notaRed, double notaMat, double notaLing, int codCursoOp1, int codCursoOp2)
        {
            this.nome = nome;
            this.notaRed = notaRed;
            this.notaMat = notaMat;
            this.notaLing = notaLing;
            media = (notaRed + notaMat + notaLing) / 3;
            this.codCursoOp1 = codCursoOp1;
            this.codCursoOp2 = codCursoOp2;
        }
        public double Media
        {
            get { return media; }
            set { media = value; }
        }
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public double NotaRed
        {
            get { return notaRed; }
            set { notaRed = value; }
        }
        public double NotaMat
        {
            get { return notaMat; }
            set { notaMat = value; }
        }
        public double NotaLing
        {
            get { return notaLing; }
            set { notaLing = value; }
        }
        public int CodCursoOp1
        {
            get { return codCursoOp1; }
            set { codCursoOp1 = value; }
        }
        public int CodCursoOp2
        {
            get { return codCursoOp2; }
            set { codCursoOp2 = value; }
        }
        public override string ToString()
        {
            return $"{Nome} {Math.Round(Media, 2)} {NotaRed} {NotaMat} {NotaLing}";
        }
    }
    class Program
    {
        static void VerificarSelecionados(Dictionary<int, Curso> dicionarioCursos, Candidato[] candidato)
        {
            Curso op1, op2;
            for (int i = 0; i < candidato.Length; i++)
            {
                op1 = dicionarioCursos[candidato[i].CodCursoOp1];
                op2 = dicionarioCursos[candidato[i].CodCursoOp2];
                if (op1.QtdVagas > 0)
                {
                    op1.Selecionado.Add(candidato[i]);
                    op1.NotaCorte = candidato[i].Media;
                    op1.QtdVagas--;
                }
                else if (op2.QtdVagas > 0)
                {
                    if (op2.QtdVagas > 0)
                    {
                        op2.Selecionado.Add(candidato[i]);
                        op2.NotaCorte = candidato[i].Media;
                        op2.QtdVagas--;
                    }
                    if (op1.FiladeEspera.ObterTamanho())
                    {
                        op1.FiladeEspera.AdicionarCandidato(candidato[i]);
                    }
                }
                else if (op1.FiladeEspera.ObterTamanho() || op2.FiladeEspera.ObterTamanho())
                {
                    if (op1.FiladeEspera.ObterTamanho())
                    {
                        op1.FiladeEspera.AdicionarCandidato(candidato[i]);
                    }
                    if (op2.FiladeEspera.ObterTamanho())
                    {
                        op2.FiladeEspera.AdicionarCandidato(candidato[i]);
                    }
                }
                else
                    Console.WriteLine("Candidato Desclassificado");
            }
        }
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
        static void Mergesort(Candidato[] candidato, int esq, int dir)
        {
            if (esq < dir)
            {
                int meio = (esq + dir) / 2;
                Mergesort(candidato, esq, meio);
                Mergesort(candidato, meio + 1, dir);
                Intercalar(candidato, esq, meio, dir);
            }
        }
        static void Intercalar(Candidato[] candidato, int esq, int meio, int dir)
        {
            int nEsq = meio - esq + 1;
            int nDir = dir - meio;

            Candidato[] vetEsq = new Candidato[nEsq + 1];
            Candidato[] vetDir = new Candidato[nDir + 1];
            vetEsq[nEsq] = new Candidato();
            vetEsq[nEsq].Media = double.MinValue;
            vetDir[nDir] = new Candidato();
            vetDir[nDir].Media = double.MinValue;

            int iEsq, iDir, i;
            for (iEsq = 0; iEsq < nEsq; iEsq++)
            {
                vetEsq[iEsq] = candidato[esq + iEsq];
            }

            for (iDir = 0; iDir < nDir; iDir++)
            {
                vetDir[iDir] = candidato[(meio + 1) + iDir];
            }

            for (iEsq = 0, iDir = 0, i = esq; i <= dir; i++)
            {
                if (vetEsq[iEsq].Media > vetDir[iDir].Media || (vetEsq[iEsq].Media == vetDir[iDir].Media && vetEsq[iEsq].NotaRed > vetDir[iDir].NotaRed || (vetEsq[iEsq].Media == vetDir[iDir].Media && vetEsq[iEsq].NotaRed == vetDir[iDir].NotaRed && vetEsq[iEsq].NotaMat > vetDir[iDir].NotaMat)))
                {
                    candidato[i] = vetEsq[iEsq];
                    iEsq++;
                }
                else
                {
                    candidato[i] = vetDir[iDir];
                    iDir++;
                }

            }
        }
        static void Resultados(StreamWriter arqSaida, Dictionary<int, Curso> dicionarioCursos, Candidato[] candidato)
        {
            foreach (var curso in dicionarioCursos.Values)
            {
                arqSaida.WriteLine($"{curso.Nome} {curso.NotaCorte:F2}");
                arqSaida.WriteLine("Selecionados");
                foreach (var candidatos in curso.Selecionado)
                {
                    arqSaida.WriteLine(candidatos.ToString());
                }
                arqSaida.WriteLine("Fila de Espera");
                arqSaida.WriteLine(curso.FiladeEspera.Listar());
            }
            arqSaida.Flush();
            arqSaida.Close();
        }
        static void Main(string[] args)
        {
            Curso curso;
            Candidato[] candidato;
            Candidato maior;
            try
            {
                StreamReader arq = new StreamReader("arq.txt", Encoding.UTF8);
                int linhas = Linhas(arq);
                arq.Close();

                arq = new StreamReader("arq.txt", Encoding.UTF8);
                string informacoesCursos = arq.ReadLine();
                string[] informacoes = informacoesCursos.Split(';');
                int numCursos = int.Parse(informacoes[0]);
                int numCandidatos = int.Parse(informacoes[1]);

                string nomeCurso;
                int codCurso, qtdVagas;

                Dictionary<int, Curso> dicionarioCursos = new Dictionary<int, Curso>();
                for (int i = 0; i < numCursos; i++)
                {
                    string infCursos = arq.ReadLine();
                    string[] inf = infCursos.Split(';');
                    codCurso = int.Parse(inf[0]);
                    nomeCurso = inf[1];
                    qtdVagas = int.Parse(inf[2]);
                    dicionarioCursos.Add(codCurso, new Curso(codCurso, qtdVagas, nomeCurso));
                }

                string nomeCandidato;
                double notaRed, notaMat, notaLing;
                int codCursoOp1, codCursoOp2;

                candidato = new Candidato[numCandidatos];
                for (int i = 0; i < numCandidatos; i++)
                {
                    string infCandidatos = arq.ReadLine();
                    string[] inf = infCandidatos.Split(';');
                    nomeCandidato = inf[0];
                    notaRed = double.Parse(inf[1]);
                    notaMat = double.Parse(inf[2]);
                    notaLing = double.Parse(inf[3]);
                    codCursoOp1 = int.Parse(inf[4]);
                    codCursoOp2 = int.Parse(inf[5]);
                    candidato[i] = new Candidato(nomeCandidato, notaRed, notaMat, notaLing, codCursoOp1, codCursoOp2);
                }
                arq.Close();

                Mergesort(candidato, 0, candidato.Length - 1);
                foreach (var candidatos in candidato)
                {
                    Console.WriteLine(candidatos.ToString());
                }
                VerificarSelecionados(dicionarioCursos, candidato);

                StreamWriter arqSaida = new StreamWriter("arqSaida.txt", false, Encoding.UTF8);
                Resultados(arqSaida, dicionarioCursos, candidato);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exceção: " + e.Message);
            }
        }
    }
}