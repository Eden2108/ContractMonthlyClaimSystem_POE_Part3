using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContractMonthlyClaimSystem.Models
{
    public class ClaimHistory
    {
        [Key]
        public int HistoryId { get; set; }

        public int ClaimId { get; set; }
        [ForeignKey("ClaimId")]
        public Claim? Claim { get; set; } // Made nullable

        public int UpdatedById { get; set; }
        [ForeignKey("UpdatedById")]
        public User? UpdatedBy { get; set; } // Made nullable

        [Required, StringLength(50)]
        public string OldStatus { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string NewStatus { get; set; } = string.Empty;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [MaxLength(250)]
        public string Remarks { get; set; } = string.Empty;
    }
}
