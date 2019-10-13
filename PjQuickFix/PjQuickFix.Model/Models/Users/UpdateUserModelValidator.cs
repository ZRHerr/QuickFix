using FluentValidation;

namespace PjQuickFix.Model.Models
{
    public sealed class UpdateUserModelValidator : UserModelValidator<UpdateUserModel>
    {
        public UpdateUserModelValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
