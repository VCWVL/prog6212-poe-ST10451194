
using System; // Importing the System namespace for fundamental classes, such as DateTime
using System.Collections.Generic; // Importing the namespace for handling generic collections, like List

namespace ST10451194_PROG6212_POE.Models // Defining the namespace for the project's model classes
{
    // Defining a view model class named GenerateReportViewModel
    // This view model is designed to facilitate the generation and management of reports within the application
    // It is used to pass data between the controller and the view, specifically for generating reports based on specified criteria
    public class GenerateReportViewModel
    {
        // Property to store the name of the report
        // Allows the user to provide a custom name for the report they want to generate
        public string ReportName { get; set; }

        // Property to store the start date for the report data range
        // This defines the earliest date for data inclusion in the report, providing a way to filter the report by date range
        public DateTime StartDate { get; set; }

        // Property to store the end date for the report data range
        // This defines the latest date for data inclusion in the report, working with the StartDate to limit report data to a specific time frame
        public DateTime EndDate { get; set; }

        // Property to specify the type of report to be generated
        // Allows selection between different report formats or data types (e.g., summary report, detailed report, etc.)
        public string ReportType { get; set; }

        // Property to store a list of existing reports that have already been generated
        // The list provides an option to display existing reports in the view, allowing users to access previously generated reports
        // By initializing it as a new List<Report>, the list is ready to be populated without needing additional setup
        public List<Report> ExistingReports { get; set; } = new List<Report>();
    }
}
