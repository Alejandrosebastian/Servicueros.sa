using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ServicuerosSA.Migrations
{
    public partial class ya : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bombo",
                columns: table => new
                {
                    BomboId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Capacidad = table.Column<int>(nullable: false),
                    FechaIngreso = table.Column<DateTime>(nullable: false),
                    Num_bombo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bombo", x => x.BomboId);
                });

            migrationBuilder.CreateTable(
                name: "Clasificacion",
                columns: table => new
                {
                    ClasificacionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Selecciones = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clasificacion", x => x.ClasificacionId);
                });

            migrationBuilder.CreateTable(
                name: "Medida",
                columns: table => new
                {
                    MedidaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Abreviatura = table.Column<string>(nullable: false),
                    Detalle = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medida", x => x.MedidaId);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    ProveedorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Celular = table.Column<string>(maxLength: 17, nullable: false),
                    Direccion = table.Column<string>(maxLength: 255, nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Estado = table.Column<bool>(nullable: false),
                    Fechaingreso = table.Column<DateTime>(nullable: false),
                    Marcaproveedor = table.Column<string>(nullable: true),
                    Nombres = table.Column<string>(maxLength: 255, nullable: false),
                    Ruc = table.Column<string>(maxLength: 13, nullable: false),
                    Telefono = table.Column<string>(maxLength: 17, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.ProveedorId);
                });

            migrationBuilder.CreateTable(
                name: "Sexo",
                columns: table => new
                {
                    SexoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Detalle = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexo", x => x.SexoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoBodega",
                columns: table => new
                {
                    TipoBodegaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Detalle = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoBodega", x => x.TipoBodegaId);
                });

            migrationBuilder.CreateTable(
                name: "TipoPiel",
                columns: table => new
                {
                    TipoPielId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Detalle = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPiel", x => x.TipoPielId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personal",
                columns: table => new
                {
                    PersonalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Apellidos = table.Column<string>(nullable: false),
                    Cedula = table.Column<string>(maxLength: 10, nullable: false),
                    Celular = table.Column<string>(maxLength: 17, nullable: false),
                    Direccion = table.Column<string>(nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    Nombres = table.Column<string>(nullable: false),
                    SexoId = table.Column<int>(nullable: false),
                    Telefono = table.Column<string>(maxLength: 17, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personal", x => x.PersonalId);
                    table.ForeignKey(
                        name: "FK_Personal_Sexo_SexoId",
                        column: x => x.SexoId,
                        principalTable: "Sexo",
                        principalColumn: "SexoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bodega",
                columns: table => new
                {
                    BodegaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CantidadAlmacenamiento = table.Column<int>(nullable: false),
                    NombreBodega = table.Column<string>(nullable: false),
                    NumeroEstantes = table.Column<int>(nullable: false),
                    TipoBodegaId = table.Column<int>(nullable: false),
                    Ubicacion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bodega", x => x.BodegaId);
                    table.ForeignKey(
                        name: "FK_Bodega_TipoBodega_TipoBodegaId",
                        column: x => x.TipoBodegaId,
                        principalTable: "TipoBodega",
                        principalColumn: "TipoBodegaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Formula",
                columns: table => new
                {
                    FormulaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fecha_Creacion = table.Column<DateTime>(nullable: false),
                    Nombre = table.Column<string>(nullable: false),
                    TipoPielId = table.Column<int>(nullable: false),
                    TipoProceso = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formula", x => x.FormulaId);
                    table.ForeignKey(
                        name: "FK_Formula_TipoPiel_TipoPielId",
                        column: x => x.TipoPielId,
                        principalTable: "TipoPiel",
                        principalColumn: "TipoPielId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lote",
                columns: table => new
                {
                    LoteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigolote = table.Column<string>(nullable: false),
                    Fechaingreso = table.Column<DateTime>(nullable: false),
                    MedidaId = table.Column<int>(nullable: false),
                    Numerodepieles = table.Column<int>(nullable: false),
                    Observaciones = table.Column<string>(nullable: true),
                    PersonalId = table.Column<int>(nullable: false),
                    Peso = table.Column<int>(nullable: false),
                    TipoPielId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lote", x => x.LoteId);
                    table.ForeignKey(
                        name: "FK_Lote_Medida_MedidaId",
                        column: x => x.MedidaId,
                        principalTable: "Medida",
                        principalColumn: "MedidaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lote_Personal_PersonalId",
                        column: x => x.PersonalId,
                        principalTable: "Personal",
                        principalColumn: "PersonalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lote_TipoPiel_TipoPielId",
                        column: x => x.TipoPielId,
                        principalTable: "TipoPiel",
                        principalColumn: "TipoPielId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Componente",
                columns: table => new
                {
                    ComponenteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Detalle = table.Column<string>(nullable: false),
                    FormulaId = table.Column<int>(nullable: false),
                    MedidaId = table.Column<int>(nullable: false),
                    Porcentaje = table.Column<string>(nullable: false),
                    Tiempo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Componente", x => x.ComponenteId);
                    table.ForeignKey(
                        name: "FK_Componente_Formula_FormulaId",
                        column: x => x.FormulaId,
                        principalTable: "Formula",
                        principalColumn: "FormulaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Componente_Medida_MedidaId",
                        column: x => x.MedidaId,
                        principalTable: "Medida",
                        principalColumn: "MedidaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bodega1",
                columns: table => new
                {
                    Bodega1Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BodegaId = table.Column<int>(nullable: false),
                    ClasificacionId = table.Column<int>(nullable: false),
                    Fechaingreso = table.Column<DateTime>(nullable: false),
                    LoteId = table.Column<int>(nullable: false),
                    MedidaId = table.Column<int>(nullable: false),
                    NumeroEstanteria = table.Column<int>(nullable: false),
                    NumeroPieles = table.Column<int>(nullable: false),
                    Observaciones = table.Column<string>(nullable: true),
                    Peso = table.Column<int>(nullable: false),
                    activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bodega1", x => x.Bodega1Id);
                    table.ForeignKey(
                        name: "FK_Bodega1_Bodega_BodegaId",
                        column: x => x.BodegaId,
                        principalTable: "Bodega",
                        principalColumn: "BodegaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bodega1_Clasificacion_ClasificacionId",
                        column: x => x.ClasificacionId,
                        principalTable: "Clasificacion",
                        principalColumn: "ClasificacionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bodega1_Lote_LoteId",
                        column: x => x.LoteId,
                        principalTable: "Lote",
                        principalColumn: "LoteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bodega1_Medida_MedidaId",
                        column: x => x.MedidaId,
                        principalTable: "Medida",
                        principalColumn: "MedidaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor_Lote",
                columns: table => new
                {
                    Proveedor_LoteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LoteId = table.Column<int>(nullable: false),
                    ProveedorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor_Lote", x => x.Proveedor_LoteId);
                    table.ForeignKey(
                        name: "FK_Proveedor_Lote_Lote_LoteId",
                        column: x => x.LoteId,
                        principalTable: "Lote",
                        principalColumn: "LoteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proveedor_Lote_Proveedor_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedor",
                        principalColumn: "ProveedorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pelambre",
                columns: table => new
                {
                    PelambreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bodega1Id = table.Column<int>(nullable: false),
                    BomboId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    FormulaId = table.Column<int>(nullable: false),
                    MedidaId = table.Column<int>(nullable: false),
                    Observaciones = table.Column<string>(nullable: true),
                    PersonalId = table.Column<int>(nullable: false),
                    Peso = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pelambre", x => x.PelambreId);
                    table.ForeignKey(
                        name: "FK_Pelambre_Bodega1_Bodega1Id",
                        column: x => x.Bodega1Id,
                        principalTable: "Bodega1",
                        principalColumn: "Bodega1Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pelambre_Bombo_BomboId",
                        column: x => x.BomboId,
                        principalTable: "Bombo",
                        principalColumn: "BomboId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pelambre_Formula_FormulaId",
                        column: x => x.FormulaId,
                        principalTable: "Formula",
                        principalColumn: "FormulaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pelambre_Medida_MedidaId",
                        column: x => x.MedidaId,
                        principalTable: "Medida",
                        principalColumn: "MedidaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pelambre_Personal_PersonalId",
                        column: x => x.PersonalId,
                        principalTable: "Personal",
                        principalColumn: "PersonalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bodega_TipoBodegaId",
                table: "Bodega",
                column: "TipoBodegaId");

            migrationBuilder.CreateIndex(
                name: "IX_Bodega1_BodegaId",
                table: "Bodega1",
                column: "BodegaId");

            migrationBuilder.CreateIndex(
                name: "IX_Bodega1_ClasificacionId",
                table: "Bodega1",
                column: "ClasificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Bodega1_LoteId",
                table: "Bodega1",
                column: "LoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Bodega1_MedidaId",
                table: "Bodega1",
                column: "MedidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Componente_FormulaId",
                table: "Componente",
                column: "FormulaId");

            migrationBuilder.CreateIndex(
                name: "IX_Componente_MedidaId",
                table: "Componente",
                column: "MedidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Formula_TipoPielId",
                table: "Formula",
                column: "TipoPielId");

            migrationBuilder.CreateIndex(
                name: "IX_Lote_MedidaId",
                table: "Lote",
                column: "MedidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Lote_PersonalId",
                table: "Lote",
                column: "PersonalId");

            migrationBuilder.CreateIndex(
                name: "IX_Lote_TipoPielId",
                table: "Lote",
                column: "TipoPielId");

            migrationBuilder.CreateIndex(
                name: "IX_Pelambre_Bodega1Id",
                table: "Pelambre",
                column: "Bodega1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Pelambre_BomboId",
                table: "Pelambre",
                column: "BomboId");

            migrationBuilder.CreateIndex(
                name: "IX_Pelambre_FormulaId",
                table: "Pelambre",
                column: "FormulaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pelambre_MedidaId",
                table: "Pelambre",
                column: "MedidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pelambre_PersonalId",
                table: "Pelambre",
                column: "PersonalId");

            migrationBuilder.CreateIndex(
                name: "IX_Personal_SexoId",
                table: "Personal",
                column: "SexoId");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_Lote_LoteId",
                table: "Proveedor_Lote",
                column: "LoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_Lote_ProveedorId",
                table: "Proveedor_Lote",
                column: "ProveedorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Componente");

            migrationBuilder.DropTable(
                name: "Pelambre");

            migrationBuilder.DropTable(
                name: "Proveedor_Lote");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Bodega1");

            migrationBuilder.DropTable(
                name: "Bombo");

            migrationBuilder.DropTable(
                name: "Formula");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "Bodega");

            migrationBuilder.DropTable(
                name: "Clasificacion");

            migrationBuilder.DropTable(
                name: "Lote");

            migrationBuilder.DropTable(
                name: "TipoBodega");

            migrationBuilder.DropTable(
                name: "Medida");

            migrationBuilder.DropTable(
                name: "Personal");

            migrationBuilder.DropTable(
                name: "TipoPiel");

            migrationBuilder.DropTable(
                name: "Sexo");
        }
    }
}
