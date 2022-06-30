using System;
using System.Collections.Generic;

#nullable disable

namespace HospiEnCasa.App.Persistencia.Models
{
    public partial class Persona
    {
        public Persona()
        {
            Enfermeros = new HashSet<Enfermero>();
            Familiars = new HashSet<Familiar>();
            Medicos = new HashSet<Medico>();
            Pacientes = new HashSet<Paciente>();
        }

        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Genero { get; set; }

        public virtual ICollection<Enfermero> Enfermeros { get; set; }
        public virtual ICollection<Familiar> Familiars { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
