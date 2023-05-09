using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoEscolar.API.Models
{
    public class Avaliacao
    {
        public int AvaliacaoId { get; set; }//PK
        public int? AlunoId { get; set; }//FK
        public Aluno? Aluno { get; set; } 
        public int? TurmaId { get; set; }//FK
        public Turma? Turma { get; set; }
        public int? DisciplinaId { get; set; }//FK
        public Disciplina? Disciplina { get; set; }
        public double? Nota { get; set; }
        public string? Descricao { get; set; } 
    }
}
