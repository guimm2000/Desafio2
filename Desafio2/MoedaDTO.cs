using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio2
{
    //Classe que vai receber o Json desserializado
    public class MoedaDTO
    {
        public Info info { get; set; }
        public float result { get; set; }

        public class Info
        {
            public float rate { get; set; }
        }

    }
}
