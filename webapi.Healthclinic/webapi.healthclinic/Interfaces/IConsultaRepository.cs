using webapihealthclinic.Domains;

namespace webapihealthclinic.Interfaces
{
    public interface IConsultaRepository
    {
        void Cadastrar(Consulta consulta);

        List<Consulta> Listar();

        List<Consulta> ListarPaciente(Guid id);

        List<Consulta> ListarMedico(Guid id);
    }
}
