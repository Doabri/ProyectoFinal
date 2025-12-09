using NuGet.Protocol.Core.Types;
using ProyectoFinal.Models.Entities;
using ProyectoFinal.Models.ViewModels;
using ProyectoFinal.Repositories;
using static ProyectoFinal.Models.ViewModels.UsuarioViewModel;

namespace ProyectoFinal.Services
{
    public class UsuarioService
    {
        private readonly Repository<Pastel> pastelRepository;
        private readonly Repository<Categoria> categoriaRepository;
        private readonly Repository<Ingrediente> ingredienteRepository;
        private readonly Repository<TamanoPastel> tamanoRepository;
        private readonly SessionService sessionService;
        private readonly Repository<Pedido> pedidoRepository;
        private readonly Repository<PedidoDetalle> pedidoDetalleRepository;

        public UsuarioService(Repository<Pastel> pastelRepository, Repository<Categoria> categoriaRepository,
            Repository<Ingrediente> ingredienteRepository, Repository<TamanoPastel> tamanoRepository,
            SessionService sessionService, Repository<Pedido> pedidoRepository,
            Repository<PedidoDetalle> pedidoDetalleRepository)
        {
            this.pastelRepository = pastelRepository;
            this.categoriaRepository = categoriaRepository;
            this.ingredienteRepository = ingredienteRepository;
            this.tamanoRepository = tamanoRepository;
            this.sessionService = sessionService;
            this.pedidoRepository = pedidoRepository;
            this.pedidoDetalleRepository = pedidoDetalleRepository;
        }


        public UsuarioViewModel.IndexUsuarioViewModel GetIndex(int categoria)
        {
            var categorias = categoriaRepository.GetAll()
                .Select(c => new UsuarioViewModel.CategoriaModel
                {
                    Id = c.Id,
                    Nombre = c.Nombre
                }).ToList();

            var query = pastelRepository.GetAll();

            if (categoria > 0)
            {
                query = query.Where(p => p.IdCategoria == categoria);
            }

            var pasteles = query
                .Select(p => new UsuarioViewModel.PastelModel
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion,
                    Precio = p.Precio
                }).ToList();

            return new UsuarioViewModel.IndexUsuarioViewModel
            {
                ListaCategorias = categorias,
                ListaPasteles = pasteles,
                CategoriaSeleccionada = categoria
            };
        }

        public UsuarioViewModel.DetallesPastelUsuarioViewModel GetDetallesPastel(int id)
        {
            var pastel = pastelRepository.Get(id);

            var ingredientes = ingredienteRepository.GetAll()
                .Where(i => i.IdPastel == id).Select(i => i.Nombre).ToList();

            var tamanos = tamanoRepository.GetAll().Select(t => new UsuarioViewModel.TamanoPastelModel
            {
                Id = t.Id,
                Nombre = t.Nombre,
                Precio = t.Precio,
            });

            return new UsuarioViewModel.DetallesPastelUsuarioViewModel
            {
                Id = pastel.Id,
                Nombre = pastel.Nombre,
                Descripcion = pastel.Descripcion,
                PrecioBase = pastel.Precio,
                Ingredientes = ingredientes,
                ListaTamaños = tamanos,
                TamanoSeleccionadoId = tamanos.First().Id
            };
        }

        public void AgregarAlCarrito(int pastelId, int tamanoId)
        {
            var pastel = pastelRepository.Get(pastelId);
            var tamano = tamanoRepository.Get(tamanoId);

            if (pastel == null || tamano == null)
                throw new Exception("Pastel o tamaño inválido");

            var pedido = new PedidoPastelModel
            {
                IdPastel = pastelId,
                IdTamano = tamanoId,   
                Nombre = pastel.Nombre,
                Tamano = tamano.Nombre,
                PrecioUnitario = pastel.Precio + tamano.Precio,
                Cantidad = 1
            };

            sessionService.AgregarAlCarrito(pedido);
        }

        public UsuarioViewModel.CarritoViewModel GetCarrito()
        {
            var lista = sessionService.GetCarrito();

            var subtotal = lista.Sum(s => s.Subtotal);
            var envio = 80m;
            var total = subtotal + envio;

            return new UsuarioViewModel.CarritoViewModel
            {
                ListaPedidos = lista,
                Subtotal = subtotal,
                Envio = envio,
                Total = total,
            };
        }

        public UsuarioViewModel.CheckOutViewModel GetCheckOut()
        {
            var carrito = sessionService.GetCarrito();

            var subtotal = carrito.Sum(p => p.Subtotal);
            var envio = 80m;
            var total = subtotal + envio;

            return new UsuarioViewModel.CheckOutViewModel
            {
                ListaCarritoPedidos = carrito.Select(p => new ResumenCarritoModel
                {
                    IdPastel = p.IdPastel,
                    IdTamano = tamanoRepository.GetAll().First(t => t.Nombre == p.Tamano).Id,
                    Nombre = p.Nombre,
                    Cantidad = p.Cantidad,
                    PrecioUnitario = p.PrecioUnitario
                }),

                Subtotal = subtotal,
                Envio = envio,
                Total = total
            };
        }


        public int RegistrarPedido(UsuarioViewModel.CheckOutViewModel model)
        {
            var pedido = new Pedido
            {
                NombreCliente = model.NombreCliente,
                Correo = model.Correo,
                Telefono = model.Telefono,
                Instrucciones = model.Instrucciones,
                Total = model.Total,
            };

            pedidoRepository.Insert(pedido);

            foreach (var p in model.ListaCarritoPedidos)
            {
                pedidoDetalleRepository.Insert(new PedidoDetalle
                {
                    IdPedido = pedido.Id,
                    IdPastel = p.IdPastel,
                    IdTamano = p.IdTamano,
                    Cantidad = p.Cantidad,
                    PrecioUnitario = p.PrecioUnitario
                });
            }

            sessionService.Limpiar();
            return pedido.Id;
        }

        public void Eliminar(Guid carritoId)
        {
            var carrito = sessionService.GetCarrito();
            carrito.RemoveAll(p => p.CarritoId == carritoId);
            sessionService.GuardarCarrito(carrito);
        }


        public void Sumar(Guid carritoId)
        {
            var carrito = sessionService.GetCarrito();

            var item = carrito.FirstOrDefault(p => p.CarritoId == carritoId);
            if (item == null) return;

            item.Cantidad++;
            sessionService.GuardarCarrito(carrito);
        }

        public void Restar(Guid carritoId)
        {
            var carrito = sessionService.GetCarrito();

            var item = carrito.FirstOrDefault(p => p.CarritoId == carritoId);

            if (item == null) return;

            item.Cantidad--;

            if (item.Cantidad <= 0)
            {
                carrito.Remove(item);
            }

            sessionService.GuardarCarrito(carrito);
        }

    }
}
