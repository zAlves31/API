using webapihealthclinic.Domains;

namespace webapihealthclinic.Interfaces
{
    public interface IPacienteRepository
    {
        void Cadastrar(Paciente paciente);

        void Deletar(Guid id);

        void Atualizar(Guid id, Paciente paciente);

        List<Paciente> Listar();
    }
}
