using System;
using System.Collections.Generic;
using System.Text;

namespace itacademy
{
    internal class CadastroFrete
    {

        List<Frete> transportes = new List<Frete>();

        public CadastroFrete()
        {
            
        }

        public List<Frete> Transportes { get { return transportes; } }
    }
}
