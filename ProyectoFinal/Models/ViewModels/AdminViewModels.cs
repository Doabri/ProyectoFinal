using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Ingrese su Nickname que se le asigno")]
        public string? Nickname { get; set; }
        [Required(ErrorMessage = "Ingrese su contraseña asignada")]
        public string? Contrasena { get; set; }
    }
}
