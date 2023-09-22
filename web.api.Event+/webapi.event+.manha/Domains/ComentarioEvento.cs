using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.manha.Domains
{
    [Table(nameof(ComentarioEvento))]
    public class ComentarioEvento
    {
        [Key]
        public Guid IdComentarioEvento { get; set; } = Guid.NewGuid();

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Descricao obrigatoria!")]
        public string? Descricao { get; set; }

        [Column(TypeName ="TEXT")]
        [Required(ErrorMessage = "Descricao obrigatoria!")] 
        public bool? Exibe { get; set; }

        //ref.tabela Usuario = FK
        [Required(ErrorMessage = "Usuario obrigatorio!")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }

        //ref.tabela Evento = FK
        [Required(ErrorMessage = "Evento obrigatorio")]
        public Guid IdEvento { get; set; }

        [ForeignKey(nameof(IdEvento))]
        public Evento? Evento { get; set; }
    }
}
