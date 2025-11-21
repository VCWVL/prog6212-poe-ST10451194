using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace PROG_POE.Models
{

    public class AcademicManager
    {
        [Key]
        public int ManagerId { get; set; }

        [Required, MaxLength(100)]
        public string? Name { get; set; }

        // Navigation: Manager approves claims
        public ICollection<Claim> ClaimsToApprove { get; set; } = new List<Claim>();
    }
}
