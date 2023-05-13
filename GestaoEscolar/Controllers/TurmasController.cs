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
            Description = "Retorna apenas o Id da turma e seu nome(Caso queira ver também os alunos, busque dados da turma pelo ID).",
            OperationId = "BuscadorDeTurmas"
        )]
        public IActionResult GetTurmas()
        {
            return Ok(Repository.GetTurmas());
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Busca completa por ID(Turma e seus respectivos alunos)",
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
            Description = "Deve ser inserido apenas o nome da turma. Exemplo: {\n\t\"nomeTurma\": \"Inserir aqui nome da Turma\"\n}",
            OperationId = "InsereNovaTurma"
        )]
        public IActionResult Add([FromBody] Turma turma)
        {
            Repository.AddTurma(turma);
            return Ok("A turma "+turma.NomeTurma+" Id:"+turma.TurmaId+" foi adicionada com sucesso!");
        }

        [HttpPut]
        [SwaggerOperation(
            Summary = "Atualizar a turma pelo ID",
            Description = "Insira apenas o id da turma e o novo nome. Exemplo: {\n\t\"turmaId\": 5,\n\t\"nomeTurma\": \"INSIRA AQUI O NOVO NOME\"\n}",
            OperationId = "AtualizaTurma"
        )]
        public IActionResult UpdateTurma(Turma turma)
        {
            var AlunoDb = Repository.GetTurma(turma.TurmaId);
            string nome = AlunoDb.NomeTurma;
            Repository.UpdateTurma(turma);
            return Ok($"A turma de nome \"{nome}\", ID: {turma.TurmaId}, teve seu nome atualizado para \"{turma.NomeTurma}\"");
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Deletar turma pelo ID",
            Description = "Deletará a turma",
            OperationId = "DeletarTurma"
        )]
        public IActionResult RemoveTurma(int id)
        {
            var turmaDb = Repository.GetTurma(id);
            string NomeTurma = turmaDb.NomeTurma;
            Repository.RemoveTurma(id);       
            return Ok($"A turma \"{NomeTurma}(ID: {id})\" foi removida!");
        }
    }
}