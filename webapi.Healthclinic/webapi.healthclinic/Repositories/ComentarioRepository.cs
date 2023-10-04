using Microsoft.EntityFrameworkCore;
using webapihealthclinic.Contexts;
using webapihealthclinic.Domains;
using webapihealthclinic.Interfaces;

namespace webapihealthclinic.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly HealtchclinicContext _healtchclinicContext;

        public ComentarioRepository()
        {
            _healtchclinicContext= new HealtchclinicContext();
        }

        public List<Comentario> BuscarPorConsulta(Guid id)
        {
            Comentario comentario = new Comentario();
            if (comentario.IdConsulta == id)
            {
                return null!;
            }
            return _healtchclinicContext.Comentario.ToList();

        }

        public void Cadastrar(Comentario comentario)
        {
            _healtchclinicContext.Comentario.Add(comentario);

            _healtchclinicContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Comentario tipoBuscado = _healtchclinicContext.Comentario.Find(id);
            _healtchclinicContext.Comentario.Remove(tipoBuscado);
            _healtchclinicContext.SaveChanges();
        }

        public List<Comentario> Listar()
        {
            return _healtchclinicContext.Comentario.ToList();
        }
    }
}
