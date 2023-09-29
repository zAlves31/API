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
    public class ComentarioController : ControllerBase
    {
        private IComentarioRepository _comentarioRepository;

        public ComentarioController()
        {
            _comentarioRepository = new ComentarioRepository();
        }

        [HttpPost]
        public IActionResult Post(Comentario comentario)
        {
            try
            {
                _comentarioRepository.Cadastrar(comentario);

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
                return Ok(_comentarioRepository.Listar());
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
                _comentarioRepository.Deletar(id);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }

}
