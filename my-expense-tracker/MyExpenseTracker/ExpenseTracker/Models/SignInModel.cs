namespace ExpenseTracker.Models
{
    public class SignInModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
