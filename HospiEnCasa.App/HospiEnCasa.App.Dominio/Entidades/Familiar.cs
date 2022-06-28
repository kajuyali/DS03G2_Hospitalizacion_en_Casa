

namespace HospiEnCasa.App.Dominio
{
    public class Familiar : Persona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int IdFamiliar { get; set; }
        [Required]
        public String Parentesco { get; set; }
        [Required]
        public string Correo { get; set; }
        [Required]
        public int IdPaciente { get; set; }

    }
}