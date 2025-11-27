using Microsoft.AspNetCore.Authentication.Cookies;
using ProyectoFinal.Models.Entities;
using ProyectoFinal.Repositories;
using ProyectoFinal.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Admin/Account/Login";
        options.AccessDeniedPath = "/Admin/Account/Login";
    });

builder.Services.AddAuthorization();

builder.Services.AddDbContext<PasteleriaProyectoContext>();

builder.Services.AddScoped(typeof(Repository<>));
builder.Services.AddScoped<AdminService>();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapDefaultControllerRoute();

app.UseStaticFiles();

app.Run();