using webapi.Inlock.codeFirst.manha.Domain;

namespace webapi.Inlock.codeFirst.manha.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario BuscarUsuario(string email, string senha);

        void Cadastrar(Usuario usuario);
    }
}
