using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace senai.inlock.webApi_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioController() 
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(UsuarioDomain usuario)
        {
            try
            {
                UsuarioDomain usuarioBuscado = _usuarioRepository.Login(usuario.Email, usuario.Senha);

                if(usuarioBuscado == null) 
                {
                    return NotFound("Email ou senha invalidos!");
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti,usuarioBuscado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email,usuarioBuscado.Email),
                    new Claim(ClaimTypes.Role,usuarioBuscado.Permissao.ToString()),

                    new Claim("Claim personalizada", "Valor da Claim personalizada")
                };

                var Key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("InLock-chave-autenticacao-webapi-dev"));

                var creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                (
                    issuer: "senai.inlock.webApi.",

                    audience: "senai.inlock.webApi.",

                    claims: claims,

                    expires: DateTime.Now.AddMinutes(5),

                    signingCredentials: creds
                );

                return Ok(new
                {

                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
                    
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
