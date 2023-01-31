
using System.ComponentModel;
using DristorApp.Controllers;
using DristorApp.Data.db;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();

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

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}");

app.MapControllerRoute(
         name: "HomePage2",
         pattern: "Home/Page",
         defaults: new { controller = "Home", action = "Index" });

//app.MapControllerRoute(
//         name: "UsersPage",
//         pattern: "Users/Page",
//         defaults: new { controller = "Users", action = "GetUsers" });

app.Run();
