namespace ProyectoFinal.Areas.Admin.Models.ViewModels
{
    public class IndexCategoriasViewModel
    {
        public IEnumerable<IndexCategoriaModel>? CategoriasIndex {  get; set; } 
    }

    public class IndexCategoriaModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
    }
}
