using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models.Entities;

public partial class Pedido
{
    public int Id { get; set; }

    public string? NombreCliente { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public string? Instrucciones { get; set; }

    public decimal Total { get; set; }

    public virtual ICollection<PedidoDetalle> PedidoDetalle { get; set; } = new List<PedidoDetalle>();
}
