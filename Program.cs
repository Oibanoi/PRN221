using Microsoft.EntityFrameworkCore;
using SignalRAssignment.Models;

namespace Assignment2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            builder.Services.AddDbContext<PizzaStoreContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("PizzaStore"));
            });
            builder.Services.AddScoped<PizzaStoreContext>();
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
            app.UseSession(); 
            app.UseRouting();
            app.UseStatusCodePagesWithRedirects("/errors/{0}");
            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}