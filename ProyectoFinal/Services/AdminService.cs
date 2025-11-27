using ProyectoFinal.Models.Entities;
using ProyectoFinal.Models.ViewModels;
using ProyectoFinal.Repositories;

namespace ProyectoFinal.Services
{
    public class AdminService
    {
        private readonly Repository<Usuarioadmin> repo;
        private readonly IConfiguration config;
        public AdminService(Repository<Usuarioadmin> repo, IConfiguration config)
        {
            this.repo = repo;
            this.config = config;
        }

        public Usuarioadmin? Login(LoginViewModel model)
        {
            var admin = repo.GetAll().FirstOrDefault(a => a.Nickname == model.Nickname && a.Contrasena == Sha256Helper.ComputeHash(model.Contrasena ?? ""));

            return admin;
        }
    }
}
