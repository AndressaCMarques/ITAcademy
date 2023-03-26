using System;

namespace itacademy
{
    internal class Program
    {

        static void Main(string[] args)
        {
            bool mostrarMenu = true;
            while (mostrarMenu)
            {
                mostrarMenu = menuPrincipal();
            }

        }

        private static bool menuPrincipal()
        {
            Menu menu = new Menu();

            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("Digite 1 para cotar o frete entre duas cidades por tamanho de caminhão");
            Console.WriteLine("Digite 2 para cadastrar um frete");
            Console.WriteLine("Digite 3 para sair");

            switch (Console.ReadLine())
            {
                case "1":
                    return menu.MenuOpcao1();
                case "2":
                    return menu.MenuOpcao2();
                case "3":
                    return false;
                default:
                    return true;
            }
        }


    }
}
