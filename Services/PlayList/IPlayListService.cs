using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tam.webapp.Services.PlayList
{
    public interface IPlayListService
    {
        Models.PlayList GetPlayListById(long? id);

        Task<Models.PlayList> GetPlayListByIdAsync(long? id);

        List<Models.PlayList> GetPlayListsByUserId(long? userId);

        Task<List<Models.PlayList>> GetPlayListsByUserIdAsync(long? userId);

        Task AddPlayListByUserId(long? userId, Models.PlayList playList);

        Task UpdatePlayList(Models.PlayList playList);

        Task RemovePlaylistAsync(Models.PlayList playList);
        bool PlayListExist(long id);
    }
}