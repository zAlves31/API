using Microsoft.EntityFrameworkCore;
using webapi.Inlock.codeFirst.manha.Domain;

namespace webapi.Inlock.codeFirst.manha.Contexts
{
    public class InLockContext : DbContext
    {
        //Define as entidades do banco de dados
        public DbSet<Estudio> Estudio { get; set; }
        public DbSet<Jogo> Jogo { get; set; }
        public DbSet<TiposUsuario> TiposUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        /// <summary>
        /// Define as opcoes de construcao do banco(String Conexao)
        /// </summary>
        /// <param name="optionsBuilder">Objeto com as definicoes</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-2B634JF; Database=inlock_games_codeFirst_manha; user id=sa; Pwd=Senai@134; TrustServerCertificate = True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
