using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Inlock.codeFirst.manha.Domain
{
    [Table("Usuario")]
    public class Usuario
    {
        public Guid IdUsuario { get; set; }= Guid.NewGuid();

        [Column(TypeName ="VARCHAR(100)")]
        [Required(ErrorMessage = "Email obrigatorio")]
        public string? Email { get; set; }

        [Column(TypeName ="VARCHAR(100)")]
        [Required(ErrorMessage ="Senha obrigatoria")]
        [StringLength(20, MinimumLength =6, ErrorMessage ="Senha de 6 a 20 caracteres")]
        public string? Senha { get; set; }

        [Required(ErrorMessage ="Tipo do usuario obrigatorio")]
        public Guid IdTipoUsuario { get; set; }

        [ForeignKey("IdTipoUsuario")]
        public TiposUsuario? TipoUsuario { get; set; }
    }
}
