using webapi.Inlock.codeFirst.manha.Contexts;
using webapi.Inlock.codeFirst.manha.Domain;
using webapi.Inlock.codeFirst.manha.Interfaces;
using webapi.Inlock.codeFirst.manha.Utils;
using webapi.Inlock.codeFirst.manha.ViewModels;

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
            try
            {
                Usuario usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.Email == email)!;

                if(usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if(confere)
                    {
                        return usuarioBuscado;
                    }
                }
                return null;
            }
            catch(Exception)  
            {
                throw;
            }
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

        public LoginViewModel Login(string? email, string? senha)
        {
            throw new NotImplementedException();
        }
    }
}
