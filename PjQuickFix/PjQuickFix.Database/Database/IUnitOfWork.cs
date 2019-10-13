using System.Threading.Tasks;

namespace PjQuickFix.Database
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
