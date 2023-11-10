﻿using Hașegan_Mihail_Lab2.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hașegan_Mihail_Lab2.Data;

public class LibraryIdentityContext : IdentityDbContext<Hașegan_Mihail_Lab2User>
{
    public LibraryIdentityContext(DbContextOptions<LibraryIdentityContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
