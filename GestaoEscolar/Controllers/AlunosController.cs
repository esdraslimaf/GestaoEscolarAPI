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

        [HttpGet]
        [SwaggerOperation(
            Summary = "Busca os alunos existentes (Dados do aluno e ID da turma que ele está)",
            Description = "Retorna apenas os dados dos alunos(Dados extendidos da turma não estão incluso. Caso queira puxar dados do aluno e turma juntos faça a busca passando id específico no outro método).",
            OperationId = "DadosAluno"
        )]
        public IActionResult GetAlunos()
        {
            return Ok(_db.GetAlunos());
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Retorna dados referente ao aluno específico e sua turma (Dados aluno + Dados turma)",
            Description = "Irá retornar dados do Aluno e da sua respectiva turma",
            OperationId = "BuscaAlunoPeloId"
        )]
        public IActionResult GetAluno(int id)
        {
            return Ok(_db.GetAluno(id));
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Adicionar um novo aluno",
            Description = "Adiciona um novo aluno (Exige uma turma para ser inscrito). Exemplo: {\n \"alunoName\":\"Nome Exemplo\",\n\"turmaId\":2\n}",
            OperationId = "InsereNovoAluno"
        )]
        public IActionResult AddAluno([FromBody] Aluno aluno)
        {
            _db.AddAluno(aluno);
            return Ok($"O Aluno {aluno.AlunoName} foi adicionado. Id: {aluno.AlunoId}");
        }

        [HttpPut]
        [SwaggerOperation(
            Summary = "Atualizar dados do aluno",
            Description = "Nota: Não mudar o ID do aluno, apenas características como nome, turma. Exemplo: {\n\t\"alunoId\": 3,\n\t\"alunoName\": \"NOVO NOME\",\n\t\"turmaId\": 2\n}",
            OperationId = "EditarAluno"
        )]
        public IActionResult UpdateAluno([FromBody] Aluno aluno)
        {
            var alunoDb = _db.GetAluno(aluno.AlunoId);
            string nomeantigo = alunoDb.AlunoName;
            _db.UpdateAluno(aluno);
            return Ok($"Nome do aluno foi atualizado de {nomeantigo}(ID:{aluno.AlunoId}) para {aluno.AlunoName}");
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
    }
}