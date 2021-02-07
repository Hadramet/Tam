namespace Tam.webapp.Models
{
    public class TrackPlayList
    {
        public long TrackId { get; set; }
        public Track Track { get; set; }
        public long PlayListId { get; set; }
        public PlayList PlayList { get; set; }

    }
}