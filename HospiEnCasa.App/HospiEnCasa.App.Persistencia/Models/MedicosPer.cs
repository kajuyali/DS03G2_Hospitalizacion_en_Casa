using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospiEnCasa.App.Persistencia.Models
{
    public class MedicosPer
    {
        public int IdMedico { get; set; }
        public int IdPersona { get; set; }
        public string Id { get; set; }
        public string Nombres{ get; set; }
        public string Apellidos { get; set; }
        public string Genero { get; set; }
        public string Telefono { get; set; }
        public string Especialidad { get; set; }
        public string Registro { get; set; }
    }
}