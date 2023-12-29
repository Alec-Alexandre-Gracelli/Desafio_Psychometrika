using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Desafio_Psychometrika.Migrations
{
    public partial class NewDbRespostaGabarito_Psychometrika : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RespostaCorreta",
                table: "Gabaritos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldMaxLength: 1,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RespostaCorreta",
                table: "Gabaritos",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
