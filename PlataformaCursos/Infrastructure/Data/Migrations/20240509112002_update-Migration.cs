using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlataformaCursos.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateNewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "senhaHash",
                table: "Tbl_usuario",
                newName: "SenhaHash");

            migrationBuilder.AlterColumn<byte[]>(
                name: "SenhaHash",
                table: "Tbl_usuario",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldUnicode: false,
                oldMaxLength: 255);

            migrationBuilder.AddColumn<byte[]>(
                name: "SenhaSalt",
                table: "Tbl_usuario",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SenhaSalt",
                table: "Tbl_usuario");

            migrationBuilder.RenameColumn(
                name: "SenhaHash",
                table: "Tbl_usuario",
                newName: "senhaHash");

            migrationBuilder.AlterColumn<string>(
                name: "senhaHash",
                table: "Tbl_usuario",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");
        }
    }
}
