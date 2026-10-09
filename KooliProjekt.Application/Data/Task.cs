using System;
using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Application.Data
{
    public class Task
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Range(0, double.MaxValue)]
        public decimal EstimatedHours { get; set; }

        [Required]
        [StringLength(100)]
        public string Worker { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public bool IsCompleted { get; set; }

        [Range(0, double.MaxValue)] 
        public decimal FixedPrice { get; set; }

        public Projekt Projekt { get; set; }
    }
}