﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Filmes.Domains;
using webapi.Filmes.Interfaces;
using webapi.Filmes.Repositories;

namespace webapi.Filmes.Controllers
{
    //Define a rota de uma requisicao sera o seguinte formato
    //dominio/api/nomeController
    //ex: https://localhost:5000/api/genero
    [Route("api/[controller]")]

    //Define que e um controlador API
    [ApiController]

    //Define que tipo de resposta da API sera no formato JSON
    [Produces("application/json")]

    //Metodo controlador que herda da controller base
    //Onde sera criado os Endpoints(rotas)
    public class GeneroController : ControllerBase
    {
        /// <summary>
        /// Objeto _generoRepository que ira receber todos os metodos definidos na interface IGeneroRepository
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }

        /// <summary>
        /// Instacia objeto _generoRepository para que haja referencia aos metodos no repositorio
        /// </summary>
        public GeneroController()
        {
            _generoRepository = new GeneroRepository();
        }

        /// <summary>
        /// EndPoint que aciona o metodo ListarTodos do genero 
        /// </summary>
        /// <returns>resposta para o usuario(front-end)</returns>>
        [HttpGet]
        [Authorize(Roles = "Administrador,comum")]
        public IActionResult Get()
        {
            try
            {
                //Criar uma lista que recebe os dados da requisicao
                List<GeneroDomain> listaGeneros = _generoRepository.ListarTodos();

                //retorna a lista no formato JSON com o status code OK(200)
                return Ok(listaGeneros);
            }
            catch (Exception erro)
            {
                //retorna um status code BadRequest(400) e a mensagem do erro
                return BadRequest(erro.Message);
            }
        }
        /// <summary>
        /// EndPoint que aciona o metodo de cadastro de genero
        /// </summary>
        /// <param name="novoGenero">Objeto recebido na requisicao</param>
        /// <returns>status code 201(created)</returns>
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            try
            {
                //Fazendo a chamada para o metodo cadastrar passando o objeto como parametro
                _generoRepository.Cadastrar(novoGenero);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }

        }

        /// <summary>
        /// EndPoint que aciona o metodo de deletar genero por ID
        /// </summary>
        /// <param name="id">id do genero a ser deletado</param>
        /// <returns>status code</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete(int id)
        {
            try
            {
                //Fazendo a chamada para o metodo deletar passando o objeto como parametro
                _generoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o metodo de buscar IdGenero
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "Administrador,comum")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                GeneroDomain generoEncontrado = _generoRepository.BuscarPorId(id);

                return Ok(generoEncontrado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o metodo Atualizar Id URL de Genero
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Genero"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize(Roles = "Administrador")]
        public IActionResult AtualizarIdUrl(int id, GeneroDomain Genero)
        {
            try
            {
                _generoRepository.AtualizarIdUrl(id, Genero);

                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona Atualizar um genero Atualizar Id por Corpo
        /// </summary>
        /// <param name="genero"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult PutIdBody(GeneroDomain genero)
        {
            try
            {
                GeneroDomain generoBuscado = _generoRepository.BuscarPorId(genero.IdGenero);

                if (generoBuscado != null)
                {
                    try
                    {
                        _generoRepository.AtualizarIdCorpo(genero);

                        return StatusCode(204);
                    }
                    catch (Exception erro)
                    {
                        return BadRequest(erro.Message);
                    }
                }
                return NotFound("Genero nao encontrado");
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }


    }

}
