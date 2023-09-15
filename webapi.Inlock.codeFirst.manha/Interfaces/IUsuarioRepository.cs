using webapi.Inlock.codeFirst.manha.Domain;
using webapi.Inlock.codeFirst.manha.ViewModels;

namespace webapi.Inlock.codeFirst.manha.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario BuscarUsuario(string email, string senha);

        void Cadastrar(Usuario usuario);
        LoginViewModel Login(string? email, string? senha);
    }
}
