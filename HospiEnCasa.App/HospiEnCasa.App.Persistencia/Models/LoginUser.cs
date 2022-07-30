using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HospiEnCasa.App.Persistencia.Models
{
    public class LoginUser
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public String Correo { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public String Contraseña { get; set; }
        public bool Recordarme { get; set; }
    }
}