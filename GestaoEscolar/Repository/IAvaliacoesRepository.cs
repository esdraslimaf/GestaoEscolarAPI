using GestaoEscolar.API.Models;

namespace GestaoEscolar.API.Repository
{
    public interface IAvaliacoesRepository
    {
        
        void AddAvaliacao(Avaliacao avalicao);
        List<Avaliacao> GetAvaliacoes();
        Avaliacao GetAvaliacaoId(int id);
        List<Avaliacao> GetAvaliacaoIdTurmaIdDisciplinaIdAluno(int IdTurma, int IdDisciplina, int IdAluno);
        List<Avaliacao> GetAvaliacaoIdTurmaIdDisciplina(int IdTurma, int IdDisciplina);
        List<Avaliacao> GetAvaliacaoIdTurma(int IdTurma);
        List<Avaliacao> GetAvaliacaoIdAluno(int idAluno);
        void RemoveAvaliacao(int id);
        void UpdateAvaliacao(Avaliacao avaliacao);

    }
}
