using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Empleados.Migrations
{
    /// <inheritdoc />
    public partial class Puestos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Puesto",
                table: "Empleados");

            migrationBuilder.AddColumn<Guid>(
                name: "PuestosidPuestos",
                table: "Empleados",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Puestos",
                columns: table => new
                {
                    idPuestos = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombrePuestos = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puestos", x => x.idPuestos);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_PuestosidPuestos",
                table: "Empleados",
                column: "PuestosidPuestos");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Puestos_PuestosidPuestos",
                table: "Empleados",
                column: "PuestosidPuestos",
                principalTable: "Puestos",
                principalColumn: "idPuestos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Puestos_PuestosidPuestos",
                table: "Empleados");

            migrationBuilder.DropTable(
                name: "Puestos");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_PuestosidPuestos",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "PuestosidPuestos",
                table: "Empleados");

            migrationBuilder.AddColumn<string>(
                name: "Puesto",
                table: "Empleados",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
