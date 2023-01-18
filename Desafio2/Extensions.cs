using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio2
{

    //Extensões para facilitar na hora de imprimir as variáveis do tipo float
    public static class Extensions
    {
        public static string formatar(this float valor, int casas)
        {
            string formatCasas = "F" + casas.ToString();
            return valor.ToString(formatCasas, CultureInfo.CreateSpecificCulture("pt-BR"));
        }

        public static string formatar(this float? valor, int casas)
        {
            string formatCasas = "F" + casas.ToString();
            
            return float.Parse(valor.ToString()).ToString(formatCasas, CultureInfo.CreateSpecificCulture("pt-BR"));
        }
    }
}
