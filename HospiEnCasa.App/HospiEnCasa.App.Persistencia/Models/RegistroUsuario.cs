using System.Security.AccessControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HospiEnCasa.App.Persistencia.Models
{
    public class RegistroUsuario
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public String Correo { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public String Contraseña { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Contraseña", ErrorMessage = "Las contraseñas no coinciden")]
        public String ConfirmarContraseña { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public String Tipo { get; set; }
    }
}