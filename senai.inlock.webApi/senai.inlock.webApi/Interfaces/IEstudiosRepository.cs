using senai.inlock.webApi_.Domains;

namespace senai.inlock.webApi_.Interfaces
{
    public interface IEstudiosRepository
    {
        void Cadastrar(EstudiosDomain novoEstudio);
        List<EstudiosDomain> ListarTodos();
    }
}
