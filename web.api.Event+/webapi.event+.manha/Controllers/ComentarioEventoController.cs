using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;
using webapi.event_.manha.Repositories;

namespace webapi.event_.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ComentarioEventoController : ControllerBase
    {
        private IComentarioEventoRepository _ComentarioEventoRepository;

        public ComentarioEventoController()
        {
            _ComentarioEventoRepository = new ComentarioEventoRepository();
        }

        [HttpPost]
        public IActionResult Post(ComentarioEvento comentarioEvento)
        {
            try
            {
                _ComentarioEventoRepository.Cadastrar(comentarioEvento);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_ComentarioEventoRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _ComentarioEventoRepository.Deletar(id);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_ComentarioEventoRepository.BuscarPorID(id));

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
