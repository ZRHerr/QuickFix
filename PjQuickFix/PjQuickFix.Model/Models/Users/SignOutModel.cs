namespace PjQuickFix.Model.Models
{
    public class SignOutModel
    {
        public SignOutModel(long userId)
        {
            UserId = userId;
        }

        public long UserId { get; }
    }
}
