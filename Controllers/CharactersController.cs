using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using webapimarvel.Models;
using static webapimarvel.Models.RestConnection;
using System.Text;
using System.Security.Cryptography;
using ApiMarvelCapco.Models;
using Newtonsoft.Json;
using WebApiMarvel.Models;

namespace APIMarvelCapco.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharactersController : ControllerBase
    {
        private static string ts = DateTime.Now.Ticks.ToString();
        private static string publicKey = "8170bdf33d2cf70a32842e289c67a882";
        private static string privateKey = "66b323fcfd4260de90c894920c2aee10d099f5f4";
        private static string hash = GerarHash(ts, privateKey, publicKey);

        private static readonly HttpClient client = new HttpClient();

        [HttpGet]
        public object REST<T>()
        {
            Characters Personagem;

            //Limpa todo o cabeçalho do client
            client.DefaultRequestHeaders.Accept.Clear();

            //Accept ContentType
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
                );

            client.DefaultRequestHeaders.Add("User-Agent", "Marvel API");

            HttpResponseMessage response = client.GetAsync("https://gateway.marvel.com/v1/public/characters?ts=" + ts + "&apikey=" + publicKey + "&hash=" + hash).Result;

            response.EnsureSuccessStatusCode();
            var conteudo =
                response.Content.ReadAsStringAsync().Result;

            dynamic resultado = JsonConvert.DeserializeObject(conteudo);

            Personagem = new Characters();
            Personagem.name = resultado.data.results[0].name;

            return Personagem;
        }

        // [HttpGet]
        // public object SerializeCharacters()
        // {
        //     List<Results> ListCharacters = new List<Results>();

        //     SerializeCharacters(ListCharacters, "https://gateway.marvel.com/v1/public/characters?ts=" + ts + "&apikey=" + publicKey + "&hash=" + hash);

        //     var Personagem = new
        //     {
        //         Personagens = ListCharacters.Count(),
        //         //TotalPersonagens = ListCharacters.Count(),
        //         //Series = ListCharacters.Count(),
        //         //PesoFinal = Characters.Sum(x => Double.Parse(x.Mass, CultureInfo.InvariantCulture)),
        //         //MediaDePeso = Characters.Sum(x => Double.Parse(x.Mass, CultureInfo.InvariantCulture)) / Characters.Count()

        //     };

        //     return Personagem;

        // }

        // private static void SerializeCharacters(List<Results> CharactersList, string MarvelPoint)
        // {
        //     var retornoStream = REST<Results>(MarvelPoint);
        // }

        private static string GerarHash(string ts, string privateKey, string publicKey)
        {
            byte[] bytes =
                Encoding.UTF8.GetBytes(ts + privateKey + publicKey);
            var gerador = MD5.Create();
            byte[] bytesHash = gerador.ComputeHash(bytes);
            return BitConverter.ToString(bytesHash)
                .ToLower().Replace("-", String.Empty);
        }
    }
}
