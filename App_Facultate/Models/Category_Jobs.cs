using Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Category_Jobs
    {

        [Key]
        [Required]
        public int id_category_job { get; set; }

        [Required]
        [MaxLength(250)]
        public string denumire_categorie_job { get; set; }


        [Required]
        [MaxLength(250)]
        public string quality { get; set; }


        [Required]
        public string descriere_job { get; set; }


        [Required]
        public string atributii_job { get; set; }
    }
}