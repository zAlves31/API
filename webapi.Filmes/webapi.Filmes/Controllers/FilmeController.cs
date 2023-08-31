using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Filmes.Domains;
using webapi.Filmes.Interfaces;
using webapi.Filmes.Repositories;

namespace webapi.Filmes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        /// <summary>
        /// Objeto _filmeRepository que ira receber todos os metodos definidos na interface IFilmeRepository
        /// </summary>
        private IFilmeRepository _filmeRepository { get; set; }


        /// <summary>
        /// Instacia objeto _filmeRepository para que haja referencia aos metodos no repositorio
        /// </summary>
        public FilmeController()
        {
            _filmeRepository = new FilmeRepository();
        }


        /// <summary>
        /// EndPoint que aciona o metodo ListarTodos do Filme
        /// </summary>
        /// <returns>resposta para o usuario(front-end)</returns>>
        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                //Criar uma lista que recebe os dados da requisicao
                List<FilmeDomain> listarFilmes = _filmeRepository.ListarTodos();

                //retorna a lista no formato JSON com o status code OK(200)
                return Ok(listarFilmes);
            }
            catch (Exception erro) 
            {
                //retorna um status code BadRequest(400) e a mensagem do erro
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// EndPoint que aciona o metodo de cadastro de filme
        /// </summary>
        /// <param name="novoFilme"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(FilmeDomain novoFilme)
        {
            try
            {
                //Fazendo a chamada para o metodo cadastrar passando o objeto como parametro
                _filmeRepository.Cadastrar(novoFilme);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        ///  EndPoint que aciona o metodo de deletar filme por ID
        /// </summary>
        /// <param name="id">id do filme a ser deletado</param>
        /// <returns>status code</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _filmeRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }

        }

        /// <summary>
        /// EndPoint que aciona o metodo de buscar IdFilme
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                FilmeDomain filmeEncontrado = _filmeRepository.BuscarPorId(id);

                return Ok(filmeEncontrado);
            }
            catch(Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona Atualizar um filme Atualizar Id por Corpo
        /// </summary>
        /// <param name="filme"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult PutIdBody(FilmeDomain filme)
        {
            try
            {
                _filmeRepository.AtualizarIdCorpo(filme);

                return StatusCode(200);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona metodo atualizar Id URL de Filme
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Filme"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult AtualizarIdUrl(int id, FilmeDomain Filme)
        {
            try
            {
                _filmeRepository.AtualizarIdUrl(id, Filme);

                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

    }
}