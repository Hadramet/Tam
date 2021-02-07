using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tam.webapp.Services.Track
{
    public interface ITrackService
    {
        Task<List<Models.Track>> GetTracksByPlaylistId(long? playlistId);
        Task<Models.Track> GetTracksByIdAsync(long? id);
        Task AddTrackByPlaylistIdAsync(Models.Track track, long playlistId);
        Task UpdateTrack(Models.Track track);
        Task RemoveTrack(Models.Track track);
    }
}