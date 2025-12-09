
namespace ST10451194_PROG6212_POE.Models // Defining the namespace for the project models
{
    // Defining a view model class named DeleteUserViewModel
    // This class is specifically created to store and transfer data related to user deletion
    // It is commonly used to confirm and carry the information needed to delete a user in the application
    public class DeleteUserViewModel
    {
        // Property to store the unique identifier of the user to be deleted
        // This ID is typically a primary key in the database, often represented as a GUID or string identifier
        // Used to precisely identify which user to delete
        public string Id { get; set; }

        // Property to store the email address of the user to be deleted
        // Email is generally used as a secondary identifier, providing a human-readable form of user identification
        // This property can be displayed to confirm that the correct user is being deleted
        public string Email { get; set; }
    }
}

