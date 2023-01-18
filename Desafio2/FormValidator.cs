using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Desafio2
{
    public class FormValidator
    {
        public FormErros erros = new FormErros();

        public URL url { get; private set; }

        public FormValidator()
        {
            url = new URL();
        }

        public bool isValid(string moedaOrigem, string moedaDestino, string strValor) 
        {     
            erros.Clear();

            moedaOrigem = moedaOrigem.Trim();
            if (moedaOrigem.Length != 3) erros.AddErro(CampoForm.MOEDA_ORIGEM, "Moeda de Origem deve ter 3 caracteres!");
            else
            {
                foreach(MoedasEnum moedas in Enum.GetValues(typeof(MoedasEnum)))
                {
                    if(moedas.ToString().Equals(moedaOrigem))
                    {
                        url.moedaOrigem = moedaOrigem;
                        break;
                    }
                }
                if(url.moedaOrigem.Equals(string.Empty)) erros.AddErro(CampoForm.MOEDA_ORIGEM, "Moeda de Origem inválida!");
            }

            moedaDestino = moedaDestino.Trim();
            if (moedaDestino.Length != 3) erros.AddErro(CampoForm.MOEDA_DESTINO, "Moeda de Destino deve ter 3 caracteres!");
            else
            {
                bool moedaValida = false;
                foreach (MoedasEnum moeda in Enum.GetValues(typeof(MoedasEnum)))
                {
                    if (moeda.ToString().Equals(moedaDestino))
                    {
                        moedaValida = true;
                        break;
                    }
                }
                if (!moedaValida) erros.AddErro(CampoForm.MOEDA_DESTINO, "Moeda de Destino inválida!");

                else if (moedaDestino.Equals(moedaOrigem)) erros.AddErro(CampoForm.MOEDA_DESTINO, "Moeda de Destino deve ser diferente da moeda de Origem!");

                else url.moedaDestino = moedaDestino;

            }

            strValor = strValor.Trim();
            float valor;

            try
            {
                valor = float.Parse(strValor);

                if (valor <= 0) erros.AddErro(CampoForm.VALOR, "Valor deve ser maior do que zero!");

                else url.amount = valor;
            }
            catch(Exception) 
            {

            }

            return erros.isEmpty();
        }
    }
}
