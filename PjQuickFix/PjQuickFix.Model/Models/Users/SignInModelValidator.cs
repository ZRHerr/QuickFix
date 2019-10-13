using DotNetCore.Validation;
using FluentValidation;
using PjQuickFix.CrossCutting.Resources;

namespace PjQuickFix.Model
{
    public sealed class SignInModelValidator : Validator<SignInModel>
    {
        public SignInModelValidator()
        {
            WithMessage(Texts.LoginPasswordInvalid);
            RuleFor(x => x.Login).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
