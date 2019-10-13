using PjQuickFix.Model.Models;
using System.Threading.Tasks;
using PjQuickFix.Database;
using PjQuickFix.Domain;

namespace PjQuickFix.Application
{
    public sealed class UserLogApplicationService : IUserLogApplicationService
    {
        public UserLogApplicationService(IUserLogRepository userLogRepository)
        {
            UserLogRepository = userLogRepository;
        }

        private IUserLogRepository UserLogRepository { get; }

        public async Task AddAsync(UserLogModel userLogModel)
        {
            var userLogEntity = UserLogEntityFactory.Create(userLogModel);

            await UserLogRepository.AddAsync(userLogEntity);
        }
    }
}
