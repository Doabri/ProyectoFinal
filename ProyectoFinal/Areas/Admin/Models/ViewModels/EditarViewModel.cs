using ProyectoFinal.Models.Entities;

namespace ProyectoFinal.Areas.Admin.Models.ViewModels
{
    public class EditarViewModel
    {
        public EditarModel EditarPastel { get; set; } = null!;
        public IEnumerable<Categoria>? Categorias { get; set; }
    }

    public class EditarModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal Precio { get; set; }
        public string Descripcion { get; set; } = null!;
        public IFormFile? Imagen { get; set; }  
        public string? Ingredientes { get; set; }
        public int PastelCategoria { get; set; }
        public string ImagenActual { get; set; } = ""; 
    }

}
