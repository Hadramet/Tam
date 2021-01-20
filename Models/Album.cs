using System;
using System.Collections.Generic;

namespace Tam.webapp.Models
{
    public class Album
    {
        public Album()
        {
            this.Tracks = new HashSet<Track>();
        }
        public long Id { get; set; }
        public DateTime Year { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }
    }
}