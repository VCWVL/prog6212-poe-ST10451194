
//Import List
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ST10451194_PROG6212_POE.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ST10451194_PROG6212_POE.Controllers
{//namespace begin

    //Using Micrisoft Idenitity with Roles - This line means that only users with the "Academic Manager" role can access the actions in this controller.
    [Authorize(Roles = "Academic Manager")]
    public class AcademicManagerController : Controller
    {//AcademicManager Controller begin

        //private fields declaration - used throughout controller
        private readonly Prog6212DbContext _context;

        //constructor - - initializes the private fields with the values passed in, allowing the controller to use them for database access
        public AcademicManagerController(Prog6212DbContext context)
        {
            _context = context;
        }

        //This method is responsible for displaying a list of claims pending approval from the manager.
        public IActionResult Index()
        {
            // Only show claims that are approved by the coordinator but pending manager approval
            var pendingClaims = _context.Claims
                .Include(c => c.ApplicationUser) // Include the ApplicationUser
                .Include(c => c.Documents) // Include the Documents
                .Where(c => c.IsApprovedByCoordinator && !c.IsApprovedByManager && c.Status == "Approved by Coordinator") //These are the conditions for claims that can be vuewd by the manager
                .ToList();
            //returns the pendingClaims list to the view, which will display it to the user.
            return View(pendingClaims);
        }

        //This method processes the approval of a claim when a POST request is made - when Approve button is clicked - takes an integer parameter representing the ID of the claim to be approved.
        [HttpPost]
        public async Task<IActionResult> Approve(int claimId)
        {
            //This line retrieves the claim from the database using the provided claimId
            var claim = await _context.Claims.FindAsync(claimId);

            // checks if the claim exists
            if (claim != null)
            {
                //if the claim exisists it set the boolean variable IsApprovedByManager to true, indicating it has been approved by the manager.
                claim.IsApprovedByManager = true;
                //The status of the claim is updated to reflect this approval.
                claim.Status = "Approved by Manager";
                //The status of the Payment is updated to Processing so that HR can process payment
                claim.PaymentStatus = "Processing";
                //This saves the changes made to the claim in the database asynchronously.
                await _context.SaveChangesAsync();
            }
            //After processing the approval, the user is redirected back to the Index action to see the updated list of claims.
            return RedirectToAction("Index");
        }

        //This method processes the rejection of a claim. Similar to the Approve method, it takes the ID of the claim to be rejected
        [HttpPost]
        public async Task<IActionResult> Reject(int claimId)
        {
            // It attempts to find the claim in the database using the claimId.
            var claim = await _context.Claims.FindAsync(claimId);

            //checks if the claim was found
            if (claim != null)
            {
                //If the claim exists, the status is updated to indicate that it has been rejected.
                claim.Status = "Rejected by Manager";
                //The changes are saved to the database
                await _context.SaveChangesAsync();
            }

            //the user is redirected to the Index action to see the updated list of claims.
            return RedirectToAction("Index");
        }
    }////AcademicManager Controller end
}//namespace end
