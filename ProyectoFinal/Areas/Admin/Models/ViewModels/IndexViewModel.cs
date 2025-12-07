using ProyectoFinal.Models.Entities;

namespace ProyectoFinal.Areas.Admin.Models.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<IndexModel>? Pasteles { get; set; }
    }

    public class IndexModel
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public string? Ingredientes { get; set; }

        public decimal Precio { get; set; }
        public string Categoria { get; set; } = null!;

    }
}
