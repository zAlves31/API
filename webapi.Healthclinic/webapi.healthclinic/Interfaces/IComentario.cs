using webapihealthclinic.Domains;

namespace webapihealthclinic.Interfaces
{
    public interface IComentario
    {
        void Cadastrar(Comentario comentario);

        void Deletar(Guid id);

        List<Comentario> Listar();
    }
}
