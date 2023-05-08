namespace GestaoEscolar.API.Models
{
    public class Turma
    {
        public int TurmaId { get; set; }
        public int AnoTurma { get; set; }
        public ICollection<Aluno> Alunos { get; set; }
    }
}
