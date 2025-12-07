using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models.Entities;

public partial class Categoria
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Pastel> Pastel { get; set; } = new List<Pastel>();
}
