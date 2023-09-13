using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiAutores.Migrations
{
    /// <inheritdoc />
    public partial class InicialWebApiSuscriptores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LlavesAPI",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Llave = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoLlave = table.Column<int>(type: "int", nullable: false),
                    Activa = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LlavesAPI", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LlavesAPI_AspNetUsers_UsuarioId1",
                        column: x => x.UsuarioId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LlavesAPI_UsuarioId1",
                table: "LlavesAPI",
                column: "UsuarioId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LlavesAPI");
        }
    }
}
