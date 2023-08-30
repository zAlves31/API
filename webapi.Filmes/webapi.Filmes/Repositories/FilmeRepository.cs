using System.Data.SqlClient;
using webapi.Filmes.Domains;
using webapi.Filmes.Interfaces;

namespace webapi.Filmes.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private string StringConexao = "Data Source = DESKTOP-2B634JF; Initial Catalog = Filmes; User Id = sa; pwd = Senai@134";

        public void AtualizarIdCorpo(FilmeDomain filme)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, FilmeDomain filme)
        {
            throw new NotImplementedException();
        }

        public FilmeDomain BuscarPorId(int id)
        {
            //Declara a conexao passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a query que sera executada
                string querySelectById = $"SELECT IdFilme, Titulo FROM Filme WHERE IdFilme = @IdFilme";

                //Abre a conexao com o banco de dados
                con.Open();

                //Declara o Sqldatareader para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                //Declara o SqlCommand passando a query que sera executada e a conexao com o bd
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    //passa o valor para o parametro @IdFilme
                    cmd.Parameters.AddWithValue("@IdFilme", id);

                    //Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    //Verifica se o resultado da query retornou algum registro
                    if (rdr.Read())
                    {
                        //Se sim, instancia um novo objeto generoBuscado do tipo FilmeDomain
                        FilmeDomain filmeBuscado = new FilmeDomain
                        {
                            //Atribui a propriedade IdFilme o valor da coluna "IdFilme" da tavela do banco de dados
                            IdFilme = Convert.ToInt32(rdr["IdFilme"]),

                            //Atribui a propriedade Titulo o valor da coluna "Titulo" da tabela do banco de dados
                            Titulo = rdr["Titulo"].ToString()
                        };
                        //Retorna o generoBuscado com os dados obtidos
                        return filmeBuscado;
                    }

                    return null;
                }
            }
        }

        /// <summary>
        /// Cadastrar um novo Filme
        /// </summary>
        /// <param name="novoFilme"></param>
        public void Cadastrar(FilmeDomain novoFilme)
        {
            using (SqlConnection con =new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO Filme(Titulo) VALUES ('"+ novoFilme.Titulo +"')";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con)) 
                {
                    //passa o valor do parametro filme
                    cmd.Parameters.AddWithValue("@Titulo", novoFilme.Titulo);

                    //Abre a conexao com o banco de dados
                    con.Open();

                    //Executar a query (queryInsert)
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deletar um determinado Filme
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            //Declara a conexao passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a query que sera executada
                string queryDelete = "DELETE FROM Filme WHERE IdFilme = @IdFilme ";


                using (SqlCommand cmd = new SqlCommand(queryDelete,con))
                {
                    //passa o valor para o parametro IdFilme
                    cmd.Parameters.AddWithValue("@IdFilme", id);

                    //Abre a conexao com o banco de dados
                    con.Open();

                    //Executar a query (queryDelete)
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<FilmeDomain> ListarTodos()
        {

            //Cria uma lista de objetos do tipo Filme
            List<FilmeDomain>  ListarFilmes =  new List<FilmeDomain>();

            //Declara a SqlConnection passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a instrucao a ser executada
                string querySelectAll = "SELECT Filme.IdFilme, Filme.IdGenero, Filme.Titulo, Genero.Nome FROM Filme INNER JOIN Genero ON Filme.IdGenero = Genero.IdGenero ";

                //Abre a conexao com banco de dados
                con.Open();

                //Declara o Sqldatareader para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr= cmd.ExecuteReader();

                    while(rdr.Read()) 
                    {
                        FilmeDomain filme = new FilmeDomain()
                        {
                            IdFilme = Convert.ToInt32(rdr[0]),

                            Titulo = rdr["Titulo"].ToString()
                        };

                        ListarFilmes.Add(filme);
                    }
                }
            }

            return ListarFilmes;
        }
    }
}
