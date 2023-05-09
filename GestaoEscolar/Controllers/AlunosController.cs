using GestaoEscolar.API.Models;
using GestaoEscolar.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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
        [SwaggerOperation(
    Summary = "Adicionar um novo aluno",
    Description = "Adiciona um novo aluno(Exige uma turma para ser inscrito)",
    OperationId = "InsereNovoAluno"
)]
        public IActionResult AddAluno([FromBody]Aluno aluno)
        {
            _db.AddAluno(aluno);
            return Ok($"Aluno {aluno.AlunoName} adicionado. Id: {aluno.AlunoId}");
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
   Summary = "Deletar aluno pelo ID",
   Description = "Deletará o aluno",
   OperationId = "DeletarAluno"
)]
        public IActionResult RemoveAluno(int id)
        {
            _db.RemoveAluno(id);
            return Ok($"Aluno de id {id} removido!");
        }

        [HttpGet]
        [SwaggerOperation(
          Summary = "Busca os alunos existentes(Indica dados do aluno e ID da turma que ele está)",
    Description = "Retorna apenas os dados do aluno.",
    OperationId = "DadosAluno"
)]
        public IActionResult GetAlunos()
        {
            return Ok(_db.GetAlunos());
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
     Summary = "Retorna dados referente ao aluno específico e sua turma(Dados aluno + Dados turma)",
    Description = "Irá retornar pelo id",
    OperationId = "BuscaAlunoPeloId"
)]
        public IActionResult GetAluno(int id)
        {
            return Ok(_db.GetAluno(id));
        }

        [HttpPut]
        [SwaggerOperation(
    Summary = "Atualizar dados do aluno",
    Description = "Nota: Não mudar o ID do aluno, apenas características como nome, turma.",
    OperationId = "EditarAluno"
)]
        public IActionResult UpdateAluno([FromBody]Aluno aluno)
        {
            _db.UpdateAluno(aluno);
            return Ok("Deu certo confia");
        }

        
    }
}

