using System;
using System.Collections.Generic;
using System.Text;

namespace itacademy
{
    internal class Menu
    {
        ExcelHandler gerenciadorExcel = new ExcelHandler();
        Caminhao caminhao = new Caminhao();
        Produtos produtosClasse = new Produtos();

        public bool MenuOpcao1()
        {
            Console.WriteLine($"Digite a cidadeA");
            string cidadeA = Console.ReadLine();

            Console.WriteLine($"Digite a cidadeB");
            string cidadeB = Console.ReadLine();

            double distancia = gerenciadorExcel.RetornaDistanciaCidades(cidadeA, cidadeB);

            if (distancia == 0)
            {
                Console.WriteLine($"Cidade não encontrada, tente novamente");
                return true;
            }

            Console.WriteLine($"Digite a modalidade do transporte: pequeno, médio ou grande ");
            string modalidadeCaminhao = Console.ReadLine();

            double frete = caminhao.calculaFrete(distancia, modalidadeCaminhao);

            if (frete != 0)
            {
                Console.WriteLine($"De {cidadeA} até {cidadeB}, utilizando um caminhão de porte {modalidadeCaminhao}, a distância é de {distancia}Km e o custo será de R$ {frete}");
            }
            else
            {
                Console.WriteLine($"Não foi possível identificar o porte do caminhão. Tente novamente.");
                return true;
            }

            return true;
        }

        public bool MenuOpcao2()
        {

            Console.WriteLine($"Quantas cidades você quer adicionar no percurso?");
            int numeroDeCidades = Convert.ToInt32(Console.ReadLine());

            List<string> cidadesLista = new List<string>();

            for (int paradas = 0; paradas < numeroDeCidades; paradas++)
            {
                Console.WriteLine($"Digite o nome da cidade da proxima parada: ");
                string cidade = Console.ReadLine();
                cidadesLista.Add(cidade);
            }

            Console.WriteLine($"a lista de cidades é");
            foreach (string cidade in cidadesLista)
            {
                Console.WriteLine(cidade);
            }

            Console.WriteLine($"A lista de produtos disponiveis é a seguinte: ");

            foreach (var par in produtosClasse.produtos)
            {
                Console.WriteLine($"Produto {par.Key} peso {par.Value}");
            }

            Console.WriteLine($"Quantos celulares gostaria de adicionar?");
            int quantidadeCelulares = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Quantas geladeiras gostaria de adicionar?");
            int quantidadeGeladeiras = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Quantos freezers gostaria de adicionar?");
            int quantidadeFreezers = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Quantas cadeiras gostaria de adicionar?");
            int quantidadeCadeiras = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Quantas luminárias gostaria de adicionar?");
            int quantidadeLuminarias = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Quantas lavadoras de roupa gostaria de adicionar?");
            int quantidadeLavadorasDeRoupa = Convert.ToInt32(Console.ReadLine());

            double pesoTotal = produtosClasse.calcularPesoTotal(quantidadeCelulares, quantidadeGeladeiras, quantidadeFreezers,
                quantidadeCadeiras, quantidadeLuminarias, quantidadeLavadorasDeRoupa);

            Console.WriteLine($"O peso total deu {pesoTotal}");




            return true;
        }


    }
}
