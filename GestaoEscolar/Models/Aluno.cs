namespace GestaoEscolar.API.Models
{
    public class Aluno
    {
        public int AlunoId { get; set; }
        public string AlunoName { get; set; }
        public int TurmaId { get; set; }
        public Turma Turma { get; set; }
    }
}
