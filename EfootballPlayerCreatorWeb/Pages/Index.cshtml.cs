using EfootballPlayerCreatorWeb.Models;
using EfootballPlayerCreatorWeb.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Numerics;

namespace EfootballPlayerCreatorWeb.Pages
{
    [IgnoreAntiforgeryToken]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }

        public JsonResult OnPostCalculateOverall([FromBody] Player player)
        {
            player.CalculateOverall();

            return new JsonResult(new
            {
                player.Overall
            });
        }
    }
}
