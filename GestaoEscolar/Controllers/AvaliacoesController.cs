using GestaoEscolar.API.Models;
using GestaoEscolar.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult AddAvaliacao([FromBody] Avaliacao avaliacao)
        {
            Repository.AddAvaliacao(avaliacao);
            return Ok(avaliacao);
        }
        [HttpDelete("{id}")]
        public IActionResult RemoveAvaliacao(int id)
        {
            Repository.RemoveAvaliacao(id);
            return Ok($"Avaliação de id {id} removida");
        }
        [HttpGet]
        public IActionResult GetAvaliacoes()
        {
            return Ok(Repository.GetAvaliacoes());       
        }


        


    }
}
