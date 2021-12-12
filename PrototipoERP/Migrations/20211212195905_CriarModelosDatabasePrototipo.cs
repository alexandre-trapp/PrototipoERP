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
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    senha = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "lembretes",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    usuario_id = table.Column<long>(type: "bigint", nullable: false),
                    data_hora = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    texto = table.Column<string>(type: "VARCHAR(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lembretes", x => x.id);
                    table.ForeignKey(
                        name: "FK_lembretes_usuarios_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_lembretes_id",
                table: "lembretes",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_lembretes_usuario_id",
                table: "lembretes",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_id",
                table: "usuarios",
                column: "id");

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
