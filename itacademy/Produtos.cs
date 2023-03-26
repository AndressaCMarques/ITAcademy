using System;
using System.Collections.Generic;
using System.Text;

namespace itacademy
{
    internal class Produtos
    {
        public IDictionary<string, double> produtos = new Dictionary<string, double>();

        public Produtos()
        {
            produtos.Add("CELULAR", 0.5);
            produtos.Add("GELADEIRA", 60);
            produtos.Add("FREEZER", 100);
            produtos.Add("CADEIRA", 5);
            produtos.Add("LUMINÁRIA", 0.8);
            produtos.Add("LAVADORA DE ROUPA", 120);

            // double peso = produtos["CELULAR"];
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


        //public double RetornaPesoTotal(double pesoProduto, string cidadeB)
        //{

        //}
    }
}
