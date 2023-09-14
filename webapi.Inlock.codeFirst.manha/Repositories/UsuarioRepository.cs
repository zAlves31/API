using webapi.Inlock.codeFirst.manha.Contexts;
using webapi.Inlock.codeFirst.manha.Domain;
using webapi.Inlock.codeFirst.manha.Interfaces;
using webapi.Inlock.codeFirst.manha.Utils;

namespace webapi.Inlock.codeFirst.manha.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly InLockContext ctx;

        public UsuarioRepository() 
        {
            ctx = new InLockContext();
        }

        public Usuario BuscarUsuario(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                ctx.Add(usuario);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
           

        }
    }
}
