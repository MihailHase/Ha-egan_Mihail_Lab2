using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hașegan_Mihail_Lab2.Data;
using Hașegan_Mihail_Lab2.Models;

namespace Hașegan_Mihail_Lab2.Pages.Borrowings
{
    public class IndexModel : PageModel
    {
        private readonly Hașegan_Mihail_Lab2Context _context;

        public IndexModel(Hașegan_Mihail_Lab2Context context)
        {
            _context = context;
        }

        public IList<Borrowing> Borrowing { get; set; } = new List<Borrowing>();

        public async Task OnGetAsync()
        {
            try
            {
                Borrowing = await _context.Borrowing
                    .Include(b => b.Book)
                        .ThenInclude(b => b.Author)
                    .Include(b => b.Member)
                    .ToListAsync();

                // Log the count of borrowings retrieved
                Console.WriteLine($"Number of borrowings: {Borrowing.Count}");

                // Log the SQL query
                var query = _context.Borrowing.ToQueryString();
                Console.WriteLine($"Executing SQL: {query}");
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error retrieving borrowings: {ex.Message}");
            }
        }
    }
}

