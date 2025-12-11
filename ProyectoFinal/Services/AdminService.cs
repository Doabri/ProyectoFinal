using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ProyectoFinal.Areas.Admin.Models.ViewModels;
using ProyectoFinal.Models.Entities;
using ProyectoFinal.Models.ViewModels;
using ProyectoFinal.Repositories;

namespace ProyectoFinal.Services
{
    public class AdminService
    {
        private readonly Repository<Usuarioadmin> repoUser;
        private readonly Repository<Pastel> repoPastel;
        private readonly Repository<Categoria> repoCategoria;
        private readonly IWebHostEnvironment hostEnvironment;
        private readonly Repository<Ingrediente> repoIngrediente;

        public AdminService(Repository<Usuarioadmin> repoUser, Repository<Pastel> repoPastel,Repository<Categoria> repoCategoria, Repository<Ingrediente> repoIngrediente, IWebHostEnvironment hostEnvironment)
        {
            this.repoUser = repoUser;
            this.repoPastel = repoPastel;
            this.repoCategoria = repoCategoria;
            this.repoIngrediente = repoIngrediente;
            this.hostEnvironment = hostEnvironment;
        }

        public Usuarioadmin? Login(LoginViewModel model)
        {
            var admin = repoUser.GetAll().FirstOrDefault(a => a.Nickname == model.Nickname && a.Contrasena == Sha256Helper.ComputeHash(model.Contrasena ?? ""));

            return admin;
        }

        public IEnumerable<IndexModel> GetPasteles()
        {
            var entidad = repoPastel.GetAll().AsQueryable().Include(x=>x.IdCategoriaNavigation).OrderBy(x=>x.Nombre)
                .Select(x=> new IndexModel
                {
                    Id= x.Id,
                    Nombre=x.Nombre,
                    Descripcion=x.Descripcion,
                    Precio=x.Precio,
                    Categoria=x.IdCategoriaNavigation.Nombre??""
                }).ToList();

            return entidad;
        }

        public void AgregarPastel(AgregarModel model)
        {
            var entidad = new Pastel
            {
                Nombre = model.Nombre,
                Descripcion = model.Descripcion,
                Precio = model.Precio,
                IdCategoria = model.PastelCategoria
            };
            repoPastel.Insert(entidad);

            if (model.Ingredientes != null)
            {
                foreach (var ing in model.Ingredientes)
                {
                    if (!string.IsNullOrWhiteSpace(ing))
                    {
                        var ingrediente = new Ingrediente
                        {
                            Nombre = ing.Trim(),
                            IdPastel = entidad.Id
                        };
                        repoIngrediente.Insert(ingrediente);
                    }
                }
            }
            AgregarImagen(model.Imagen, entidad.Id);
        }


        public void AgregarImagen(IFormFile archivo, int idPastel)
        {
            if (archivo.Length > 1024 * 1024 * 2)
            {
                throw new ArgumentException("Seleccione una imagen de 2MB o menos.");
            }

            if (archivo.ContentType != "image/jpeg")
            {
                throw new ArgumentException("Selecciones una imagen JPEG o JPG");
            }

            var rutaCarpeta = hostEnvironment.WebRootPath + "/pasteles/";

            if (!Directory.Exists(rutaCarpeta))
            {
                Directory.CreateDirectory(rutaCarpeta);
            }

            var ruta = rutaCarpeta + $"{idPastel}.jpg";

            var file = File.Create(ruta);
            archivo.CopyTo(file);
            file.Close();

        }

        public EditarModel GetByEditar(int id)
        {
            var entidad = repoPastel.GetAll().AsQueryable()
                .Include(x => x.Ingrediente)
                .FirstOrDefault(x => x.Id == id);

            if (entidad == null)
                throw new ArgumentException("Pastel no encontrado.");

            string ingredientesTexto = string.Join(", ", entidad.Ingrediente.Select(i => i.Nombre));

            return new EditarModel
            {
                Id = entidad.Id,
                Nombre = entidad.Nombre,
                Descripcion = entidad.Descripcion ?? "",
                Precio = entidad.Precio,
                PastelCategoria = entidad.IdCategoria,
                Ingredientes = ingredientesTexto
            };
        }

