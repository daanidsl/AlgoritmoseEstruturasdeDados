using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Q_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<char> sequencia = new Stack<char>();

            Console.WriteLine("Informe a sequencia:");
            string s = Console.ReadLine();
            char caractere;

            for (int i = 0; i < s.Length; i++)
            {
                caractere = s[i];

                if(caractere == '(' || caractere == '[')
                {
                    sequencia.Push(caractere);
                }

                else if(caractere == ')')
                {
                    if(sequencia.Count == 0 || sequencia.Peek() != '(')
                    {
                        sequencia.Push(caractere);
                        break;
                    }
                    sequencia.Pop();
                }
                
                else if(caractere == ']')
                {
                    if (sequencia.Count == 0 || sequencia.Peek() != '[')
                    {
                        sequencia.Push(caractere);
                        break;
                    }
                    sequencia.Pop();
                }
            }

            if(sequencia.Count == 0)
            {
                Console.Write("Sequencia bem formada!");
            }
            else
            {
                Console.Write("Sequencia mal formada!");
            }

            Console.ReadLine();
        }
    }
}
