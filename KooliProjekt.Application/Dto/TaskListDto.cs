
using System;

namespace KooliProjekt.Application.Dto
{
    public class TaskListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public string Worker { get; set; }
        public bool IsCompleted { get; set; }
    }
}