        public void EditarPastel(EditarModel m)
        {
            var entidad = repoPastel.GetAll().AsQueryable()
                .Include(x => x.Ingrediente)
                .FirstOrDefault(x => x.Id == m.Id);

            if (entidad == null)
                throw new ArgumentException("Pastel no encontrado.");

            entidad.Nombre = m.Nombre;
            entidad.Descripcion = m.Descripcion;
            entidad.Precio = m.Precio;
            entidad.IdCategoria = m.PastelCategoria;

            repoPastel.Update(entidad);


            entidad.Ingrediente.Clear();

            if (!string.IsNullOrWhiteSpace(m.Ingredientes))
            {
                var lista = m.Ingredientes
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(i => i.Trim())
                    .ToList();

                foreach (var ing in lista)
                {
                    entidad.Ingrediente.Add(new Ingrediente
                    {
                        Nombre = ing,
                        IdPastel = entidad.Id
                    });
                }
            }

            repoPastel.Update(entidad);

            if (m.Imagen != null && m.Imagen.Length > 0)
            {
                AgregarImagen(m.Imagen, entidad.Id);
            }
        }


        public EliminarViewModel GetByEliminar(int id)
        {
            var entidad = repoPastel.GetAll().AsQueryable().Include(x => x.IdCategoriaNavigation).Where(x => x.Id == id).FirstOrDefault();
            if (entidad == null) throw new ArgumentException("Pastel no encontrado.");

            return new EliminarViewModel()
            {
                Nombre = entidad.Nombre??"",
                Categoria = entidad.IdCategoriaNavigation.Nombre??"",
                Id = id
            };
        }

        public void EliminarPastel(EliminarViewModel m)
        {
            var entidad = repoPastel.GetAll().AsQueryable()
                .Include(x => x.Ingrediente)
                .FirstOrDefault(x => x.Id == m.Id);

            if (entidad == null)
                throw new ArgumentException("Pastel no encontrado.");

            repoPastel.Delete(entidad.Id);

            var rutaImagen = Path.Combine(hostEnvironment.WebRootPath, "pasteles", $"{m.Id}.jpg");
            if (File.Exists(rutaImagen))
                File.Delete(rutaImagen);
        }

        public IEnumerable<IndexCategoriaModel> GetCategoriasAdmin()
        {
            var entidad = repoCategoria.GetAll().OrderBy(x=>x.Nombre).Select(x=> new IndexCategoriaModel
            {
                Nombre=x.Nombre??"",
                Id=x.Id
            }).ToList();

            return entidad;
        }

        public void AgregarCategoria(AgregarCategoriaViewModel model)
        {
            var entidad = new Categoria
            {
                Nombre = model.Nombre,
            };

            repoCategoria.Insert(entidad);
        }

        public EditarCategoriaViewModel GetByEditarCategoria(int id)
        {
            var entidad = repoCategoria.Get(id);  
            if (entidad == null) throw new ArgumentException("Categoria no encotrada.");

            return new EditarCategoriaViewModel
            {
                Id = entidad.Id,
                Nombre = entidad.Nombre ?? "",
            };
        }

        public void EditarCategoria(EditarCategoriaViewModel m)
        {
            var entidad = repoCategoria.Get(m.Id);
            if (entidad == null) throw new ArgumentException("Categoria no encotrada.");

            entidad.Nombre = m.Nombre;
            entidad.Id=m.Id;

            repoCategoria.Update(entidad);
        }

        public EliminarCategoriaViewModel GetByEliminarCategoria(int id)
        {
            var entidad = repoCategoria.Get(id);
            if (entidad == null) throw new ArgumentException("Categoria no encotrada.");

            return new EliminarCategoriaViewModel
            {
                Id = entidad.Id,
                Nombre = entidad.Nombre ?? "",
            };
        }

        public void EliminarCategoria(EliminarCategoriaViewModel m)
        {
            var entidad = repoCategoria.Get(m.Id);
            if (entidad == null) throw new ArgumentException("Categoria no encontrada.");

            var pasteles = repoPastel.GetAll().Where(x => x.IdCategoria == m.Id).ToList();

            foreach (var pastel in pasteles)
            {
                repoPastel.Delete(pastel.Id);
            }

            repoCategoria.Delete(m.Id);
        }

    }
}
