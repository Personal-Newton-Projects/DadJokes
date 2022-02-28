using DadJokes.Models;
using System.Text.Json;
using System.Net.Http.Headers;

namespace DadJokes.API
{
    public static class DadJokeManager
    {

        public static List<DadJoke> DadJokes = new List<DadJoke>();

        public static DadJoke GetDadJoke()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = httpClient.GetAsync("https://icanhazdadjoke.com").GetAwaiter().GetResult();
            var apiResponse = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonSerializer.Deserialize<DadJoke>(apiResponse);
        }

        public static string GetJokeFromList(int index)
        {
            if(DadJokes.Count > 0)
            {
                return DadJokes[index].joke;
            }
            else
            {
                return null;
            }
        }

        public static string GetTopJoke()
        {
            return DadJokes[DadJokes.Count - 1].joke;
        }


    }
}
