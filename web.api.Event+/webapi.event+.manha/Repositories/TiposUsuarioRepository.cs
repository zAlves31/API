using webapi.event_.manha.Contexts;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;

namespace webapi.event_.manha.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        private readonly EventContext _eventContext;

        public TiposUsuarioRepository() 
        { 
            _eventContext = new EventContext();
        }

        public void Atualizar(TiposUsuario tipoUsuario)
        {
            throw new NotImplementedException();
        }

        public TiposUsuario BuscarPorID(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(TiposUsuario tipoUsuario)
        {
            _eventContext.TiposUsuario.Add(tipoUsuario);

            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            TiposUsuario TipoBuscado = _eventContext.TiposUsuario.Find(id);
            _eventContext.TiposUsuario.Remove(TipoBuscado);
            _eventContext.SaveChanges();
        }

        public List<TiposUsuario> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
