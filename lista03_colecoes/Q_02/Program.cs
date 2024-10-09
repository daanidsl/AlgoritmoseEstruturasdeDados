using System;
using System.Collections.Generic;

namespace Q_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<double> notacao = new Stack<double>();

            Console.WriteLine("Informe uma expressao:");
            string expressao = Console.ReadLine();

            char letra;
            double v1, v2, resultado = 0;

            for(int i = 0; i < expressao.Length; i++)
            {
                letra = expressao[i];

                if (letra != '-' && letra != '+' && letra != '/' && letra != '*')
                {
                    double num = (double)Char.GetNumericValue(letra);
                    notacao.Push(num);
                }
                else
                {
                    v1 = notacao.Pop();
                    v2 = notacao.Pop();

                    if (letra == '-')
                    {
                        resultado = v2 - v1;
                        notacao.Push(resultado);
                    }
                    else if (letra == '+')
                    {
                        resultado = v2 + v1;
                        notacao.Push(resultado);
                    }
                    else if (letra == '/')
                    {
                        resultado = v2 / v1;
                        notacao.Push(resultado);
                    }
                    else if (letra == '*')
                    {
                        resultado = v2 * v1;
                        notacao.Push(resultado);
                    }
                }
            }
            Console.Write("Resultado: " + resultado);
            Console.ReadLine();
        }
    }
}
