using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace PrototipoERP.Migrations
{
    public partial class CriarModelosDatabasePrototipo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    senha = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "lembretes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false),
                    data_hora = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    texto = table.Column<string>(type: "VARCHAR(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_lembretes_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_lembretes_Id",
                table: "lembretes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_lembretes_UsuarioId",
                table: "lembretes",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_Id",
                table: "usuarios",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_nome_senha",
                table: "usuarios",
                columns: new[] { "nome", "senha" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lembretes");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
