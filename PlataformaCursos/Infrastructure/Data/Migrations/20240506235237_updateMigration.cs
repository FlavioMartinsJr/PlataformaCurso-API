using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlataformaCursos.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cod",
                table: "Tbl_usuario");

            migrationBuilder.AddColumn<bool>(
                name: "isProfessor",
                table: "Tbl_usuario",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "senhaHash",
                table: "Tbl_usuario",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isProfessor",
                table: "Tbl_usuario");

            migrationBuilder.DropColumn(
                name: "senhaHash",
                table: "Tbl_usuario");

            migrationBuilder.AddColumn<string>(
                name: "cod",
                table: "Tbl_usuario",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true);
        }
    }
}
