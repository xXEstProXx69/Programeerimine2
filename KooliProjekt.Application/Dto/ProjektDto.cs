using System;

namespace KooliProjekt.Application.Dto
{
    public class ProjektDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime Deadline { get; set; }
        public decimal Budget { get; set; }
        public decimal HourlyRate { get; set; }
        public string Team { get; set; }
    }
}