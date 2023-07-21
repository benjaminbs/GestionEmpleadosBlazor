using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionEmpleadosBlazor.Server.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEmp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpresaEmp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorreoAsigEmp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CelAsigEmp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelFijoAsigEmp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtAsigEmp = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empleado");
        }
    }
}
