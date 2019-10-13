using Microsoft.AspNetCore.Identity;
using PjQuickFix.Model.Models;
using System.Collections.Generic;

namespace PjQuickFix.Domain
{
    public class UserEntity : IdentityUser
    {
        public UserEntity
        (
            long userId,
            FullName fullName,
            SignIn signIn,
            Roles roles,
            Status status
        )
        {
            UserId = userId;
            FullName = fullName;
            SignIn = signIn;
            Roles = roles;
            Status = status;
        }

        public UserEntity(long userId)
        {
            UserId = userId;
        }

        public long UserId { get; private set; }

        public FullName FullName { get; private set; }

        public SignIn SignIn { get; private set; }

        public Roles Roles { get; private set; }

        public Status Status { get; private set; }

        public ICollection<UserLogEntity> UsersLogs { get; private set; }

        public void Add()
        {
            Roles = Roles.User;
            Status = Status.Active;
        }

        public void ChangeFullName(string name, string surname)
        {
            FullName = new FullName(name, surname);
        }

        public void Inactivate()
        {
            Status = Status.Inactive;
        }
    }
}
