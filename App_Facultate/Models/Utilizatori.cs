using Models;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Utilizatori
    {
        [Key]
        [Required]
        public int id_utilizator{ get; set; }

        [Required]
        [MaxLength(250)]
        public string username { get; set; }

        [Required]
        [MaxLength(250)]
        public string nume { get; set; }

        [Required]
        [MaxLength(250)]
        public string prenume { get; set; }

        [Required]
        [MaxLength(250)]
        public string parola { get; set; }

        [EmailAddress]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Must be a valid Email Address")]
        public string email { get; set; }

    }
}
