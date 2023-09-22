using webapi.event_.manha.Contexts;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;

namespace webapi.event_.manha.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly EventContext _eventContext;

        public EventoRepository()
        {
            _eventContext = new EventContext();
        }

        public void Atualizar(Guid id, Evento evento)
        {
            Evento eventoBuscado = _eventContext.Evento.Find(id)!;

            if (eventoBuscado != null)
            {
                eventoBuscado.DataEvento = evento.DataEvento;
                eventoBuscado.NomeEvento = evento.NomeEvento;
                eventoBuscado.Descricao = evento.Descricao;
                eventoBuscado.IdTipoEvento = evento.IdTipoEvento;
                eventoBuscado.IdInstituicao = evento.IdInstituicao;
            }

            _eventContext.Evento.Update(eventoBuscado!);

            _eventContext.SaveChanges();
        }

        public Evento BuscarPorID(Guid id)
        {
            return _eventContext.Evento.FirstOrDefault(e => e.IdEvento == id)!;
        }

        public void Cadastrar(Evento evento)
        {
            _eventContext.Evento.Add(evento);

            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Evento EventoBuscado = _eventContext.Evento.Find(id);
            _eventContext.Evento.Remove(EventoBuscado);
            _eventContext.SaveChanges();
        }

        public List<Evento> Listar()
        {
            return _eventContext.Evento.ToList();
        }
    }
}
