using GestaoEscolar.API.Models;

namespace GestaoEscolar.API.Repository
{
    public interface IAlunoRepository
    {
        void AddAluno(Aluno aluno);
        void RemoveAluno(int id);
        void UpdateAluno(Aluno aluno);
        List<Aluno> GetAlunos();
        Aluno GetAluno(int id);
        List<Aluno> GetAlunosLIKE(string nome);

    }
}
