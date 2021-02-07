using System.Linq;
using System.Threading.Tasks;
using Tam.webapp.Db;

namespace Tam.webapp.Repositories.TrackPlayList
{
    public class TrackPlayListRepository : ITrackPlayListRepository
    {
        private readonly TamDbContext _context;

        public TrackPlayListRepository(TamDbContext context)
        {
            _context = context;
        }

        public IQueryable<Models.TrackPlayList> GeTrackPlayLists(long? playListId)
        {
            return _context.TrackPlayLists.Where(t => t.PlayListId == playListId);
        }

        public async Task AddAsync(Models.TrackPlayList trackPlayList)
        {
            await _context.AddAsync(trackPlayList);
            await _context.SaveChangesAsync();
        }
    }
}