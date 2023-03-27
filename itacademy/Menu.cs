using System;
using System.Collections.Generic;
using System.Text;

namespace itacademy
{
    internal class Menu
    {
        ExcelHandler gerenciadorExcel = new ExcelHandler();
        Frete freteClass = new Frete();

        public bool MenuOpcao1()
        {
            Console.WriteLine($"Digite a cidade A");
            string cidadeA = Console.ReadLine();

            Console.WriteLine($"Digite a cidade B");
            string cidadeB = Console.ReadLine();

            double distancia = gerenciadorExcel.RetornaDistanciaCidades(cidadeA, cidadeB);

            if (distancia == 0)
            {
                Console.WriteLine($"Cidade não encontrada, tente novamente");
                return true;
            }

            Console.WriteLine($"Digite a modalidade do transporte: pequeno, médio ou grande ");
            string modalidadeCaminhao = Console.ReadLine();

            double valorFrete = freteClass.calculaFrete(distancia, modalidadeCaminhao);

            if (valorFrete != 0)
            {
                Console.WriteLine($"De {cidadeA} até {cidadeB}, utilizando um caminhão de porte {modalidadeCaminhao}, a distância é de {distancia}Km e o custo será de R$ {valorFrete}");
            }
            else
            {
                Console.WriteLine($"Não foi possível identificar o porte do caminhão. Tente novamente.");
                return true;
            }

            return true;
        }

        public Frete MenuOpcao2()
        {
            Frete frete = new Frete();

            List<string> lista = AdicionaListaCidades();
            if (lista.Count > 0)
            {
                frete.CidadesLista = lista;
            }
            else 
            {
                Console.WriteLine("Não foi possivel cadastrar a lista de cidades. Crie um novo frete");
            }



            /*
            Console.WriteLine($"A lista de produtos disponiveis é a seguinte: ");

            foreach (var par in frete.produtos)
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

            double pesoTotal = frete.calcularPesoTotal(quantidadeCelulares, quantidadeGeladeiras, quantidadeFreezers,
                quantidadeCadeiras, quantidadeLuminarias, quantidadeLavadorasDeRoupa);

            Console.WriteLine($"O peso total deu {pesoTotal}");
            */



            return frete;
        }

        public void MenuOpcao3(CadastroFrete cadastroFrete)
        {
            foreach (Frete frete in cadastroFrete.Transportes)
            {
                Console.WriteLine("O frete cadastrado tem os seguintes dados:");

                Console.WriteLine("Lista de cidades cadastradas:");
                foreach (string cidade in frete.CidadesLista)
                {
                    Console.WriteLine($"- {cidade}");
                }

                Console.WriteLine("Lista de produtos cadastrados:");
                foreach (var par in frete.produtos)
                {
                    Console.WriteLine($"Produto {par.Key} peso {par.Value}");
                }

                Console.WriteLine(frete.CustoTotal);

            }
        }



        public List<string> AdicionaListaCidades()
        {
            List<string> cidadesLista = new List<string>();
            try
            {
                Console.WriteLine($"Quantas cidades você quer adicionar no percurso?");
                int numeroDeCidades = Convert.ToInt32(Console.ReadLine());


                for (int paradas = 0; paradas < numeroDeCidades; paradas++)
                {
                    Console.WriteLine($"Digite o nome da cidade da proxima parada: ");
                    string cidade = Console.ReadLine();
                    if (gerenciadorExcel.ConsultaCidadeExiste(cidade))
                    {
                        cidadesLista.Add(cidade);
                    }
                    else
                    {
                        Console.WriteLine($"Não foi possivel adicionar a cidade pois não foi encontrada");
                    }
                }

                Console.WriteLine($"a lista de cidades é");
                foreach (string cidade in cidadesLista)
                {
                    Console.WriteLine($"- {cidade}");
                }
                return cidadesLista;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro Inesperado, tente novamente");
                return cidadesLista;
            }
        }



    }
}
