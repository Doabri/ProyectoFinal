using ProyectoFinal.Helpers;
using static ProyectoFinal.Models.ViewModels.UsuarioViewModel;
using static System.Net.WebRequestMethods;

namespace ProyectoFinal.Services
{
    public class SessionService
    {
        private readonly IHttpContextAccessor http;
        private const string carritoKey = "CARRITO_SESSION";

        public SessionService(IHttpContextAccessor http)
        {
            this.http = http;
        }

        public List<PedidoPastelModel> GetCarrito()
        {
            return http.HttpContext!.Session
                .GetObject<List<PedidoPastelModel>>(carritoKey)
                ?? new List<PedidoPastelModel>();
        }

        public void GuardarCarrito(List<PedidoPastelModel> carrito)
        {
            http.HttpContext!.Session.SetObject(carritoKey, carrito);
        }

        public void AgregarAlCarrito(PedidoPastelModel item)
        {
            var carrito = GetCarrito();

            var existente = carrito.FirstOrDefault(p =>
                p.IdPastel == item.IdPastel &&
                p.IdTamano == item.IdTamano);

            if (existente != null)
            {
                existente.Cantidad += item.Cantidad;
            }
            else
            {
                carrito.Add(item);
            }

            GuardarCarrito(carrito);
        }


        public void Limpiar()
        {
            http.HttpContext!.Session.Remove(carritoKey);
        }
    }

}
