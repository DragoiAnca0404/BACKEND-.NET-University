using Models;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Administratori
    {
        [Key]
        [Required]
        public int id_administrator { get; set; }
        public int id_utilizator { get; set; }
        public virtual Utilizatori Utilizatori { get; set; }
    }
}