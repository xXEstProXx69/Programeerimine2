using System;
using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Application.Data
{
    public class Projekt
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public DateTime Start { get; set; }

        public DateTime Deadline { get; set; }

        public decimal Budget { get; set; }

        public decimal HourlyRate { get; set; }

        [StringLength(500)]
        public string Team { get; set; }
    }
}