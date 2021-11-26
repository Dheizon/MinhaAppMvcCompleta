using Microsoft.EntityFrameworkCore.Migrations;

namespace DevIO.Data.Migrations
{
    public partial class EnderecoTesteAddIBGESIAFI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IBGE",
                table: "EnderecoTeste",
                type: "varchar(16)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SIAFI",
                table: "EnderecoTeste",
                type: "varchar(16)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IBGE",
                table: "EnderecoTeste");

            migrationBuilder.DropColumn(
                name: "SIAFI",
                table: "EnderecoTeste");
        }
    }
}
