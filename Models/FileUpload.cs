using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PROG_POE.Models
{
    public class FileUpload
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FileName { get; set; } = string.Empty;

        [Required]
        public string FilePath { get; set; } = string.Empty;

        // Foreign key
        public int ClaimId { get; set; }
        [ForeignKey("ClaimId")]
        public Claim? Claim { get; set; }
    }
}
