using webapi.event_.manha.Domains;

namespace webapi.event_.manha.Interfaces
{
    public interface IPresencasEventoRepository
    {
        void Cadastrar(PresencasEvento presencasEvento);

        void Deletar(Guid id);

        List<PresencasEvento> Listar();

        List<PresencasEvento> ListarMinhas(Guid id);
    }
}
