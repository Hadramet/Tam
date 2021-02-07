using Tam.webapp.Models;

namespace Tam.webapp.Models
{
    public class UserPlayList
    {
        public long UserId { get; set; }
        public User User { get; set; }
        public long PlayListId { get; set; }
        public PlayList PlayList { get; set; }
    }
}