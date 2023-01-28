using DAL.Context;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RestoranCompany.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Reflection;
using System.Configuration;

namespace RestoranCompany
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); //Bu ayar ile program ba�lat�l�rken autommappere Automapperconfig s�n�f�na git. Oray� tara. Ordaki modelleri �evir diyoruz.


            builder.Services.AddDbContext<RestoranCompanyDbContext>(opts =>
            {
                opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

                //opts.UseLazyLoadingProxies();

            });

           // Kendime not. Burada cookie ayarlar� yap�l�yor. 

            builder.Services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(opts =>
                {
                    opts.Cookie.Name = ".RestoranCompany.auth";
                    opts.ExpireTimeSpan = TimeSpan.FromDays(1);
                    opts.SlidingExpiration = false;
                    opts.LoginPath = "/Account/Login";
                    opts.LogoutPath = "/Account/Logout";
                    opts.AccessDeniedPath = "/Home/AccessDenied";
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}