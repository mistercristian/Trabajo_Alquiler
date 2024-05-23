using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trabajo_Alquiler.Migrations
{
    /// <inheritdoc />
    public partial class Alquiler : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Propiedades",
                columns: table => new
                {
                    Idpropiedad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo_propiedad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    No_habitaciones = table.Column<int>(type: "int", nullable: false),
                    Precio_alquiler = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    Disponible = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propiedades", x => x.Idpropiedad);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inquilinos",
                columns: table => new
                {
                    Idinquilino = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropiedadesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inquilinos", x => x.Idinquilino);
                    table.ForeignKey(
                        name: "FK_Inquilinos_Propiedades_PropiedadesId",
                        column: x => x.PropiedadesId,
                        principalTable: "Propiedades",
                        principalColumn: "Idpropiedad",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    Idcontrato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha_Inicio = table.Column<DateTime>(type: "date", nullable: false),
                    Fecha_Fin = table.Column<DateTime>(type: "date", nullable: false),
                    Deposito = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    Terminos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropiedadesId = table.Column<int>(type: "int", nullable: false),
                    InquilinosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.Idcontrato);
                    table.ForeignKey(
                        name: "FK_Contratos_Inquilinos_InquilinosId",
                        column: x => x.InquilinosId,
                        principalTable: "Inquilinos",
                        principalColumn: "Idinquilino",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Contratos_Propiedades_PropiedadesId",
                        column: x => x.PropiedadesId,
                        principalTable: "Propiedades",
                        principalColumn: "Idpropiedad",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Idpago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha_Pago = table.Column<DateTime>(type: "date", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContratosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Idpago);
                    table.ForeignKey(
                        name: "FK_Pagos_Contratos_ContratosId",
                        column: x => x.ContratosId,
                        principalTable: "Contratos",
                        principalColumn: "Idcontrato",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_InquilinosId",
                table: "Contratos",
                column: "InquilinosId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_PropiedadesId",
                table: "Contratos",
                column: "PropiedadesId");

            migrationBuilder.CreateIndex(
                name: "IX_Inquilinos_PropiedadesId",
                table: "Inquilinos",
                column: "PropiedadesId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_ContratosId",
                table: "Pagos",
                column: "ContratosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Contratos");

            migrationBuilder.DropTable(
                name: "Inquilinos");

            migrationBuilder.DropTable(
                name: "Propiedades");
        }
    }
}
