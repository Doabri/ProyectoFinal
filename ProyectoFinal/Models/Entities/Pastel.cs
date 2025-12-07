using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models.Entities;

public partial class Pastel
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string? Ingredientes { get; set; }

    public decimal Precio { get; set; }

    public int IdCategoria { get; set; }

    public virtual Categoria IdCategoriaNavigation { get; set; } = null!;
}
