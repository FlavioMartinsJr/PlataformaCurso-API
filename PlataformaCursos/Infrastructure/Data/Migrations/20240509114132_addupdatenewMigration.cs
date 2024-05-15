using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlataformaCursos.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class addupdatenewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "Tbl_usuario",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "Tbl_usuario");
        }
    }
}
