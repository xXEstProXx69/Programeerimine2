
using System;

namespace KooliProjekt.Application.Dto
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public decimal EstimatedHours { get; set; }
        public string Worker { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public decimal FixedPrice { get; set; }
        public int? ProjektId { get; set; }
    }
}
