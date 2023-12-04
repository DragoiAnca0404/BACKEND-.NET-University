using Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Models
{
    public class Job_qualities
    {
        [Key]
        [Required]
        public int id_job_quality { get; set; }

        [Required]
        [MaxLength(250)]
        public string quality { get; set; }

        // Foreign key
        public int id_category_job { get; set; }
        public virtual Category_Jobs Category_Jobs { get; set; }
    }
}
