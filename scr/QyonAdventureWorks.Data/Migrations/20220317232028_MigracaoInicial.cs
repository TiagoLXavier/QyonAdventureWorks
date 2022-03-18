using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QyonAdventureWorks.Data.Migrations
{
    public partial class MigracaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Competidores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    Sexo = table.Column<string>(type: "char(1)", nullable: false),
                    TemperaturaMediaCorpo = table.Column<decimal>(type: "decimal", nullable: false),
                    Peso = table.Column<decimal>(type: "decimal", nullable: false),
                    Altura = table.Column<decimal>(type: "decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competidores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PistaCorridas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PistaCorridas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoCorridas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompetidorId = table.Column<int>(type: "int", nullable: false),
                    PistaCorridaId = table.Column<int>(type: "int", nullable: false),
                    DataCorrida = table.Column<DateTime>(type: "datetime", nullable: false),
                    TempoGasto = table.Column<decimal>(type: "decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoCorridas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoCorridas_Competidores_CompetidorId",
                        column: x => x.CompetidorId,
                        principalTable: "Competidores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricoCorridas_PistaCorridas_PistaCorridaId",
                        column: x => x.PistaCorridaId,
                        principalTable: "PistaCorridas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoCorridas_CompetidorId",
                table: "HistoricoCorridas",
                column: "CompetidorId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoCorridas_PistaCorridaId",
                table: "HistoricoCorridas",
                column: "PistaCorridaId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricoCorridas");

            migrationBuilder.DropTable(
                name: "Competidores");

            migrationBuilder.DropTable(
                name: "PistaCorridas");
        }
    }
}
