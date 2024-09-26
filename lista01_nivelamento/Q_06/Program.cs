using System;

namespace Q_06
{
    class Livro
    {
        private string titulo;
        private string autores;
        private string editora;

        public Livro(string titulo, string autores, string editora)
        {
            this.titulo = titulo;
            this.autores = autores;
            this.editora = editora;
        }

        public string Titulo
        {
            get { return this.titulo; }
            set { this.titulo = value; }
        }

        public string Autores
        {
            get { return this.autores; }
            set { this.autores = value; }
        }

        public string Editora
        {
            get { return this.editora; }
            set { this.editora = value; }
        }
    }
    class Biblioteca
    {
        private Livro[] acervo; 
        private int numLivros;
        private const int MAXLIV = 50;
        
        public Biblioteca()
        {
            acervo = new Livro[MAXLIV];
            numLivros = 0;
        }

        public bool AdicionarLivro(string titulo, string autores, string editora)
        {
            if (numLivros < MAXLIV)
            {
                acervo[numLivros] = new Livro(titulo, autores, editora);
                numLivros++;
                return true;
            }
            return false;
        }

        public bool AdicionarLivroNoAcervo(Livro livro)
        {
            if(numLivros < MAXLIV)
            {
                acervo[numLivros] = livro;
                numLivros++;
                return true;
            }
            return false;
        }

        public Livro RetornandoLivro(string titulo)
        {
            for(int i = 0; i < numLivros; i++)
            {
                if (acervo[i].Titulo == titulo)
                {
                    return acervo[i];
                }
            }
            return null;
        }
        public string Titulos()
        {
            string titulos = "";
            for(int i = 0; i < numLivros; i++)
            {
                titulos += acervo[i].Titulo + " ";
            }
            return titulos;
        }

        public int Num()
        {
            return numLivros;
        }
    }
    class Teste
    {
        static void Main(string[] args)
        {
            Biblioteca biblioteca = new Biblioteca();
            biblioteca.AdicionarLivro("Jogos de Herança", "Jennifer Lynn Barnes", "Alt");
            biblioteca.AdicionarLivro("Livro2", "Autora2", "Editora2");
            biblioteca.AdicionarLivro("Livro3", "Autora3", "Editora3");
            biblioteca.AdicionarLivro("Livro4", "Autora4", "Editora4");

            Livro livro = biblioteca.RetornandoLivro("Jogos de Herança");
            if (livro != null)
            {
                Console.WriteLine("Título: " + livro.Titulo);
                Console.WriteLine("Autores: " + livro.Autores);
                Console.WriteLine("Editora: " + livro.Editora);
            }
            else
            {
                Console.WriteLine("O livro não foi encontrado");
            }

            Console.WriteLine("Biblioteca: ");
            Console.WriteLine(biblioteca.Titulos());
            Console.ReadLine();
        }
    }
}
