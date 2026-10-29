using System;

namespace KooliProjekt.Application.Dto
{
    public class ProjektListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime Deadline { get; set; }
    }
}