using DotNetCore.Repositories;
using PjQuickFix.Domain;
using PjQuickFix.Model;
using System.Threading.Tasks;

namespace PjQuickFix.Database.User
{
    public interface IUserRepository : IRelationalRepository<UserEntity>
    {
        Task<SignedInModel> SignInAsync(SignInModel signInModel);

        Task UpdateStatusAsync(UserEntity userEntity);
    }
}

