using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbRate.Entities
{
    public class DbRateItem
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(10)]
        [Required]
        public string From { get; set; }

        [MaxLength(10)]
        [Required]
        public string To { get; set; }

        [Required]
        public double Rate { get; set; }
    }
}
