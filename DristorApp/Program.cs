
using System.ComponentModel;
using DristorApp.Controllers;
using DristorApp.Data.db;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using DristorApp;
//var builder = WebApplication.CreateBuilder(args);



//// Add services to the container.
//builder.Services.AddControllersWithViews();
//builder.Services.AddDbContext<AppDbContext>();
//// builder.Services.AddDbContext<AppDbContext>();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

////app.MapControllerRoute(
////    name: "default",
////    pattern: "{controller=Home}/{action=Index}");


///*app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller=Home}/{action=Index}");*/

//app.MapControllerRoute(
//          name: "default",
//         pattern: "Home/Page",
//         defaults: new { controller = "Home", action = "Index" });

///*app.MapControllerRoute(
//         name: "users_page",
//         pattern: "Users/Page",
//         defaults: new { controller = "Users", action = "GetUsers" });

//app.MapControllerRoute(
//         name: "user_page",
//         pattern: "Users/AddUser",
//         defaults: new { controller = "Users", action = "AddUser" });*/
///*app.MapControllerRoute(
//     name: "user_add",
//     pattern: "{controller=Users}/{action=AddUser}");
//*/

//app.Run();
//// setx DristorDbUserConn Host=localhost;Port=5432;Database=DristorApp;Username=DristorApp;Password=Admin@123456


namespace DristorApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Launchup>(); });
    }
}
