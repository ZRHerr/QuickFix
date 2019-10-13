using DotNetCore.EntityFrameworkCore;
using PjQuickFix.Domain;

namespace PjQuickFix.Database
{
    public sealed class UserLogRepository : EntityFrameworkCoreRelationalRepository<UserLogEntity>, IUserLogRepository
    {
        public UserLogRepository(Context context) : base(context)
        {
        }
    }
}
