using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace ProyectoFinal.Models.Entities;

public partial class PasteleriaProyectoContext : DbContext
{
    public PasteleriaProyectoContext()
    {
    }

    public PasteleriaProyectoContext(DbContextOptions<PasteleriaProyectoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Pastel> Pastel { get; set; }

    public virtual DbSet<Pedidos> Pedidos { get; set; }

    public virtual DbSet<Usuarioadmin> Usuarioadmin { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=PasteleriaProyecto;port=3306", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.36-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("categoria");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Nombre).HasMaxLength(20);
        });

        modelBuilder.Entity<Pastel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pastel");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Descripcion).HasMaxLength(70);
            entity.Property(e => e.Detalles).HasMaxLength(200);
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Precio).HasPrecision(10);
        });

        modelBuilder.Entity<Pedidos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pedidos");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CodigoUnico).HasMaxLength(20);
            entity.Property(e => e.Correo).HasMaxLength(50);
            entity.Property(e => e.Instrucciones).HasMaxLength(150);
        });

        modelBuilder.Entity<Usuarioadmin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("usuarioadmin");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Contrasena).HasMaxLength(25);
            entity.Property(e => e.Nickname).HasMaxLength(60);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
