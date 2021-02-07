using System.Linq;

namespace Tam.webapp.Repositories.User
{
    public interface IUserRepository
    {
        IQueryable<Models.User> GetUsers();
        Models.User Get(long? id);
    }
}