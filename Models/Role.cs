namespace PROG_POE.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string RoleName { get; set; } = string.Empty;

        // Navigation property
        public ICollection<Lecturer>? Lecturers { get; set; }
    }
}
