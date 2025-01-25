using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyNetAPI.Migrations
{
    public partial class AdicionarPerfisEPerfilPadrao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Adiciona a coluna PerfilId à tabela Usuarios
            migrationBuilder.AddColumn<int>(
                name: "PerfilId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            // Cria a tabela Perfil
            migrationBuilder.CreateTable(
                name: "Perfil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.Id);
                });

            // Insere os perfis "Admin" e "Visualizador"
            migrationBuilder.Sql("INSERT INTO Perfil (Nome) VALUES ('Admin')");
            migrationBuilder.Sql("INSERT INTO Perfil (Nome) VALUES ('Visualizador')");

            // Atualiza os usuários sem perfil para o perfil "Visualizador"
            migrationBuilder.Sql(@"
                UPDATE Usuarios 
                SET PerfilId = (SELECT Id FROM Perfil WHERE Nome = 'Visualizador') 
                WHERE PerfilId IS NULL
            ");

            // Cria o índice para a coluna PerfilId
            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PerfilId",
                table: "Usuarios",
                column: "PerfilId");

            // Adiciona a chave estrangeira entre Usuarios e Perfil
            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Perfil_PerfilId",
                table: "Usuarios",
                column: "PerfilId",
                principalTable: "Perfil",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove a chave estrangeira
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Perfil_PerfilId",
                table: "Usuarios");

            // Remove a tabela Perfil
            migrationBuilder.DropTable(
                name: "Perfil");

            // Remove o índice criado
            migrationBuilder.DropIndex(
                name: "IX_Usuarios_PerfilId",
                table: "Usuarios");

            // Remove a coluna PerfilId da tabela Usuarios
            migrationBuilder.DropColumn(
                name: "PerfilId",
                table: "Usuarios");
        }
    }
}
