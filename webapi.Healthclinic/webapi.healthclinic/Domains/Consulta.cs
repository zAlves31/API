﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapihealthclinic.Domains
{
    [Table(nameof(Consulta))]
    public class Consulta
    {
        [Key]
        public Guid IdConsulta { get; set; } = Guid.NewGuid();

        [Column(TypeName = "DATETIME")]
        [Required(ErrorMessage = "Data de agendamento obrigatorio!")]
        public DateTime DataAgendamento { get; set; }

        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "Data de agendamento obrigatorio!")]
        public TimeSpan HorarioAgendamento { get; set; }

        //ref.tabela Paciente = FK
        [Required(ErrorMessage = "Informe a clinica ")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set; }


        //ref.tabela Medico = FK
        [Required(ErrorMessage = "Informe o Medico ")]
        public Guid IdMedico { get; set; }

        [ForeignKey(nameof(IdMedico))]
        public Medico? Medico { get; set; }


        //ref.tabela Comentario = FK
        [Required(ErrorMessage = "Informe o Comentario ")]
        public Guid IdProntuario { get; set; }

        [ForeignKey(nameof(IdProntuario))]
        public Prontuario? Prontuario { get; set; }
    }
}
