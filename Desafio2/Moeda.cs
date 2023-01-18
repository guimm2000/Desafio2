using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio2
{
    //Como a moeda não vai receber o Json direto, ela ficou um pouco diferente da classa MoedaDTO
    public class Moeda
    { 
        public float rate { get; private set; }
        public float result { get; private set; }

        public Moeda(float rate, float result) 
        { 
            this.rate = rate;
            this.result = result;
        }

    }
}
