using System.Threading.Tasks;

namespace Tam.webapp.Repositories.Track
{
    public interface ITrackRepository
    {
        Models.Track GetTrack(long? id);
        Task<Models.Track> GetTrackAsync(long? id);
        Task AddTrackAsync(Models.Track track);
        Task UpdateAsync(Models.Track track);
        Task DeleteAsync(Models.Track track);
    }
}