using DotNetCore.Objects;
using PjQuickFix.Model.Models;

namespace PjQuickFix.Infrastructure
{
    public interface ISignInService
    {
        SignInModel CreateSignIn(SignInModel signInModel);

        TokenModel CreateToken(SignedInModel signedInModel);

        IResult Validate(SignedInModel signedInModel, SignInModel signInModel);
    }
}
