using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace PROG_POE.Models
{
    public class Lecturer
    {
        [Key]
        public int LecturerId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        // Navigation: Lecturer can submit multiple claims
        public ICollection<Claim> Claims { get; set; } = new List<Claim>();
    }
}
