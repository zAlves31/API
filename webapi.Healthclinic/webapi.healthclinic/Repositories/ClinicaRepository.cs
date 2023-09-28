using webapihealthclinic.Contexts;
using webapihealthclinic.Domains;
using webapihealthclinic.Interfaces;

namespace webapihealthclinic.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {

        private readonly HealtchclinicContext _healtchclinicContext;

        public ClinicaRepository()
        {
            _healtchclinicContext= new HealtchclinicContext();
        }

        public void Atualizar(Guid id, Clinica clinica)
        {
            Clinica tipoClinicaBuscado = _healtchclinicContext.Clinica.Find(id);

            if (tipoClinicaBuscado != null)
            {
                tipoClinicaBuscado.Nome = clinica.Nome;
                tipoClinicaBuscado.Endereco = clinica.Endereco;
                tipoClinicaBuscado.Abertura = clinica.Abertura;
                tipoClinicaBuscado.Fechamento = clinica.Fechamento;
                tipoClinicaBuscado.CNPJ = clinica.CNPJ;
                tipoClinicaBuscado.RazaoSocial = clinica.RazaoSocial;
            }

            _healtchclinicContext.Clinica.Update(tipoClinicaBuscado);

            _healtchclinicContext.SaveChanges();
        }

        public void Cadastrar(Clinica clinica)
        {
           _healtchclinicContext.Clinica.Add(clinica);
            
           _healtchclinicContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Clinica tipoBuscado = _healtchclinicContext.Clinica.Find(id);
            _healtchclinicContext.Clinica.Remove(tipoBuscado);
            _healtchclinicContext.SaveChanges(true);
        }

        public List<Clinica> Listar()
        {
            return _healtchclinicContext.Clinica.ToList();
        }
    }
}
