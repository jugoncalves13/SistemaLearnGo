using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaLearnGo.Migrations
{
    /// <inheritdoc />
    public partial class FotoCadastroCerto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CadastroDataNascimento1",
                table: "Cadastro",
                newName: "CadastroFoto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CadastroFoto",
                table: "Cadastro",
                newName: "CadastroDataNascimento1");
        }
    }
}
