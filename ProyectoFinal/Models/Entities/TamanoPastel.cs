using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models.Entities;

public partial class TamanoPastel
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Precio { get; set; }

    public virtual ICollection<PedidoDetalle> PedidoDetalle { get; set; } = new List<PedidoDetalle>();
}
