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
            var pastel = adminService.GetByEditar(id);

            if (pastel == null)
                return NotFound();

            var vm = new EditarViewModel
            {
                EditarPastel = pastel,
                Categorias = categoriaService.GetCategorias()
            };

            return View(vm);
        }


        [HttpPost]
        public IActionResult Editar(EditarViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Categorias = categoriaService.GetCategorias();
                return View(vm);
            }

            adminService.EditarPastel(vm.EditarPastel);

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
