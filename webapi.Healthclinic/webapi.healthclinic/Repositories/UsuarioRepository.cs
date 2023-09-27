using webapihealthclinic.Contexts;
using webapihealthclinic.Domains;
using webapihealthclinic.Interfaces;
using webapihealthclinic.Utils;

namespace webapihealthclinic.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly HealtchclinicContext _healtchclinicContext;

        public UsuarioRepository()
        {
            _healtchclinicContext= new HealtchclinicContext();
        }

        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                _healtchclinicContext.Usuario.Add(usuario);

                _healtchclinicContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
