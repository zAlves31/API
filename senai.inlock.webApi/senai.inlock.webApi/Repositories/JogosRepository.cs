using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi_.Repositories
{
    public class JogosRepository : IJogosRepository
    {
        private string StringConexao = "Data Source = DESKTOP-2B634JF; Initial Catalog inlock_gamesJVAB; User Id = sa; pwd = Senai@134";

        public void Cadastrar(JogosDomain novoJogo)
        {
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
               
            }
            
        }

        public List<JogosDomain> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
