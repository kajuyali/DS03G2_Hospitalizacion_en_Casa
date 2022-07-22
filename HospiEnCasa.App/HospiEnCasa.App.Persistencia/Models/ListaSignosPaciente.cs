using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospiEnCasa.App.Persistencia.Models
{
    public class ListaSignosPaciente
    {
        public int IdPaciente { get; set; }
        public double Oximetria { get; set; }
        public double FreCardiaca { get; set; }
        public double FreRespiratoria { get; set; }
        public double Temperatura { get; set; }
        public double Presion { get; set; }
    }
}