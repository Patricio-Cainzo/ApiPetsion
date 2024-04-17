using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPetsion.Migrations
{
    /// <inheritdoc />
    public partial class Primera : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anfitriones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoVivienda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patio = table.Column<bool>(type: "bit", nullable: false),
                    AdmiteGato = table.Column<bool>(type: "bit", nullable: false),
                    AdmitePerroGrande = table.Column<bool>(type: "bit", nullable: false),
                    AdmitePerroMediano = table.Column<bool>(type: "bit", nullable: false),
                    AdmitePerroPequeno = table.Column<bool>(type: "bit", nullable: false),
                    PaseoMascota = table.Column<bool>(type: "bit", nullable: false),
                    Horarios = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfreceAlojamiento = table.Column<bool>(type: "bit", nullable: false),
                    GuarderiaDiurna = table.Column<bool>(type: "bit", nullable: false),
                    DisponibleLunes = table.Column<bool>(type: "bit", nullable: false),
                    DisponibleMartes = table.Column<bool>(type: "bit", nullable: false),
                    DisponibleMiercoles = table.Column<bool>(type: "bit", nullable: false),
                    DisponibleJueves = table.Column<bool>(type: "bit", nullable: false),
                    DisponibleViernes = table.Column<bool>(type: "bit", nullable: false),
                    DisponibleSabado = table.Column<bool>(type: "bit", nullable: false),
                    DisponibleDomingo = table.Column<bool>(type: "bit", nullable: false),
                    CantidadmascotaAdmite = table.Column<int>(type: "int", nullable: false),
                    MascotasdistDueño = table.Column<bool>(type: "bit", nullable: false),
                    AceptaCancelaciones = table.Column<bool>(type: "bit", nullable: false),
                    NombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anfitriones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechadeNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreDeUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anfitriones");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
