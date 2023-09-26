using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapihealthclinic.Domains
{
    [Table(nameof(Comentario))]
    public class Comentario
    {
        [Key]
        public Guid IdComentario { get; set; } = Guid.NewGuid();

        [Column(TypeName ="VARCHAR")]
        [Required(ErrorMessage ="Comentario obrigatorio!")]  
        public string? Feedback { get; set; }

    }
}
