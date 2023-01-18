using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace Desafio2
{
    //Classe que fará a comunicação com a API
    public class API
    {
        //String contendo o resultado obtido pela API que será desserializado posteriormente
        public string Json { get; private set; }

        public async void conectarComAPI(string url)
        {
            using HttpClient client = new();
            client.DefaultRequestHeaders.Accept.Clear();

            this.Json = ProcessRepositoriesAsync(client, url).Result;

            //Para guardar o JSON, presisei fazer com que a Task tivesse retorno
            static async Task<string> ProcessRepositoriesAsync(HttpClient client, string url)
            {
                return await client.GetStringAsync(url);
            }
        }
    }
}
