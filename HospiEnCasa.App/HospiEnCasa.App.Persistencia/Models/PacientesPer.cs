using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospiEnCasa.App.Persistencia.Models
{
    public class PacientesPer
    {
        public int IdPaciente { get; set; }
        public int IdPersona { get; set; }
        public string Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Genero { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
    }
}