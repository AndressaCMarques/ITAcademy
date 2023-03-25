using System;

namespace itacademy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Coloque a distância desejada em km: ");

            //o read line é para ler a proxima string e converter de uma string para inteiro
            int distanciaCidade = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"A distância é: {distanciaCidade}");

            Console.WriteLine("Qual o peso dos produtos em Kg? ");
            int pesoProdutoTotal = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"O peso total dos produtos é: {pesoProdutoTotal}"); //interpolação cifrão para colocar o texto inteiro e botar a variável no final

            double precoPorKMCaminhaoPequeno = 4.87;
            double precoPorKMCaminhaoMedio = 11.92;
            double precoPorKMCaminhaoGrande = 27.44;

            int pesoCaminhaoPequeno = 1000;
            int pesoCaminhaoMedio = 4000;
            int pesoCaminhaoGrande = 10000;

            double custoFrete;

            //Agora precisa colocar uma condição, em vez de colocar direto o número 1000, usa a variável criada, pois na hora que muda o peso só muda em um lugar, não em todos 
            if (pesoProdutoTotal <= pesoCaminhaoPequeno)
            {
                custoFrete = distanciaCidade * precoPorKMCaminhaoPequeno;
                Console.WriteLine($"O custo do frete do caminhão pequeno é: {Math.Round(custoFrete, 2)}");
            }else if (pesoProdutoTotal <= pesoCaminhaoMedio)
            {
                custoFrete= distanciaCidade * precoPorKMCaminhaoMedio;
                Console.WriteLine($"O custo do frete do caminhão Médio é: {Math.Round(custoFrete, 2)}");

            }else if (pesoProdutoTotal <= pesoCaminhaoGrande)
            {
                custoFrete= distanciaCidade * precoPorKMCaminhaoGrande;
                Console.WriteLine($"O custo do frete do caminhão grande é: {Math.Round(custoFrete, 2)}");
            }
        }
    }
}
