using System.ComponentModel.DataAnnotations;

namespace PROG_POE.Models
{
    public class FileUpload
    {
        [Key]
        public int FileId { get; set; }

        [Required]
        public int ClaimId { get; set; }
        public Claim Claim { get; set; }

        [Required]
        public string? FileName { get; set; }

        [Required]
        public string? FilePath { get; set; } // encrypted storage path

        public DateTime UploadedOn { get; set; } = DateTime.Now;
    }
}
