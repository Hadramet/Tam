using System;

namespace Tam.webapp.Models
{
    /// <summary>
    /// Tam base PlayList Model
    /// </summary>
    public class TPlayList
    {
        public long Id { get; set; }

        public string PlayListName { get; set; }

        public string UserName { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}