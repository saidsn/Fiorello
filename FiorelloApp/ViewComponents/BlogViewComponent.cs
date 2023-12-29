using FiorelloApp.Data;
using FiorelloApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FiorelloApp.ViewComponents
{
    public class BlogViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public BlogViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            IEnumerable<Blog> blogs = await _context.Blogs.Where(b => !b.SoftDeleted).ToListAsync();

            return await Task.FromResult(View(blogs));
        }
    }
}
