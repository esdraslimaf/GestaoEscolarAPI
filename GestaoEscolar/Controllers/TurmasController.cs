using GestaoEscolar.API.Models;
using GestaoEscolar.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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

        [HttpGet]
        [SwaggerOperation(
          Summary = "Busca as turmas existentes(Apenas apenas as turmas)",
    Description = "Retorna apenas o Id da Turma e seu respectivo nome.",
    OperationId = "BuscadorDeTurmas"
)]
        public IActionResult GetTurmas()
        {
            return Ok(Repository.GetTurmas());
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
     Summary = "Busca uma turma pelo ID(Turma e seus respectivos alunos)",
    Description = "Retorna a turma e os alunos cadastrados na turma",
    OperationId = "BuscaTurmaPeloId"
)]
        public IActionResult GetTurma(int id)
        {
            return Ok(Repository.GetTurma(id));
        }

        [HttpPost]
        [SwaggerOperation(
    Summary = "Adicionar uma nova turma",
    Description = "Deve ser inserido apenas o nome da turma",
    OperationId = "InsereNovaTurma"
)]
        public IActionResult Add([FromBody] Turma turma)
        {
            Repository.AddTurma(turma);
            return Ok(turma);
        }
        
        [HttpDelete("{id}")]
        [SwaggerOperation(
   Summary = "Deletar turma pelo ID",
   Description = "Deletará a turma",
   OperationId = "DeletarTurma"
)]
        public IActionResult RemoveTurma(int id)
        {
            Repository.RemoveTurma(id);
            return Ok("Id " + id + " removido");
        }
        
                [HttpPut]
                [SwaggerOperation(
            Summary = "Atualizar a turma pelo ID",
            Description = "Deve ser inserido apenas o novo nome",
            OperationId = "AtualizaTurma"
        )]
                public IActionResult UpdateTurma(Turma turma)
                {
                    Repository.UpdateTurma(turma);
                    return Ok($"Turma de id {turma.TurmaId} atualizado para {turma.NomeTurma}");
                }
              
    }
}
