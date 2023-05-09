using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoEscolar.API.Migrations
{
    public partial class DbSetAvaliacao_Aluno_Turma_Disciplina : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacao_Alunos_AlunoId",
                table: "Avaliacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacao_Disciplinas_DisciplinaId",
                table: "Avaliacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacao_Turmas_TurmaId",
                table: "Avaliacao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Avaliacao",
                table: "Avaliacao");

            migrationBuilder.RenameTable(
                name: "Avaliacao",
                newName: "Avaliacoes");

            migrationBuilder.RenameIndex(
                name: "IX_Avaliacao_TurmaId",
                table: "Avaliacoes",
                newName: "IX_Avaliacoes_TurmaId");

            migrationBuilder.RenameIndex(
                name: "IX_Avaliacao_DisciplinaId",
                table: "Avaliacoes",
                newName: "IX_Avaliacoes_DisciplinaId");

            migrationBuilder.RenameIndex(
                name: "IX_Avaliacao_AlunoId",
                table: "Avaliacoes",
                newName: "IX_Avaliacoes_AlunoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Avaliacoes",
                table: "Avaliacoes",
                column: "AvaliacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacoes_Alunos_AlunoId",
                table: "Avaliacoes",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "AlunoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacoes_Disciplinas_DisciplinaId",
                table: "Avaliacoes",
                column: "DisciplinaId",
                principalTable: "Disciplinas",
                principalColumn: "DisciplinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacoes_Turmas_TurmaId",
                table: "Avaliacoes",
                column: "TurmaId",
                principalTable: "Turmas",
                principalColumn: "TurmaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacoes_Alunos_AlunoId",
                table: "Avaliacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacoes_Disciplinas_DisciplinaId",
                table: "Avaliacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacoes_Turmas_TurmaId",
                table: "Avaliacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Avaliacoes",
                table: "Avaliacoes");

            migrationBuilder.RenameTable(
                name: "Avaliacoes",
                newName: "Avaliacao");

            migrationBuilder.RenameIndex(
                name: "IX_Avaliacoes_TurmaId",
                table: "Avaliacao",
                newName: "IX_Avaliacao_TurmaId");

            migrationBuilder.RenameIndex(
                name: "IX_Avaliacoes_DisciplinaId",
                table: "Avaliacao",
                newName: "IX_Avaliacao_DisciplinaId");

            migrationBuilder.RenameIndex(
                name: "IX_Avaliacoes_AlunoId",
                table: "Avaliacao",
                newName: "IX_Avaliacao_AlunoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Avaliacao",
                table: "Avaliacao",
                column: "AvaliacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacao_Alunos_AlunoId",
                table: "Avaliacao",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "AlunoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacao_Disciplinas_DisciplinaId",
                table: "Avaliacao",
                column: "DisciplinaId",
                principalTable: "Disciplinas",
                principalColumn: "DisciplinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacao_Turmas_TurmaId",
                table: "Avaliacao",
                column: "TurmaId",
                principalTable: "Turmas",
                principalColumn: "TurmaId");
        }
    }
}
