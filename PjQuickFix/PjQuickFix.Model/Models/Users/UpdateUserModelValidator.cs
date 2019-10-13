using FluentValidation;

namespace PjQuickFix.Model
{
    public sealed class UpdateUserModelValidator : UserModelValidator<UpdateUserModel>
    {
        public UpdateUserModelValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
