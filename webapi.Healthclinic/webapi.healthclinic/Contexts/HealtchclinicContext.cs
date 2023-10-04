using Microsoft.EntityFrameworkCore;
using webapihealthclinic.Domains;

namespace webapihealthclinic.Contexts
{
    public class HealtchclinicContext : DbContext
    {
        public DbSet<TiposUsuario> TiposUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Prontuario> Prontuario { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Especialidade> Especialidade { get; set; }
        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<Comentario> Comentario { get; set; }
        public DbSet<Clinica> Clinica { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-2B634JF; Database=webapi_healthclinic_manha; user id=sa; Pwd=Senai@134; TrustServerCertificate = True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
