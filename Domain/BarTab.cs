using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class BarTab
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Bar name")]
        public string BarName { get; set; }

        [Required]
        [Display(Name = "Bar name")]
        public double TabAmount { get; set; }

        public IEnumerable<String> Items { get; set; }

        public IEnumerable<String> WhoWasThere { get; set; }

        public DateTime Date;
    }
}
