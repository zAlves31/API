using webapi.event_.manha.Contexts;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;

namespace webapi.event_.manha.Repositories
{
    public class ComentarioEventoRepository : IComentarioEventoRepository
    {

        private readonly EventContext _eventContext;

        public ComentarioEventoRepository()
        {
            _eventContext = new EventContext();
        }

        public ComentarioEvento BuscarPorID(Guid id)
        {
            return _eventContext.ComentarioEvento.FirstOrDefault(e => e.IdComentarioEvento == id)!;
        }

        public void Cadastrar(ComentarioEvento comentarioEvento)
        {
            _eventContext.ComentarioEvento.Add(comentarioEvento);

            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            ComentarioEvento comentarioBuscado = _eventContext.ComentarioEvento.Find(id);
            _eventContext.ComentarioEvento.Remove(comentarioBuscado);
            _eventContext.SaveChanges();
        }

        public List<ComentarioEvento> Listar()
        {
            return _eventContext.ComentarioEvento.ToList();
        }
    }
}
