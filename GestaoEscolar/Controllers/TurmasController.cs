using GestaoEscolar.API.Models;
using GestaoEscolar.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEscolar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmasController : ControllerBase
    {
        private readonly ITurmaRepository Repository;

        public TurmasController(ITurmaRepository repository)
        {
            Repository = repository;
        }


        [HttpPost]
        public IActionResult Add(Turma turma)
        {
            Repository.AddTurma(turma);
            return Ok(turma);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveTurma(int id)
        {
            Repository.RemoveTurma(id);
            return Ok("Id "+id+" removido");
        }

        [HttpPut]
        public IActionResult UpdateTurma(Turma turma)
        {
            Repository.UpdateTurma(turma);
            return Ok($"Usuário de id {turma.TurmaId} atualizado para {turma.NomeTurma}");
        }

    }
}
