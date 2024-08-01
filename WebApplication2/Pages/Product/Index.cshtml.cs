using WebApplication2.Data;
using WebApplication2.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace WebApplication2.Pages.Product
{
    public class IndexModel : PageModel
    {
        private readonly ProductDBContext _context;

        public IndexModel(ProductDBContext context)
        {
            _context = context;
        }

        public List<WebApplication2.Entities.Product> Products { get; set; }
        public void OnGet(string info = "")
        {
            Products = _context.Products.ToList();
            Info = info;
        }

        public string Info { get; set; }

        [BindProperty]
        public WebApplication2.Entities.Product Product { get; set; }

        public IActionResult OnPost(string action)
        {
            if (action == "add")
            {
                if (Product != null)
                {
                    _context.Products.Add(Product);
                    _context.SaveChanges();
                    Info = $"{Product.Name} added successfully";
                    return RedirectToPage("Index", new { info = Info });
                }
                return RedirectToPage("Index", new { info = "null" });
            }
            else if (action == "edit")
            {
                Products = _context.Products.ToList();
                var product = _context.Products.Find(Product.Id);
                if (product != null)
                {
                    product.Name = Product.Name;
                    product.Price = Product.Price;
                    _context.SaveChanges();
                    Info = $"{product.Name} updated successfully";
                }
               
                return RedirectToPage("Index", new { info = Info });
            }
            else if (action == "delete")
            {
                var product = _context.Products.Find(Product.Id);
                if (product != null)
                {
                    _context.Products.Remove(product);
                    _context.SaveChanges();
                    Info = $"{product.Name} deleted successfully";
                }
                
                return RedirectToPage("Index", new { info = Info });
            }

            return RedirectToPage("Index", new { info = "Unknown action" });
        }
    }
}
