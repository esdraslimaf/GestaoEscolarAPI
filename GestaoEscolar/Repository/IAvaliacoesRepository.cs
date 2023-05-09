using GestaoEscolar.API.Models;

namespace GestaoEscolar.API.Repository
{
    public interface IAvaliacoesRepository
    {
        
        void AddAvaliacao(Avaliacao avalicao);
        List<Avaliacao> GetAvaliacoes();
        void RemoveAvaliacao(int id);


    }
}
