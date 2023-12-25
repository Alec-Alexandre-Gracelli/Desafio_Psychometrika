using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Desafio_Psychometrika.Migrations
{
    public partial class Db_Psychometrika : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gabaritos",
                columns: table => new
                {
                    GabaritoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProvaSimuladoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestoesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RespostaCorreta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gabaritos", x => x.GabaritoId);
                });

            migrationBuilder.CreateTable(
                name: "Questoes",
                columns: table => new
                {
                    QuestoesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Questao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questoes", x => x.QuestoesId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "ProvaSimulados",
                columns: table => new
                {
                    ProvaSimuladoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestoesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProvaNome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Resposta = table.Column<int>(type: "int", nullable: true),
                    Respondido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvaSimulados", x => x.ProvaSimuladoId);
                    table.ForeignKey(
                        name: "FK_ProvaSimulados_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProvaSimulados_UsuarioId",
                table: "ProvaSimulados",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gabaritos");

            migrationBuilder.DropTable(
                name: "ProvaSimulados");

            migrationBuilder.DropTable(
                name: "Questoes");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
