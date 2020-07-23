using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gradeamentos",
                columns: table => new
                {
                    IdGradeamento = table.Column<Guid>(nullable: false),
                    codigo = table.Column<string>(nullable: false),
                    Titulo = table.Column<string>(nullable: false),
                    Autor = table.Column<string>(nullable: false),
                    Orientador = table.Column<string>(nullable: false),
                    Data = table.Column<string>(nullable: false),
                    Resumo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gradeamentos", x => x.IdGradeamento);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gradeamentos");
        }
    }
}
