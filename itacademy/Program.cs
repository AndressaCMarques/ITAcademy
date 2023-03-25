using System;

namespace itacademy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Coloque a distância desejada em km: ");
            int distanciaCidade = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"A distância é: {distanciaCidade}");

            Console.WriteLine("Qual o peso dos produtos em Kg? ");
            int pesoProdutoTotal = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"O peso total dos produtos é: {pesoProdutoTotal}");

        }
    }
}
