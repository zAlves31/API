using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi_.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "o campo de email e obrigatorio!")]

        public string Email { get; set; }

        [StringLength(20, MinimumLength = 3, ErrorMessage = "A senha deve ter de 3 a 20 caracteres")]
        [Required(ErrorMessage = "o campo de senha e obrigatorio")]
        public string Senha { get; set; }

        public string Permissao { get; set; }
    }
}
