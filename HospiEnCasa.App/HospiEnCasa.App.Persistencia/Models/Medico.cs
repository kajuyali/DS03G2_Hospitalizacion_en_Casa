using System;
using System.Collections.Generic;

#nullable disable

namespace HospiEnCasa.App.Persistencia.Models
{
    public partial class Medico
    {
        public Medico()
        {
            Asignados = new HashSet<Asignado>();
            Sugerencia = new HashSet<Sugerencia>();
        }

        public int IdMedico { get; set; }
        public string Especialidad { get; set; }
        public string Registro { get; set; }
        public string DocumentoPersona { get; set; }

        public virtual Persona DocumentoPersonaNavigation { get; set; }
        public virtual ICollection<Asignado> Asignados { get; set; }
        public virtual ICollection<Sugerencia> Sugerencia { get; set; }
    }
}
