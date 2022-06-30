using System;
using System.Collections.Generic;

#nullable disable

namespace HospiEnCasa.App.Persistencia.Models
{
    public partial class SignosVitale
    {
        public SignosVitale()
        {
            SignosPacientes = new HashSet<SignosPaciente>();
        }

        public int IdSigno { get; set; }
        public string DescripSignoVital { get; set; }
        public double RangoMin { get; set; }
        public double RangoMax { get; set; }

        public virtual ICollection<SignosPaciente> SignosPacientes { get; set; }
    }
}
