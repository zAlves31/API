using webapihealthclinic.Domains;

namespace webapihealthclinic.Interfaces
{
    public interface IMedicoRepository
    {
        void Cadastrar(Medico medico);

        void Deletar(Guid id);

        List<Medico> Listar();
    }
}
