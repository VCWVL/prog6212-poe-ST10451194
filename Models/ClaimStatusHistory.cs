using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PROG_POE.Models
{
    public class ClaimStatusHistory
    {
        [Key]
        public int Id { get; set; }

        public string Status { get; set; } = string.Empty; // Pending, Approved, Rejected

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Foreign key
        public int ClaimId { get; set; }
        [ForeignKey("ClaimId")]
        public Claim? Claim { get; set; }
    }

}
