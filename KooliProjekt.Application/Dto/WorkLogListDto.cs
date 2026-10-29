using System;

namespace KooliProjekt.Application.Dto
{
    public class WorkLogListDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Hours { get; set; }
        public string Worker { get; set; }
    }
}