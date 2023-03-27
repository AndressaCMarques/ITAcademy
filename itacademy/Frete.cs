using System;
using System.Collections.Generic;
using System.Text;

namespace itacademy
{
    internal class Frete
    {
        public IDictionary<string, double> produtos = new Dictionary<string, double>();
        public IDictionary<string, double> caminhoes = new Dictionary<string, double>();
        List<string> cidadesLista = new List<string>();
        List<int> quantidadesProdutos = new List<int>();

        double distanciaTotal;
        List<double> distanciaTrecho = new List<double>();

        double pesoTotal;

        List<double> custoTrecho = new List<double>();
        double custoTotal;

        double custoMedioKM;
        double custoMedioTipoProduto;
        int numeroCaminhaoPequeno;
        int numeroCaminhaoMedio;
        int numeroCaminhaoGrande;
        int numeroVeiculosTotal;
        int totaItensTransportados;
        double custoUnitarioMedio;
        int custoCaminhaoPequeno;
        int custoCaminhaoMedio;
        int custoCaminhaoGrande;

        //custo total do frete
        //custo medio por km
        //custo medio por produto
        //custo total por trecho
        //custo total para cada modalidade
        //numero total de itens

        public Frete()
        {
            produtos.Add("CELULAR", 0.5);
            produtos.Add("GELADEIRA", 60);
            produtos.Add("FREEZER", 100);
            produtos.Add("CADEIRA", 5);
            produtos.Add("LUMINÁRIA", 0.8);
            produtos.Add("LAVADORA DE ROUPA", 120);

            caminhoes.Add("PEQUENO", 4.87);
            caminhoes.Add("MÉDIO", 11.92);
            caminhoes.Add("GRANDE", 27.44);

        }

        public double CalculaFrete(double distancia, string modalidadeCaminhao)
        {
            double frete = 0;

            foreach (var par in caminhoes)
            {
                if (modalidadeCaminhao.ToUpper() == par.Key)
                {
                    frete = distancia * par.Value;
                }
            }

            return frete;
        }

        public double CalcularPesoTotal(IDictionary<string, double> produtos, List<int> quantidadesProdutos)
        {
            double pesoTotal = 0;
            int count = 0;

            foreach(var par in produtos)
            {
                pesoTotal = pesoTotal + (quantidadesProdutos[count] * par.Value) ;
                count++;
            }

            return pesoTotal;
        }

        public int ImprimeTotalItensTransportados(IDictionary<string, double> produtos, List<int> quantidadesProdutos)
        {
            int total = 0;
            int count = 0;
            Console.WriteLine("\nLista de produtos transportados:");
            foreach (var par in produtos)
            {
                if (quantidadesProdutos[count] > 0)
                {
                    Console.WriteLine($"Produto {par.Key} quantidade {quantidadesProdutos[count]}");
                    total = total + quantidadesProdutos[count];
                }
                count++;
            }

            Console.WriteLine($"quantidade total: {total}");
            return total;
        }

        public int QuantidadeTotalProdutos(List<int> quantidadesProdutos)
        {
            int total = 0;
            foreach(var qnt in quantidadesProdutos)
            {
                total = total + qnt;
            }
            return total;
        } 





        public double DistanciaTotal { get => distanciaTotal; set => distanciaTotal = value; }
        public double CustoTotal { get => custoTotal; set => custoTotal = value; }
        public double CustoMedioKM { get => custoMedioKM; set => custoMedioKM = value; }
        public double CustoMedioTipoProduto { get => custoMedioTipoProduto; set => custoMedioTipoProduto = value; }
        public int TotaItensTransportados { get => totaItensTransportados; set => totaItensTransportados = value; }
        public List<string> CidadesLista { get => cidadesLista; set => cidadesLista = value; }
        public List<int> QuantidadesProdutos { get => quantidadesProdutos; set => quantidadesProdutos = value; }
        public double PesoTotal { get => pesoTotal; set => pesoTotal = value; }
        public List<double> CustoTrecho { get => custoTrecho; set => custoTrecho = value; }
        public List<double> DistanciaTrecho { get => distanciaTrecho; set => distanciaTrecho = value; }
        public int NumeroCaminhaoPequeno { get => numeroCaminhaoPequeno; set => numeroCaminhaoPequeno = value; }
        public int NumeroCaminhaoMedio { get => numeroCaminhaoMedio; set => numeroCaminhaoMedio = value; }
        public int NumeroCaminhaoGrande { get => numeroCaminhaoGrande; set => numeroCaminhaoGrande = value; }
        public int NumeroVeiculosTotal { get => numeroVeiculosTotal; set => numeroVeiculosTotal = value; }
        public double CustoUnitarioMedio { get => custoUnitarioMedio; set => custoUnitarioMedio = value; }
        public int CustoCaminhaoPequeno { get => custoCaminhaoPequeno; set => custoCaminhaoPequeno = value; }
        public int CustoCaminhaoMedio { get => custoCaminhaoMedio; set => custoCaminhaoMedio = value; }
        public int CustoCaminhaoGrande { get => custoCaminhaoGrande; set => custoCaminhaoGrande = value; }
    }
}
