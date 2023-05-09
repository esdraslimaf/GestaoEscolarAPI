using GestaoEscolar.API.Database;
using GestaoEscolar.API.Models;

namespace GestaoEscolar.API.Repository
{
    public class DisciplinaRepository : IDisciplinaRepository
    {
        private readonly GestaoContext _db;
        public DisciplinaRepository(GestaoContext db)
        {
            _db = db;
        }

        public void AddDisciplina(Disciplina Disciplina)
        {
            _db.Disciplinas.Add(Disciplina);
            _db.SaveChanges();
        }

        public Disciplina GetDisciplina(int id)
        {
            return _db.Disciplinas.Find(id);
        }

        public List<Disciplina> GetDisciplinas()
        {
            return _db.Disciplinas.ToList();
        }

        public void RemoveDisciplina(int id)
        {
            _db.Disciplinas.Remove(_db.Disciplinas.Find(id)!);
        }

        public void UpdateDisciplina(Disciplina Disciplina)
        {
            var disciplinaDB = _db.Disciplinas.Find(Disciplina.DisciplinaId);
            disciplinaDB.NomeDisciplina = Disciplina.NomeDisciplina;
            _db.SaveChanges();
        }
    }
}
