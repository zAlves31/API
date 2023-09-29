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
    public class ProntuarioController : ControllerBase
    {
        private IProntuarioRepository _prontuarioRepository;

        public ProntuarioController()
        {
            _prontuarioRepository = new ProntuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(Prontuario prontuario)
        {
            try
            {
                _prontuarioRepository.Cadastrar(prontuario);

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
                return Ok(_prontuarioRepository.Listar());
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
                _prontuarioRepository.Deletar(id);
                return StatusCode(201);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Prontuario prontuario)
        {
            try
            {
                _prontuarioRepository.Atualizar(id, prontuario);
                return NoContent();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
