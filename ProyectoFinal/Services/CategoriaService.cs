using ProyectoFinal.Models.Entities;
using ProyectoFinal.Models.ViewModels;
using ProyectoFinal.Repositories;

namespace ProyectoFinal.Services
{
    public class CategoriaService
    {
        private readonly Repository<Categoria> repo;
        private readonly IConfiguration config;
        public CategoriaService(Repository<Categoria> repo, IConfiguration config)
        {
            this.repo = repo;
            this.config = config;
        }

        public IEnumerable<Categoria>? GetCategorias()
        {
            return repo.GetAll();
        }
    }
}
