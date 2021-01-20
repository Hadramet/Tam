using System.Linq;
using Tam.webapp.Db;

namespace Tam.webapp.Repositories.Track
{
    public interface ITrackRepository
    {
        Models.Track Get(long id);
        IQueryable<Models.Track> GetAllTracks(int? count = null, int? page = null);
    }
    public class TrackRepository : ITrackRepository
    {
        private readonly TamDbContext _dbContext;

        public TrackRepository(TamDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Models.Track Get(long id)
        {
           return _dbContext.Tracks.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Models.Track> GetAllTracks(int? count = null, int? page = null)
        {
            throw new System.NotImplementedException();
        }
    }
}
