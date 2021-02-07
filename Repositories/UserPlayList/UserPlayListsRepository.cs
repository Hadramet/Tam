using System.Linq;
using System.Threading.Tasks;
using Tam.webapp.Db;

namespace Tam.webapp.Repositories.UserPlayList
{
    public class UserPlayListsRepository : IUserPlayListRepository
    {
        private readonly TamDbContext _context;

        public UserPlayListsRepository(TamDbContext context)
        {
            _context = context;
        }
        public IQueryable<Models.UserPlayList> GetUserPlayLists(long? userId)
        {
            return _context.UserPlayLists.Where(u => u.UserId == userId);
        }

        public void AddUserPlayList(Models.UserPlayList userPlayList)
        {
            _context.Add(userPlayList);
            _context.SaveChanges();
        }

        public async Task AddUserPlayListAsync(Models.UserPlayList userPlayList)
        {
            _context.Add(userPlayList);
            await _context.SaveChangesAsync();
        }
    }
}