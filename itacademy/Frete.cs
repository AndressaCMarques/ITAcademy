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

        double distanciaTotal;
        double distanciaTrecho;
        double custoTotal;
        double custoTrecho;
        double custoMedioKM;
        double custoMedioTipoProduto;
        int numeroVeiculos;
        int totaItensTransportados;

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

        public double calculaFrete(double distancia, string modalidadeCaminhao)
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

        public double calcularPesoTotal(int quantidadeCelular, int quantidadeGeladeira, int quantidadeFreezer, int quantidadeCadeira, int quantidadeLuminaria, int quantidadeLavadora)
        {
            double pesoTotal;

            pesoTotal = quantidadeCelular * produtos["CELULAR"];
            pesoTotal = pesoTotal + (quantidadeGeladeira * produtos["GELADEIRA"]);
            pesoTotal = pesoTotal + (quantidadeFreezer * produtos["FREEZER"]);
            pesoTotal = pesoTotal + (quantidadeCadeira * produtos["CADEIRA"]);
            pesoTotal = pesoTotal + (quantidadeLuminaria * produtos["LUMINÁRIA"]);
            pesoTotal = pesoTotal + (quantidadeLavadora * produtos["LAVADORA DE ROUPA"]);

            return pesoTotal;
        }



        public double DistanciaTotal { get => distanciaTotal; set => distanciaTotal = value; }
        public double DistanciaTrecho { get => distanciaTrecho; set => distanciaTrecho = value; }
        public double CustoTotal { get => custoTotal; set => custoTotal = value; }
        public double CustoTrecho { get => custoTrecho; set => custoTrecho = value; }
        public double CustoMedioKM { get => custoMedioKM; set => custoMedioKM = value; }
        public double CustoMedioTipoProduto { get => custoMedioTipoProduto; set => custoMedioTipoProduto = value; }
        public int NumeroVeiculos { get => numeroVeiculos; set => numeroVeiculos = value; }
        public int TotaItensTransportados { get => totaItensTransportados; set => totaItensTransportados = value; }
        public List<string> CidadesLista { get => cidadesLista; set => cidadesLista = value; }
    }
}
