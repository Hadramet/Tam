using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tam.webapp.Db;

namespace Tam.webapp.Repositories.Track
{
    public class TrackRepository : ITrackRepository
    {
        private readonly TamDbContext _context;

        public TrackRepository(TamDbContext context)
        {
            _context = context;
        }

        public Models.Track GetTrack(long? trackId)
        {
            return _context.Tracks.FirstOrDefault(t => t.Id == trackId);
        }

        public Task<Models.Track> GetTrackAsync(long? id)
        {
            return _context.Tracks.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddTrackAsync(Models.Track track)
        {
            await _context.Tracks.AddAsync(track);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Models.Track track)
        {
            _context.Tracks.Update(track);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Models.Track track)
        {
            _context.Tracks.Remove(track);
            await _context.SaveChangesAsync();
        }
    }
}