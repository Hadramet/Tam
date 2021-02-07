using System.Linq;
using System.Threading.Tasks;

namespace Tam.webapp.Repositories.UserPlayList
{
    public interface IUserPlayListRepository
    {
        IQueryable<Models.UserPlayList> GetUserPlayLists(long? userId);
        void AddUserPlayList(Models.UserPlayList userPlayList);
        Task AddUserPlayListAsync(Models.UserPlayList userPlayList);
    }
}