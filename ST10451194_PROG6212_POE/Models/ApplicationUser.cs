
//Import List

using Microsoft.AspNetCore.Identity; // Importing the ASP.NET Core Identity namespace for user authentication and management

namespace ST10451194_PROG6212_POE.Models // Defining a namespace for the project models
{
    // Defining a class ApplicationUser that extends the IdentityUser class provided by ASP.NET Core Identity
    public class ApplicationUser : IdentityUser
    {
        // Property to store the user's first name
        public string Firstname { get; set; } // Represents the user's first name

        // Property to store the user's last name
        public string Lastname { get; set; } // Represents the user's last name

        //Property to store the users faculty they belong to
        public string Faculty { get; set; }

        public string IDNumber { get; set; } //New Proptery for ID Number

        public string HomeAddress { get; set; } //New Property for HomeAdress

        // Navigation property to establish a one-to-many relationship with the Claim class
        // This property will hold a collection of claims associated with this user
        public virtual ICollection<Claim> Claims { get; set; } // Represents the list of claims linked to the user
    }
}
