using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapihealthclinic.Domains
{
    [Table(nameof(Prontuario))]
    public class Prontuario
    {
        [Key]
        public Guid IdProntuario { get; set; } = Guid.NewGuid();

        [Column(TypeName ="TEXT")]
        [Required(ErrorMessage ="Descricao obrigatoria!")]
        public string? Descricao { get; set; }
    }
}
