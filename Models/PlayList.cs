using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tam.webapp.Models
{
    /// <summary>
    /// Tam base PlayList Model
    /// </summary>
    public class PlayList
    {
        [Key]
        public long Id { get; set; }

        public string PlayListName { get; set; }

        public virtual ICollection<TrackPlayList> TrackPlayLists { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}