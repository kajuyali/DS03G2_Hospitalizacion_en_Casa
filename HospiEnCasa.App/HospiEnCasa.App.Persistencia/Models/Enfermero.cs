using System;
using System.Collections.Generic;

#nullable disable

namespace HospiEnCasa.App.Persistencia.Models
{
    public partial class Enfermero
    {
        public Enfermero()
        {
            Asignados = new HashSet<Asignado>();
        }

        public int IdEnfer { get; set; }
        public string Especialidad { get; set; }
        public string Registro { get; set; }
        public string DocumentoPersona { get; set; }

        public virtual Persona DocumentoPersonaNavigation { get; set; }
        public virtual ICollection<Asignado> Asignados { get; set; }
    }
}
