using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Postagem.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoTabelasEBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cartas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tema = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Base = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntregaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Entregas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCarta = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdTerritorio = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Local = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entregas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entregas_Cartas_IdCarta",
                        column: x => x.IdCarta,
                        principalTable: "Cartas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Territorios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PontoReferencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntregaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Territorios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Territorios_Entregas_EntregaId",
                        column: x => x.EntregaId,
                        principalTable: "Entregas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cartas_EntregaId",
                table: "Cartas",
                column: "EntregaId");

            migrationBuilder.CreateIndex(
                name: "IX_Entregas_IdCarta",
                table: "Entregas",
                column: "IdCarta");

            migrationBuilder.CreateIndex(
                name: "IX_Entregas_IdTerritorio",
                table: "Entregas",
                column: "IdTerritorio");

            migrationBuilder.CreateIndex(
                name: "IX_Territorios_EntregaId",
                table: "Territorios",
                column: "EntregaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cartas_Entregas_EntregaId",
                table: "Cartas",
                column: "EntregaId",
                principalTable: "Entregas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Entregas_Territorios_IdTerritorio",
                table: "Entregas",
                column: "IdTerritorio",
                principalTable: "Territorios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cartas_Entregas_EntregaId",
                table: "Cartas");

            migrationBuilder.DropForeignKey(
                name: "FK_Territorios_Entregas_EntregaId",
                table: "Territorios");

            migrationBuilder.DropTable(
                name: "Entregas");

            migrationBuilder.DropTable(
                name: "Cartas");

            migrationBuilder.DropTable(
                name: "Territorios");
        }
    }
}
