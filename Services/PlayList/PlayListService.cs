using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tam.webapp.Models;
using Tam.webapp.Repositories.PlayLists;
using Tam.webapp.Repositories.TrackPlayList;
using Tam.webapp.Repositories.User;
using Tam.webapp.Repositories.UserPlayList;

namespace Tam.webapp.Services.PlayList
{
    public class PlayListService : IPlayListService
    {
        private readonly IPlayListsRepository _playLists;
        private readonly IUserPlayListRepository _userPlayList;
        private readonly ITrackPlayListRepository _trackPlayList;
        private readonly IUserRepository _user;

        public PlayListService
        (
            IPlayListsRepository playLists , 
            IUserPlayListRepository userPlayList ,
            ITrackPlayListRepository trackPlayList,
            IUserRepository user
        )
        {
            _playLists = playLists;
            _userPlayList = userPlayList;
            _trackPlayList = trackPlayList;
            _user = user;
        }

        public Models.PlayList GetPlayListById(long? id)
        {
            if (id == null) 
                throw new ArgumentNullException(paramName: $" Invalid PlayList id ");
            return _playLists.GetPlayLists().FirstOrDefault(predicate: m => m.Id == id);
        }

        public Task<Models.PlayList> GetPlayListByIdAsync(long? id)
        {
            if (id == null) 
                throw new ArgumentNullException($"Invalid PlayList id ");
            return Task.Run(() => GetPlayListById(id));
        }

        public List<Models.PlayList> GetPlayListsByUserId(long? userId)
        {
            var userPlayList = _userPlayList.GetUserPlayLists(userId);
            var playList = new List<Models.PlayList> ();

            //Populating
            foreach (var item in userPlayList)
            {
                var current = GetPlayListById(item.PlayListId);
                current.Quantity = _trackPlayList.GeTrackPlayLists(item.PlayListId).Count();
                playList.Add(current);
            }

            return playList;
        }

        public Task<List<Models.PlayList>> GetPlayListsByUserIdAsync(long? userId)
        {
            return  Task.Run(() => GetPlayListsByUserId(userId));
        }

        public async Task AddPlayListByUserId(long? userId, Models.PlayList playList)
        {
            if (playList == null)
                throw new ArgumentNullException($"Invalid playlist");

            var user = _user.Get(userId);

            var userPlaylist = new UserPlayList
            {
                PlayList = playList,

                User = user
            };

            await _playLists.AddPlaylistAsync(playList);

            await _userPlayList.AddUserPlayListAsync(userPlaylist);
        }

        public async Task UpdatePlayList(Models.PlayList playList)
        {
            if (playList == null)
                throw new ArgumentNullException($"Invalid playlist");
            await _playLists.UpdatePlaylistAsync(playList);
        }

        public async Task RemovePlaylistAsync(Models.PlayList playList)
        {
            if (playList == null)
                throw new ArgumentNullException($"Invalid playlist");
            await _playLists.DeletePlaylistAsync(playList);
        }

        public bool PlayListExist(long id)
        {
            return _playLists.GetPlayLists().Any(p => p.Id == id) ;
        }
    }
}