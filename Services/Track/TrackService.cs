using System;
using Tam.webapp.Repositories.Track;

namespace Tam.webapp.Services.Track
{
    public interface ITrackService
    {
        Models.Track Find(long id);
    }

    public class TrackService : ITrackService
    {
        private readonly ITrackRepository _trackRepository;

        public TrackService(ITrackRepository trackRepository)
        {
            _trackRepository = trackRepository;
        }

        public Models.Track Find(long id)
        {
            var track = _trackRepository.Get(id);
            if (track == null) throw new ArgumentNullException();
            return track;
        }
    }
}
