namespace GestaoEscolar.API.Models
{
    public class Aluno
    {
        public int AlunoId { get; set; } //Gerenciado pelo banco
        public string AlunoName { get; set; } = null!; //Obrigatório
        public int? TurmaId { get; set; } //Obrigatório
        public Turma? Turma { get; set; }
    }
}
