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
    public class ConsultaController : ControllerBase
    {
        private IConsultaRepository _consultaRepository;

        public ConsultaController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_consultaRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("idMedico")]
        public IActionResult ListarPorMedico(Guid idMedico)
        {
            try
            {
                return Ok(_consultaRepository.ListarMedico(idMedico));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("idPaciente")]
        public IActionResult ListarPacientes(Guid idPaciente)
        {
            try
            {
                return Ok(_consultaRepository.ListarPaciente(idPaciente));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Consulta consulta)
        {
            try
            {
                _consultaRepository.Cadastrar(consulta);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
