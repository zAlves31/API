using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Inlock.codeFirst.manha.Interfaces;
using webapi.Inlock.codeFirst.manha.Repositories;
using webapi.Inlock.codeFirst.manha.ViewModels;

namespace webapi.Inlock.codeFirst.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController() 
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel usuario)
        {
            try
            {
                LoginViewModel loginBuscado = _usuarioRepository.Login(usuario.Email, usuario.Senha);

                if(loginBuscado == null)
                {
                    return NotFound("Email ou senha invalidos");
                }
            }
            catch (Exception erro) 
            { 
                return BadRequest(erro.Message);
            }
        }
    }
}
