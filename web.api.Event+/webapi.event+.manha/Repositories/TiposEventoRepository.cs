using webapi.event_.manha.Contexts;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;

namespace webapi.event_.manha.Repositories
{
    public class TiposEventoRepository : ITiposEventoRepository
    {
        private readonly EventContext _eventContext;

        public TiposEventoRepository() 
        {
            _eventContext = new EventContext();
        }

        public void Atualizar(Guid id, TiposEvento tipoEvento)
        {
            TiposEvento tipoEventoBuscado = _eventContext.TiposEvento.Find(id);

            if(tipoEventoBuscado != null) 
            { 
                tipoEventoBuscado.Titulo = tipoEvento.Titulo;
            }

            _eventContext.TiposEvento.Update(tipoEventoBuscado);

            _eventContext.SaveChanges();
        }

        public TiposEvento BuscarPorID(Guid id)
        {
            return _eventContext.TiposEvento.FirstOrDefault(e => e.IdTipoEvento == id);
        }

        public void Cadastrar(TiposEvento tipoEvento)
        {
            _eventContext.TiposEvento.Add(tipoEvento);

            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            TiposEvento TipoBuscado = _eventContext.TiposEvento.Find(id);
            _eventContext.TiposEvento.Remove(TipoBuscado);
            _eventContext.SaveChanges();
        }

        public List<TiposEvento> Listar()
        {
            return _eventContext.TiposEvento.ToList();
        }
    }
}
