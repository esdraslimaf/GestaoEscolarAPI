using GestaoEscolar.API.Database;
using GestaoEscolar.API.Models;

namespace GestaoEscolar.API.Repository
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly GestaoContext _db;
        public AlunoRepository(GestaoContext db)
        {
            _db = db;
        }
        public void Add(Aluno aluno)
        {
            _db.Alunos.Add(aluno);
            _db.SaveChanges();
        }
    }
}
