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
        public User Character { get; set; }
        public Monster Monster { get; set; }
        
        public async Task<IActionResult> OnGet()
        {
            Monster = await _client.GetFromJsonAsync<Monster>(Url);
            return Page();
        }
        
    }
}