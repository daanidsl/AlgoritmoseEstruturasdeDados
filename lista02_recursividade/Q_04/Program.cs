using System;

namespace Q_04
{
    internal class Program
    {
        static int MDC(int x, int y)
        {
            int resultado;

            if (x == y)
            {
                resultado = x;
            }
            else
            {
                if (x < y)
                {
                    resultado = MDC(y - x,x);
                }

                else
                {
                    resultado = MDC(x - y, y);
                }
            }

            return resultado;
        }
        static void Main(string[] args)
        {
            Console.Write("Digite o valor de x: ");
            int x = int.Parse(Console.ReadLine());
            Console.Write("Digite o valor de y: ");
            int y = int.Parse(Console.ReadLine());

            Console.WriteLine("MDC: " + MDC(x, y));
            Console.ReadLine();
        }
    }
}
