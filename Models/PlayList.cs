using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tam.webapp.Models;

namespace Tam.webapp.Models
{
    /// <summary>
    /// Tam base PlayList Model
    /// </summary>
    public class PlayList
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Quantity { get; set; }

        public virtual ICollection<UserPlayList> UserPlayLists { get; set; }

        public virtual ICollection<TrackPlayList> TrackPlayLists { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}