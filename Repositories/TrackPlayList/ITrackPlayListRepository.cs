using System.Linq;
using System.Threading.Tasks;

namespace Tam.webapp.Repositories.TrackPlayList

{
    public interface ITrackPlayListRepository
    {
        IQueryable<Models.TrackPlayList> GeTrackPlayLists(long? playListId);
        Task AddAsync(Models.TrackPlayList trackPlayList);
    }
}