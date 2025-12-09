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

builder.Services.AddDbContext<ProyectoPasteleriaContext>();

builder.Services.AddScoped(typeof(Repository<>));
builder.Services.AddScoped<AdminService>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<SessionService>();

//esto es para la session 
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapDefaultControllerRoute();

app.Run();