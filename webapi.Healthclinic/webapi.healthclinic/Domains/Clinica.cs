using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapihealthclinic.Domains
{
    [Table(nameof(Clinica))]
    public class Clinica
    {
        [Key]
        public Guid IdClinica { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome obrigatorio!")]
        public string? Nome { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Endereco obrigatorio!")]
        public string? Endereco { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Horario de abertura obrigatorio!")]
        public DateTime Abertura { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Horario de fechamento obrigatorio!")]
        public DateTime Fechamento { get; set; }

        [Column(TypeName = "CHAR(14)")]
        [Required(ErrorMessage = "CNPJ obrigatorio!")]
        public string? CNPJ { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "RazaoSocial obrigatorio!")]
        public string? RazaoSocial { get; set; }
    }
}
