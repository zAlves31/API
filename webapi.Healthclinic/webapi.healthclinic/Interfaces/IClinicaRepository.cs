using webapihealthclinic.Domains;

namespace webapihealthclinic.Interfaces
{
    public interface IClinicaRepository
    {
        void Cadastrar(Clinica clinica);

        void Deletar(Guid id);

        void Atualizar(Guid id, Clinica clinica);

        List<Clinica> Listar();
    }
}
