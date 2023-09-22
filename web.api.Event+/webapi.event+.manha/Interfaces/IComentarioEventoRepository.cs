using webapi.event_.manha.Domains;

namespace webapi.event_.manha.Interfaces
{
    public interface IComentarioEventoRepository
    {
        void Cadastrar(ComentarioEvento comentarioEvento);

        void Deletar(Guid id);

        List<ComentarioEvento> Listar();

        ComentarioEvento BuscarPorID(Guid id);
    }
}
