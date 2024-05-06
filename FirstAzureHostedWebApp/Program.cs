using FirstAzureHostedWebApp.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connStr = builder.Configuration.GetConnectionString("CustomersConnection");

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CustomersDbContext>(optionsAction =>
{
    optionsAction.UseSqlServer(connectionString: connStr);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
