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
        private readonly IDisciplinaRepository _repository;

        public DisciplinaController(IDisciplinaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Buscar ID e NOME das disciplinas",
            Description = "Caso queira buscar também as avaliações dessa disciplina, faça uma busca completa por ID",
            OperationId = "BuscarDisciplinas"
        )]
        public IActionResult GetDisciplinas()
        {
            return Ok(_repository.GetDisciplinas());
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
           Summary = "Buscar ID+NOME+Avaliações cadastradas de uma determinada disciplina",
           Description = "Busca Completa",
           OperationId = "BuscarDisciplinasPorId"
           )]
        public IActionResult GetDisciplina(int id)
        {
            return Ok(_repository.GetDisciplina(id));
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Adicionar disciplina",
            Description = "Inserir apenas o nome da disciplina. Exemplo: {\n\t\"nomeDisciplina\": \"Filosofia\"\n}",
            OperationId = "AdicionarDisciplina"
        )]
        public IActionResult AddDisciplina([FromBody] Disciplina disciplina)
        {
            _repository.AddDisciplina(disciplina);
            return Ok($"Disciplina: \"{disciplina}\" adicionada com sucesso!");
        }

        [HttpPut]
        [SwaggerOperation(
            Summary = "Atualizar nome da disciplina pelo ID",
            Description = "Insira o ID da disciplina e coloque o novo nome desejado. Exemplo: {\n\t\"disciplinaId\": 5,\n\t\"nomeDisciplina\": \"INSERIR NOVO NOME AQUI\"\n}",
            OperationId = "EditarDisciplina"
        )]
        public IActionResult UpdateDisciplina([FromBody] Disciplina disciplina)
        {
            var disciplinaDb = _repository.GetDisciplina(disciplina.DisciplinaId);
            string nome = disciplinaDb.NomeDisciplina;
            _repository.UpdateDisciplina(disciplina);
            return Ok($"Nome da disciplina \"{nome}(Id:{disciplina.DisciplinaId})\" foi alterado para \"{disciplina.NomeDisciplina}({disciplina.DisciplinaId})\"");
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Remover disciplina pelo ID",
            Description = "Informe o ID para remover determina disciplina!",
            OperationId = "RemoveDisciplina"
        )]
        public IActionResult RemoveDisciplina(int id)
        {
            var disciplina = _repository.GetDisciplina(id);
            string NomeDisciplina = disciplina.NomeDisciplina;
            _repository.RemoveDisciplina(id);
            return Ok($"A disciplina \"{NomeDisciplina} (Id:{id})\" foi removida com sucesso!");
        }
    }
}