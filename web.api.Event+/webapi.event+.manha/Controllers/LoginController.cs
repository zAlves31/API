﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;
using webapi.event_.manha.Repositories;
using webapi.event_.manha.ViewModels;

namespace webapi.event_.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public LoginController() 
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(LoginViewModel usuario)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(usuario.Email!, usuario.Senha!);

                if(usuarioBuscado == null)
                {
                    return StatusCode(401, "Email ou senha invalidos!");
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email,usuarioBuscado.Email!),
                    new Claim(JwtRegisteredClaimNames.Name,usuarioBuscado.Nome!),
                    new Claim(JwtRegisteredClaimNames.Jti,usuarioBuscado.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role,usuarioBuscado.TiposUsuario!.Titulo!)
                };

                var Key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("event-webapi-chave-autenticacao"));

                var creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
               (
                   issuer: "webapi.event+.manha",
                   audience: "webapi.event+.manha",
                   claims: claims,
                   expires: DateTime.Now.AddMinutes(5),
                   signingCredentials: creds
                    );
                return Ok(new
                {

                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });


            }
            catch (Exception)
            {
                throw;
            }
        }

        
    }
}
