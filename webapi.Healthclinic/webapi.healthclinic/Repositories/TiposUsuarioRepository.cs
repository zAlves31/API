using webapihealthclinic.Contexts;
using webapihealthclinic.Domains;
using webapihealthclinic.Interfaces;

namespace webapihealthclinic.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {

        private readonly HealtchclinicContext _healtchclinicContext;

        public TiposUsuarioRepository()
        {
            _healtchclinicContext = new HealtchclinicContext();
        }

        public void Cadastrar(TiposUsuario tipoUsuario)
        {
            _healtchclinicContext.TiposUsuario.Add(tipoUsuario);

            _healtchclinicContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            TiposUsuario tipoBuscado = _healtchclinicContext.TiposUsuario.Find(id);
            _healtchclinicContext.TiposUsuario.Remove(tipoBuscado);
            _healtchclinicContext.SaveChanges();
        }

        public List<TiposUsuario> Listar()
        {
            return _healtchclinicContext.TiposUsuario.ToList();
        }
    }
}
