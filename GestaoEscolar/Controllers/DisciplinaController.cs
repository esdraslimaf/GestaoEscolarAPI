using GestaoEscolar.API.Models;
using GestaoEscolar.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GestaoEscolar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinaController : ControllerBase
    {
        private readonly IDisciplinaRepository Repository;
        public DisciplinaController(IDisciplinaRepository repository)
        {
            Repository = repository;
        }

        [HttpDelete]
        [SwaggerOperation(
        Summary = "Remover disciplina pelo ID",
        Description = "Remove disciplina",
        OperationId = "RemoveDisciplina"
        )]
        public IActionResult RemoveDisciplina(int id)
        {
            Repository.RemoveDisciplina(id);
            return Ok("Disciplina de id "+id+" removida!");
        }

        [HttpPost]
        [SwaggerOperation(
       Summary = "Adicionar disciplina",
       Description = "Adiciona disciplina",
       OperationId = "AdicionarDisciplina"
       )]
        public IActionResult AddDisciplina(Disciplina disciplina)
        {
            Repository.AddDisciplina(disciplina);
            return Ok(disciplina);
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Buscar ID e NOME das disciplinas",
            Description = "Busca dados das disciplinas",
            OperationId = "BuscarDisciplinas"
            )]
        public IActionResult GetDisciplinas()
        {
            return Ok(Repository.GetDisciplinas());
        }

      /*  [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Buscar ID e NOME das disciplinas",
            Description = "Busca dados das disciplinas",
            OperationId = "BuscarDisciplinasPorId"
            )]
        public IActionResult GetDisciplina(int id)
        {
            return Ok(Repository.GetDisciplina(id));
        }
      */
        [HttpPut]
        [SwaggerOperation(
            Summary = "Atualizar nome da disciplina pelo ID",
            Description = "Edita nomes das disciplinas",
            OperationId = "EditarDisciplina"
            )]
        public IActionResult UpdateDisciplina(Disciplina disciplina)
        {
            Repository.UpdateDisciplina(disciplina);
            return Ok($"Nome da disciplina de id {disciplina.DisciplinaId} foi alterada para {disciplina.NomeDisciplina}");
        }

    }
}
