using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlataformaCursos.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InicialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_categoria",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_categoria", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cod = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    dataCriacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    dataAlteracao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_usuario", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_curso",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    descricao = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    imagemUrl = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    preco = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    publicado = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    usuarioId = table.Column<int>(type: "int", nullable: false),
                    dataCriacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    dataAlteracao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_curso", x => x.id);
                    table.ForeignKey(
                        name: "FK_Tbl_curso_Tbl_usuario_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Tbl_usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_anexo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    arquivoUrl = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    cursoId = table.Column<int>(type: "int", nullable: false),
                    dataCriacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    dataAlteracao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_anexo", x => x.id);
                    table.ForeignKey(
                        name: "FK_Tbl_anexo_Tbl_curso_cursoId",
                        column: x => x.cursoId,
                        principalTable: "Tbl_curso",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_capitulo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    descricao = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    videoUrl = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    cursoId = table.Column<int>(type: "int", nullable: false),
                    dataCriacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    dataAlteracao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_capitulo", x => x.id);
                    table.ForeignKey(
                        name: "FK_Tbl_capitulo_Tbl_curso_cursoId",
                        column: x => x.cursoId,
                        principalTable: "Tbl_curso",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_cursoCategoria",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cursoId = table.Column<int>(type: "int", nullable: false),
                    categoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_cursoCategoria", x => x.id);
                    table.ForeignKey(
                        name: "FK_Tbl_cursoCategoria_Tbl_categoria_categoriaId",
                        column: x => x.categoriaId,
                        principalTable: "Tbl_categoria",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Tbl_cursoCategoria_Tbl_curso_cursoId",
                        column: x => x.cursoId,
                        principalTable: "Tbl_curso",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Tbl_matricula",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usuarioId = table.Column<int>(type: "int", nullable: false),
                    cursoId = table.Column<int>(type: "int", nullable: false),
                    dataCriacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    dataAlteracao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_matricula", x => x.id);
                    table.ForeignKey(
                        name: "FK_Tbl_matricula_Tbl_curso_cursoId",
                        column: x => x.cursoId,
                        principalTable: "Tbl_curso",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_matricula_Tbl_usuario_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Tbl_usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_matriculaCapitulo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    completo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    matriculaId = table.Column<int>(type: "int", nullable: false),
                    capituloId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_matriculaCapitulo", x => x.id);
                    table.ForeignKey(
                        name: "FK_Tbl_matriculaCapitulo_Tbl_capitulo_capituloId",
                        column: x => x.capituloId,
                        principalTable: "Tbl_capitulo",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Tbl_matriculaCapitulo_Tbl_matricula_matriculaId",
                        column: x => x.matriculaId,
                        principalTable: "Tbl_matricula",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_anexo_cursoId",
                table: "Tbl_anexo",
                column: "cursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_capitulo_cursoId",
                table: "Tbl_capitulo",
                column: "cursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_curso_usuarioId",
                table: "Tbl_curso",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_cursoCategoria_categoriaId",
                table: "Tbl_cursoCategoria",
                column: "categoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_cursoCategoria_cursoId",
                table: "Tbl_cursoCategoria",
                column: "cursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_matricula_cursoId",
                table: "Tbl_matricula",
                column: "cursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_matricula_usuarioId",
                table: "Tbl_matricula",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_matriculaCapitulo_capituloId",
                table: "Tbl_matriculaCapitulo",
                column: "capituloId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_matriculaCapitulo_matriculaId",
                table: "Tbl_matriculaCapitulo",
                column: "matriculaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_anexo");

            migrationBuilder.DropTable(
                name: "Tbl_cursoCategoria");

            migrationBuilder.DropTable(
                name: "Tbl_matriculaCapitulo");

            migrationBuilder.DropTable(
                name: "Tbl_categoria");

            migrationBuilder.DropTable(
                name: "Tbl_capitulo");

            migrationBuilder.DropTable(
                name: "Tbl_matricula");

            migrationBuilder.DropTable(
                name: "Tbl_curso");

            migrationBuilder.DropTable(
                name: "Tbl_usuario");
        }
    }
}
