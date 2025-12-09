using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models.Entities;

public partial class Ingrediente
{
    public int Id { get; set; }

    public int IdPastel { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual Pastel IdPastelNavigation { get; set; } = null!;
}
