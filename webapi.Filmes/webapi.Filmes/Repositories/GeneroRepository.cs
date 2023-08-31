using System.Data.SqlClient;
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

        private string StringConexao = "Data Source = DESKTOP-2B634JF; Initial Catalog = Filmes; User Id = sa; pwd = Senai@134";

        /// <summary>
        /// Atualizar um genero passando o seu id pelo corpo da requisicao
        /// </summary>
        /// <param name="genero">Objeto genero com as novas informacoes</param>
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            //Declara a conexao passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(StringConexao)) 
            {
                //Declara a query que sera executada
                string queryUpdate = "UPDATE Genero SET Nome = @Nome WHERE IdGenero = @IdGenero ";

                //Abre a conexao com o banco de dados
                con.Open();

                //Declara o SqlCommand passando a query que sera executada e a conexao com o bd
                using (SqlCommand cmd = new SqlCommand(queryUpdate, con)) 
                {
                    //passa o valor para o parametro @Nome
                    cmd.Parameters.AddWithValue("@Nome", genero.Nome);

                    //passa o valor para o parametro @IdGe nero
                    cmd.Parameters.AddWithValue("@IdGenero", genero.IdGenero);

                    //Executar a query (queryInsert)
                    cmd.ExecuteNonQuery();
                }
            }

        }

        public void AtualizarIdUrl(int id, GeneroDomain Genero)
        {
            //Declara a conexao passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a query que sera executada
                string queryUpdate = "UPDATE Genero SET Nome = @NovoNome WHERE IdGenero = @IdGenero";

                //Declara o SqlCommand passando a query que sera executada e a conexao com o bd
                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {

                    //Abre a conexao com o banco de dados
                    con.Open();

                    //passa o valor para o parametro @IdGnero
                    cmd.Parameters.AddWithValue("@IdGenero", id);

                    //passa o valor para o parametro @NovoNome
                    cmd.Parameters.AddWithValue("@NovoNome", Genero.Nome);

                    //Executar a query (queryInsert)
                    cmd.ExecuteNonQuery();

                }
            }
        }

        /// <summary>
        /// Buscar um Genero atraves do seu id
        /// </summary>
        /// <param name="id">Id do Genero a ser buscado</param>
        /// <returns>Objeto buscado ou null caso nao seja encontrado</returns>
        public GeneroDomain BuscarPorId(int id)
        {
            //Declara a conexao passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a query que sera executada
                string querySelectById = $"SELECT IdGenero, Nome FROM Genero WHERE IdGenero = @IdGenero";

                //Abre a conexao com o banco de dados
                con.Open();

                //Declara o Sqldatareader para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                //Declara o SqlCommand passando a query que sera executada e a conexao com o bd
                using (SqlCommand cmd = new SqlCommand(querySelectById, con)) 
                {
                    //passa o valor para o parametro @IdGnero
                    cmd.Parameters.AddWithValue("@IdGenero", id);

                    //Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();
                    
                    //Verifica se o resultado da query retornou algum registro
                    if (rdr.Read()) 
                    {
                        //Se sim, instancia um novo objeto generoBuscado do tipo GeneroDomain
                        GeneroDomain generoBuscado = new GeneroDomain
                        {
                            //Atribui a propriedade IdGenero o valor da coluna "IdGenero" da tavela do banco de dados
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),

                            //Atribui a propriedade Nome o valor da coluna "Nome" da tabela do banco de dados
                            Nome = rdr["Nome"].ToString()
                        };
                        //Retorna o generoBuscado com os dados obtidos
                        return generoBuscado;

                    }
                    //Se nao, retorna null
                    return null;
                }
            }
        }

        /// <summary>
        /// Cadastrar um novo Genero
        /// </summary>
        /// <param name="novoGenero">Objeto com as informacoes que serao cadastradas</param>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            //Declara a conexao passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a query que sera executada
                string queryInsert = "INSERT INTO Genero(Nome) VALUES ('"+ novoGenero.Nome +"')";

                //Declara o SqlCommand passando a query que sera executada e a conexao com o bd
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {

                    //passa o valor do parametro filme
                    cmd.Parameters.AddWithValue("@Nome", novoGenero.Nome);

                    //Abre a conexao com o banco de dados
                    con.Open();

                    //Executar a query (queryInsert)
                    cmd.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Deleletar um determinado genero
        /// </summary>
        /// <param name="id">Id do objeto a ser deletado</param>
        public void Deletar(int id)
        {
                //Declara a conexao passando a string de conexao como parametro
                using (SqlConnection con = new SqlConnection(StringConexao))
                {
                    //Declara a query que sera executada
                    string queryDelete = "DELETE FROM Genero WHERE IdGenero = @IdGenero";

                    
                    //Declara o SqlCommand passando a query que sera executada e a conexao com o bd
                    using (SqlCommand cmd = new SqlCommand(queryDelete,con))
                    {
                        //passa o valor para o parametro IdGenero
                        cmd.Parameters.AddWithValue("@IdGenero", id);   
                        
                        //Abre a conexao com o banco de dados
                        con.Open();

                        //Executar a query (queryDelete)
                        cmd.ExecuteNonQuery();
                    }
                }
            
        }


        /// <summary>
        /// Listar todos os objetos Generos
        /// </summary>
        /// <returns> Lista de objetos(Generos) </returns>
        public List<GeneroDomain> ListarTodos()
        {
            //Cria uma lista de objetos do tipo genero
            List<GeneroDomain> ListarGeneros= new List<GeneroDomain>();

            //Declara a SqlConnection passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(StringConexao)) 
            {
                //Declara a instrucao a ser executada
                string querySelectAll = "SELECT IdGenero, Nome FROM Genero";
                
                //Abre a conexao com banco de dados
                con.Open();

                //Declara o Sqldatareader para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                //Declara o SqlCommand passando a query que sera executada e a conexao com o bd
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con)) 
                { 
                    //Executa a query e armazena  os dados no rdr
                    rdr = cmd.ExecuteReader();

                    while(rdr.Read()) 
                    {
                        GeneroDomain genero = new GeneroDomain()
                        {
                            //Atribui a propriedade IdGenero o valor recebido no rdr
                            IdGenero = Convert.ToInt32(rdr[0]),

                            //atribui a propriedade Nome o valor recebido no rdr
                            Nome = rdr["Nome"].ToString()
                        };

                        //Adiciona cada objeto dentro da lista 
                        ListarGeneros.Add(genero);
                    }


                }
            }

            return ListarGeneros;
        }
    }
}
