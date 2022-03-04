using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ProyectoIntegrado.DAL.Entities
{
    public partial class proyectointegradodbContext : DbContext
    {

        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<PosicionDeTrabajo> Posiciones { get; set; }
        public DbSet<FamiliaProfesional> FamiliasP { get; set; }
        public DbSet<TipoDeCiclo> TipoCiclos { get; set; }
        public DbSet<Ciclo> Ciclos { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Mensaje> Mensajes { get; set; }


        public proyectointegradodbContext()
        {
        }

        public proyectointegradodbContext(DbContextOptions<proyectointegradodbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=51.254.98.185;port=7045;user=carlos;password=sargentomillo;database=proyectointegradodb", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.22-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
