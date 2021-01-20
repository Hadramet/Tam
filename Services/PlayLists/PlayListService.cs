using System;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using Tam.webapp.Models;
using Tam.webapp.Repositories.PlayLists;

namespace Tam.webapp.Services.PlayLists
{
    
    public class PlayListService : IPlayListsService
    {

        private readonly IPlayListsRepository _playListsRepository;

        public PlayListService(IPlayListsRepository playListsRepository)
        {
            _playListsRepository = playListsRepository;
        }

        public PlayList GetPlayList(long id)
        {
            return _playListsRepository.Get(id);
        }

        public IEnumerable<PlayList> GetAllPlayList ()
        {
            var result = _playListsRepository.GetAll().ToList();
            if (result == null) throw new ArgumentNullException();
            return result;
        }

        
    }
}
