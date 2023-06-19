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
        public IActionResult OnGet(string id)        
        {
            if (id == null)

                Response.Redirect("/index");
            if (HttpContext.Session.GetString("role") != "1" || HttpContext.Session.GetString("username") == null)
            {

                return Redirect("/index");
            }
            else
            { 
                    var id_prd = Convert.ToInt32(id);
                    Categories = _context.Categories.ToList();
                    product = _context.Products.Where(p => p.ProductID == id_prd).FirstOrDefault();               
               
            }
            return Page();
        }
        public void OnPost()
        {

            if (HttpContext.Session.GetString("role") != "1" || HttpContext.Session.GetString("username") == null)
            {
                Response.Redirect("/index");
            }
            else
            {
                product.QuantityPerUnit = 1;
                product.SupplierID = 1;

                _context.Products.Update(product);
                _context.SaveChanges();
                Response.Redirect("/admin");
            }
            
        }
    }
}
