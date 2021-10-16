using System.ComponentModel.DataAnnotations;

namespace Models
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