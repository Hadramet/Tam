using System.Collections.Generic;
using System.Linq;
using Tam.webapp.Models;

namespace Tam.webapp.Repositories.PlayLists
{
    public interface IPlayListsRepository
    {

        void Add(PlayList playlist);

        PlayList Get(long id);

        PlayList GetPlayListTracks(long id);

        IQueryable<PlayList> GetAll(int? count = null, int? page = null);
        void Update(long id, PlayList playList);
        void Remove(long id);
    
    }
}
