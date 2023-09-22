using webapi.event_.manha.Contexts;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;

namespace webapi.event_.manha.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private readonly EventContext _eventContext;

        public InstituicaoRepository()
        {
            _eventContext = new EventContext();
        }

        public void Atualizar(Guid id, Instituicao instituicao)
        {
            Instituicao instituicaoBuscada = _eventContext.Instituicao.Find(id)!;

            if (instituicaoBuscada != null)
            {
                instituicaoBuscada.CNPJ = instituicao.CNPJ;
                instituicaoBuscada.Endereco = instituicao.Endereco;
                instituicaoBuscada.NomeFantasia = instituicao.NomeFantasia;
            }

            _eventContext.Instituicao.Update(instituicaoBuscada!);

            _eventContext.SaveChanges();
        }

        public Instituicao BuscarPorID(Guid id)
        {
            return _eventContext.Instituicao.FirstOrDefault(e => e.IdInstituicao == id)!;
        }

        public void Cadastrar(Instituicao instituicao)
        {
            _eventContext.Instituicao.Add(instituicao);

            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Instituicao instituicaoBuscada = _eventContext.Instituicao.Find(id);
            _eventContext.Instituicao.Remove(instituicaoBuscada);
            _eventContext.SaveChanges();
        }

        public List<Instituicao> Listar()
        {   
            return _eventContext.Instituicao.ToList();
        }
    }
}
