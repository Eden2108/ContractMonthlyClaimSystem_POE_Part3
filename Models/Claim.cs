using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContractMonthlyClaimSystem.Models
{
    public class Claim
    {
        [Key]
        [Column("claimID")]
        public int ClaimID { get; set; }

        // NEW FIELDS YOU ADDED
        [Column("number_of_sessions")]
        public int NumberOfSessions { get; set; }

        [Column("number_of_hours")]
        public int NumberOfHours { get; set; }

        [Column("amount_of_rate", TypeName = "decimal(18,2)")]
        public decimal HourlyRate { get; set; }

        [Column("total_amount", TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        [MaxLength(150)]
        [Column("module_name")]
        public string ModuleName { get; set; }

        [MaxLength(150)]
        [Column("faculty_name")]
        public string FacultyName { get; set; }

        [MaxLength(250)]
        [Column("supporting_documents")]
        public string SupportingDocuments { get; set; }

        [MaxLength(50)]
        [Column("claim_status")]
        public string ClaimStatus { get; set; }

        [Column("creating_date")]
        public DateTime CreatingDate { get; set; }


        [Column("lecturerID")]
        public int LecturerID { get; set; }

        public User Lecturer { get; set; }

        [MaxLength(150)]
        [Column("lecturer_name")]
        public string LecturerName { get; set; }
    }
}
