using GestaoEscolar.API.Database;
using GestaoEscolar.API.Models;

namespace GestaoEscolar.API.Repository
{
    public class TurmaRepository : ITurmaRepository
    {
        GestaoContext _db = new GestaoContext();
        public void AddTurma(Turma turma)
        {
            _db.Turmas.Add(turma);
            _db.SaveChanges();
        }

        public void RemoveTurma(int id)
        {
            _db.Turmas.Remove(_db.Turmas.Find(id));
            _db.SaveChanges();
        }

        public void UpdateTurma(Turma turma)
        {
            var TurmaDb = _db.Turmas.Find(turma.TurmaId);
            TurmaDb.NomeTurma = turma.NomeTurma;
            _db.SaveChanges();
        }
    }
}
