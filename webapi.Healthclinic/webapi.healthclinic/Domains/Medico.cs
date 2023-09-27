using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapihealthclinic.Domains
{
    [Table(nameof(Medico))]
    public class Medico
    {
        [Key]
        public Guid IdMedico { get; set; } = Guid.NewGuid();

        [Column(TypeName = "CHAR(8)")]
        [Required(ErrorMessage = "Numero do CRM obrigatorio!")]
        public string? CRM { get; set; }

        //ref.tabela Usuario = FK
        [Required(ErrorMessage = "Informe o usuario ")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }


        //ref.tabela Especialidade = FK
        [Required(ErrorMessage = "Informe a especialidade ")]
        public Guid IdEspecialidade { get; set; }

        [ForeignKey(nameof(IdEspecialidade))]
        public Especialidade? Especialidade { get; set; }


        //ref.tabela Clinica = FK
        [Required(ErrorMessage = "Informe a clinica ")]
        public Guid IdClinica { get; set; }

        [ForeignKey(nameof(IdClinica))]
        public Clinica? Clinica { get; set; }
    }
}
