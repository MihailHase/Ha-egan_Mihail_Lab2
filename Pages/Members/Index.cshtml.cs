using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hașegan_Mihail_Lab2.Data;
using Hașegan_Mihail_Lab2.Models;
using Microsoft.Extensions.Logging;

namespace Hașegan_Mihail_Lab2.Pages.Members
{
    public class IndexModel : PageModel
    {
        private readonly Hașegan_Mihail_Lab2Context _context;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(Hașegan_Mihail_Lab2Context context, ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IList<Member> Member { get; set; } = new List<Member>();

        public async Task OnGetAsync()
        {
            try
            {
                Member = await _context.Member.ToListAsync();

                // Log the count of members retrieved
                _logger.LogInformation($"Number of members: {Member.Count}");

                // Log the SQL query
                var query = _context.Member.ToQueryString();
                _logger.LogInformation($"Executing SQL: {query}");
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError($"Error retrieving members: {ex.Message}");
            }
        }
    }
}

