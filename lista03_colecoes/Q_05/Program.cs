using System;
using System.Collections.Generic;

namespace Q_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> ocorrencias = new Dictionary<string, int>();

            Console.WriteLine("Digite a Frase:");
            string frase = Console.ReadLine();

            string[] palavras = frase.Split(' ');

            foreach (string palavra in palavras)
            {
                string minuscula = palavra.ToLower();
                if (!ocorrencias.ContainsKey(minuscula))
                {
                    ocorrencias.Add(minuscula, 1);
                }
                else
                {
                    ocorrencias[minuscula]++;
                }
            }

            foreach (KeyValuePair<string, int> i in ocorrencias)
            {
                Console.WriteLine($"{i.Key}: {i.Value} ocorrencia(s).");
            }

            Console.ReadLine();
        }
    }
}
