using webapihealthclinic.Domains;

namespace webapihealthclinic.Interfaces
{
    public interface IProntuarioRepository
    {
        void Cadastrar(Prontuario prontuario);

        void Deletar(Guid id);

        void Atualizar(Guid id, Prontuario prontuario);

        List<Clinica> Listar();
    }
}
