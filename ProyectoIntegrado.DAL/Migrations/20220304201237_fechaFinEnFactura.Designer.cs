﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoIntegrado.DAL.Entities;

namespace ProyectoIntegrado.DAL.Migrations
{
    [DbContext(typeof(proyectointegradodbContext))]
    [Migration("20220304201237_fechaFinEnFactura")]
    partial class fechaFinEnFactura
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("CicloPosicionDeTrabajo", b =>
                {
                    b.Property<int>("CiclosId")
                        .HasColumnType("int");

                    b.Property<int>("PosicionesId")
                        .HasColumnType("int");

                    b.HasKey("CiclosId", "PosicionesId");

                    b.HasIndex("PosicionesId");

                    b.ToTable("CicloPosicionDeTrabajo");
                });

            modelBuilder.Entity("ProyectoIntegrado.DAL.Entities.Alumno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellidos")
                        .HasColumnType("longtext");

                    b.Property<string>("CodigoVerificacion")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("EmailVerificado")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("FechaDeNacimiento")
                        .HasColumnType("Date");

                    b.Property<int>("IdProvincia")
                        .HasColumnType("int");

                    b.Property<string>("Localidad")
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext");

                    b.Property<double>("NotaMedia")
                        .HasColumnType("double");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("idCiclo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdProvincia");

                    b.HasIndex("idCiclo");

