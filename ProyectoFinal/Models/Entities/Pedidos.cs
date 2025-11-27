using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models.Entities;

public partial class Pedidos
{
    public int Id { get; set; }

    public int? IdPastel { get; set; }

    public int? Telefono { get; set; }

    public string? CodigoUnico { get; set; }

    public string? Correo { get; set; }

    public string? Instrucciones { get; set; }
}
