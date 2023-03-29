using System;
using System.Collections.Generic;

namespace itacademy
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Menu menu = new Menu();
            CadastroFrete cadastroFrete = new CadastroFrete();
            
            menuPrincipal();

            bool mostrarMenu = true;
            while (mostrarMenu)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        menu.CotarFrete();
                        mostrarMenu = true;
                        menuPrincipal();
                        break;
                    case "2":
                        Frete freteMenu = menu.CadastrarFrete();
                        cadastroFrete.Transportes.Add(freteMenu);
                        mostrarMenu = true;
                        menuPrincipal();
                        break;
                    case "3":
                        menu.ConsultarDadosFretes(cadastroFrete);
                        mostrarMenu = true;
                        menuPrincipal();
                        break;
                    case "4":
                        Console.Clear();
                        mostrarMenu = true;
                        menuPrincipal();
                        break;
                    case "5":
                        mostrarMenu = false;
                        menuPrincipal();
                        break;
                    default:
                        mostrarMenu = true;
                        menuPrincipal();
                        break;
                }
            }
        }

        private static void menuPrincipal()
        {
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine("Digite 1 para cotar o frete entre duas cidades por modalidade de caminhão");
            Console.WriteLine("Digite 2 para cadastrar um frete");
            Console.WriteLine("Digite 3 para mostrar dados de cada frete cadastrado");
            Console.WriteLine("Digite 4 para limpar o console");
            Console.WriteLine("Digite 5 para sair");
        }




    }
}
