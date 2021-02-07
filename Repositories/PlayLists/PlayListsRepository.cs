using System.Linq;
using System.Threading.Tasks;
using Tam.webapp.Db;
using Tam.webapp.Models;

namespace Tam.webapp.Repositories.PlayLists
{
    public class PlayListsRepository : IPlayListsRepository
    {
        private readonly TamDbContext _context;

        public PlayListsRepository(TamDbContext context)
        {
            _context = context;
        }
        public IQueryable<PlayList> GetPlayLists()
        {
            return _context.PlayLists;
        }

        public void AddPlaylist(PlayList playList)
        {
            _context.Add(playList);
            _context.SaveChanges();
        }

        public async Task AddPlaylistAsync(PlayList playList)
        {
            _context.Add(playList);
            await _context.SaveChangesAsync();
        }

        public void UpdatePlaylist(PlayList playList)
        {
            _context.Update(playList);
            _context.SaveChanges();
        }

        public async Task UpdatePlaylistAsync(PlayList playList)
        {
            _context.Update(playList);
            await _context.SaveChangesAsync();
        }

        public void DeletePlaylist(PlayList playList)
        {
            _context.Remove(playList);
            _context.SaveChanges();
        }

        public async Task DeletePlaylistAsync(PlayList playList)
        {
            _context.Remove(playList);
            await _context.SaveChangesAsync();
        }
    }
}