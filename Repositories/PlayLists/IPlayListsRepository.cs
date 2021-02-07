using System.Linq;
using System.Threading.Tasks;
using Tam.webapp.Models;

namespace Tam.webapp.Repositories.PlayLists
{
    public interface IPlayListsRepository
    {
        IQueryable<PlayList> GetPlayLists();

        void AddPlaylist(PlayList playList);
        Task AddPlaylistAsync(PlayList playList);

        void UpdatePlaylist(PlayList playList);
        Task UpdatePlaylistAsync(PlayList playList);

        void DeletePlaylist(PlayList playList);
        Task DeletePlaylistAsync(PlayList playList);
        
    }
}