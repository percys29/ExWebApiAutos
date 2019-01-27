using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ExWebApiAutos.Model.VehiculoDb
{
    public partial class VehiculoDbContext : DbContext
    {
        public VehiculoDbContext()
        {
        }

        public VehiculoDbContext(DbContextOptions<VehiculoDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TMarca> TMarca { get; set; }
        public virtual DbSet<TVehiculo> TVehiculo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Data Source=LABA202LP04\\SQLEXPRESS;Initial Catalog=Vehiculo;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TMarca>(entity =>
            {
                entity.Property(e => e.MarcaId).ValueGeneratedNever();

                entity.Property(e => e.MarcaNombre).IsUnicode(false);
            });

            modelBuilder.Entity<TVehiculo>(entity =>
            {
                entity.Property(e => e.VehiculoId).ValueGeneratedNever();

                entity.Property(e => e.VehiculoColor).IsUnicode(false);

                entity.Property(e => e.VehiculoFull).IsUnicode(false);

                entity.Property(e => e.VehiculoMecanico).IsUnicode(false);

                entity.Property(e => e.VehiculoPlaca).IsUnicode(false);

                entity.HasOne(d => d.Marca)
                    .WithMany(p => p.TVehiculo)
                    .HasForeignKey(d => d.MarcaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_vehiculo_T_marca");
            });
        }
    }
}
