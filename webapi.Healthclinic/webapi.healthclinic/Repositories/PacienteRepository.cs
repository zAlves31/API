using webapihealthclinic.Contexts;
using webapihealthclinic.Domains;
using webapihealthclinic.Interfaces;

namespace webapihealthclinic.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {

        private readonly HealtchclinicContext _healtchclinicContext;

        public PacienteRepository()
        {
            _healtchclinicContext = new HealtchclinicContext();
        }

        public void Atualizar(Guid id, Paciente paciente)
        {
            Paciente tipoProntuarioBuscado = _healtchclinicContext.Paciente.Find(id);

            if(tipoProntuarioBuscado != null)
            {
                tipoProntuarioBuscado.DataNascimento = paciente.DataNascimento;
                tipoProntuarioBuscado.Telefone = paciente.Telefone;
                tipoProntuarioBuscado.RG = paciente.RG;
                tipoProntuarioBuscado.CPF = paciente.CPF;
                tipoProntuarioBuscado.Endereco = paciente.Endereco;
                tipoProntuarioBuscado.IdUsuario = paciente.IdUsuario;
            }
            _healtchclinicContext.Update(tipoProntuarioBuscado);
            _healtchclinicContext.SaveChanges();
        }

        public void Cadastrar(Paciente paciente)
        {
            _healtchclinicContext.Paciente.Add(paciente);
            _healtchclinicContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Paciente tipoBuscado = _healtchclinicContext.Paciente.Find(id);
            _healtchclinicContext.Paciente.Remove(tipoBuscado);
            _healtchclinicContext.SaveChanges();
        }

        public List<Paciente> Listar()
        {
            return _healtchclinicContext.Paciente.ToList();
        }
    }
}
