using Model;
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

        public int id_student { get; set; }
        public virtual Studenti Studenti { get; set; }

    }
}