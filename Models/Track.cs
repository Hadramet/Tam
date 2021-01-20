using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tam.webapp.Models
{
    public class Track
    {
        [Key]
        public long Id { get; set; }

        public string Title { get; set; }

        public string description { get; set; }

        public virtual ICollection<TrackPlayList> TrackPlayLists { get; set; }
    }

    public class TrackPlayList
    {
        [Key]
        public long Id;

        [ForeignKey(nameof(Track))]
        public long TrackId { get; set; }
        public Track Track { get; set; }

        [ForeignKey(nameof(PlayList))]
        public long PlayListId { get; set; }
        public PlayList PlayList { get; set; }

    }
}