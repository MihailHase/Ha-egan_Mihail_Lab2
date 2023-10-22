using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hașegan_Mihail_Lab2.Models;

namespace Hașegan_Mihail_Lab2.Data
{
    public class Hașegan_Mihail_Lab2Context : DbContext
    {
        public Hașegan_Mihail_Lab2Context (DbContextOptions<Hașegan_Mihail_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Hașegan_Mihail_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Hașegan_Mihail_Lab2.Models.Publisher>? Publisher { get; set; }

        public DbSet<Hașegan_Mihail_Lab2.Models.Author>? Author { get; set; }
    }
}
