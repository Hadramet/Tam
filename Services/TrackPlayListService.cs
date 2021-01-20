using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tam.webapp.Models;
using Tam.webapp.Repositories.PlayLists;
using Tam.webapp.Repositories.Track;

namespace Tam.webapp.Services
{
    public interface ITrackPlayListService
    {
        List<Models.Track> GetPlayListTracks(long playListId);
    }
    public class TrackPlayListService : ITrackPlayListService
    {
        private readonly ITrackRepository _trackRepository;
        private readonly IPlayListsRepository _playListsRepository;

        public TrackPlayListService(ITrackRepository trackRepository , IPlayListsRepository playListsRepository)
        {
            _trackRepository = trackRepository;
            _playListsRepository = playListsRepository;
        }
        public List<Models.Track> GetPlayListTracks(long playListId)
        {
            return _playListsRepository
                .GetPlayListTracks(playListId)
                .TrackPlayLists
                .Select(playlistTrackPlayList =>
                    playlistTrackPlayList.Track = _trackRepository.Get(playlistTrackPlayList.TrackId))
                .ToList();
        }
    }
}
