using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PruebaScaffold.Models
{
    public partial class PruebaScaffoldContext : DbContext
    {
        public PruebaScaffoldContext()
        {
        }

        public PruebaScaffoldContext(DbContextOptions<PruebaScaffoldContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<DetallesFactura> DetallesFacturas { get; set; } = null!;
        public virtual DbSet<Factura> Facturas { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:Conexion");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.ClienteId)
                    .ValueGeneratedNever()
                    .HasColumnName("ClienteID");

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoPostal)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DetallesFactura>(entity =>
            {
                entity.HasKey(e => e.DetalleId)
                    .HasName("PK__Detalles__6E19D6FA44A15F19");

                entity.Property(e => e.DetalleId)
                    .ValueGeneratedNever()
                    .HasColumnName("DetalleID");

                entity.Property(e => e.FacturaId).HasColumnName("FacturaID");

                entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

                entity.Property(e => e.Subtotal).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Factura)
                    .WithMany(p => p.DetallesFacturas)
                    .HasForeignKey(d => d.FacturaId)
                    .HasConstraintName("FK__DetallesF__Factu__5070F446");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.DetallesFacturas)
                    .HasForeignKey(d => d.ProductoId)
                    .HasConstraintName("FK__DetallesF__Produ__5165187F");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.Property(e => e.FacturaId)
                    .ValueGeneratedNever()
                    .HasColumnName("FacturaID");

                entity.Property(e => e.ClienteId).HasColumnName("ClienteID");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("FK__Facturas__Client__4D94879B");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.Property(e => e.ProductoId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProductoID");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
