using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoEscolar.API.Migrations
{
    public partial class Avaliacao_Aluno_Turma_Disciplina : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Turmas_TurmaId",
                table: "Alunos");

            migrationBuilder.AlterColumn<int>(
                name: "TurmaId",
                table: "Alunos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Avaliacao",
                columns: table => new
                {
                    AvaliacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlunoId = table.Column<int>(type: "int", nullable: true),
                    TurmaId = table.Column<int>(type: "int", nullable: true),
                    DisciplinaId = table.Column<int>(type: "int", nullable: true),
                    Nota = table.Column<double>(type: "float", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacao", x => x.AvaliacaoId);
                    table.ForeignKey(
                        name: "FK_Avaliacao_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "AlunoId");
                    table.ForeignKey(
                        name: "FK_Avaliacao_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "DisciplinaId");
                    table.ForeignKey(
                        name: "FK_Avaliacao_Turmas_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turmas",
                        principalColumn: "TurmaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_AlunoId",
                table: "Avaliacao",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_DisciplinaId",
                table: "Avaliacao",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_TurmaId",
                table: "Avaliacao",
                column: "TurmaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Turmas_TurmaId",
                table: "Alunos",
                column: "TurmaId",
                principalTable: "Turmas",
                principalColumn: "TurmaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Turmas_TurmaId",
                table: "Alunos");

            migrationBuilder.DropTable(
                name: "Avaliacao");

            migrationBuilder.AlterColumn<int>(
                name: "TurmaId",
                table: "Alunos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Turmas_TurmaId",
                table: "Alunos",
                column: "TurmaId",
                principalTable: "Turmas",
                principalColumn: "TurmaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
