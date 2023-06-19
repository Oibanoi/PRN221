using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SignalRAssignment.Models;

namespace SignalRAssignment.Pages.SignUp
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public Account account { get; set; }
        private readonly PizzaStoreContext _context;
        public IndexModel(PizzaStoreContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            account = new Account();
        }
        public void OnPost()
        {
            account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
            var check_account = _context.Accounts.Where(a => a.UserName == account.UserName).FirstOrDefault();
            if (check_account == null)
            {
                _context.Accounts.Add(account);
                _context.SaveChanges();
                Response.Redirect("/signin");
            }
            else
            {
                ModelState.AddModelError("Error", "Username already exists");
            }
           
        }
    }
}
