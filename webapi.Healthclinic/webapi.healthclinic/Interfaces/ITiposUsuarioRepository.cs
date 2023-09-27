using webapihealthclinic.Domains;

namespace webapihealthclinic.Interfaces
{
    public interface ITiposUsuarioRepository
    {
        void Cadastrar(TiposUsuario tipoUsuario);

        void Deletar(Guid id);

        List<TiposUsuario> Listar();
    }
}
