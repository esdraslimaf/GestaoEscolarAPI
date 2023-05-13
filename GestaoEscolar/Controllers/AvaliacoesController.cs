using GestaoEscolar.API.Models;
using GestaoEscolar.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GestaoEscolar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacoesController : ControllerBase
    {
        private readonly IAvaliacoesRepository Repository;

        public AvaliacoesController(IAvaliacoesRepository repository)
        {
            Repository = repository;
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Adicionar avaliação (Inserir ID do aluno, ID da turma, ID da disciplina, nota e descrição da avaliação)",
            Description = "Exemplo: {\n\t\"alunoId\": 2,\n\t\"turmaId\": 2,\n\t\"disciplinaId\": 1,\n\t\"nota\": 4,\n\t\"descricao\": \"Avaliação 1 de Português!\"\n}",
            OperationId = "AdicionarAvaliacao"
        )]
        public IActionResult AddAvaliacao([FromBody] Avaliacao avaliacao)
        {
            Repository.AddAvaliacao(avaliacao);
            return Ok(avaliacao);
        }

        [HttpPut]
        public IActionResult UpdateAvaliacao([FromBody] Avaliacao avaliacao)
        {
            Repository.UpdateAvaliacao(avaliacao);
            return Ok(avaliacao);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Remover uma avaliação por ID",
            Description = "Caso não saiba o ID da avaliação, consultar nos Gets",
            OperationId = "DeletarAvaliacao"
        )]
        public IActionResult RemoveAvaliacao(int id)
        {
            var DadosAvaliacao = Repository.GetAvaliacaoId(id);
            string DescricaoAv = DadosAvaliacao.Descricao;
            Repository.RemoveAvaliacao(id);
            return Ok($"Avaliação \"{DescricaoAv} - Id:{id}\" removida com sucesso!");
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Busca todas as avaliações cadastradas na aplicação",
            Description = "Você também pode fazer uma busca por turma, aluno ou avaliações",
            OperationId = "BuscarAvaliacoes"
        )]
        public IActionResult GetAvaliacoes()
        {
            return Ok(Repository.GetAvaliacoes());
        }

        [HttpGet("pesquisar-aluno/{IdAluno}")]
        [SwaggerOperation(
            Summary = "Busca todas as avaliações cadastradas de um determinado aluno",
            Description = "",
            OperationId = "BuscarAvaliacoesAluno"
        )]
        public IActionResult GetAvaliacoesIdAluno(int IdAluno)
        {
            return Ok(Repository.GetAvaliacaoIdAluno(IdAluno));
        }

        [HttpGet("pesquisar-turma/{IdTurma}")]
        [SwaggerOperation(
            Summary = "Busca todas as avaliações cadastradas em uma turma específica",
            Description = "",
            OperationId = "BuscarAvaliacoesTurma"
        )]
        public IActionResult GetAvaliacoesIdTurma(int IdTurma)
        {
            return Ok(Repository.GetAvaliacaoIdTurma(IdTurma));
        }

        [HttpGet("pesquisar-turma-disciplina/{IdTurma}/{IdDisciplina}")]
        [SwaggerOperation(
          Summary = "Busca todas as avaliações cadastradas em uma turma e em uma disciplina específica",
          Description = "",
          OperationId = "BuscarAvaliacoesTurmaDisciplina"
      )]       
        public IActionResult GetAvaliacoes(int IdTurma, int IdDisciplina)
        {
            return Ok(Repository.GetAvaliacaoIdTurmaIdDisciplina(IdTurma, IdDisciplina));
        }

        [HttpGet("pesquisar-turma-disciplina-aluno/{IdTurma}/{IdDisciplina}/{IdAluno}")]
        [SwaggerOperation(
          Summary = "Busca todas as avaliações cadastradas em uma turma, uma disciplina e um aluno específico",
          Description = "",
          OperationId = "BuscarAvaliacoesTurmaDisciplinaAluno"
      )]        
        public IActionResult GetAvaliacoes(int IdTurma, int IdDisciplina, int IdAluno)
        {
            return Ok(Repository.GetAvaliacaoIdTurmaIdDisciplinaIdAluno(IdTurma, IdDisciplina, IdAluno));
        }



    }
}
