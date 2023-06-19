using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SignalRAssignment.Models;

namespace Assignment2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly PizzaStoreContext _context;
        public List<Product> Products { get; set; }
        public IndexModel(PizzaStoreContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Products = _context.Products.Include(p => p.Category).ToList();                
        }
    }
}