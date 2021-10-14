using Models;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Studenti
    {
        [Key]
        [Required]
        public int id_student { get; set; }

        [Required]
        public bool scutit_plata { get; set; }

        // Foreign key
        public int id_specializare { get; set; }
        public virtual Specializari Specializari { get; set; }

        public int id_utilizator { get; set; }
        public virtual Utilizatori Utilizatori { get; set; }
    }
}
