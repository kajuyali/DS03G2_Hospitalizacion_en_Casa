using System;
using System.Collections.Generic;

#nullable disable

namespace HospiEnCasa.App.Persistencia.Models
{
    public partial class Historium
    {
        public Historium()
        {
            Sugerencia = new HashSet<Sugerencia>();
        }

        public int IdHistoria { get; set; }
        public string Diagnostico { get; set; }
        public int IdPaciente { get; set; }

        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual ICollection<Sugerencia> Sugerencia { get; set; }
    }
}
