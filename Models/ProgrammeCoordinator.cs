using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace PROG_POE.Models
{
    public class ProgrammeCoordinator
    {
        [Key]
        public int CoordinatorId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        // Navigation: Coordinator verifies claims
        public ICollection<Claim> ClaimsToVerify { get; set; } = new List<Claim>();
    }
}
