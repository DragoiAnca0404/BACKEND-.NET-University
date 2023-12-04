using Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class subject_category
    {
        [Key]
        [Required]
        public int id_subject_category { get; set; }
        public int id_materie { get; set; }
        public virtual Materii Materii { get; set; }

        public int id_category_job { get; set; }
        public virtual Category_Jobs Category_Jobs { get; set; }

    }
}
