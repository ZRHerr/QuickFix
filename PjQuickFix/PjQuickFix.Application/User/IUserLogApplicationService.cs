using PjQuickFix.Model;
using System.Threading.Tasks;

namespace PjQuickFix.Application
{
    public interface IUserLogApplicationService
    {
        Task AddAsync(UserLogModel userLogModel);
    }
}