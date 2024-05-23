using Trabajo_Alquiler.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Trabajo_Alquiler.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]

        public User User {get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync() 
        {
        if(!ModelState.IsValid) return Page();

            if (User.Email == "Santiago@gmail.com" && User.Password == "12345") 
            {
                return RedirectToPage("/index");
            }
            return Page();
        }

       /* public void OnPost() {
            Console.WriteLine("User: " + User.Email + " Password: " + User.Password);*/
        
    }
}
