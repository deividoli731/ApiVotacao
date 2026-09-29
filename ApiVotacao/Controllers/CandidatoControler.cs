using ApiVotacao.Models;
using ApiVotacao.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiVotacao.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidatosController : ControllerBase
    {
        private readonly ICandidatoRepository _repository;

        public CandidatosController(
            ICandidatoRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Cadastrar(Candidato candidato)
        {
            bool sucesso =
                _repository.AdicionarCandidato(candidato);

            if (!sucesso)
            {
                return BadRequest(
                    "Já existe candidato com esse número.");
            }

            return CreatedAtAction(
                nameof(Listar),
                candidato);
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var candidatos =
                _repository.ListarCandidatos();

            return Ok(candidatos);
        }

        [HttpPost("votos")]
        public IActionResult RegistrarVoto(Voto voto)
        {
            bool sucesso =
                _repository.RegistrarVoto(voto);

            if (!sucesso)
            {
                return BadRequest(
                    "Candidato não encontrado.");
            }

            return Ok("Voto registrado com sucesso.");
        }

        [HttpGet("votos/{numero}")]
        public IActionResult ConsultarVotos(int numero)
        {
            var votos =
                _repository.ConsultarVotos(numero);

            return Ok(votos);
        }
    }
}