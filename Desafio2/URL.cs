using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio2
{
    //Classe responsável por obter a URL que será usada na requisição HTTP
    public class URL
    {
        public float? amount { get; set; } = 0;
        public string? moedaOrigem { get; set; } = string.Empty;
        public string moedaDestino { get; set; } = string.Empty;

        private string url;
        public string Url
        {
            get
            {
                string URL = url;
                URL = URL.Insert(43, moedaOrigem);
                URL = URL.Insert(50, moedaDestino);
                URL += amount.ToString();
                return URL;
            }

            private set
            {
                url = value;
            }
        }
        
        public URL()
        {
            Url = "https://api.exchangerate.host/convert?from=&to=&amount=";
        }
    }
}
