using GestaoEscolar.API.Database;
using GestaoEscolar.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoEscolar.API.Repository
{
    public class TurmaRepository : ITurmaRepository
    {
        private readonly GestaoContext _db;

        public TurmaRepository(GestaoContext db)
        {
            _db = db;
        }

        public void AddTurma(Turma turma)
        {
            _db.Turmas.Add(turma);
            _db.SaveChanges();            
        }

        public void RemoveTurma(int id)
        {
            _db.Turmas.Remove(_db.Turmas.Find(id)!);
            _db.SaveChanges();
        }

        public List<Turma> GetTurmas()
        {
            return _db.Turmas.ToList();
        }

       

        public void UpdateTurma(Turma turma)
        {
            var TurmaDb = _db.Turmas.Find(turma.TurmaId);
            TurmaDb.NomeTurma = turma.NomeTurma;
            _db.SaveChanges();
        }

        public Turma GetTurma(int id)
        {
            return _db.Turmas.Include(a => a.Alunos).FirstOrDefault(t => t.TurmaId == id);
        }
    }
}
