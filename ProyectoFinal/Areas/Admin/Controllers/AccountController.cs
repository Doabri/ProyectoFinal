using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ProyectoFinal.Services;
using ProyectoFinal.Models.ViewModels;

namespace ProyectoFinal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly AdminService adminService;

        public AccountController(AdminService adminService)
        {
            this.adminService = adminService;
        }

        public IActionResult Login()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Login(LoginViewModel model)
        //{
        //    var admin = adminService.Login(model);

        //    if (admin == null)
        //    {
        //        ModelState.AddModelError("", "Contraseña o Nickname incorrectos");
        //        return View(model);
        //    }
        //    else if(admin.Nickname!=null)
        //    {
        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.NameIdentifier,
        //            admin.Id.ToString()),
        //            new Claim(ClaimTypes.Name,
        //                admin.Nickname)
        //        };

        //        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        //        var principal = new ClaimsPrincipal(identity);

        //        await HttpContext.SignInAsync(principal);

        //        return RedirectToAction("Index", "Home", new { area = "Admin" });
        //    }
        //    else
        //    {
        //        return View(model);
        //    }
        //}
    }
}
