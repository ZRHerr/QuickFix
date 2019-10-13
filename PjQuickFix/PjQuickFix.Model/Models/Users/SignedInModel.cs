namespace PjQuickFix.Model.Models
{
    public class SignedInModel
    {
        public long UserId { get; set; }

        public Roles Roles { get; set; }

        public SignInModel SignIn { get; set; }
    }
}