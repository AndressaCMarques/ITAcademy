using System;
using System.Collections.Generic;
using System.Text;

namespace itacademy
{
    internal class Menu
    {
        ExcelHandler gerenciadorExcel = new ExcelHandler();
        Frete freteClass = new Frete();

        public bool CotarFrete()
        {
            Console.WriteLine($"\nDigite a cidade A");
            string cidadeA = Console.ReadLine();

            Console.WriteLine($"\nDigite a cidade B");
            string cidadeB = Console.ReadLine();

            double distancia = gerenciadorExcel.RetornaDistanciaCidades(cidadeA, cidadeB);

            if (distancia == 0)
            {
                Console.WriteLine($"\nCidade não encontrada, tente novamente");
                return true;
            }

            Console.WriteLine($"\nDigite a modalidade do transporte: pequeno, médio ou grande ");
            string modalidadeCaminhao = Console.ReadLine();

            double valorFrete = freteClass.CalculaFrete(distancia, modalidadeCaminhao);

            if (valorFrete != 0)
            {
                Console.WriteLine($"\nDe {cidadeA} até {cidadeB}, utilizando um caminhão de porte {modalidadeCaminhao}, a distância é de {distancia}Km e o custo será de R$ {Math.Round(valorFrete, 2)}");
            }
            else
            {
                Console.WriteLine($"\nNão foi possível identificar o porte do caminhão. Tente novamente.");
                return true;
            }

            return true;
        }

