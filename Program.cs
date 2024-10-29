using Microsoft.EntityFrameworkCore;
using SistemaLearnGo.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

/*builder.Services.AddDbContext<Contexto> //Juliani
    (options => options.UseSqlServer("Data Source=SP-1491034\\SQLSENAI;Initial Catalog = SistemaLearnGoNovo;" +
    " Integrated Security = True;TrustServerCertificate = True"));*/

/*builder.Services.AddDbContext<Contexto> //Gabi
    (options => options.UseSqlServer("Data Source=SP-1491009\\SQLSENAI;Initial Catalog = SistemaLearnGoNovo;" +
    " Integrated Security = True;TrustServerCertificate = True"));*/

builder.Services.AddDbContext<Contexto> //Isabela
    (options => options.UseSqlServer("Data Source=SP-1491007\\SQLSENAI;Initial Catalog = SistemaLearnGoNovo;" +
    " Integrated Security = True;TrustServerCertificate = True"));

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
    pattern: "{controller=Cadastro}/{action=Login}/{id?}");

app.Run();
