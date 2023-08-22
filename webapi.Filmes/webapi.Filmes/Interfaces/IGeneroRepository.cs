using webapi.Filmes.Domains;

namespace webapi.Filmes.Interfaces
{
    /// <summary>
    /// Interface Responsavel pelo repostitorio GeneroRepository
    /// Definir os metodos que serao implementados pelo GeneroRepository
    /// </summary>
    public interface IGeneroRepository
    {
        //tipodeRetorno NomeMetodo(tipoParametro nomeParametro)

        void Cadastrar(GeneroDomain novoGenero);
        List<GeneroDomain> ListarTodos();
        void AtualizarIdCorpo(GeneroDomain genero);
        void Deletar(int id);
    }
}
