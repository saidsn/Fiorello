using FiorelloApp.Data;
using FiorelloApp.Models;
using FiorelloApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FiorelloApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Slider> sliders = await _context.Sliders.Where(s => !s.SoftDeleted).ToListAsync();
            SliderDetail sliderDetail = await _context.SliderDetails.Where(sd => !sd.SoftDeleted).FirstOrDefaultAsync();
            List<Category> categories = await _context.Categories.Where(c => !c.SoftDeleted).ToListAsync();
            IEnumerable<Product> products = await _context.Products
                .Where(p => !p.SoftDeleted)
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .ToListAsync();
            IEnumerable<Blog> blogs = await _context.Blogs.Where(b => !b.SoftDeleted).ToListAsync();


            HomeVM homeVM = new()
            {
                Sliders = sliders,
                SliderDetail = sliderDetail,
                Categories = categories,
                Products = products,
                Blogs = blogs
            };

            return View(homeVM);
        }
    }
}
