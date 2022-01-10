using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UserInterface.Pages
{
    public class UserStats : PageModel
    {
        [BindProperty] 
        public Stats Character { get; set; }

        public void OnGet()
        {
            
        }
        
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();
            TempData["UserStats"] = JsonSerializer.Serialize(Character);
            return Redirect("/DnD");
        }
    }
}