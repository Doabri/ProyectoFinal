using ProyectoFinal.Models.Entities;

namespace ProyectoFinal.Areas.Admin.Models.ViewModels
{
    public class AgregarViewModel
    {
        public AgregarModel Agregar { get; set; } = null!;
        public IEnumerable<Categoria>? Categorias { get; set; }
    }

    public class AgregarModel
    {
        public string Nombre { get; set; } = null!;
        public decimal Precio { get; set; }
        public string Descripcion { get; set; } = null!;
        public IFormFile Imagen { get; set; } = null!;
        public string? Ingredientes { get; set; }
        public int PastelCategoria {  get; set; }
    }
}