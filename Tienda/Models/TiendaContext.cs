using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Tienda.Models
{
    public partial class TiendaContext : DbContext
    {
        public TiendaContext()
        {
        }

        public TiendaContext(DbContextOptions<TiendaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tcliente> Tcliente { get; set; }
        public virtual DbSet<Tcompra> Tcompra { get; set; }
        public virtual DbSet<Tproducto> Tproducto { get; set; }
        public virtual DbSet<Tusuario> Tusuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data source=LAPTOP-SQ0Q815D\\SQLEXPRESS; Initial Catalog=Tienda; user id=johan_samper; password=admin;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tcliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__TCLIENTE__885457EE1B6B05BF");

                entity.ToTable("TCLIENTE");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.Celular)
                    .IsRequired()
                    .HasColumnName("celular")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasColumnName("sexo")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tcompra>(entity =>
            {
                entity.HasKey(e => e.IdCompra)
                    .HasName("PK__TCOMPRA__48B99DB7132CABCC");

                entity.ToTable("TCOMPRA");

                entity.Property(e => e.IdCompra).HasColumnName("idCompra");

                entity.Property(e => e.CantidadTotal).HasColumnName("cantidadTotal");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.Property(e => e.ValorTotal)
                    .HasColumnName("valorTotal")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Tcompra)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TCOMPRA__idClien__3E52440B");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Tcompra)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TCOMPRA__idProdu__3F466844");
            });

            modelBuilder.Entity<Tproducto>(entity =>
            {
                entity.HasKey(e => e.IdProdcuto)
                    .HasName("PK__TPRODUCT__AC92243C57952C88");

                entity.ToTable("TPRODUCTO");

                entity.Property(e => e.IdProdcuto).HasColumnName("idProdcuto");

                entity.Property(e => e.CantidadRestante).HasColumnName("cantidadRestante");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasColumnName("marca")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Precio)
                    .HasColumnName("precio")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<Tusuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__TUSUARIO__645723A6A011815A");

                entity.ToTable("TUSUARIO");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasColumnName("contraseña")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasColumnName("usuario")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Tusuario)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TUSUARIO__idClie__3B75D760");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
