using System.ComponentModel.DataAnnotations;

namespace Commander.Models
{
    public class Materii
    {
        [Key]
        [Required]
        public int id_materie { get; set; }

        [Required]
        [MaxLength(250)]
        public string denumire_materie { get; set; }

    }
}