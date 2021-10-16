using Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public enum grad
    {
        Asistent_universitar, Lector_universitar, Conferentiar_universitar, Profesor_universitar
    }

    public class Profesori
    {
        [Key]
        [Required]
        public int id_profesor { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal salariu { get; set; }

        [DisplayFormat(NullDisplayText = "Fara grad")]
        public grad? grad { get; set; }

        public int id_utilizator{ get; set; }
        public virtual Utilizatori Utilizatori { get; set; }

        public int id_materie { get; set; }
        public virtual Materii Materii { get; set; }

    }
}