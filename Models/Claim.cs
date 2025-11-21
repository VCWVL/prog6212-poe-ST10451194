using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROG_POE.Models
{
    public class Claim
    {
        [Key]
        public int ClaimId { get; set; }

        [Required]
        public int LecturerId { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(0, double.MaxValue)]
        public double HoursWorked { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double HourlyRate { get; set; }

        [NotMapped]
        public double Amount => HoursWorked * HourlyRate;

        public string? FileName { get; set; }
        public string? FilePath { get; set; }

        public ClaimStatus Status { get; set; } = ClaimStatus.Pending;

        public string? CoordinatorComment { get; set; }
        public string? ManagerComment { get; set; }

        [NotMapped]
        public IFormFile? Upload { get; set; }
    }
}
