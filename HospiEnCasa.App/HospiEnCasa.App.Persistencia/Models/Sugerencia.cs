using System;
using System.Collections.Generic;

#nullable disable

namespace HospiEnCasa.App.Persistencia.Models
{
    public partial class Sugerencia
    {
        public int IdSugerencia { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public int IdHistoria { get; set; }
        public int IdMedico { get; set; }

        public virtual Historium IdHistoriaNavigation { get; set; }
        public virtual Medico IdMedicoNavigation { get; set; }
    }
}
