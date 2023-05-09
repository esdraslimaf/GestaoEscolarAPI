using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoEscolar.API.Models
{
    [NotMapped]
    public class Avaliacao
    {
        public int AvaliacaoId { get; set; }
        public int AlunoId { get; set; }
        public Aluno? Aluno { get; set; }
        public int TurmaId { get; set; }
        public Turma? Turma { get; set; }
        public int DisciplinaId { get; set; }
        public Disciplina? Disciplina { get; set; }
        public double Nota { get; set; }
        public string? Descricão { get; set; } 
    }
}
