using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaLearnGo.Migrations
{
    /// <inheritdoc />
    public partial class FotoCadastro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CadastroDataNascimento1",
                table: "Cadastro",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CadastroDataNascimento1",
                table: "Cadastro");
        }
    }
}
