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

        public DateTime Start { get; set; }

        public decimal EstimatedHours { get; set; }

        [Required]
        [StringLength(100)]
        public string ResponsiblePerson { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public bool IsCompleted { get; set; }

        public decimal FixedPrice { get; set; }
    }
}