using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models.ViewModels

{
    public class UsuarioViewModel
    {
        public class IndexUsuarioViewModel
        {
            public IEnumerable<CategoriaModel> ListaCategorias { get; set; } = null!;
            public int CategoriaSeleccionada { get; set; }
            public IEnumerable<PastelModel> ListaPasteles { get; set; } = null!;
        }
        public class CategoriaModel
        {
            public int Id { get; set; }
            public string? Nombre { get; set; }
        }

        public class PastelModel
        {
            public int Id { get; set; }
            public string? Nombre { get; set; }
            public string? Descripcion { get; set; }
            public decimal Precio { get; set; }
        }
        public class DetallesPastelUsuarioViewModel
        {
            public int Id { get; set; }
            public string? Nombre { get; set; }
            public string? Descripcion { get; set; }
            public decimal PrecioBase { get; set; }
            public List<string> Ingredientes { get; set; } = null!;


            public IEnumerable<TamanoPastelModel> ListaTamaños { get; set; } = null!;
            public int TamanoSeleccionadoId { get; set; }
        }
        public class TamanoPastelModel
        {
            public int Id { get; set; }
            public string? Nombre { get; set; }
            public decimal Precio { get; set; }

            public string Texto => Precio == 0 ? $"{Nombre}" : $"{Nombre} (+$ {Precio})";

        }

        public class CarritoViewModel
        {
            public IEnumerable<PedidoPastelModel> ListaPedidos { get; set; } = null!;

            public decimal Subtotal { get; set; }
            public decimal Envio { get; set; } = 80;
            public decimal Total { get; set; }
        }
        public class PedidoPastelModel
        {
            public Guid CarritoId { get; set; } = Guid.NewGuid();//es para crear una llave unica de cada pastel 

            public int IdPastel { get; set; }
            public int IdTamano { get; set; }

            public string Nombre { get; set; } = null!;
            public string Tamano { get; set; } = null!;
            public decimal PrecioUnitario { get; set; }
            public int Cantidad { get; set; }

            public decimal Subtotal => PrecioUnitario * Cantidad;
        }

        public class CheckOutViewModel
        {
            public string? NombreCliente { get; set; }
            public string? Correo { get; set; }
            public string? Telefono { get; set; }
            public string? Instrucciones { get; set; }

            public decimal Subtotal { get; set; }
            public decimal Envio { get; set; }
            public decimal Total { get; set; }

            public List<PedidoPastelModel> ListaCarritoPedidos { get; set; } = new();
        }
    }
}
