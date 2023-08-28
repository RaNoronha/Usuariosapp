using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsuariosApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SENHA = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    DTHRCRIACAO = table.Column<string>(type: "datetime2", nullable: true),
                    DTHRALTERACAO = table.Column<string>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HISTORICOATIVIDADE",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DATAHORA = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TIPO = table.Column<int>(type: "int", nullable: false),
                    DESCRICAO = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    USUARIO_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HISTORICOATIVIDADE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HISTORICOATIVIDADE_USUARIO_USUARIO_ID",
                        column: x => x.USUARIO_ID,
                        principalTable: "USUARIO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HISTORICOATIVIDADE_USUARIO_ID",
                table: "HISTORICOATIVIDADE",
                column: "USUARIO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_EMAIL",
                table: "USUARIO",
                column: "EMAIL",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HISTORICOATIVIDADE");

            migrationBuilder.DropTable(
                name: "USUARIO");
        }
    }
}
