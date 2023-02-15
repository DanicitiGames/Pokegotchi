using PokeProject.Objects;
using System.Text.Json;
using RestSharp;

namespace PokeProject.Request
{
    public class PokeRequest
    {
        public Pokemon GetPokemon(string pokemon)
        {
            var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{pokemon.ToLower()}");
            RestRequest request = new RestRequest("", Method.Get);
            var response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine(response.ErrorMessage);
                return null;
            }
            if (response.Content == null) { return null; }
            return JsonSerializer.Deserialize<Pokemon>(response.Content);
        }
        public bool ValidatePokemon(string pokemon)
        {
            if(pokemon == null) { return false; }
            if(pokemon == "") { return false; }
            var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{pokemon.ToLower()}");
            RestRequest request = new RestRequest("", Method.Get);
            var response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return false;
            }
            if (response.Content == null) { return false; }
            return true;
        }
    }
}