        public Frete CadastrarFrete()
        {
            Frete frete = new Frete();
            try
            {

                List<string> lista = AdicionaListaCidades();

                if (lista.Count > 1)
                {
                    frete.CidadesLista = lista;
                }
                else
                {
                    Console.WriteLine("\nNão foi possivel cadastrar a lista com pelo menos 2 cidades para o frete. Crie um novo frete");
                }

                Console.WriteLine($"\nA lista de produtos pré cadastrados disponiveis é a seguinte: ");
                foreach (var linha in frete.produtos)
                {
                    Console.WriteLine($"Produto {linha.Key} peso {linha.Value}");
                }

                frete = AdicionarProdutoAoFrete(frete);

                Console.WriteLine($"\nAgora adicione produtos ao frete: ");
                foreach (var par in frete.produtos)
                {
                    Console.WriteLine($"\nProduto {par.Key} peso {par.Value}");
                    Console.WriteLine($"Gostaria de adicionar quantos deste produto?");
                    int quantidadeProdutoInput = Convert.ToInt32(Console.ReadLine());
                    frete.QuantidadesProdutos.Add(quantidadeProdutoInput);
                    frete.TotaItensTransportados = frete.TotaItensTransportados + quantidadeProdutoInput;
                }

                double distanciaTrecho;
                frete.CustoTotal = 0;

                //percorrendo um trecho de cada vez
                for (int i = 0; i < frete.CidadesLista.Count - 1; i++)
                {
                    //calcula o peso total fazendo a lista de quantidades de cada produto x o peso de cada um no dicionario seguindo a mesma ordem
                    frete.PesoTotal = frete.CalcularPesoTotal(frete.produtos, frete.QuantidadesProdutos);
                    Console.WriteLine($"\nO peso total deu {frete.PesoTotal}");

                    //calcula o trecho de 2 cidades no percurso
                    distanciaTrecho = gerenciadorExcel.RetornaDistanciaCidades(frete.CidadesLista[i], frete.CidadesLista[i + 1]);
                    frete.DistanciaTrecho.Add(distanciaTrecho);
                    Console.WriteLine($"\nA distancia do trecho de {frete.CidadesLista[i]} para {frete.CidadesLista[i + 1]} é de {distanciaTrecho} KM");


                    frete.DistanciaTotal = frete.DistanciaTotal + distanciaTrecho;

                    List<int> numeroCaminhoes = new List<int>();
                    numeroCaminhoes = frete.CalculaCaminhoes(frete.PesoTotal);

                    frete.NumeroCaminhaoPequenoTotal = frete.NumeroCaminhaoPequenoTrecho + numeroCaminhoes[0];
                    frete.NumeroCaminhaoMedioTotal = frete.NumeroCaminhaoMedioTrecho + numeroCaminhoes[1];
                    frete.NumeroCaminhaoGrandeTotal = frete.NumeroCaminhaoGrandeTrecho + numeroCaminhoes[2];

                    frete.NumeroCaminhaoPequenoTrecho = numeroCaminhoes[0];
                    frete.NumeroCaminhaoMedioTrecho = numeroCaminhoes[1];
                    frete.NumeroCaminhaoGrandeTrecho = numeroCaminhoes[2];

                    frete.CustoTrechoPequeno.Add(distanciaTrecho * frete.caminhoes["PEQUENO"] * frete.NumeroCaminhaoPequenoTrecho);
                    frete.CustoTrechoMedio.Add(distanciaTrecho * frete.caminhoes["MÉDIO"] * frete.NumeroCaminhaoMedioTrecho);
                    frete.CustoTrechoGrande.Add(distanciaTrecho * frete.caminhoes["GRANDE"] * frete.NumeroCaminhaoGrandeTrecho);

                    frete.CustoTrechoTotal = frete.CustoTrechoPequeno[i] + frete.CustoTrechoMedio[i] + frete.CustoTrechoGrande[i];

                    frete.CustoCaminhaoPequenoTotal = frete.CustoCaminhaoPequenoTotal + frete.CustoTrechoPequeno[i];
                    frete.CustoCaminhaoMedioTotal = frete.CustoCaminhaoMedioTotal + frete.CustoTrechoMedio[i];
                    frete.CustoCaminhaoGrandeTotal = frete.CustoCaminhaoGrandeTotal + frete.CustoTrechoGrande[i];

                    frete.CustoTotal = frete.CustoTotal + frete.CustoTrechoTotal;

                    Console.WriteLine($"\nTransportando os seguintes produtos e quantidades: ");
                    int count = 0;
                    foreach (var par in frete.produtos)
                    {
                        if (frete.QuantidadesProdutos[count] > 0)
                        {
                            Console.WriteLine($"Produto {par.Key} quantidade {frete.QuantidadesProdutos[count]} peso {par.Value}");
                        }
                        count++;
                    }

                    frete.CustoUnitarioMedio = (frete.CustoTrechoTotal / frete.QuantidadeTotalProdutosParaTrecho(frete.QuantidadesProdutos));
                    Console.WriteLine($"\nUtilizando {frete.NumeroCaminhaoPequenoTrecho} caminhoes pequenos, {frete.NumeroCaminhaoMedioTrecho} caminhoes medios, {frete.NumeroCaminhaoGrandeTrecho} caminhoes grandes, para o trecho");
                    Console.WriteLine($"Resultando em um valor total de R$ {Math.Round(frete.CustoTrechoTotal, 2)} para o trecho, sendo R${Math.Round(frete.CustoUnitarioMedio, 2)} o custo unitario médio pelo trecho");

                    Console.WriteLine($"\nO caminhao chegou na {frete.CidadesLista[i + 1]}, deseja descarregar algum produto?");

                    Console.WriteLine($"\nDigite 1 para sim ou 2 para não:");
                    var descarregarProduto = Console.ReadLine();

                    if (descarregarProduto == "1")
                    {
                        int posicao = 0;
                        foreach (var linha in frete.produtos)
                        {
                            if (frete.QuantidadesProdutos[posicao] > 0)
                            {
                                Console.WriteLine($"Gostaria de descarregar quantos desse item: {linha.Key}?");
                                int quantidadeProdutoDescarregado = Convert.ToInt32(Console.ReadLine());

                                if (frete.QuantidadesProdutos[posicao] >= quantidadeProdutoDescarregado && quantidadeProdutoDescarregado >= 0)
                                {
                                    frete.QuantidadesProdutos[posicao] = frete.QuantidadesProdutos[posicao] - quantidadeProdutoDescarregado;
                                    posicao = posicao + 1;
                                }
                                else
                                {
                                    Console.WriteLine($"Não é possivel retirar uma quantidade maior do que a quantidade cadastrada");
                                }
                            }
                        }
                    }
                }

                Console.WriteLine($"\nO custo total de todos os trechos será de {Math.Round(frete.CustoTotal, 2)}");
                frete.CustoMedioKM = frete.CustoTotal / frete.DistanciaTotal;
                frete.CustoMedioTipoProduto = frete.CustoTotal / frete.TotaItensTransportados;
                return frete;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nErro Inesperado, tente novamente");
                return frete;
            }
        }

