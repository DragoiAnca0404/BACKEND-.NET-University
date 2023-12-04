using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public enum ziua
    {
        Monday, Tuesday, Wednesday, Thursday, Friday
    }
    public class Orar
    {
        [Key]
        [Required]
        public int id_orar { get; set; }


        [DisplayFormat(NullDisplayText = "Fara zi")]
        public ziua? ziua { get; set; }


        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]

        public String  Time_start { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public String Time_end { get; set; }

        public int id_materie { get; set; }
        public virtual Materii Materii { get; set; }

    }
}