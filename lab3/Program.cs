using lab3_App.Models.ContactModels;
using lab3_App.Models.CarModels;
using Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using lab3_App.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddSession();
        builder.Services.AddControllersWithViews();
        builder.Services.AddTransient<IContactService, EFContactService>();
        builder.Services.AddTransient<ICarService, EFCarService>();
        builder.Services.AddTransient<IManufacturerService, EFManufacturerService>();
        builder.Services.AddSingleton<IDateTimeProvider, CurrentDateTimeProvider>();
        builder.Services.AddDbContext<AppDbContext>();

        builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>();
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
        app.UseMiddleware<LastVisitCookie>();
        //app.Use(async (context, next) =>
        //{
        //    return;
        //});

        app.UseAuthentication();
        app.UseSession();
        app.UseAuthorization();
        app.MapRazorPages();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}