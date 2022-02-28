using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace DadJokes.Pages
{
    public class IndexModel : PageModel
    {

        public string Joke;

        public void OnGet()
        {
            if(DadJokeManager.DadJokes.Count < 17)
            {
                DadJokeManager.DadJokes.Add(DadJokeManager.GetDadJoke());
                Joke = DadJokeManager.GetTopJoke();

            }
            else
            {
                DadJokeManager.DadJokes.Clear();
                DadJokeManager.DadJokes.Add(DadJokeManager.GetDadJoke());
                Joke = DadJokeManager.GetTopJoke();

            }

        }
    }
}