
//Import List

using System.ComponentModel.DataAnnotations.Schema; // Importing the namespace for attributes related to database mapping, such as ForeignKey
using System.ComponentModel.DataAnnotations; // Importing the namespace for data annotations used for validation

namespace ST10451194_PROG6212_POE.Models // Defining the namespace for the models used in the project
{
    // Defining a class named Document
    // This class represents a document associated with a claim
    public class Document
    {
        // Property to uniquely identify each document in the database
        public int DocumentId { get; set; } // Auto-implemented property for storing the document's unique identifier

        // Property to store the name of the document
        // The Required attribute ensures that this field must be filled out
        [Required(ErrorMessage = "Document Name is required.")] // Custom error message to display if validation fails
        [MaxLength(255)] // Specifies that the maximum length for the document name is 255 characters
        public string DocumentName { get; set; } // String property for storing the name of the document

        // Property to store the file path of the uploaded document
        // The Required attribute ensures that this field must be filled out
        [Required(ErrorMessage = "File Path is required.")] // Custom error message to display if validation fails
        public string FilePath { get; set; } // String property for storing the file path of the document

        // Property to store the date and time when the document was uploaded
        [Required] // The Required attribute ensures that this field must be filled out
        public DateTime UploadedOn { get; set; } // DateTime property for storing the timestamp of when the document was uploaded

        // Property to establish a relationship between the Document and Claim classes
        [ForeignKey("Claim")] // This attribute indicates that the ClaimId property is a foreign key referencing the Claim table
        public int ClaimId { get; set; } // Integer property for storing the ID of the associated claim

        // Navigation property to represent the relationship between Document and Claim
        public virtual Claim Claim { get; set; } // Virtual property for accessing the related Claim object, allowing Entity Framework to load it automatically
    }
}
