﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using ServicuerosSA.Data;
using System;

namespace ServicuerosSA.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180829002441_curtido")]
    partial class curtido
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ServicuerosSA.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("ServicuerosSA.Models.Bodega", b =>
                {
                    b.Property<int>("BodegaId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CantidadAlmacenamiento");

                    b.Property<string>("NombreBodega")
                        .IsRequired();

                    b.Property<int>("NumeroEstantes");

                    b.Property<int>("TipoBodegaId");

                    b.Property<string>("Ubicacion")
                        .IsRequired();

                    b.HasKey("BodegaId");

                    b.HasIndex("TipoBodegaId");

                    b.ToTable("Bodega");
                });

            modelBuilder.Entity("ServicuerosSA.Models.Bodega1", b =>
                {
                    b.Property<int>("Bodega1Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BodegaId");

                    b.Property<int>("ClasificacionId");

                    b.Property<DateTime>("Fechaingreso");

                    b.Property<int>("LoteId");

                    b.Property<int>("MedidaId");

                    b.Property<int>("NumeroEstanteria");

                    b.Property<int>("NumeroPieles");

                    b.Property<string>("Observaciones");

                    b.Property<int>("Peso");

                    b.Property<int>("TipoPielId");

                    b.Property<bool>("activo");

                    b.HasKey("Bodega1Id");

                    b.HasIndex("BodegaId");

                    b.HasIndex("ClasificacionId");

                    b.HasIndex("LoteId");

                    b.HasIndex("MedidaId");

                    b.HasIndex("TipoPielId");

                    b.ToTable("Bodega1");
                });

            modelBuilder.Entity("ServicuerosSA.Models.Bodegatripa", b =>
                {
                    b.Property<int>("BodegaTripaId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClasificacionTripaId");

                    b.Property<int>("DescarneId");

                    b.Property<int>("NumeroPieles");

                    b.Property<int>("PersonalId");

                    b.Property<bool>("activo");

                    b.Property<int>("peso");

                    b.HasKey("BodegaTripaId");

                    b.HasIndex("ClasificacionTripaId");

                    b.HasIndex("DescarneId");

                    b.HasIndex("PersonalId");

                    b.ToTable("Bodegatripa");
                });

            modelBuilder.Entity("ServicuerosSA.Models.Bombo", b =>
                {
                    b.Property<int>("BomboId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Capacidad");

                    b.Property<DateTime>("FechaIngreso");

                    b.Property<int>("Num_bombo");

                    b.HasKey("BomboId");

                    b.ToTable("Bombo");
                });

            modelBuilder.Entity("ServicuerosSA.Models.Clasificacion", b =>
                {
                    b.Property<int>("ClasificacionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Selecciones")
                        .IsRequired();

                    b.HasKey("ClasificacionId");

                    b.ToTable("Clasificacion");
                });

            modelBuilder.Entity("ServicuerosSA.Models.ClasificacionTripa", b =>
                {
                    b.Property<int>("ClasificacionTripaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Detalle")
                        .IsRequired();

                    b.HasKey("ClasificacionTripaId");

                    b.ToTable("ClasificacionTripa");
                });

            modelBuilder.Entity("ServicuerosSA.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Direccion")
                        .IsRequired();

                    b.Property<string>("Nombre")
                        .IsRequired();

                    b.Property<string>("RUC")
                        .IsRequired();

                    b.Property<string>("Teleofno")
                        .IsRequired();

                    b.Property<string>("correo")
                        .IsRequired();

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("ServicuerosSA.Models.Componente", b =>
                {
                    b.Property<int>("ComponenteId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Detalle")
                        .IsRequired();

                    b.Property<int>("FormulaId");

                    b.Property<int>("MedidaId");

                    b.Property<string>("Porcentaje")
                        .IsRequired();

                    b.Property<bool>("Quimico");

                    b.Property<int>("Tiempo");

                    b.HasKey("ComponenteId");

                    b.HasIndex("FormulaId");

                    b.HasIndex("MedidaId");

                    b.ToTable("Componente");
                });

            modelBuilder.Entity("ServicuerosSA.Models.Curtido", b =>
                {
                    b.Property<int>("CurtidoId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BomboId");

                    b.Property<int>("ClasificacionTripaId");

                    b.Property<DateTime>("Fecha");

                    b.Property<int>("FormulaId");

                    b.Property<int>("NPieles");

                    b.Property<string>("Observaciones");

                    b.Property<int>("PersonalId");

                    b.Property<int>("Peso");

                    b.HasKey("CurtidoId");

                    b.HasIndex("BomboId");

                    b.HasIndex("ClasificacionTripaId");

                    b.HasIndex("FormulaId");

                    b.HasIndex("PersonalId");

                    b.ToTable("Curtido");
                });

            modelBuilder.Entity("ServicuerosSA.Models.Descarne", b =>
                {
                    b.Property<int>("DescarneId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Activo");

                    b.Property<int>("Cantidad");

                    b.Property<string>("CodigoLote");

                    b.Property<DateTime>("Fecha");

                    b.Property<int>("PelambreId");

                    b.Property<int>("PersonalId");

                    b.Property<string>("codigodescarne");

                    b.HasKey("DescarneId");

                    b.HasIndex("PelambreId");

                    b.HasIndex("PersonalId");

                    b.ToTable("Descarne");
                });

            modelBuilder.Entity("ServicuerosSA.Models.Formula", b =>
                {
                    b.Property<int>("FormulaId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Fecha_Creacion");

                    b.Property<string>("Nombre")
                        .IsRequired();

                    b.Property<int>("TipoPielId");

                    b.Property<string>("TipoProceso")
                        .IsRequired();

                    b.Property<string>("Version");

                    b.HasKey("FormulaId");

                    b.HasIndex("TipoPielId");

                    b.ToTable("Formula");
                });

            modelBuilder.Entity("ServicuerosSA.Models.Lote", b =>
                {
                    b.Property<int>("LoteId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Codigolote")
                        .IsRequired();

                    b.Property<DateTime>("Fechaingreso");

                    b.Property<int>("Numerodepieles");

                    b.Property<string>("Observaciones");

                    b.Property<int>("PersonalId");

                    b.Property<int>("TipoPielId");

                    b.Property<bool>("estado");

                    b.HasKey("LoteId");

                    b.HasIndex("PersonalId");

                    b.HasIndex("TipoPielId");

                    b.ToTable("Lote");
                });

            modelBuilder.Entity("ServicuerosSA.Models.Medida", b =>
                {
                    b.Property<int>("MedidaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Abreviatura")
                        .IsRequired();

                    b.Property<string>("Detalle")
                        .IsRequired();

                    b.HasKey("MedidaId");

                    b.ToTable("Medida");
                });

            modelBuilder.Entity("ServicuerosSA.Models.Pelambre", b =>
                {
                    b.Property<int>("PelambreId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Activo");

                    b.Property<int>("Bodega1Id");

                    b.Property<int>("BomboId");

                    b.Property<string>("Codigo");

                    b.Property<string>("CodigoLote");

                    b.Property<DateTime>("Fecha");

                    b.Property<int>("FormulaId");

                    b.Property<string>("Observaciones");

                    b.Property<int>("PersonalId");

                    b.Property<int>("Peso");

                    b.Property<int>("TotalPieles");

                    b.Property<string>("codigopelambre");

                    b.HasKey("PelambreId");

                    b.HasIndex("Bodega1Id");

                    b.HasIndex("BomboId");

                    b.HasIndex("FormulaId");

                    b.HasIndex("PersonalId");

                    b.ToTable("Pelambre");
                });

            modelBuilder.Entity("ServicuerosSA.Models.Personal", b =>
                {
                    b.Property<int>("PersonalId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Apellidos")
                        .IsRequired();

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasMaxLength(17);

                    b.Property<string>("Direccion");

                    b.Property<DateTime>("FechaNacimiento");

                    b.Property<string>("Nombres")
                        .IsRequired();

                    b.Property<int>("SexoId");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(17);

                    b.HasKey("PersonalId");

                    b.HasIndex("SexoId");

                    b.ToTable("Personal");
                });

            modelBuilder.Entity("ServicuerosSA.Models.Proveedor", b =>
                {
                    b.Property<int>("ProveedorId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasMaxLength(17);

                    b.Property<string>("Direccion")
                        .HasMaxLength(255);

                    b.Property<string>("Email");

                    b.Property<bool>("Estado");

                    b.Property<DateTime>("Fechaingreso");

                    b.Property<string>("Marcaproveedor");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Ruc")
                        .IsRequired()
                        .HasMaxLength(13);

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(17);

                    b.HasKey("ProveedorId");

                    b.ToTable("Proveedor");
                });

            modelBuilder.Entity("ServicuerosSA.Models.Proveedor_Lote", b =>
                {
                    b.Property<int>("Proveedor_LoteId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("LoteId");

                    b.Property<int>("ProveedorId");

                    b.HasKey("Proveedor_LoteId");

                    b.HasIndex("LoteId");

                    b.HasIndex("ProveedorId");

                    b.ToTable("Proveedor_Lote");
                });

            modelBuilder.Entity("ServicuerosSA.Models.Sexo", b =>
                {
                    b.Property<int>("SexoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Detalle")
                        .IsRequired();

                    b.HasKey("SexoId");

                    b.ToTable("Sexo");
                });

            modelBuilder.Entity("ServicuerosSA.Models.TipoBodega", b =>
                {
                    b.Property<int>("TipoBodegaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Detalle")
                        .IsRequired();

                    b.HasKey("TipoBodegaId");

                    b.ToTable("TipoBodega");
                });

            modelBuilder.Entity("ServicuerosSA.Models.TipoPiel", b =>
                {
                    b.Property<int>("TipoPielId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Detalle")
                        .IsRequired();

                    b.HasKey("TipoPielId");

                    b.ToTable("TipoPiel");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ServicuerosSA.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ServicuerosSA.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ServicuerosSA.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ServicuerosSA.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ServicuerosSA.Models.Bodega", b =>
                {
                    b.HasOne("ServicuerosSA.Models.TipoBodega", "TiposBodega")
                        .WithMany()
                        .HasForeignKey("TipoBodegaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ServicuerosSA.Models.Bodega1", b =>
                {
                    b.HasOne("ServicuerosSA.Models.Bodega", "Bodegas")
                        .WithMany()
                        .HasForeignKey("BodegaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ServicuerosSA.Models.Clasificacion", "Clasificaciones")
                        .WithMany()
                        .HasForeignKey("ClasificacionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ServicuerosSA.Models.Lote", "Lotes")
                        .WithMany()
                        .HasForeignKey("LoteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ServicuerosSA.Models.Medida", "Medida")
                        .WithMany()
                        .HasForeignKey("MedidaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ServicuerosSA.Models.TipoPiel", "TipoPiel")
                        .WithMany()
                        .HasForeignKey("TipoPielId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ServicuerosSA.Models.Bodegatripa", b =>
                {
                    b.HasOne("ServicuerosSA.Models.ClasificacionTripa", "ClasificacionTripa")
                        .WithMany()
                        .HasForeignKey("ClasificacionTripaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ServicuerosSA.Models.Descarne", "Descarnes")
                        .WithMany()
                        .HasForeignKey("DescarneId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ServicuerosSA.Models.Personal", "personal")
                        .WithMany()
                        .HasForeignKey("PersonalId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ServicuerosSA.Models.Componente", b =>
                {
                    b.HasOne("ServicuerosSA.Models.Formula", "formula")
                        .WithMany()
                        .HasForeignKey("FormulaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ServicuerosSA.Models.Medida", "Medida")
                        .WithMany()
                        .HasForeignKey("MedidaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ServicuerosSA.Models.Curtido", b =>
                {
                    b.HasOne("ServicuerosSA.Models.Bombo", "Bombo")
                        .WithMany()
                        .HasForeignKey("BomboId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ServicuerosSA.Models.ClasificacionTripa", "ClasificacionTripa")
                        .WithMany()
                        .HasForeignKey("ClasificacionTripaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ServicuerosSA.Models.Formula", "Formula")
                        .WithMany()
                        .HasForeignKey("FormulaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ServicuerosSA.Models.Personal", "Personal")
                        .WithMany()
                        .HasForeignKey("PersonalId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ServicuerosSA.Models.Descarne", b =>
                {
                    b.HasOne("ServicuerosSA.Models.Pelambre", "Pelambres")
                        .WithMany()
                        .HasForeignKey("PelambreId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ServicuerosSA.Models.Personal", "personales")
                        .WithMany()
                        .HasForeignKey("PersonalId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ServicuerosSA.Models.Formula", b =>
                {
                    b.HasOne("ServicuerosSA.Models.TipoPiel", "tipoPiel")
                        .WithMany()
                        .HasForeignKey("TipoPielId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ServicuerosSA.Models.Lote", b =>
                {
                    b.HasOne("ServicuerosSA.Models.Personal", "Personal")
                        .WithMany()
                        .HasForeignKey("PersonalId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ServicuerosSA.Models.TipoPiel", "TipoPieles")
                        .WithMany()
                        .HasForeignKey("TipoPielId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ServicuerosSA.Models.Pelambre", b =>
                {
                    b.HasOne("ServicuerosSA.Models.Bodega1", "Bodega1")
                        .WithMany()
                        .HasForeignKey("Bodega1Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ServicuerosSA.Models.Bombo", "Bombo")
                        .WithMany()
                        .HasForeignKey("BomboId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ServicuerosSA.Models.Formula", "Formula")
                        .WithMany()
                        .HasForeignKey("FormulaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ServicuerosSA.Models.Personal", "personal")
                        .WithMany()
                        .HasForeignKey("PersonalId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ServicuerosSA.Models.Personal", b =>
                {
                    b.HasOne("ServicuerosSA.Models.Sexo", "Sexo")
                        .WithMany()
                        .HasForeignKey("SexoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ServicuerosSA.Models.Proveedor_Lote", b =>
                {
                    b.HasOne("ServicuerosSA.Models.Lote", "Lotes")
                        .WithMany()
                        .HasForeignKey("LoteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ServicuerosSA.Models.Proveedor", "Proveedores")
                        .WithMany()
                        .HasForeignKey("ProveedorId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
