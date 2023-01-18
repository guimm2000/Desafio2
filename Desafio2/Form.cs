using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio2
{
    public class Form
    {
        public string MoedaOrigem { get; private set; }
        public string MoedaDestino { get; private set; }
        public string Valor { get; private set; }

        public void lerDados()
        {
            lerDados(null);
        }

        public void lerDados(FormValidator? validador)
        {
            if(validador != null)
            {
                Console.WriteLine("\n---------------------------- ERROS ---------------------------");

                // Percorre cada item do Enumerável
                foreach (CampoForm campo in Enum.GetValues(typeof(CampoForm)))
                {
                    var msg = validador.erros.GetErrorMessage(campo);

                    if (msg.Length > 0)
                        Console.WriteLine("{0}: {1}", campo.ToString(), msg);
                }

                Console.WriteLine("--------------------------------------------------------------");
            }

            if(validador == null || validador.erros.HasErro(CampoForm.MOEDA_ORIGEM))
            {
                Console.Write("Moeda origem: ");
                MoedaOrigem = Console.ReadLine();

                Controlador.Stop(MoedaOrigem);
            }

            if (validador == null || validador.erros.HasErro(CampoForm.MOEDA_DESTINO))
            {
                Console.Write("Moeda destino: ");
                MoedaDestino = Console.ReadLine();
            }

            if (validador == null || validador.erros.HasErro(CampoForm.VALOR))
            {
                Console.Write("Valor: ");
                Valor = Console.ReadLine();
            }
        }
    }
}
