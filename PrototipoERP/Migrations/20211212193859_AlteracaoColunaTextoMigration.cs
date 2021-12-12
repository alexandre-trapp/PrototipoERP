using Microsoft.EntityFrameworkCore.Migrations;

namespace PrototipoERP.Migrations
{
    public partial class AlteracaoColunaTextoMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TextoLembrete",
                table: "lembretes",
                newName: "Texto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Texto",
                table: "lembretes",
                newName: "TextoLembrete");
        }
    }
}
