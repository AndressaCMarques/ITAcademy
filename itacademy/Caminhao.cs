using System;
using System.Collections.Generic;
using System.Text;

namespace itacademy
{
    internal class Caminhao
    {

        public double calculaFrete(double distancia, string modalidadeCaminhao)
        {
            double frete = 0;

            if (modalidadeCaminhao == "pequeno")
            {
                frete = distancia * 4.87;
                return frete;
            }
            if (modalidadeCaminhao == "médio")
            {
                frete = distancia * 11.92;
                return frete;
            }
            if (modalidadeCaminhao == "grande")
            {
                frete = distancia * 27.44;
                return frete;
            }
            //se o usuário não seguir a condição, isso é, não escrever o que deveria, retorna o valor inicial que estava estipulado o frete que é 0
            return frete;
        }





    }
}
