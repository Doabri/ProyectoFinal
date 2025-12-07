using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Areas.Admin.Models.ViewModels;
using ProyectoFinal.Models.Entities;
using ProyectoFinal.Services;

namespace ProyectoFinal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly CategoriaService categoriaService;
        private readonly AdminService adminService;

        public HomeController(CategoriaService categoriaService, AdminService adminService)
        {
            this.categoriaService = categoriaService;
            this.adminService = adminService;
        }

        [Authorize]
        public IActionResult Index()
        {
            IndexViewModel vm = new IndexViewModel()
            {
                Pasteles = adminService.GetPasteles()
            };

            return View(vm);
        }

        public IActionResult Agregar()
        {
            var categorias = categoriaService.GetCategorias();
            if (categorias != null)
            {
                var model = new AgregarViewModel
                {
                    Categorias = categorias,
                };
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(AgregarViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Categorias = categoriaService.GetCategorias() ?? new List<Categoria>();
                return View(vm);
            }

            AgregarModel entidad = new AgregarModel()
            {
                Nombre = vm.Agregar.Nombre,
                Precio = vm.Agregar.Precio,
                Descripcion = vm.Agregar.Descripcion,
                Ingredientes = vm.Agregar.Ingredientes,
                PastelCategoria = vm.Agregar.PastelCategoria,
                Imagen = vm.Agregar.Imagen
            };

            adminService.AgregarPastel(entidad);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Editar(int id)
        {
            var categorias = categoriaService.GetCategorias();
            if (categorias != null)
            {
                var model = new EditarViewModel
                {
                    Categorias = categorias,
                    EditarPastel = adminService.GetByEditar(id)
                };
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Editar(EditarViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Categorias = categoriaService.GetCategorias() ?? new List<Categoria>();
                return View(vm);
            }

            var entidad = new EditarModel
            {
                Id = vm.EditarPastel.Id,
                Nombre = vm.EditarPastel.Nombre,
                Precio = vm.EditarPastel.Precio,
                Descripcion = vm.EditarPastel.Descripcion,
                Ingredientes = vm.EditarPastel.Ingredientes,
                PastelCategoria = vm.EditarPastel.PastelCategoria,
                Imagen = vm.EditarPastel.Imagen
            };

            adminService.EditarPastel(entidad);

            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(int id)
        {
            EliminarViewModel vm = adminService.GetByEliminar(id);
            return View(vm);
        }
        [HttpPost]
        public IActionResult Eliminar(EliminarViewModel vm)
        {
            adminService.EliminarPastel(vm);
            return RedirectToAction("Index");
        }

    }
}
