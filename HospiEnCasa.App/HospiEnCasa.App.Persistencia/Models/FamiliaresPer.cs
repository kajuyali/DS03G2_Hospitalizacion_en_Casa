using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospiEnCasa.App.Persistencia.Models
{
    public class FamiliaresPer
    {
        public int IdFamiliar { get; set; }
        public int IdPersona { get; set; }
        public int IdPaciente { get; set; }
        public string Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Genero { get; set; }
        public string Parentesco { get; set; }
        public string Correo { get; set; }
    }
}