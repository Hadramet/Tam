using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Tam.webapp.Models
{
    public class Track
    {
        [Key]
        public long Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Artist { get; set; }

        public TimeSpan Duration { get; set; }

        public DateTime AddedDate { get; set; }

        [NotMappedAttribute]
        public IFormFile Local { get; set; }

        public string LocalSource { get; set; }

        public string Source { get; set; }

        public virtual ICollection<TrackPlayList> TrackPlayLists { get; set; }
    }
}