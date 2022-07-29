using System;
using System.Collections.Generic;

#nullable disable

namespace HospiEnCasa.App.Persistencia.Models
{
    public partial class SignosPaciente
    {
        public int IdSignoPaciente { get; set; }
        public DateTime Fecha { get; set; }
        public double Valor { get; set; }
        public int IdSigno { get; set; }
        public int IdPaciente { get; set; }


        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual SignosVitale IdSignoNavigation { get; set; }
    }
}
