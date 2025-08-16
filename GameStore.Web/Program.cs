using GameStore.Application.Services;
using GameStore.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));

            builder.Services.AddScoped<CustomersService>();
            builder.Services.AddScoped<ConsolesService>();
            builder.Services.AddScoped<GamesService>();
            builder.Services.AddScoped<InvoicesService>();
            builder.Services.AddScoped<InvoiceItemsService>();
            builder.Services.AddScoped<ProductsService>();

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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Invoices}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
