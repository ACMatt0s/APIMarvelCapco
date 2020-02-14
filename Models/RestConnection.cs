using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace webapimarvel.Models
{
    public class RestConnection
    {

        private static readonly HttpClient client = new HttpClient();

        public static T REST<T>(string MarvelPoint)
        {
            //Limpa todo o cabeçalho do client
            client.DefaultRequestHeaders.Accept.Clear();

            //Accept ContentType
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
                );

            client.DefaultRequestHeaders.Add("User-Agent", "Marvel API");

            HttpResponseMessage response = client.GetAsync(MarvelPoint).Result;

            response.EnsureSuccessStatusCode();
            var conteudo =
                response.Content.ReadAsStringAsync().Result;

            dynamic resultado = JsonConvert.DeserializeObject(conteudo);

            //var stream = await client.GetStreamAsync(MarvelPoint);
            //var retornoStream = await JsonSerializer.DeserializeAsync<T>(conteudo);

            

            return (T)resultado;
        }
    }
}