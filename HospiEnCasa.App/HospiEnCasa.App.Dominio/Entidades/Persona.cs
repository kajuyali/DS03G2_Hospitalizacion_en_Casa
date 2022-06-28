using System;

namespace HospiEnCasa.App.Dominio
{
    public class Persona 
    {
        // [Key] Para que sea una clave primaria
        [Key]
        public String Documento { get; set; }
        // [Required] Para que sea un campo obligatorio
        [Required]
        public String Nombres { get; set; }
        
        [Required]	
        public String Apellidos { get; set; }
        [Required]
        public String Telefono { get; set; }
        [Required]
        public Genero Genero { get; set; }
    }
}