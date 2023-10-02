using webapihealthclinic.Contexts;
using webapihealthclinic.Domains;
using webapihealthclinic.Interfaces;

namespace webapihealthclinic.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {

        private readonly HealtchclinicContext _healtchclinicContext;

        public ConsultaRepository()
        {
            _healtchclinicContext= new HealtchclinicContext();
        }

        public void Cadastrar(Consulta consulta)
        {
            _healtchclinicContext.Consulta.Add(consulta);
            _healtchclinicContext.SaveChanges();
        }

        public List<Consulta> Listar()
        {
            return _healtchclinicContext.Consulta.ToList();
        }

        public List<Consulta> ListarMedico(Guid id)
        {
            Medico medico = new Medico();
            if (medico.IdMedico == id)
            {
                return _healtchclinicContext.Consulta.ToList();
            }
            return null!;
        }

        public List<Consulta> ListarPaciente(Guid id)
        {
            Paciente paciente = new Paciente();
            if (paciente.IdPaciente == id)
            {
                return _healtchclinicContext.Consulta.ToList();
            }
            return null!;
        }
    }
}
