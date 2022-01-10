using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using BusinessLogic.FightLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserInterface.Models;

namespace UserInterface.Pages
{
    public class UserStats : PageModel
    {
        [BindProperty] 
        public User Character { get; set; }

        public Monster Monster { get; set; }

        //public Opponents Opponents { get; set; }
        public FightResult Result { get; set; }
        
        private readonly HttpClient _client = new();
        private new const string DBUrl = "https://localhost:5003/Monster";
        private new const string BLUrl = "https://localhost:5005/GameFight/Fight";
        public void OnGet()
        {
            
        }
        
        public async Task OnPostAsync()
        {
            if (!ModelState.IsValid) return;
            Monster = await _client.GetFromJsonAsync<Monster>(DBUrl);
            var fightResult = await _client.PostAsJsonAsync(BLUrl, 
                new Opponents{Monster = Monster, User = Character});
            Result = await fightResult.Content.ReadFromJsonAsync<FightResult>();
            
        }
    }
}