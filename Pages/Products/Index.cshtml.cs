using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorPagesMovie.Pages_Products
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;

        public IndexModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Titles { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? ProductTitle { get; set; }

        public async Task OnGetAsync()
        {
            var products = from p in _context.Product
                select p;
            if (!string.IsNullOrEmpty(SearchString))
            {
                products = products.Where(s => s.Title.Contains(SearchString));
            }

            Product = await products.ToListAsync();
        }
    }
}