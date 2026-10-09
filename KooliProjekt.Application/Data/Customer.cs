using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Data
{
    [Index(nameof(CustomerName), IsUnique = true)]

    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string CustomerName { get; set; }

        [Required,StringLength(255)]

        public string PasswordHash { get; set; }
    }
}
