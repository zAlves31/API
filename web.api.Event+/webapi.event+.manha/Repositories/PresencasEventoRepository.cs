using webapi.event_.manha.Contexts;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;

namespace webapi.event_.manha.Repositories
{
    public class PresencasEventoRepository : IPresencasEventoRepository
    {

        private readonly EventContext _eventContext;

        public PresencasEventoRepository()
        {
            _eventContext = new EventContext();
        }

        public void Cadastrar(PresencasEvento presencasEvento)
        {
            _eventContext.PresencasEvento.Add(presencasEvento);

            _eventContext.SaveChanges();

        }

        public void Deletar(Guid id)
        {
            PresencasEvento PresencaBuscada = _eventContext.PresencasEvento.Find(id);
            _eventContext.PresencasEvento.Remove(PresencaBuscada);
            _eventContext.SaveChanges();
        }

        public List<PresencasEvento> Listar()
        {
            return _eventContext.PresencasEvento.ToList();
        }

        public List<PresencasEvento> ListarMinhas(Guid id)
        {
            return _eventContext.PresencasEvento.Where(e => e.IdUsuario== id).ToList();
        }
    }
}
