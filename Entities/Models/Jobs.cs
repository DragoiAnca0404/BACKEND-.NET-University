using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Jobs
    {
        [Key]
        [Required]
        public int id_job { get; set; }

        [Required]
        [MaxLength(250)]
        public string denumire_job { get; set; }

        public int id_category_job { get; set; }
        public virtual Category_Jobs Category_Jobs { get; set; }
    }
}
