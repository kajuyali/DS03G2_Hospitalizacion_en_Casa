﻿using System;
using System.Collections.Generic;

#nullable disable

namespace HospiEnCasa.App.Persistencia.Models
{
    public partial class Familiar
    {
        public int IdFamiliar { get; set; }
        public string Parentesco { get; set; }
        public string Correo { get; set; }
        public int IdPaciente { get; set; }
        public int IdPersona { get; set; }

        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual Persona IdPersonaNavigation { get; set; }
    }
}
