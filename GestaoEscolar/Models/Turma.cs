namespace GestaoEscolar.API.Models
{
    public class Turma
    {
        public int TurmaId { get; set; }
        public string NomeTurma { get; set; } = null!;
        public ICollection<Aluno>? Alunos { get; set; }
        public ICollection<Avaliacao>? Avaliacoes { get; set; }
    }
}
