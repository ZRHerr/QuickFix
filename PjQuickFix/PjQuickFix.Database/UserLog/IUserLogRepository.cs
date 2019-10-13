using DotNetCore.Repositories;
using PjQuickFix.Domain;

namespace PjQuickFix.Database
{
    public interface IUserLogRepository : IRelationalRepository<UserLogEntity> { }
}
