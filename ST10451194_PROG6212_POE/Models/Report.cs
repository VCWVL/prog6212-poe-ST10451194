
using System.ComponentModel.DataAnnotations; // Importing the namespace for data annotations, which provide validation and formatting for model properties

namespace ST10451194_PROG6212_POE.Models // Defining the namespace for model classes specific to the project
{
    // Defining a class named Report
    // The Report class represents a report record in the application, capturing details like name, type, date range, and file path
    public class Report
    {
        // Property to hold the unique identifier for each report
        // ReportId is an integer serving as the primary key for the Report class
        public int ReportId { get; set; }

        // Property to store the name of the report
        // [Required] ensures that ReportName must have a value; it cannot be null or empty
        // [StringLength(100)] enforces a maximum character limit of 100 for the ReportName to prevent overly long names
        [Required(ErrorMessage = "Report Name is required.")]
        [StringLength(100, ErrorMessage = "Report Name cannot exceed 100 characters.")]
        public string ReportName { get; set; }

        // Property to store the type or category of the report
        // [Required] enforces that ReportType must be provided, enhancing data completeness
        // [StringLength(50)] limits the length to 50 characters, ensuring the type is concise
        [Required(ErrorMessage = "Report Type is required.")]
        [StringLength(50, ErrorMessage = "Report Type cannot exceed 50 characters.")]
        public string ReportType { get; set; }

        // Property to specify the start date for the report
        // [Required] ensures a start date is specified, which is essential for date range validation and report accuracy
        [Required(ErrorMessage = "Start Date is required.")]
        public DateTime StartDate { get; set; }

        // Property to specify the end date for the report
        // [Required] enforces that an end date must be provided, forming a valid date range
        // [DateGreaterThan("StartDate")] custom attribute checks that EndDate is after StartDate to ensure logical date order
        [Required(ErrorMessage = "End Date is required.")]
        [DateGreaterThan("StartDate", ErrorMessage = "End Date must be after Start Date.")]
        public DateTime EndDate { get; set; }

        // Property to store the file path of the report document
        // [Required] ensures FilePath is always provided, guaranteeing access to the report document
        // [StringLength(200)] restricts the file path length to a maximum of 200 characters for manageable path length
        // [RegularExpression] validates that the FilePath ends with a specific file extension (.pdf, .docx, or .xlsx), ensuring file type consistency
        [Required(ErrorMessage = "File Path is required.")]
        [StringLength(200, ErrorMessage = "File Path cannot exceed 200 characters.")]
        [RegularExpression(@"^.*\.(pdf|docx|xlsx)$", ErrorMessage = "File Path must be a .pdf, .docx, or .xlsx file.")]
        public string FilePath { get; set; }
    }
}
