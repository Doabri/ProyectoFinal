using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace ProyectoFinal.Models.Entities;

public partial class ProyectoPasteleriaContext : DbContext
{
    public ProyectoPasteleriaContext()
    {
    }

    public ProyectoPasteleriaContext(DbContextOptions<ProyectoPasteleriaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Ingrediente> Ingrediente { get; set; }

    public virtual DbSet<Pastel> Pastel { get; set; }

    public virtual DbSet<Pedido> Pedido { get; set; }

    public virtual DbSet<PedidoDetalle> PedidoDetalle { get; set; }

    public virtual DbSet<TamanoPastel> TamanoPastel { get; set; }

    public virtual DbSet<Usuarioadmin> Usuarioadmin { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;database=ProyectoPasteleria;password=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.36-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("categoria");

            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Ingrediente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ingrediente");

            entity.HasIndex(e => e.IdPastel, "IdPastel");

            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.IdPastelNavigation).WithMany(p => p.Ingrediente)
                .HasForeignKey(d => d.IdPastel)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ingrediente_ibfk_1");
        });

        modelBuilder.Entity<Pastel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pastel");

            entity.HasIndex(e => e.IdCategoria, "IdCategoria");

            entity.Property(e => e.Descripcion).HasMaxLength(200);
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Precio).HasPrecision(10, 2);

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Pastel)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pastel_ibfk_1");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pedido");

            entity.Property(e => e.Correo).HasMaxLength(80);
            entity.Property(e => e.Instrucciones).HasMaxLength(200);
            entity.Property(e => e.NombreCliente).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);
            entity.Property(e => e.Total).HasPrecision(10, 2);
        });

        modelBuilder.Entity<PedidoDetalle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pedido_detalle");

            entity.HasIndex(e => e.IdPastel, "IdPastel");

            entity.HasIndex(e => e.IdPedido, "IdPedido");

            entity.HasIndex(e => e.IdTamano, "IdTamano");

            entity.Property(e => e.PrecioUnitario).HasPrecision(10, 2);

            entity.HasOne(d => d.IdPastelNavigation).WithMany(p => p.PedidoDetalle)
                .HasForeignKey(d => d.IdPastel)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pedido_detalle_ibfk_2");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.PedidoDetalle)
                .HasForeignKey(d => d.IdPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pedido_detalle_ibfk_1");

            entity.HasOne(d => d.IdTamanoNavigation).WithMany(p => p.PedidoDetalle)
                .HasForeignKey(d => d.IdTamano)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pedido_detalle_ibfk_3");
        });

        modelBuilder.Entity<TamanoPastel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tamano_pastel");

            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Precio).HasPrecision(10, 2);
        });

        modelBuilder.Entity<Usuarioadmin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("usuarioadmin");

            entity.Property(e => e.Contrasena).HasMaxLength(255);
            entity.Property(e => e.Nickname).HasMaxLength(60);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
