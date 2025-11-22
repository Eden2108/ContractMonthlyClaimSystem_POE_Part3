using System;
using System.ComponentModel.DataAnnotations;

namespace ContractMonthlyClaimSystem.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [MaxLength(150)]
        public string? FullNames { get; set; }

        [MaxLength(150)]
        public string Surname { get; set; } = string.Empty;

        [MaxLength(150)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Role { get; set; } = string.Empty; // Lecturer, Coordinator, Manager, HR

        public string Gender { get; set; } = string.Empty;

        [MaxLength(150)]
        public string Password { get; set; } = string.Empty;

        public DateTime Date { get; set; }
    }
}
