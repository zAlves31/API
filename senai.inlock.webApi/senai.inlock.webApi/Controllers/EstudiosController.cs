using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Repositories;

namespace senai.inlock.webApi_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        private IEstudiosRepository _estudiosRepository { get; set; }

        public EstudiosController() 
        {
            _estudiosRepository = new EstudiosRepository();
        }


        [HttpGet]
        [Authorize(Roles = "Comum, Administrador")]

        public IActionResult Get()
        {
            try
            {
                List<EstudiosDomain> ListarEstudios = _estudiosRepository.ListarTodos();

                return Ok(ListarEstudios);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        
        public IActionResult Post(EstudiosDomain novoestudio)
        {
            try
            {
                _estudiosRepository.Cadastrar(novoestudio);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

    }
}
