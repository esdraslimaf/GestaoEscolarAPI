using GestaoEscolar.API.Models;

namespace GestaoEscolar.API.Repository
{
    public interface ITurmaRepository
    {
        void AddTurma(Turma turma);
        void UpdateTurma(Turma turma);
        void RemoveTurma(int id);
        List<Turma> GetTurmas();
        Turma GetTurma(int id);

    }
}
