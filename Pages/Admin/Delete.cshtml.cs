using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SignalRAssignment.Models;

namespace SignalRAssignment.Pages.Admin
{
    public class DeleteModel : PageModel
    {
        private readonly PizzaStoreContext _context;

        public DeleteModel(PizzaStoreContext context)
        {
            _context = context;
        }
        public void OnGet(string id)
        {
           
            if (HttpContext.Session.GetString("role") != "1")
            {
                Response.Redirect("/signin");
            }
            int product_id = Convert.ToInt32(id);
            var product = _context.Products.Where(p => p.ProductID == product_id).FirstOrDefault();
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            Response.Redirect("/admin");

        }
        
    }
}
