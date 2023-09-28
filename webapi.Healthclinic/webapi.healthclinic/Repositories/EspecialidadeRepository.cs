using Microsoft.Identity.Client;
using webapihealthclinic.Contexts;
using webapihealthclinic.Domains;
using webapihealthclinic.Interfaces;

namespace webapihealthclinic.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {

        private readonly HealtchclinicContext _healtchclinicContext;

        public EspecialidadeRepository()
        {
            _healtchclinicContext= new HealtchclinicContext();
        }

        public void Cadastrar(Especialidade especialidade)
        {
            _healtchclinicContext.Especialidade.Add(especialidade);

            _healtchclinicContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Especialidade tipoBuscado = _healtchclinicContext.Especialidade.Find(id);
            _healtchclinicContext.Especialidade.Remove(tipoBuscado);
            _healtchclinicContext.SaveChanges();
        }

        public List<Especialidade> Listar()
        {
            return _healtchclinicContext.Especialidade.ToList();
        }
    }
}
