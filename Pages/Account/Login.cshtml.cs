using Trabajo_Alquiler.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Trabajo_Alquiler.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]

        public string User {get; set; }
        public void OnGet()
        {
        }

        public void OnPost() 
        {
            Console.WriteLine("User: " + User.Email + " Password: " + User.Password);
        }
    }
}