        public void ConsultarDadosFretes(CadastroFrete cadastroFrete)
        {
            foreach (Frete frete in cadastroFrete.Transportes)
            {
                Console.WriteLine("\nO frete cadastrado tem os seguintes dados:");
                Console.WriteLine($"\nO valor total do frete é de: R${Math.Round(frete.CustoTotal, 2)}");
                Console.WriteLine($"\nO valor médio por KM do frete é de: R${Math.Round(frete.CustoMedioKM, 2)}");
                Console.WriteLine($"\nO custo médio por produto do frete é de: R${Math.Round(frete.CustoMedioTipoProduto, 2)}");

                double custoTotalPorTrecho = 0;
                for (int i = 0; i < frete.CustoTrechoGrande.Count; i++)
                {
                    custoTotalPorTrecho = frete.CustoTrechoPequeno[i] + frete.CustoTrechoMedio[i] + frete.CustoTrechoGrande[i];
                    Console.WriteLine($"\nO custo total por trecho do frete é de: R${Math.Round(custoTotalPorTrecho, 2)}");
                }

                Console.WriteLine($"\nO custo total para a modalidade pequeno é de: R${Math.Round(frete.CustoCaminhaoPequenoTotal, 2)}");
                Console.WriteLine($"\nO custo total para a modalidade medio é de: R${Math.Round(frete.CustoCaminhaoMedioTotal, 2)}");
                Console.WriteLine($"\nO custo total para a modalidade grande é de: R${Math.Round(frete.CustoCaminhaoGrandeTotal, 2)}");
            }
        }



        public List<string> AdicionaListaCidades()
        {
            List<string> cidadesLista = new List<string>();
            try
            {
                Console.WriteLine($"\nQuantas cidades você quer adicionar no percurso?");
                int numeroDeCidades = Convert.ToInt32(Console.ReadLine());


                for (int paradas = 0; paradas < numeroDeCidades; paradas++)
                {
                    Console.WriteLine($"\nDigite o nome da cidade da proxima parada: ");
                    string cidade = Console.ReadLine();
                    if (gerenciadorExcel.ConsultaCidadeExiste(cidade))
                    {
                        cidadesLista.Add(cidade);
                    }
                    else
                    {
                        Console.WriteLine($"\nNão foi possivel adicionar a cidade pois não foi encontrada");
                    }
                }

                Console.WriteLine($"\na lista de cidades é");
                foreach (string cidade in cidadesLista)
                {
                    Console.WriteLine($"- {cidade}");
                }
                return cidadesLista;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nErro Inesperado, tente novamente");
                return cidadesLista;
            }
        }

        public Frete AdicionarProdutoAoFrete(Frete frete)
        {

            Console.WriteLine($"\nGostaria de cadastrar mais algum produto?");
            Console.WriteLine($"Digite 1 para Sim");
            Console.WriteLine($"Digite 2 para Nao");

            string adicionarProduto = Console.ReadLine();

            if (adicionarProduto != null && adicionarProduto.Equals("1"))
            {
                Console.WriteLine($"\nQuantos produtos gostaria de cadastrar?");
                int quantidadeProdutos = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < quantidadeProdutos; i++)
                {
                    Console.WriteLine($"\nDigite o nome do produto a ser adicionado neste frete");
                    string novoProduto = Console.ReadLine();

                    Console.WriteLine($"\nDigite o peso do novo produto em KG");
                    double novoPeso = Convert.ToDouble(Console.ReadLine());

                    frete.produtos.Add(novoProduto, novoPeso);

                    Console.WriteLine($"\nProduto cadastrado com sucesso!");
                }
            }

            return frete;
        }



    }
}
