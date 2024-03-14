
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql("Host=localhost;Database=ecommerce_database;Password=mypassword;"));

// Säg åt ASP.NET att vi skall använda deras inbyggda token system.
// Det hanterar automatiskt validering och så.
builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);

builder.Services.AddIdentityCore<User>()
    // Ge också information om var alla användare ligger (i ApplicationDbContex).
    .AddEntityFrameworkStores<ApplicationDbContext>()
    // Säg också åt ASP.NET att lägga till endpoints för att kunna registrera användare
    // och inloggning (det finns också fler, men dessa är de viktigaste).
    .AddApiEndpoints();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Mappa alla routes för registrering och inloggning endpoints.
var app = builder.Build();

app.MapIdentityApi<User>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
