using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace PjQuickFix.Model.Models
{
    public class AddUserModel : UserModel
    {
        public SignInModel SignIn { get; set; }
    }
}
