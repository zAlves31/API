using webapi.Filmes.Domains;
using webapi.Filmes.Interfaces;

namespace webapi.Filmes.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        /// <summary>
        /// String de conexao com banco de dados que recebe os seguintes parametros
        /// Data Source : Nome do servidor 
        /// Initial Catalog : Nome do banco de dados
        /// Autenticacao:
        ///     -Windows : Integrated Security = true
        ///     - SqlServer: User Id = sa; Pwd = Senha
        /// </summary>

        private string StringConexao = "Data Source = DESKTOP-2B634JF; Initial Catalog = Filmes; User Id = sa; pwd = senai@134";
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, GeneroDomain Genero)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(GeneroDomain novoGenero)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<GeneroDomain> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
