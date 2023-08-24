using Microsoft.AspNetCore.Http;
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

        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                //Criar uma lista que recebe os dados da requisicao
                List<GeneroDomain> listaGeneros = _generoRepository.ListarTodos();

                //retorna a lista no formato JSON com o status code OK(200)
                return Ok(listaGeneros);
            }
            catch(Exception erro)
            {
                //retorna um status code BadRequest(400) e a mensagem do erro
                return BadRequest(erro.Message);
            }
        }
        /// <summary>
        /// Endopoint que aciona o metodo de cadastro de genero
        /// </summary>
        /// <param name="novoGenero">Objeto recebido na requisicao</param>
        /// <returns>status code 201(created)</returns>
        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            try 
            { 
                //Fazendo a chamada para o metodo cadastrar passando o objeto como parametro
                _generoRepository.Cadastrar(novoGenero);

                return StatusCode(201);
            }
            catch(Exception erro) 
            {
                return BadRequest(erro.Message);
            }
           
        }

       
            
    }
}
