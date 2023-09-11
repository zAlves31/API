using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System.Data.SqlClient;


namespace senai.inlock.webApi_.Repositories
{
    public class EstudiosRepository : IEstudiosRepository
    {
        private string StringConexao = "Data Source = DESKTOP-2B634JF; Initial Catalog inlock_gamesJVAB; User Id = sa; pwd = Senai@134";

        public void Cadastrar(EstudiosDomain novoEstudio)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO Estudio(Nome) VALUES (@Nome)";


                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", novoEstudio.Nome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<EstudiosDomain> ListarTodos()
        {
            List<EstudiosDomain> ListarEstudios = new List<EstudiosDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT * FROM Estudio";

                con.Open();

                SqlDataReader rdr;
            }
            return ListarEstudios;
        }
        
    }
}
