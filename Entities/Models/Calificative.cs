using Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Calificative
    {
        [Key]
        [Required]
        public int id_Calificativ { get; set; }

        [Range(1, 10)]
        public double nota { get; set; }

        public int id_materie { get; set; }
        public virtual Materii Materii { get; set; }

        public int id_student { get; set; }
        public virtual Studenti Studenti { get; set; }
    }
}