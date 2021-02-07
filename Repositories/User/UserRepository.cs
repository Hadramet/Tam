using System.Linq;
using Tam.webapp.Db;

namespace Tam.webapp.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly TamDbContext _context;

        public UserRepository(TamDbContext context)
        {
            _context = context;
        }
        public IQueryable<Models.User> GetUsers()
        {
            return _context.Users;
        }

        public Models.User Get(long? id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }
    }
}