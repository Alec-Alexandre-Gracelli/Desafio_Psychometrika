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
                name: "ProvaSimulados",
                columns: table => new
                {
                    ProvaSimuladoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProvaNome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvaSimulados", x => x.ProvaSimuladoId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProvaSimuladoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Questoes",
                columns: table => new
                {
                    QuestoesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProvaSimuladoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Questao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questoes", x => x.QuestoesId);
                    table.ForeignKey(
                        name: "FK_Questoes_ProvaSimulados_ProvaSimuladoId",
                        column: x => x.ProvaSimuladoId,
                        principalTable: "ProvaSimulados",
                        principalColumn: "ProvaSimuladoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlternativaQuestoes",
                columns: table => new
                {
                    AlternativaQuestoesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestoesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Alternativas = table.Column<int>(type: "int", nullable: false),
                    Correta = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlternativaQuestoes", x => x.AlternativaQuestoesId);
                    table.ForeignKey(
                        name: "FK_AlternativaQuestoes_Questoes_QuestoesId",
                        column: x => x.QuestoesId,
                        principalTable: "Questoes",
                        principalColumn: "QuestoesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlternativaQuestoes_QuestoesId",
                table: "AlternativaQuestoes",
                column: "QuestoesId");

            migrationBuilder.CreateIndex(
                name: "IX_Questoes_ProvaSimuladoId",
                table: "Questoes",
                column: "ProvaSimuladoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlternativaQuestoes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Questoes");

            migrationBuilder.DropTable(
                name: "ProvaSimulados");
        }
    }
}
