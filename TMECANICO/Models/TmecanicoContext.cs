using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TMECANICO.Models;

public partial class TmecanicoContext : DbContext
{
    public TmecanicoContext()
    {
    }

    public TmecanicoContext(DbContextOptions<TmecanicoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Mecanicco> Mecaniccos { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-E1EBHHH; Database=TMECANICO; Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente);

            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.Direccion)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.IdVehiculo).HasColumnName("id_vehiculo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Numero)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.IdVehiculoNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdVehiculo)
                .HasConstraintName("FK_Clientes_Vehiculos");
        });

        modelBuilder.Entity<Mecanicco>(entity =>
        {
            entity.HasKey(e => e.IdMecanico);

            entity.Property(e => e.IdMecanico).HasColumnName("id_mecanico");
            entity.Property(e => e.Cedula)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Horario)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.IdVehiculo);

            entity.Property(e => e.IdVehiculo).HasColumnName("id_vehiculo");
            entity.Property(e => e.Color)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.IdMecanico).HasColumnName("id_mecanico");
            entity.Property(e => e.Modelo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Reparacion)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.IdMecanicoNavigation).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.IdMecanico)
                .HasConstraintName("FK_Vehiculos_Mecaniccos");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
