using System;
using System.IO;
using System.Text;

namespace Q_05
{
    class Jogador
    {
        private int numero;
        private string nome;
        private string posicao;
        public Jogador(int numero, string nome, string posicao)
        {
            this.numero = numero;
            this.nome = nome;
            this.posicao = posicao;
        }

        public int Numero
        {
            get { return this.numero; }
            set { this.numero = value; }
        }

        public string Nome
        {
            get { return this.nome; }
            set { this.nome = value; }
        }

        public string Posicao
        {
            get { return this.posicao; }
            set {
                if (value == "goleiro" || value == "zagueiro" || value == "lateral" || value == "meia" || value == "atacante")
                {
                    this.posicao = value;
                }
            }
        }
    }

    class Time
    {
        private string nome;
        private Jogador[] titulares;
        private int quantTitulares;
        private Jogador[] reservas;
        private int quantReservas;

        public Time(string nome)
        {
            this.nome = nome;
            titulares = new Jogador[11];
            quantTitulares = 0;
            reservas = new Jogador[12];
            quantReservas = 0;
        }

        public string Nome
        {
            get { return this.nome; }
            set { this.nome = value; }
        }

        public bool AdicionarTitular(Jogador titular)
        {
            if(quantTitulares < 11)
            {
                titulares[quantTitulares] = titular;
                quantTitulares++;
                return true;
            }
            return false;
        }

        public bool AdicionarReserva(Jogador reserva)
        {
            if(quantReservas < 12)
            {
                reservas[quantReservas] = reserva;
                quantReservas++;
                return true;
            }
            return false;
        }

        public bool SubstituirTitular(string nomet, Jogador novot)
        {
            for(int i = 0; i < titulares.Length; i++)
            {
                if (titulares[i].Nome == nomet)
                {
                    titulares[i] = novot;
                    return true;
                }
            }
            return false;
        }

        public bool SubstituirReserva(string nomer, Jogador novor)
        {
            for(int i = 0; i < reservas.Length; i++)
            {
                if (reservas[i].Nome == nomer)
                {
                    reservas[i] = novor;
                    return true;
                }
            }
            return false;
        }

        public bool ConsultarTitular(string nometitular)
        {
            for(int i = 0; i < titulares.Length; i++)
            {
                if (titulares[i].Nome == nometitular)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ConsultarReserva(string nomereserva)
        {
            for(int i = 0; i < reservas.Length; i++)
            {
                if (reservas[i] != null && reservas[i].Nome == nomereserva)
                {
                    return true;
                }
            }
            return false;
        }
        public bool ExcluirTitular(string titularexcluido)
        {
            int num = -1;
            for(int i = 0; i < titulares.Length; i++)
            {
                if (titulares[i] != null && titulares[i].Nome == titularexcluido)
                {
                    num = i;
                }
            }

            if(num != -1)
            {
                for(int i = num; i < titulares.Length - 1; i++)
                {
                    titulares[i] = titulares[i + 1];
                }
                quantTitulares--;
                return true;
            }
            return false;
        }
        public bool ExcluirReserva(string reservaexcluido)
        {
            int num = -1;
            for (int i = 0; i < reservas.Length; i++)
            {
                if (reservas[i] != null && reservas[i].Nome == reservaexcluido)
                {
                    num = i;
                }
            }

            if (num != -1)
            {
                for (int i = num; i < reservas.Length - 1; i++)
                {
                    reservas[i] = reservas[i + 1];
                }
                quantReservas--;
                return true;
            }
            return false;
        }
        public void GerarArqTime(string dados)
        {
            try
            {
                StreamWriter arq = new StreamWriter(dados, false, Encoding.UTF8);
                arq.WriteLine("Time: " + Nome);

                arq.WriteLine("Número de titulares: " + quantTitulares);
                arq.WriteLine("Número de reservas: " + quantReservas);

                arq.WriteLine("Dados dos jogadores: ");

                arq.WriteLine("Titulares:");

                for (int i = 0; i < quantTitulares; i++)
                {
                    if (titulares[i] != null)
                    {
                        arq.WriteLine(titulares[i].Numero + "  " + titulares[i].Nome + "  " + titulares[i].Posicao);
                    }
                }

                arq.WriteLine("Reservas:");
                for (int i = 0; i < quantReservas; i++)
                {
                    if (reservas[i] != null)
                    {
                        arq.WriteLine(reservas[i].Numero + "  " + reservas[i].Nome + "  " + reservas[i].Posicao);
                    }
                }
                arq.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Exceção: " + e.Message);
            }
        }
    }

    class Teste
    {
        static void Main(string[] args)
        {
            Time time = new Time("Portugal");
            Jogador jogador1 = new Jogador(11, "João Félix", "atacante");
            Jogador jogador2 = new Jogador(22, "Diogo Costa", "goleiro");
            Jogador jogador3 = new Jogador(7, "Cristiano Ronaldo", "atacante");
            Jogador jogador4 = new Jogador(6, "Vitinha", "meia");
            
            time.AdicionarTitular(jogador3);
            time.AdicionarReserva(jogador1);

            time.SubstituirTitular("Cristiano Ronaldo", jogador2);
            time.SubstituirReserva("João Félix", jogador4);

            Console.WriteLine("Consultando titular: " + time.ConsultarTitular("Diogo Costa"));
            Console.WriteLine("Consultando reserva: " + time.ConsultarReserva("Cristiano Ronaldo"));

            time.ExcluirTitular("Diogo Costa");
            time.ExcluirReserva("João Félix");

            time.GerarArqTime("time.txt");
            Console.ReadLine();
        }
    }
}
