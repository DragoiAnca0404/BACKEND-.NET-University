using System.ComponentModel.DataAnnotations;

namespace Commander.Models
{
    public class Specializari
    {
        [Key]
        [Required]
        public int id_Specializare { get; set; }

        [Required]
        [MaxLength(250)]
        public string denumire_specializare { get; set; }

    }
}