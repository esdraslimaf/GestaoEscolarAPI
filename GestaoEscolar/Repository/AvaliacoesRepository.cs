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
        public List<Avaliacao> GetAvaliacaoIdAluno(int IdAluno)
        {
            return _db.Avaliacoes.Where(a => a.AlunoId == IdAluno).ToList();
        }

        public List<Avaliacao> GetAvaliacaoIdTurmaIdDisciplinaIdAluno(int IdTurma, int IdDisciplina, int IdAluno)
        {
            return _db.Avaliacoes.Where(a => a.TurmaId == IdTurma && a.DisciplinaId == IdDisciplina && a.AlunoId==IdAluno).ToList();
        }

        public List<Avaliacao> GetAvaliacaoIdTurmaIdDisciplina(int IdTurma, int IdDisciplina)
        {
            return _db.Avaliacoes.Where(a => a.TurmaId == IdTurma && a.DisciplinaId == IdDisciplina).ToList();
        }

        public List<Avaliacao> GetAvaliacaoIdTurma(int IdTurma)
        {
            return _db.Avaliacoes.Where(a => a.TurmaId == IdTurma).ToList();
        }

        public void RemoveAvaliacao(int id)
        {
            _db.Avaliacoes.Remove(_db.Avaliacoes.Find(id)!);
            _db.SaveChanges();
        }

        public Avaliacao GetAvaliacaoId(int id)
        {
           return _db.Avaliacoes.Find(id)!;
        }

        public void UpdateAvaliacao(Avaliacao avaliacao)
        {
            _db.Avaliacoes.Update(avaliacao);
            _db.SaveChanges();
        }
    }
}
