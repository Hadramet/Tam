using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Tam.webapp.Db;
using Tam.webapp.Models;

namespace Tam.webapp.Repositories.PlayLists
{

    public  class PlayListsRepository : IPlayListsRepository
    {
        private readonly TamDbContext _dbContext;

        public PlayListsRepository(TamDbContext dbContext)
        {
            this._dbContext = dbContext;
        }        

        public PlayList Get(long id)
        {
            return _dbContext.PlayLists.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<PlayList> GetAll(int? count=null, int? page = null)
        {
            var actualCount = count.GetValueOrDefault(10);

            return _dbContext.PlayLists
                .Skip(actualCount * page.GetValueOrDefault(0))
                .Take(actualCount);
        }

        public void Add(PlayList entity)
        {

            var playlist = _dbContext.PlayLists
                .Add(new PlayList
            {
                PlayListName = entity.PlayListName,                
                CreatedDate = DateTime.UtcNow,
            });

            _dbContext.SaveChanges();
        }

        public void Update(long id, PlayList playList)
        {
            throw new NotImplementedException();
        }

        public void Remove(long id)
        {
            throw new NotImplementedException();
        }

        public PlayList GetPlayListTracks(long id)
        {
            return _dbContext.PlayLists
                .Where(x => x.Id == id)
                .Include(s => s.TrackPlayLists)
                .ThenInclude(x=> x.Track)
                .FirstOrDefault();
        }
    }

}
