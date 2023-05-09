using GestaoEscolar.API.Models;

namespace GestaoEscolar.API.Repository
{
    public interface IDisciplinaRepository
    {
        void AddDisciplina(Disciplina Disciplina);
        void RemoveDisciplina(int id);
        void UpdateDisciplina(Disciplina Disciplina);
        List<Disciplina> GetDisciplinas();
        Disciplina GetDisciplina(int id);
    }
}
