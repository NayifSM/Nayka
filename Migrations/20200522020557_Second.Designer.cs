﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shop.Web.Data;

namespace Ventas.Web.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200522020557_Second")]
    partial class Second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Shop.Web.Data.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Disponible");

                    b.Property<string>("ImageUrl")
                        .IsRequired();

                    b.Property<string>("Nombre");

                    b.Property<decimal>("Precio");

                    b.Property<double>("Stock");

                    b.Property<string>("UltimaCompra");

                    b.Property<string>("UltimaVenta");

                    b.Property<int?>("UsuariosId");

                    b.HasKey("Id");

                    b.HasIndex("UsuariosId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Ventas.Web.Data.Entities.Usuarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido_Materno")
                        .IsRequired();

                    b.Property<string>("Apellido_Paterno")
                        .IsRequired();

                    b.Property<string>("Correo")
                        .HasMaxLength(100);

                    b.Property<string>("Direccion")
                        .HasMaxLength(100);

                    b.Property<string>("Nombre")
                        .IsRequired();

                    b.Property<string>("Telefono")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Shop.Web.Data.Entities.Product", b =>
                {
                    b.HasOne("Ventas.Web.Data.Entities.Usuarios", "Usuarios")
                        .WithMany()
                        .HasForeignKey("UsuariosId");
                });
#pragma warning restore 612, 618
        }
    }
}