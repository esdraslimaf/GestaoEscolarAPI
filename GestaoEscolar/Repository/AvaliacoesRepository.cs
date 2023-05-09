using GestaoEscolar.API.Database;
using GestaoEscolar.API.Models;

namespace GestaoEscolar.API.Repository
{
    public class AvaliacoesRepository : IAvaliacoesRepository
    {
        private readonly GestaoContext _db;
        public AvaliacoesRepository(GestaoContext db)
        {
            _db = db;
        }
        
        public void AddAvaliacao(Avaliacao avaliacao)
        {
            _db.Avaliacoes.Add(avaliacao);
            _db.SaveChanges();
        }

        public List<Avaliacao> GetAvaliacoes()
        {
            return _db.Avaliacoes.ToList();
        }

        public void RemoveAvaliacao(int id)
        {
            _db.Avaliacoes.Remove(_db.Avaliacoes.Find(id));
        }
    }
}
