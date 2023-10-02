using webapihealthclinic.Domains;

namespace webapihealthclinic.Interfaces
{
    public interface IMedicoRepository
    {
        void Cadastrar(Medico medico);

        void Deletar(Guid id);

        void Atualizar(Guid id, Medico medico);

        List<Medico> Listar();
    }
}
