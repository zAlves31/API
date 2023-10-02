using webapihealthclinic.Contexts;
using webapihealthclinic.Controllers;
using webapihealthclinic.Domains;
using webapihealthclinic.Interfaces;

namespace webapihealthclinic.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {

        private readonly HealtchclinicContext _healtchclinicContext;

        public MedicoRepository()
        {
            _healtchclinicContext= new HealtchclinicContext();
        }

        public void Atualizar(Guid id, Medico medico)
        {
            Medico tipoMedicoBuscado = _healtchclinicContext.Medico.Find(id);

            if(tipoMedicoBuscado != null)
            {
                tipoMedicoBuscado.Telefone = medico.Telefone;
            }

            _healtchclinicContext.Update(tipoMedicoBuscado);
            _healtchclinicContext.SaveChanges();
        }

        public void Cadastrar(Medico medico)
        {
            _healtchclinicContext.Medico.Add(medico);
            _healtchclinicContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Medico tipoBuscado = _healtchclinicContext.Medico.Find(id);
            _healtchclinicContext.Medico.Remove(tipoBuscado);
            _healtchclinicContext.SaveChanges();    
        }

        public List<Medico> Listar()
        {
            return _healtchclinicContext.Medico.Select(p => new Medico
            {
                IdMedico = p.IdMedico,
                CRM = p.CRM,
                Telefone = p.Telefone,
                CPF = p.CPF,
                
   

                IdUsuario = p.IdUsuario,
                Usuario = new Usuario
                {
                    IdUsuario = p.IdUsuario,
                    Nome = p.Usuario!.Nome,
                    Email = p.Usuario!.Email,
                    Senha = p.Usuario!.Senha,
                    IdTipoUsuario = p.Usuario!.IdTipoUsuario,

                    TiposUsuario = new TiposUsuario
                    {
                        IdTipoUsuario = p.Usuario.IdTipoUsuario,
                        Titulo = p.Usuario.TiposUsuario!.Titulo
                    }

                },

                IdEspecialidade = p.IdEspecialidade,
                Especialidade = new Especialidade
                {
                    IdEspecialidade= p.IdEspecialidade,
                    Titulo = p.Especialidade.Titulo
                },

                IdClinica= p.IdClinica,
                Clinica = new Clinica
                {
                    IdClinica= p.IdClinica,
                    Nome = p.Clinica!.Nome,
                    Endereco = p.Clinica!.Endereco,
                    Abertura = p.Clinica!.Abertura,
                    Fechamento = p.Clinica!.Fechamento,
                    CNPJ = p.Clinica!.CNPJ,
                    RazaoSocial = p.Clinica!.RazaoSocial
                }

            }).ToList();
        }
    }
}
