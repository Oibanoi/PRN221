using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SignalRAssignment.Models;

namespace SignalRAssignment.Pages.Admin
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Product product { get; set; }
        private readonly PizzaStoreContext _context;
        [BindProperty]
        public List<Category> Categories { get; set; }
        public CreateModel(PizzaStoreContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            if (HttpContext.Session.GetString("role") != "1")
            {
                Response.Redirect("/index");
            }
            Categories = _context.Categories.ToList();
            product = new Product();
        }
        public void OnPost()
        {

            if (HttpContext.Session.GetString("role") != "1")
            {
                Response.Redirect("/index");
            }
            product.QuantityPerUnit = 1;
            product.SupplierID = 1;
            _context.Products.Add(product);
            _context.SaveChanges();
            Response.Redirect("/admin");
        }
    }
}
