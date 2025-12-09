using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models.ViewModels;
using ProyectoFinal.Services;

namespace ProyectoFinal.Controllers
{
    public class HomeController : Controller
    {
        private readonly UsuarioService usuarioService;

        public HomeController(UsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }
        public IActionResult Index(int id)
        {
            var vm = usuarioService.GetIndex(id);
            return View(vm);
        }

        public IActionResult Detalles(int id)
        {
            var vm = usuarioService.GetDetallesPastel(id);
            return View(vm);
        }

        public IActionResult Carrito()
        {
            var vm = usuarioService.GetCarrito();
            return View(vm);
        }

        [HttpPost]
        public IActionResult AgregarCarrito(int pastelId, int TamanoSeleccionadoId)
        {
            usuarioService.AgregarAlCarrito(pastelId, TamanoSeleccionadoId);
            return RedirectToAction("Carrito");
        }


        public IActionResult EliminarDelCarrito(Guid id)
        {
            usuarioService.Eliminar(id);
            return RedirectToAction("Carrito");
        }

        public IActionResult SumarCantidad(Guid id)
        {
            usuarioService.Sumar(id);
            return RedirectToAction("Carrito");
        }

        public IActionResult RestarCantidad(Guid id)
        {
            usuarioService.Restar(id);
            return RedirectToAction("Carrito");
        }


        public IActionResult Checkout()
        {
            var carrito = usuarioService.GetCarrito();

            if (!carrito.ListaPedidos.Any())
            {
                return RedirectToAction("Carrito");
            }

            var vm = usuarioService.GetCheckOut();
            return View(vm);
        }

        [HttpPost]
        public IActionResult FinalizarPedido(UsuarioViewModel.CheckOutViewModel model)
        {
            if (model.ListaCarritoPedidos == null || !model.ListaCarritoPedidos.Any())
            {
                ModelState.AddModelError("", "Tu carrito está vacío.");

                var vm = usuarioService.GetCheckOut();
                vm.NombreCliente = model.NombreCliente;
                vm.Correo = model.Correo;
                vm.Telefono = model.Telefono;
                vm.Instrucciones = model.Instrucciones;

                return View("CheckOut", vm);
            }

            if (!ModelState.IsValid)
            {
                var vm = usuarioService.GetCheckOut();
                vm.NombreCliente = model.NombreCliente;
                vm.Correo = model.Correo;
                vm.Telefono = model.Telefono;
                vm.Instrucciones = model.Instrucciones;

                return View("CheckOut", vm);
            }

            var pedidoId = usuarioService.RegistrarPedido(model);
            return RedirectToAction("Confirmacion", new { id = pedidoId });
        }


        public IActionResult ConfirmacionPedido(int id)
        {
            ViewBag.PedidoId = id;
            return View();
        }
    }
}
