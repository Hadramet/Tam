using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tam.webapp.Models;
using Tam.webapp.Repositories.PlayLists;
using Tam.webapp.Repositories.Track;
using Tam.webapp.Repositories.TrackPlayList;

namespace Tam.webapp.Services.Track
{
    public class TrackService : ITrackService
    {
        private readonly IPlayListsRepository _playLists;
        private readonly ITrackRepository _track;
        private readonly ITrackPlayListRepository _trackPlayList;

        public TrackService(ITrackRepository track, IPlayListsRepository playLists,
            ITrackPlayListRepository trackPlayList)
        {
            _track = track;
            _playLists = playLists;
            _trackPlayList = trackPlayList;
        }

        public async Task<List<Models.Track>> GetTracksByPlaylistId(long? playlistId)
        {
            if (playlistId == null)
                throw new ArgumentNullException($"Invalid playlist id");

            var trackPlayLists = _trackPlayList.GeTrackPlayLists(playlistId).ToList();
            var track = await Task.Run(() =>
                trackPlayLists.Select(item => _track.GetTrack(item.TrackId)).ToList());
            track = track.OrderByDescending(s => s.AddedDate).ToList();

            return track;
        }

        public async Task<Models.Track> GetTracksByIdAsync(long? id)
        {
            return await _track.GetTrackAsync(id);
        }

        public async Task AddTrackByPlaylistIdAsync(Models.Track track, long playlistId)
        {
            await _track.AddTrackAsync(track);

            var currentPlayList = await _playLists.GetPlayLists().FirstOrDefaultAsync(p => p.Id == playlistId);

            var trackPlayList = new TrackPlayList {Track = track, PlayList = currentPlayList};

            await _trackPlayList.AddAsync(trackPlayList);
        }

        public async Task UpdateTrack(Models.Track track)
        {
            await _track.UpdateAsync(track);
        }

        public async Task RemoveTrack(Models.Track track)
        {
            await _track.DeleteAsync(track);
        }
    }
}