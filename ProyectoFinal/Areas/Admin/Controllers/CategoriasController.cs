using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Areas.Admin.Models.ViewModels;
using ProyectoFinal.Models.Entities;
using ProyectoFinal.Services;
using System.Security.Cryptography.X509Certificates;

namespace ProyectoFinal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriasController : Controller
    {
        private readonly AdminService adminService;
        private readonly CategoriaService categoriaService;
        public CategoriasController(AdminService adminService, CategoriaService categoriaService)
        {
            this.adminService = adminService;
            this.categoriaService = categoriaService;
        }
        [Authorize]
        public IActionResult Index()
        {
            IndexCategoriasViewModel vm = new IndexCategoriasViewModel()
            {
                CategoriasIndex = adminService.GetCategoriasAdmin()
            };

            return View(vm);
        }

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(AgregarCategoriaViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            adminService.AgregarCategoria(vm);
            return RedirectToAction("Index");
        }
        public IActionResult Editar(int id)
        {
            EditarCategoriaViewModel vm = adminService.GetByEditarCategoria(id);
            return View(vm);
        }
        [HttpPost]
        public IActionResult Editar(EditarCategoriaViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            adminService.EditarCategoria(vm);
            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(int id)
        {
            EliminarCategoriaViewModel vm = adminService.GetByEliminarCategoria(id);
            return View(vm);
        }
        [HttpPost]
        public IActionResult Eliminar(EliminarCategoriaViewModel vm)
        {
            adminService.EliminarCategoria(vm);
            return RedirectToAction("Index");
        }
    }
}
