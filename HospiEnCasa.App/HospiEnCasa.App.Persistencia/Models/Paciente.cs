using System;
using System.Collections.Generic;

#nullable disable

namespace HospiEnCasa.App.Persistencia.Models
{
    public partial class Paciente
    {
        public Paciente()
        {
            Asignados = new HashSet<Asignado>();
            Familiars = new HashSet<Familiar>();
            Historia = new HashSet<Historium>();
            SignosPacientes = new HashSet<SignosPaciente>();
        }

        public int IdPac { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public int IdPersona { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; }
        public virtual ICollection<Asignado> Asignados { get; set; }
        public virtual ICollection<Familiar> Familiars { get; set; }
        public virtual ICollection<Historium> Historia { get; set; }
        public virtual ICollection<SignosPaciente> SignosPacientes { get; set; }
    }
}
