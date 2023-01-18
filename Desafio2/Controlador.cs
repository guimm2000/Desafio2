using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Desafio2
{
    public class Controlador
    {
        private static InterfaceUsuario UI;

        public static void Start()
        {
            UI = new InterfaceUsuario();
            UI.Inicio();

            while (UI.Conversor());

        }
        
        public static void Stop(string moedaOrigem) 
        {
            if(string.IsNullOrEmpty(moedaOrigem)) Environment.Exit(0);
        }

        public static Moeda chamarAPI(string url)
        {
            API api = new API();
            api.conectarComAPI(url);

            if (string.IsNullOrEmpty(api.Json))
            {
                return null;
            }

            else
            {
                MoedaDTO moedaDto = new MoedaDTO();
                try
                {
                    moedaDto = JsonSerializer.Deserialize<MoedaDTO>(api.Json);
                    return new Moeda(moedaDto.info.rate, moedaDto.result);
                }
                catch(Exception ex)
                {
                    return null;
                }
            }
        }
    }
}
