using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UserInterface.Pages
{
    public class DnD : PageModel
    {
        private readonly HttpClient _client = new();
        private new const string Url = "https://localhost:5003/Monster";
        public Stats Character { get; set; }
        public Stats Monster { get; set; }
        
        public async Task<IActionResult> OnGet()
        {
            if (!TempData.TryGetValue("UserStats", out var json))
            {
                return Redirect("/");
            }

            try
            {
                Character = JsonSerializer.Deserialize<Stats>((string) json);
            }
            catch
            {
                return Redirect("/");
            }
            
            Monster = await _client.GetFromJsonAsync<Stats>(Url);
            return Page();
        }
        
    }
}