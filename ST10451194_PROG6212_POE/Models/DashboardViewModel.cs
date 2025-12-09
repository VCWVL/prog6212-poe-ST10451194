
namespace ST10451194_PROG6212_POE.Models // Defines the namespace where the DashboardViewModel class resides
{
    // The DashboardViewModel class is used to represent the data that will be displayed on the dashboard
    // This class contains properties to hold the summary information related to claims and payments
    public class DashboardViewModel
    {
        // The TotalClaims property represents the total number of claims in the system.
        // This is typically used to show the overall number of claims submitted, regardless of their status.
        public int TotalClaims { get; set; }

        // The PendingClaims property holds the number of claims that are currently pending approval or processing.
        // This value is important to track the claims that are still under review or need further action.
        public int PendingClaims { get; set; }

        // The ApprovedClaims property represents the number of claims that have been approved.
        // This value shows how many claims have been processed successfully and approved for payment or other actions.
        public int ApprovedClaims { get; set; }

        // The TotalPayments property holds the total amount of money allocated for all claims.
        // This is a summary of all payments associated with claims that have been processed, regardless of their payment status.
        public decimal TotalPayments { get; set; }

        // The PendingPayments property holds the total amount of money that has been allocated to claims but is still pending payment.
        // This helps track the claims that have been approved but have not yet been paid.
        public decimal PendingPayments { get; set; }

        // The CompletedPayments property holds the total amount of money that has been successfully paid out for claims.
        // This represents the total value of claims that have been processed and fully paid.
        public decimal CompletedPayments { get; set; }
    }
}
