using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SignalRAssignment.Models;

namespace SignalRAssignment.Pages.SignIn
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public Account account { get; set;}
        private readonly PizzaStoreContext _context;
        public IndexModel(PizzaStoreContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            account = new Account();
        }
        public IActionResult OnPost()
        {
            var account_check = _context.Accounts.Where(a => a.UserName == account.UserName).FirstOrDefault();
            if (account_check != null)
            {
                if (BCrypt.Net.BCrypt.Verify(account.Password, account_check.Password))
                {
                    HttpContext.Session.SetString("username", account_check.UserName);
                    HttpContext.Session.SetString("role", account_check.Type.ToString());
                    return RedirectToPage("/Index");
                }
                else
                {
                    ModelState.AddModelError("Error", "Password is incorrect");
                    return Page();
                }
            }
            else
            {
                ModelState.AddModelError("Error", "Username does not exist");
                return Page();
            }
        }
       
    }
}
