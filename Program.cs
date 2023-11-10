using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Hașegan_Mihail_Lab2.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Hașegan_Mihail_Lab2.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<Hașegan_Mihail_Lab2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Hașegan_Mihail_Lab2Context") ?? throw new InvalidOperationException("Connection string 'Hașegan_Mihail_Lab2Context' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Hașegan_Mihail_Lab2Context") ?? throw new InvalidOperationException("Connection string 'Hașegan_Mihail_Lab2Context' not found.")));

builder.Services.AddDefaultIdentity<Hașegan_Mihail_Lab2User>(options =>
    options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<LibraryIdentityContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
