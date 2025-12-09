using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models.Entities;

public partial class PedidoDetalle
{
    public int Id { get; set; }

    public int IdPedido { get; set; }

    public int IdPastel { get; set; }

    public int IdTamano { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public virtual Pastel IdPastelNavigation { get; set; } = null!;

    public virtual Pedido IdPedidoNavigation { get; set; } = null!;

    public virtual TamanoPastel IdTamanoNavigation { get; set; } = null!;
}
