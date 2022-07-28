using System;
using System.Collections.Generic;

// #nullable disable

namespace HospiEnCasa.App.Persistencia.Models
{
    public class SignosList
    {
//        public SignosList()
//        {
//            SignosList = new HashSet<SignosList>();
//        }
        public int IdSigno { get; set; }
        public int IdPaciente { get; set; }
        public string DescripSignoVital { get; set; }
        public double Valor { get; set; }
        public DateTime Fecha { get; set; }

//        public virtual ICollection<SignosList> SignosList { get; set; }
    }
}
