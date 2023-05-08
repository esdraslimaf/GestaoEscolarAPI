namespace GestaoEscolar.API.Models
{
    public class Disciplina
    {
        public int DisciplinaId { get; set; }
        public string NomeDisciplina { get; set; } = null!;
        public ICollection<AlunoDisciplina>? AlunoDisciplina { get; set; }
    }
}
