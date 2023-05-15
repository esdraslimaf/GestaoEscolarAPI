using GestaoEscolar.API.Database;
using GestaoEscolar.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoEscolar.API.Repository
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly GestaoContext _db;
        public AlunoRepository(GestaoContext db)
        {
            _db = db;
        }
        //fazer método para checar se existe a turma
        public void AddAluno(Aluno aluno)
        {           
            _db.Alunos.Add(aluno);
            _db.SaveChanges();
        }

        public void RemoveAluno(int id)
        {
            _db.Alunos.Remove(_db.Alunos.Find(id)!);
            _db.SaveChanges();
        }

        public void UpdateAluno(Aluno aluno)
        {
            var alunoDb = _db.Alunos.Find(aluno.AlunoId);
            alunoDb.AlunoName = aluno.AlunoName;
            alunoDb.TurmaId = aluno.TurmaId;
            _db.SaveChanges();
        }
        public List<Aluno> GetAlunos()
        {
            return _db.Alunos.OrderBy(a => a.TurmaId).ThenBy(a => a.AlunoId).ToList();
        }

        public Aluno GetAluno(int id)
        {
            return _db.Alunos.Include(a => a.Turma).ThenInclude(t=>t.Alunos).FirstOrDefault(a => a.AlunoId == id)!;
        }
    }
}
