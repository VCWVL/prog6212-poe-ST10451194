using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PROG_POE.Models
{
    public class Claim
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public double HoursWorked { get; set; }

        [Required]
        public double HourlyRate { get; set; }

        [Required]
        public double TotalAmount => HoursWorked * HourlyRate;

        public string? Status { get; set; } = "Pending"; // Pending, Approved, Rejected

        // Date
        public DateTime SubmittedDate { get; set; } = DateTime.Now;

        // Foreign key
        public int LecturerId { get; set; }
        [ForeignKey("LecturerId")]
        public Lecturer? Lecturer { get; set; }

        // Navigation property
        public ICollection<FileUpload>? Files { get; set; }
    }
}
