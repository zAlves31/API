using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapihealthclinic.Domains;
using webapihealthclinic.Interfaces;
using webapihealthclinic.Repositories;

namespace webapihealthclinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PacienteController : ControllerBase
    {
        private IPacienteRepository _pacienteRepository;

        public PacienteController()
        {
            _pacienteRepository = new PacienteRepository();
        }

        [HttpPost]
        public IActionResult Post(Paciente paciente)
        {
            try
            {
                _pacienteRepository.Cadastrar(paciente);

                return StatusCode(201);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_pacienteRepository.Listar());
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _pacienteRepository.Deletar(id);
                return StatusCode(201);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Paciente paciente)
        {
            try
            {
                _pacienteRepository.Atualizar(id, paciente);
                return NoContent();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
