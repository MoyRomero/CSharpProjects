using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiAutores.Migrations
{
    /// <inheritdoc />
    public partial class ActualizacionCampoUsuarioId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LlavesAPI_AspNetUsers_UsuarioId1",
                table: "LlavesAPI");

            migrationBuilder.DropIndex(
                name: "IX_LlavesAPI_UsuarioId1",
                table: "LlavesAPI");

            migrationBuilder.DropColumn(
                name: "UsuarioId1",
                table: "LlavesAPI");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "LlavesAPI",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_LlavesAPI_UsuarioId",
                table: "LlavesAPI",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_LlavesAPI_AspNetUsers_UsuarioId",
                table: "LlavesAPI",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LlavesAPI_AspNetUsers_UsuarioId",
                table: "LlavesAPI");

            migrationBuilder.DropIndex(
                name: "IX_LlavesAPI_UsuarioId",
                table: "LlavesAPI");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "LlavesAPI",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId1",
                table: "LlavesAPI",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LlavesAPI_UsuarioId1",
                table: "LlavesAPI",
                column: "UsuarioId1");

            migrationBuilder.AddForeignKey(
                name: "FK_LlavesAPI_AspNetUsers_UsuarioId1",
                table: "LlavesAPI",
                column: "UsuarioId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
