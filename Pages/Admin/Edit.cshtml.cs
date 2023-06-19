using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SignalRAssignment.Models;

namespace SignalRAssignment.Pages.Admin
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Product product { get; set; }
        private readonly PizzaStoreContext _context;
        [BindProperty]
        public List<Category> Categories { get; set; }
        public EditModel(PizzaStoreContext context)
        {
            _context = context;
        }
        public void OnGet(string id)
        {
            if (HttpContext.Session.GetString("role") != "1")
            {
                Response.Redirect("/signin");
            }
            var id_prd = Convert.ToInt32(id);
            Categories = _context.Categories.ToList();
            product = _context.Products.Where(p => p.ProductID == id_prd).FirstOrDefault();
        }
        public void OnPost()
        {

            if (HttpContext.Session.GetString("role") != "1")
            {
                Response.Redirect("/signin");
            }
            product.QuantityPerUnit = 1;
            product.SupplierID = 1;

            _context.Products.Update(product);
            _context.SaveChanges();
            Response.Redirect("/admin");
        }
    }
}
