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
            //Declara a conexao passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a query que sera executada
                string queryInsert = "INSERT INTO Genero(Nome) VALUES ('"+ novoGenero.Nome +"')";

                //Declara o SqlCommand passando a query que sera executada e a conexao com o bd
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    //Abre a conexao com o banco de dados
                    con.Open();

                    //Executar a query (queryInsert)
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

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
