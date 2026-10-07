using System;
using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Application.Data
{
    public class WorkLog
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public decimal Hours { get; set; }

        [Required]
        [StringLength(100)]
        public string Worker { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }
    }
}