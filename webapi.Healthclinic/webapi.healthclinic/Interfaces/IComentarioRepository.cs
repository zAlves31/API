using webapihealthclinic.Domains;

namespace webapihealthclinic.Interfaces
{
    public interface IComentarioRepository
    {
        void Cadastrar(Comentario comentario);

        List<Comentario> BuscarPorConsulta(Guid id);

        void Deletar(Guid id);

        List<Comentario> Listar();
    }
}