                    b.ToTable("Alumnos");
                });

            modelBuilder.Entity("ProyectoIntegrado.DAL.Entities.Ciclo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdFamilia")
                        .HasColumnType("int");

                    b.Property<int>("IdTipo")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("IdFamilia");

                    b.HasIndex("IdTipo");

                    b.ToTable("Ciclos");
                });

            modelBuilder.Entity("ProyectoIntegrado.DAL.Entities.Contrato", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("empresaStripeId")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("fechaAltaSuscripcion")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("fechaCancelacion")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("idEmpresa")
                        .HasColumnType("int");

                    b.Property<string>("suscripcionId")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.HasIndex("idEmpresa");

                    b.ToTable("Contratos");
                });

            modelBuilder.Entity("ProyectoIntegrado.DAL.Entities.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CodigoVerificacion")
                        .HasColumnType("longtext");

                    b.Property<string>("Direccion")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("EmailVerificado")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Localidad")
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ProvinciaId")
                        .HasColumnType("int");

                    b.Property<string>("empresaStripeID")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ProvinciaId");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("ProyectoIntegrado.DAL.Entities.Factura", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("fechaCreacion")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("fechaFin")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("fechaPago")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("idContrato")
                        .HasColumnType("int");

                    b.Property<int>("idEmpresa")
                        .HasColumnType("int");

                    b.Property<string>("suscripcionId")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.HasIndex("idContrato");

                    b.HasIndex("idEmpresa");

                    b.ToTable("Facturas");
                });

            modelBuilder.Entity("ProyectoIntegrado.DAL.Entities.FacturasContratos", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("idContrato")
                        .HasColumnType("int");

                    b.Property<int>("idFactura")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("idContrato");

                    b.HasIndex("idFactura");

                    b.ToTable("FacturasContratos");
                });

            modelBuilder.Entity("ProyectoIntegrado.DAL.Entities.FamiliaProfesional", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("FamiliasP");
                });

            modelBuilder.Entity("ProyectoIntegrado.DAL.Entities.Inscripcion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AlumnoId")
                        .HasColumnType("int");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("EstadoInscripcion")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("FechaInscripcion")
                        .HasColumnType("Date");

                    b.Property<int>("PosicionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlumnoId");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("PosicionId");

                    b.ToTable("Inscripciones");
                });

            modelBuilder.Entity("ProyectoIntegrado.DAL.Entities.Mensaje", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("alumnoId")
                        .HasColumnType("int");

                    b.Property<string>("contenido")
                        .HasColumnType("longtext");

                    b.Property<int>("empresaId")
                        .HasColumnType("int");

                    b.Property<bool>("leido")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("id");

                    b.HasIndex("alumnoId");

                    b.HasIndex("empresaId");

                    b.ToTable("Mensajes");
                });

            modelBuilder.Entity("ProyectoIntegrado.DAL.Entities.PosicionDeTrabajo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("longtext");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Horario")
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext");

                    b.Property<double>("Remuneracion")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Posiciones");
                });

            modelBuilder.Entity("ProyectoIntegrado.DAL.Entities.Provincia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Provincias");
                });

            modelBuilder.Entity("ProyectoIntegrado.DAL.Entities.TipoDeCiclo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("TipoCiclos");
                });

            modelBuilder.Entity("CicloPosicionDeTrabajo", b =>
                {
                    b.HasOne("ProyectoIntegrado.DAL.Entities.Ciclo", null)
                        .WithMany()
                        .HasForeignKey("CiclosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoIntegrado.DAL.Entities.PosicionDeTrabajo", null)
                        .WithMany()
                        .HasForeignKey("PosicionesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProyectoIntegrado.DAL.Entities.Alumno", b =>
                {
                    b.HasOne("ProyectoIntegrado.DAL.Entities.Provincia", "Provincia")
                        .WithMany()
                        .HasForeignKey("IdProvincia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoIntegrado.DAL.Entities.Ciclo", "ciclo")
                        .WithMany()
                        .HasForeignKey("idCiclo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ciclo");

                    b.Navigation("Provincia");
                });

            modelBuilder.Entity("ProyectoIntegrado.DAL.Entities.Ciclo", b =>
                {
                    b.HasOne("ProyectoIntegrado.DAL.Entities.FamiliaProfesional", "familia")
                        .WithMany()
                        .HasForeignKey("IdFamilia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoIntegrado.DAL.Entities.TipoDeCiclo", "Tipociclo")
                        .WithMany()
                        .HasForeignKey("IdTipo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("familia");

                    b.Navigation("Tipociclo");
                });

            modelBuilder.Entity("ProyectoIntegrado.DAL.Entities.Contrato", b =>
                {
                    b.HasOne("ProyectoIntegrado.DAL.Entities.Empresa", "empresa")
                        .WithMany()
                        .HasForeignKey("idEmpresa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("empresa");
                });

            modelBuilder.Entity("ProyectoIntegrado.DAL.Entities.Empresa", b =>
                {
                    b.HasOne("ProyectoIntegrado.DAL.Entities.Provincia", "Provincia")
                        .WithMany()
                        .HasForeignKey("ProvinciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Provincia");
                });

            modelBuilder.Entity("ProyectoIntegrado.DAL.Entities.Factura", b =>
                {
                    b.HasOne("ProyectoIntegrado.DAL.Entities.Contrato", "contrato")
                        .WithMany()
                        .HasForeignKey("idContrato")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoIntegrado.DAL.Entities.Empresa", "empresa")
                        .WithMany()
                        .HasForeignKey("idEmpresa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("contrato");

                    b.Navigation("empresa");
                });

            modelBuilder.Entity("ProyectoIntegrado.DAL.Entities.FacturasContratos", b =>
                {
                    b.HasOne("ProyectoIntegrado.DAL.Entities.Contrato", "contrato")
                        .WithMany()
                        .HasForeignKey("idContrato")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoIntegrado.DAL.Entities.Factura", "factura")
                        .WithMany()
                        .HasForeignKey("idFactura")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("contrato");

                    b.Navigation("factura");
                });

            modelBuilder.Entity("ProyectoIntegrado.DAL.Entities.Inscripcion", b =>
                {
                    b.HasOne("ProyectoIntegrado.DAL.Entities.Alumno", "alumno")
                        .WithMany()
                        .HasForeignKey("AlumnoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoIntegrado.DAL.Entities.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoIntegrado.DAL.Entities.PosicionDeTrabajo", "Posicion")
                        .WithMany()
                        .HasForeignKey("PosicionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("alumno");

                    b.Navigation("Empresa");

                    b.Navigation("Posicion");
                });

            modelBuilder.Entity("ProyectoIntegrado.DAL.Entities.Mensaje", b =>
                {
                    b.HasOne("ProyectoIntegrado.DAL.Entities.Alumno", "alumno")
                        .WithMany()
                        .HasForeignKey("alumnoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoIntegrado.DAL.Entities.Empresa", "empresa")
                        .WithMany()
                        .HasForeignKey("empresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("alumno");

                    b.Navigation("empresa");
                });

            modelBuilder.Entity("ProyectoIntegrado.DAL.Entities.PosicionDeTrabajo", b =>
                {
                    b.HasOne("ProyectoIntegrado.DAL.Entities.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });
#pragma warning restore 612, 618
        }
    }
}
