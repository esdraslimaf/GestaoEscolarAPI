using GestaoEscolar.API.Models;
using GestaoEscolar.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEscolar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly IAlunoRepository _db;
        public AlunosController(IAlunoRepository repoaluno)
        {
            _db = repoaluno;
        }


        [HttpPost]
        public IActionResult AddAluno([FromBody]Aluno aluno)
        {
            _db.Add(aluno);
            return Ok($"Aluno {aluno.AlunoName} adicionado. Id: {aluno.AlunoId}");
        }
    }
}
