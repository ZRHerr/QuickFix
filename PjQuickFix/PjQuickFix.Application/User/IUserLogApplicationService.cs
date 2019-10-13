using PjQuickFix.Model.Models;
using System.Threading.Tasks;

namespace PjQuickFix.Application
{
    public interface IUserLogApplicationService
    {
        Task AddAsync(UserLogModel userLogModel);
    }
}