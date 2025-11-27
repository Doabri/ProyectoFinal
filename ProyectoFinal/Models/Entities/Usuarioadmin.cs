using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models.Entities;

public partial class Usuarioadmin
{
    public int Id { get; set; }

    public string? Nickname { get; set; }

    public string? Contrasena { get; set; }
}
