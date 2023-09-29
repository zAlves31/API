using webapihealthclinic.Contexts;
using webapihealthclinic.Domains;
using webapihealthclinic.Interfaces;

namespace webapihealthclinic.Repositories
{
    public class ProntuarioRepository : IProntuarioRepository
    {

        private readonly HealtchclinicContext _healtchclinicContext;

        public ProntuarioRepository()
        {
            _healtchclinicContext= new HealtchclinicContext();
        }

        public void Atualizar(Guid id, Prontuario prontuario)
        {
            Prontuario tipoProntuarioBuscado = _healtchclinicContext.Prontuario.Find(id);

            if(tipoProntuarioBuscado !=null)
            {
                tipoProntuarioBuscado.Descricao = prontuario.Descricao;
            }

            _healtchclinicContext.Prontuario.Update(tipoProntuarioBuscado);
            _healtchclinicContext.SaveChanges();
        }

        public void Cadastrar(Prontuario prontuario)
        {
            _healtchclinicContext.Prontuario.Add(prontuario);

            _healtchclinicContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Prontuario tipoBuscado = _healtchclinicContext.Prontuario.Find(id);
            _healtchclinicContext.Prontuario.Remove(tipoBuscado);
            _healtchclinicContext.SaveChanges();
        }

        public List<Prontuario> Listar()
        {
            return _healtchclinicContext.Prontuario.ToList();
        }
    }
}
