using System;
using System.Collections.Generic;

#nullable disable

namespace HospiEnCasa.App.Persistencia.Models
{
    public partial class Asignado
    {
        public int IdAsignado { get; set; }
        public int IdPaciente { get; set; }
        public int IdEnfermero { get; set; }
        public int IdMedico { get; set; }

        public virtual Enfermero IdEnfermeroNavigation { get; set; }
        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
    }
}
